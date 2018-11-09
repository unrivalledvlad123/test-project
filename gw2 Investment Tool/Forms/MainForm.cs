using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using gw2_Investment_Tool.Classes;
using gw2_Investment_Tool.ServiceAccess;
using Newtonsoft.Json;


namespace gw2_Investment_Tool.Forms
{
    public partial class MainForm : Form
    {
        public List<ResultItem> ItemsToBuy = new List<ResultItem>();
        public List<Item> AllItems = new List<Item>();
        public static List<ItemFull> ItemNames = new List<ItemFull>();
        public Dictionary<int, int> ResultSet = new Dictionary<int, int>(); //key - itemId , value - quantity
        public List<int> AllItemIds = new List<int>();
        public static List<WhiteListedItem> WhiteListedItems = new List<WhiteListedItem>();
        public List<Recipe> newRecipesFull = new List<Recipe>();
        public static int TotalGold = 0;
        public static float TotalKarma = 0;
		
		public List<Recipe> OldRecipeDataToCompare = new List<Recipe>();
		public List<Recipe> NewRecipeDataToCompare = new List<Recipe>();


        public MainForm()
        {
            InitializeComponent();
            SetGridColumns();
            SetGuildIngridientsGridColumns();
	        SetAllCompareGridsColumns();
			SetIngridientsGridColumns();
            SetItemNameGridColumns();
	        cbLists.DataSource = GetAllList();
	        LoadDataInitially();
			
        }

        #region // <================ Events ================> 

	    private async void btnLoadData_Click(object sender, EventArgs e)
	    {
		    dgvItemsToCalculate.DataSource = null;
		    AllItemIds.Clear();
		    AllItems.Clear();
		    try
		    {
			    string line;
			    StreamReader file = new StreamReader(Properties.Settings.Default.LoadCurrentItems + @"\" + cbLists.SelectedItem +
			                                         ".txt");
			    while ((line = file.ReadLine()) != null)
			    {
				    Item item = new Item();
				    string[] values = line.Split(Convert.ToChar("%"));
				    int itemId;
				    int quantity;
				    decimal karmaperitem;
				    bool active;
				    int.TryParse(values[0], out itemId);
				    int.TryParse(values[1], out quantity);
				    decimal.TryParse(values[3], out karmaperitem);
				    bool.TryParse(values[4], out active);

				    item.ItemId = itemId;
				    item.Quantity = quantity;
				    item.Discipline = values[2];
				    item.KarmaPerItem = karmaperitem;
				    item.Active = active;

				    if (AllItems.FirstOrDefault(p => p.ItemId == item.ItemId) == null)
				    {
					    AllItems.Add(item);
					    AllItemIds.Add(item.ItemId);
				    }
			    }
			    file.Close();
		    }
		    catch (Exception exception)
		    {
			    MessageBox.Show(
				    @"Directories Not Set! Please use setting button to set them first, then hit Reload data button",
				    @"Load error",
				    MessageBoxButtons.OK, MessageBoxIcon.Error);
		    }
		    await GetNameFromApi(AllItemIds, null);
		    dgvItemsToCalculate.DataSource = AllItems;
		    labelKarmaValue.Text = CalculateTotalKarma().ToString(CultureInfo.InvariantCulture);
	    }

	    private async void btnAddItem_Click(object sender, EventArgs e)
	    {
		    AddOrEditForm addForm = new AddOrEditForm(null);

		    if (addForm.ShowDialog() == DialogResult.OK)
		    {
			    if (addForm.Item != null)
			    {
				    Item newItem = addForm.Item;
				    var check = AllItems.FirstOrDefault(p => p.ItemId == newItem.ItemId);
				    if (check == null)
				    {
					    try
					    {

						    AllItems.Add(newItem);
						    AllItemIds.Add(newItem.ItemId);
						    await GetNameFromApi(null, addForm.Item.ItemId);
						    dgvItemsToCalculate.DataSource = null;
						    dgvItemsToCalculate.DataSource = AllItems;
					    }
					    catch (Exception)
					    {
						    AllItems.Remove(newItem);
						    AllItemIds.Remove(newItem.ItemId);
						    MessageBox.Show(@"Invalid ItemID!", @"Add error",
							    MessageBoxButtons.OK, MessageBoxIcon.Error);
					    }


					    if (newItem.Active)
					    {
						    labelKarmaValue.Text = CalculateTotalKarma().ToString(CultureInfo.InvariantCulture);
					    }
				    }
				    else
				    {
					    MessageBox.Show(@"Item is already added!", @"Add error",
						    MessageBoxButtons.OK, MessageBoxIcon.Error);
				    }
			    }

		    }
	    }

	    private void btnWhiteList_Click(object sender, EventArgs e)
        {
            WhiteListForm WLForm = new WhiteListForm(WhiteListedItems);
            if (WLForm.ShowDialog() == DialogResult.OK)
            {
                WhiteListedItems.Clear();
                WhiteListedItems = WLForm.ItemsToSave;

                List<string> lines = new List<string>();
                foreach (var item in WhiteListedItems)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(item.Name);
                    sb.Append("%");
                    sb.Append(item.ItemId.ToString());
                    sb.Append("%");
                    sb.Append(item.Price);
                    sb.Append("%");
                    sb.Append(item.Active.ToString());

                    lines.Add(sb.ToString());
                }
                if (lines.Count != 0)
                {
                    File.WriteAllLines(Properties.Settings.Default.LoadWhiteList, lines);
                }
                else
                {
                    File.WriteAllText(Properties.Settings.Default.LoadWhiteList, string.Empty);
                }
            }
        }

        private async void btnCalculate_Click(object sender, EventArgs e)
        {
            await GetRecipeFromApi(AllItems);
            await CombineAllData();
            TotalGold = await CalculateMargin(AllItems);
            float karma;
            float.TryParse(labelKarmaValue.Text, out karma);
            TotalKarma = karma;
            ResultForm resultForm = new ResultForm(ItemsToBuy);
            resultForm.ShowDialog();
            ItemsToBuy.Clear();
            ResultSet.Clear();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> lines = new List<string>();
            foreach (var item in AllItems)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(item.ItemId.ToString());
                sb.Append("%");
                sb.Append(item.Quantity.ToString());
                sb.Append("%");
                sb.Append(item.Discipline);
                sb.Append("%");
                sb.Append(item.KarmaPerItem);
                sb.Append("%");
                sb.Append(item.Active.ToString());

                lines.Add(sb.ToString());
            }
            if (lines.Count != 0)
            {
                File.WriteAllLines(Properties.Settings.Default.LoadCurrentItems + @"\" + cbLists.SelectedItem +".txt", lines);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvItemsToCalculate.SelectedRows.Count <= 0)
                return;

            Item selectedItem = (Item) dgvItemsToCalculate.SelectedRows[0].DataBoundItem;
            if (AllItems.FirstOrDefault(p => p.ItemId == selectedItem.ItemId) != null)
            {
                AllItems.Remove(selectedItem);
                AllItemIds.Remove(selectedItem.ItemId);
                dgvItemsToCalculate.DataSource = null;
                dgvItemsToCalculate.DataSource = AllItems;
                labelKarmaValue.Text = CalculateTotalKarma().ToString(CultureInfo.InvariantCulture);
            }
        }

        private void dgvItemsToCalculate_OnCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string flag = null;
            float total = 0;
            float totalOld = 0;
            foreach (DataGridViewRow row in dgvItemsToCalculate.Rows)
            {
                if (dgvItemsToCalculate.CurrentCell == row.Cells["karmaPE"] ||
                    dgvItemsToCalculate.CurrentCell == row.Cells["quantity"])
                {
                    flag = "value";
                    float karma;
                    float quantity;
                    float.TryParse(row.Cells["quantity"].Value.ToString(), out quantity);
                    float.TryParse(row.Cells["karmaPE"].Value.ToString(), out karma);
                    row.Cells["karmaTotal"].Value = karma * quantity;
                }
                if ((bool) row.Cells["active"].Value)
                {
                    total = total + (float) row.Cells["karmaTotal"].Value;
                }
            }

            try
            {
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell) dgvItemsToCalculate.CurrentCell;
                if (dgvItemsToCalculate.CurrentRow != null)
                {
                    Item currentRow = dgvItemsToCalculate.CurrentRow.DataBoundItem as Item;
                    flag = "checkbox";
                    float total1;
                    float current;
                    float.TryParse(labelKarmaValue.Text, out total1);
                    float.TryParse(currentRow.TotalKarma.ToString(), out current);
                    if (!(bool) checkbox.EditedFormattedValue)
                    {
                        totalOld = total1 - current;
                    }
                    else
                    {
                        totalOld = total1 + current;
                    }
                }
            }
            catch
            {
                // ignored
            }
            if (flag == "value")
            {
                labelKarmaValue.Text = total.ToString(CultureInfo.InvariantCulture);
            }
            else if (flag == "checkbox")
            {
                labelKarmaValue.Text = totalOld.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();
            form.ShowDialog();
        }

	    private void btnFilter_Click(object sender, EventArgs e)
	    {
		    if (newRecipesFull.Count == 0)
		    {
				return;
		    }

		    if (!string.IsNullOrWhiteSpace(tbFilter.Text))
		    {
			    newRecipesFull.PrepareForFilter();
			    RadioButton checkedButton = groupBox1.Controls
				    .OfType<RadioButton>().FirstOrDefault(x => x.Checked);

			    if (checkedButton != null)
			    {
				    dgvNewItems.DataSource = null;
				    switch (checkedButton.Name)
				    {
					    case "radioName":
						    dgvNewItems.DataSource = newRecipesFull.Where(p => p.OutputItemName.ToLower().Contains(tbFilter.Text.ToLower())).ToList();
						    break;
					    case "radioType":
						    dgvNewItems.DataSource = newRecipesFull.Where(p => p.type.ToLower().Contains(tbFilter.Text.ToLower())).ToList();
						    break;
					    case "radioDisciplines":
							dgvNewItems.DataSource = newRecipesFull.Where(p => p.DisciplinesString.ToLower().Contains(tbFilter.Text.ToLower())).ToList();
						    break;
					    case "radioFlags":
						    dgvNewItems.DataSource = newRecipesFull.Where(p => p.FlagsString.ToLower().Contains(tbFilter.Text.ToLower())).ToList();
						    break;
				    }
			    }
			}
		    else
		    {
			    dgvNewItems.DataSource = null;
			    dgvNewItems.DataSource = newRecipesFull;
		    }
		}

	    private void btnExport_Click(object sender, EventArgs e)
	    {
		    var data = dgvNewItems.DataSource as List<Recipe>;
		    var json = JsonConvert.SerializeObject(data);
		    File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\OldData.txt", json);
	    }

		#endregion

		#region // < ================ Methodts ================>

		public List<string> GetAllList()
	    {
		    try
		    {
			    List<string> alLists = new List<string>();
			    string[] files = Directory.GetFiles(Properties.Settings.Default.LoadCurrentItems);
			    foreach (string list in files)
			    {
				    var temp = list.Replace(Properties.Settings.Default.LoadCurrentItems, "");
				    string temp2 = temp.Replace(@"\", "");
				    string temp3 = temp2.Replace(".txt", "");
				    alLists.Add(temp3);
			    }

			    return alLists;
		    }
		    catch (Exception e)
		    {
			    MessageBox.Show(this, "Set directories!");
			    return new List<string>();
		    }

	    }


	    public void LoadDataInitially()
	    {
		    try
		    {
			    string line2;
			    StreamReader file2 =
				    new StreamReader(Properties.Settings.Default.LoadWhiteList);
			    while ((line2 = file2.ReadLine()) != null)
			    {
				    WhiteListedItem item = new WhiteListedItem();
				    string[] values = line2.Split(Convert.ToChar("%"));
				    int itemId;
				    int price;
				    bool active;
				    int.TryParse(values[1], out itemId);
				    int.TryParse(values[2], out price);
				    bool.TryParse(values[3], out active);

				    item.ItemId = itemId;
				    item.Price = price;
				    item.Name = values[0];
				    item.Active = active;

				    if (WhiteListedItems.FirstOrDefault(p => p.ItemId == item.ItemId) == null)
				    {
					    WhiteListedItems.Add(item);
				    }
			    }
			    file2.Close();

			    string line3;
			    StreamReader file3 = new StreamReader(Properties.Settings.Default.LoadNames);
			    while ((line3 = file3.ReadLine()) != null)
			    {
				    ItemFull item = new ItemFull();
				    string[] values = line3.Split(Convert.ToChar("%"));
				    int itemId;
				    int.TryParse(values[0], out itemId);
				    item.id = itemId;
				    item.name = values[1];
				    item.rarity = values[2];
				    int level;
				    int.TryParse(values[3], out level);
				    item.level = level;
				    ItemNames.Add(item);


			    }
			    file3.Close();
		    }
		    catch (Exception e)
		    {

		    }
	    }



	    public async Task GetNameFromApi(List<int> allIds, int? singleId)
        {
            if (allIds != null)
            {
	            List<ItemFull> allitems = await SAItems.GetAlItemsAsync(allIds);
                foreach (var id in allIds)
                {
	                ItemFull item = allitems.FirstOrDefault(p => p.id == id);
                    Item sincedItem = AllItems.FirstOrDefault(p => p.ItemId == item.id);
                    if (sincedItem != null)
                    {
                        sincedItem.Name = item.name + "  " + item.level + "  " + item.rarity;
                        sincedItem.TotalKarma = (float?) (sincedItem.KarmaPerItem * sincedItem.Quantity);
                    }
                }
            }
            else
            {
	            ItemFull item = await SAItems.GetItemsAsync((int) singleId);
                Item sincedItem = AllItems.FirstOrDefault(p => p.ItemId == item.id);
                if (sincedItem != null)
                {
					sincedItem.Name = item.name + "  " + item.level + "  " + item.rarity;
					sincedItem.TotalKarma = (float?) (sincedItem.KarmaPerItem * sincedItem.Quantity);
                }
            }
        }

        public async Task GetRecipeFromApi(List<Item> allItems)
        {      
			foreach (var item in allItems)
            {
                if (item.Active)
                {
	                // cant change to multiple calls as v2 api does not support multiple recipe calls!!!!
					int[] recipe = await SAItems.GetRecipesOutputAsync(item.ItemId);
                    if (recipe.Length != 0)
                    {
                        var currentRecipeId = recipe[0];
                        Recipe recipeData = await SAItems.GetRecipesIngredientsAsync(currentRecipeId);
                        if (recipeData != null)
                        {
                            foreach (var ingredient in recipeData.ingredients)
                            {
                                if (ResultSet.ContainsKey(ingredient.item_id))
                                {
                                    var oldQuantity = ResultSet[ingredient.item_id];
                                    ResultSet[ingredient.item_id] = oldQuantity +
                                                                    (ingredient.count * item.Quantity /
                                                                     recipeData.output_item_count);
                                }
                                else
                                {
                                    ResultSet.Add(ingredient.item_id,
                                        ingredient.count * item.Quantity / recipeData.output_item_count);
                                }
                            }
                        }
                    }
                }
            }
        }

	    public float CalculateTotalKarma()
	    {
		    try
		    {
			    float total = 0;
			    foreach (DataGridViewRow row in dgvItemsToCalculate.Rows)
			    {
				    DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
				    if (Convert.ToBoolean(cell.Value))
				    {
					    total = total + (float) row.Cells["karmaTotal"].Value;
				    }
			    }
			    return total;
		    }
		    catch (Exception e)
		    {
			    return float.Epsilon;
		    }

	    }

	    public async Task CombineAllData()
        {
	        List<int> allitemIds = ResultSet.Select(pair => pair.Key).ToList();
	        List<ItemFull> allItemApis = await SAItems.GetAlItemsAsync(allitemIds);
	        List<ItemPrices> allItemPriceses = await SAItems.GetAllItemPrices(allitemIds);
			foreach (var result in ResultSet)
            {
				ResultItem resultItem = new ResultItem();
	            ItemFull item = allItemApis.FirstOrDefault(p => p.id == result.Key);
	            ItemPrices prices = allItemPriceses.FirstOrDefault(p => p.id == result.Key);
                if (prices != null)
                {
                    resultItem.ItemId = result.Key;
                    resultItem.Quantity = result.Value;
                    resultItem.Name = item.name;
                    resultItem.PriceEach = prices.buys.unit_price != 0? prices.buys.unit_price + 1: prices.sells.unit_price +1;
                    resultItem.Total = resultItem.PriceEach * result.Value;
                    resultItem.PriceFormated = ParsePrices(prices.buys.unit_price != 0 ? prices.buys.unit_price + 1 : prices.sells.unit_price + 1);
                    resultItem.PriceTotalFormated = ParsePrices((prices.buys.unit_price != 0 ? prices.buys.unit_price + 1 : prices.sells.unit_price + 1) * result.Value);
                    resultItem.RecalculateChecked = false;
                    ItemsToBuy.Add(resultItem);
                }
            }
        }

        public async Task<int> CalculateMargin(List<Item> AllItems)
        {
	        var count = 0;
			List<int> allitemIds = AllItems.Select(pair => pair.ItemId).ToList();
			List<ItemPrices> allItemPriceses = await SAItems.GetAllItemPrices(allitemIds);
			foreach (var item in AllItems)
            {
                if (item.Active)
                {
	                ItemPrices prices = allItemPriceses.FirstOrDefault(p => p.id == item.ItemId);
                    count = count + (prices.sells.unit_price + 1) * item.Quantity;
                }

            }
            return count;
        }

        public string ParsePrices(int price)
        {
            string result;
            int copper = price % 100;
            int left = price / 100;
            int silver = left % 100;
            int gold = left / 100;
            if (gold == 0 && silver != 0)
            {
                result = string.Format("{0}s, {1}c", silver, copper);
            }
            else if (gold == 0 && silver == 0)
            {
                result = string.Format("{0}c", copper);
            }
            else
            {
                result = string.Format("{0}g, {1}s, {2}c", gold, silver, copper);
            }

            return result;
        }

        #endregion

        private void SetGridColumns()
        {
            dgvItemsToCalculate.DataSource = null;
            dgvItemsToCalculate.Columns.Clear();
            dgvItemsToCalculate.AutoGenerateColumns = false;
            dgvItemsToCalculate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            DataGridViewCheckBoxColumn c1 = new DataGridViewCheckBoxColumn();
            c1.Name = "active";
            c1.HeaderText = "Active";
            c1.DataPropertyName = "Active";
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            c1.Width = 40;
            dgvItemsToCalculate.Columns.Add(c1);

            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.Name = "name";
            c2.HeaderText = "Item Name";
            c2.DataPropertyName = "Name";
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvItemsToCalculate.Columns.Add(c2);

            DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
            c3.Name = "quantity";
            c3.HeaderText = "Quantity";
            c3.DataPropertyName = "Quantity";
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            c3.Width = 100;
            dgvItemsToCalculate.Columns.Add(c3);

            DataGridViewTextBoxColumn c4 = new DataGridViewTextBoxColumn();
            c4.Name = "discipline";
            c4.HeaderText = "Discipline";
            c4.DataPropertyName = "Discipline";
            c4.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            c4.Width = 100;
            dgvItemsToCalculate.Columns.Add(c4);

            DataGridViewTextBoxColumn c5 = new DataGridViewTextBoxColumn();
            c5.Name = "karmaPE";
            c5.HeaderText = "Karma Per Item";
            c5.DataPropertyName = "KarmaPerItem";
            c5.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            c5.Width = 100;
            dgvItemsToCalculate.Columns.Add(c5);

            DataGridViewTextBoxColumn c6 = new DataGridViewTextBoxColumn();
            c6.Name = "karmaTotal";
            c6.HeaderText = "Karma Total";
            c6.DataPropertyName = "TotalKarma";
            c6.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            c6.Width = 100;
            dgvItemsToCalculate.Columns.Add(c6);

            DataGridViewTextBoxColumn c7 = new DataGridViewTextBoxColumn();
            c7.Name = "itemId";
            c7.HeaderText = "Item ID";
            c7.DataPropertyName = "ItemId";
            c7.Visible = false;
            dgvItemsToCalculate.Columns.Add(c7);

        }

        #region // < ================ New Items Tab ================>

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            dgvIngredients.DataSource = null;
            dgvGuildIngridients.DataSource = null;
            dgvNewItems.DataSource = null;
           
            if (tbOld.Text.Length != 0)
            {
                List<int> itemIds = await SAItems.GetAllrecipeIdsAsync();
                tbNew.Text = itemIds.Last().ToString();
                List<int> newItemsIDsIndexes = new List<int>();
                int newIndex;
                int oldIndex;
                int.TryParse(tbNew.Text, out newIndex);
                int.TryParse(tbOld.Text, out oldIndex);
                for (int i = oldIndex; i <= newIndex; i++)
                {
                    newItemsIDsIndexes.Add(i);
                }
                newRecipesFull = await SAItems.GetRecipeFullAsync(newItemsIDsIndexes);
	            newRecipesFull = await CombineFullRecipeData(newRecipesFull);
				dgvNewItems.DataSource = null;
                dgvNewItems.DataSource = newRecipesFull;
            }
        }



		private async Task<List<Recipe>> CombineFullRecipeData(List<Recipe> input)
		{
			List<int> recipeItemIds = new List<int>();
			List<int> recipeGuildItemIds = new List<int>();
			int globalMissingItemIndex = 0;

			foreach (Recipe recipe in input)
			{
				if (recipe.type == "GuildConsumable" || recipe.type == "GuildDecoration" ||
					recipe.type == "GuildConsumableWvw")
				{
					if (recipe.guild_ingredients != null)
					{
						recipeGuildItemIds.AddRange(
							recipe.guild_ingredients.Select(ingredients => ingredients.upgrade_id));
					}

					recipeGuildItemIds.Add(recipe.output_upgrade_id);
					if (recipe.ingredients != null)
					{
						recipeItemIds.AddRange(recipe.ingredients.Select(ingredients => ingredients.item_id));
					}

					recipeItemIds.Add(recipe.output_item_id);
				}
				else
				{
					recipeItemIds.AddRange(recipe.ingredients.Select(ingredients => ingredients.item_id));
					recipeItemIds.Add(recipe.output_item_id);
				}
			}

			//remove dublicate Ids to reduce apiCalls
			var noDupesGuildItems = recipeGuildItemIds.Distinct().ToList();
			var noDupesItems = recipeItemIds.Distinct().ToList();

			// do mass calls
			var allGuildItemsDetails = await SAItems.GetAllGuildItemsAsync(noDupesGuildItems);
			var allItemsDetails = await SAItems.GetAlItemsAsync(noDupesItems);

			foreach (var recipe in input)
			{
				if (recipe.type == "GuildConsumable" || recipe.type == "GuildDecoration" ||
					recipe.type == "GuildConsumableWvw")
				{
					if (recipe.guild_ingredients != null)
					{
						foreach (var ingredients in recipe.guild_ingredients)
						{
							GuildItemFull ingData = allGuildItemsDetails.First(p => p.id == ingredients.upgrade_id);
							ingredients.name = ingData.name;
						}
					}

					if (recipe.ingredients != null)
					{
						foreach (var ingredients in recipe.ingredients)
						{
							ItemFull ingData = allItemsDetails.FirstOrDefault(p => p.id == ingredients.item_id);
							if (ingData != null) ingredients.name = ingData.name;
						}
					}

					GuildItemFull nameData =
						allGuildItemsDetails.FirstOrDefault(p => p.id == recipe.output_upgrade_id);
					if (nameData == null)
					{
						globalMissingItemIndex++;
						recipe.OutputItemName = "Missing Name" + globalMissingItemIndex;
						recipe.Description = "Missing Description";
						recipe.Rarity = "Common";
					}
					else
					{
						recipe.OutputItemName = nameData.name;
						recipe.Description = nameData.description;
						recipe.Rarity = "Common";
					}
				}
				else
				{
					foreach (var ingredients in recipe.ingredients)
					{
						ItemFull ingData = allItemsDetails.FirstOrDefault(p => p.id == ingredients.item_id);
						if (ingData != null)
						{
							ingredients.name = ingData.name;
						}
					}

					ItemFull nameData = allItemsDetails.FirstOrDefault(p => p.id == recipe.output_item_id);
					if (nameData != null)
					{
						recipe.OutputItemName = nameData.name;
						if (nameData.details != null)
						{
							recipe.Description = nameData.details.description ?? nameData.description;
						}
						else
						{
							recipe.Description = nameData.description;
						}

						recipe.Rarity = nameData.rarity;
						recipe.type = nameData.type;
						recipe.flags = nameData.flags;
					}
				}
			}

			return input;
		}

		private void dgvNewItems_CellSelected(object sender, EventArgs e)
        {
            if (dgvNewItems.SelectedCells[0].Value != null)
            {
	            Recipe selectedItem =
                    newRecipesFull.FirstOrDefault(
                        p => p.OutputItemName == dgvNewItems.SelectedCells[0].Value.ToString());
                dgvIngredients.DataSource = null;
                dgvGuildIngridients.DataSource = null;
                if (selectedItem != null)
                {
                    dgvIngredients.DataSource = selectedItem.ingredients;
                    dgvGuildIngridients.DataSource = selectedItem.guild_ingredients;
                    labelType.Text = selectedItem.type;
                    labelMinRating.Text = selectedItem.min_rating.ToString();
                    labelDisciplines.Text = SimpleStringBuilder(selectedItem.disciplines);
                    labelFlags.Text = SimpleStringBuilder(selectedItem.flags);
                    labelName.Text = selectedItem.OutputItemName;
                    labelDescriptionValue.Text = selectedItem.Description;
                    labelRarityValue.Text = selectedItem.Rarity;
                    labelOutputCount.Text = selectedItem.output_item_count.ToString();
                    if (selectedItem.type == "GuildConsumable" || selectedItem.type == "GuildDecoration" ||
                        selectedItem.type == "GuildConsumableWvw")
                    {
                        labelItemIdValue.Text = selectedItem.output_upgrade_id.ToString();
                    }
                    else
                    {
                        labelItemIdValue.Text = selectedItem.output_item_id.ToString();
                    }
                    labelRecipeIdValue.Text = selectedItem.id.ToString();
                }
            }
        }

        public string SimpleStringBuilder(string[] strings)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var str in strings)
            {
                sb.Append(str + " ");
            }
            return sb.ToString();
        }

        private void SetItemNameGridColumns()
        {
            dgvNewItems.DataSource = null;
            dgvNewItems.Columns.Clear();
            dgvNewItems.AutoGenerateColumns = false;
            dgvNewItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvNewItems.RowHeadersVisible = false;
			
            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.Name = "OutputItemName";
            c1.HeaderText = @"Item Name";
            c1.DataPropertyName = "OutputItemName";
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvNewItems.Columns.Add(c1);

            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.Name = "id";
            c2.HeaderText = @"Item ID";
            c2.DataPropertyName = "id";
            c2.Visible = false;
            dgvNewItems.Columns.Add(c2);
        }

        private void SetIngridientsGridColumns()
        {
            dgvIngredients.DataSource = null;
            dgvIngredients.Columns.Clear();
            dgvIngredients.AutoGenerateColumns = false;
            dgvIngredients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvIngredients.RowHeadersVisible = false;


            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.Name = "name";
            c1.HeaderText = @"Item Name";
            c1.DataPropertyName = "name";
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvIngredients.Columns.Add(c1);

            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.Name = "count";
            c2.HeaderText = @"Quantity";
            c2.DataPropertyName = "count";
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            c2.Width = 100;
            dgvIngredients.Columns.Add(c2);

            DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
            c3.Name = "item_id";
            c3.HeaderText = @"Item ID";
            c3.DataPropertyName = "item_id";
            c3.Visible = false;
            dgvIngredients.Columns.Add(c3);
        }

        private void SetGuildIngridientsGridColumns()
        {
            dgvGuildIngridients.DataSource = null;
            dgvGuildIngridients.Columns.Clear();
            dgvGuildIngridients.AutoGenerateColumns = false;
            dgvGuildIngridients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvGuildIngridients.RowHeadersVisible = false;


            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.Name = "name";
            c1.HeaderText = "Item Name";
            c1.DataPropertyName = "name";
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGuildIngridients.Columns.Add(c1);

            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.Name = "count";
            c2.HeaderText = "Quantity";
            c2.DataPropertyName = "count";
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            c2.Width = 100;
            dgvGuildIngridients.Columns.Add(c2);

            DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
            c3.Name = "upgrade_id";
            c3.HeaderText = "Item ID";
            c3.DataPropertyName = "upgrade_id";
            c3.Visible = false;
            dgvGuildIngridients.Columns.Add(c3);

        }
	    private void SetAllCompareGridsColumns()
	    {
			//all grid
		    dgvRecipeCompareAll.DataSource = null;
		    dgvRecipeCompareAll.Columns.Clear();
		    dgvRecipeCompareAll.AutoGenerateColumns = false;
		    dgvRecipeCompareAll.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
		    dgvRecipeCompareAll.RowHeadersVisible = false;
		    dgvRecipeCompareAll.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


			DataGridViewTextBoxColumn c11 = new DataGridViewTextBoxColumn();
		    c11.Name = "OutputItemName";
		    c11.HeaderText = @"Item Name";
		    c11.DataPropertyName = "OutputItemName";
		    c11.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		    dgvRecipeCompareAll.Columns.Add(c11);

		    DataGridViewTextBoxColumn c21 = new DataGridViewTextBoxColumn();
		    c21.Name = "id";
		    c21.HeaderText = @"Item ID";
		    c21.DataPropertyName = "id";
		    c21.Visible = false;
		    dgvRecipeCompareAll.Columns.Add(c21);


			// both regular ingredients grids
		    dgvCompareRecipesNewIngredients.DataSource = null;
		    dgvCompareRecipesNewIngredients.Columns.Clear();
		    dgvCompareRecipesNewIngredients.AutoGenerateColumns = false;
		    dgvCompareRecipesNewIngredients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
		    dgvCompareRecipesNewIngredients.RowHeadersVisible = false;

		    dgvRecipeCompareOldIngredients.DataSource = null;
		    dgvRecipeCompareOldIngredients.Columns.Clear();
		    dgvRecipeCompareOldIngredients.AutoGenerateColumns = false;
		    dgvRecipeCompareOldIngredients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
		    dgvRecipeCompareOldIngredients.RowHeadersVisible = false;

		    DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
		    c1.Name = "name";
		    c1.HeaderText = @"Item Name";
		    c1.DataPropertyName = "name";
		    c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		    dgvCompareRecipesNewIngredients.Columns.Add(c1);
		   

		    DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
		    c2.Name = "count";
		    c2.HeaderText = @"Quantity";
		    c2.DataPropertyName = "count";
		    c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
		    c2.Width = 100;
		    dgvCompareRecipesNewIngredients.Columns.Add(c2);
		   

		    DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
		    c3.Name = "item_id";
		    c3.HeaderText = @"Item ID";
		    c3.DataPropertyName = "item_id";
		    c3.Visible = false;
		    dgvCompareRecipesNewIngredients.Columns.Add(c3);

		    DataGridViewTextBoxColumn c12 = new DataGridViewTextBoxColumn();
		    c12.Name = "name";
		    c12.HeaderText = @"Item Name";
		    c12.DataPropertyName = "name";
		    c12.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		    dgvRecipeCompareOldIngredients.Columns.Add(c12);


		    DataGridViewTextBoxColumn c22 = new DataGridViewTextBoxColumn();
		    c22.Name = "count";
		    c22.HeaderText = @"Quantity";
		    c22.DataPropertyName = "count";
		    c22.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
		    c22.Width = 100;
		    dgvRecipeCompareOldIngredients.Columns.Add(c22);


		    DataGridViewTextBoxColumn c32 = new DataGridViewTextBoxColumn();
		    c32.Name = "item_id";
		    c32.HeaderText = @"Item ID";
		    c32.DataPropertyName = "item_id";
		    c32.Visible = false;
		    dgvRecipeCompareOldIngredients.Columns.Add(c32);

			//both guild ingredients grids
		    dgvCompareRecipesNewGuildIngredients.DataSource = null;
		    dgvCompareRecipesNewGuildIngredients.Columns.Clear();
		    dgvCompareRecipesNewGuildIngredients.AutoGenerateColumns = false;
		    dgvCompareRecipesNewGuildIngredients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
		    dgvCompareRecipesNewGuildIngredients.RowHeadersVisible = false;

		    dgvRecipeCompareOldGuildIngredients.DataSource = null;
		    dgvRecipeCompareOldGuildIngredients.Columns.Clear();
		    dgvRecipeCompareOldGuildIngredients.AutoGenerateColumns = false;
		    dgvRecipeCompareOldGuildIngredients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
		    dgvRecipeCompareOldGuildIngredients.RowHeadersVisible = false;

		    DataGridViewTextBoxColumn c13 = new DataGridViewTextBoxColumn();
		    c13.Name = "name";
		    c13.HeaderText = "Item Name";
		    c13.DataPropertyName = "name";
		    c13.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		    dgvCompareRecipesNewGuildIngredients.Columns.Add(c13);

		    DataGridViewTextBoxColumn c23 = new DataGridViewTextBoxColumn();
		    c23.Name = "count";
		    c23.HeaderText = "Quantity";
		    c23.DataPropertyName = "count";
		    c23.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
		    c23.Width = 100;
		    dgvCompareRecipesNewGuildIngredients.Columns.Add(c23);

		    DataGridViewTextBoxColumn c33 = new DataGridViewTextBoxColumn();
		    c33.Name = "upgrade_id";
		    c33.HeaderText = "Item ID";
		    c33.DataPropertyName = "upgrade_id";
		    c33.Visible = false;
		    dgvCompareRecipesNewGuildIngredients.Columns.Add(c33);

			
		    DataGridViewTextBoxColumn c41 = new DataGridViewTextBoxColumn();
		    c41.Name = "name";
		    c41.HeaderText = "Item Name";
		    c41.DataPropertyName = "name";
		    c41.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		    dgvRecipeCompareOldGuildIngredients.Columns.Add(c41);

		    DataGridViewTextBoxColumn c42 = new DataGridViewTextBoxColumn();
		    c42.Name = "count";
		    c42.HeaderText = "Quantity";
		    c42.DataPropertyName = "count";
		    c42.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
		    c42.Width = 100;
		    dgvRecipeCompareOldGuildIngredients.Columns.Add(c42);

		    DataGridViewTextBoxColumn c43 = new DataGridViewTextBoxColumn();
		    c43.Name = "upgrade_id";
		    c43.HeaderText = "Item ID";
		    c43.DataPropertyName = "upgrade_id";
		    c43.Visible = false;
		    dgvRecipeCompareOldGuildIngredients.Columns.Add(c43);

		}


		#endregion

		private async void btnLoadOldData_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				string json = File.ReadAllText(dialog.FileName);
				OldRecipeDataToCompare = JsonConvert.DeserializeObject<List<Recipe>>(json);

				List<int> ids = OldRecipeDataToCompare.Select(p => p.id).ToList();
				NewRecipeDataToCompare = await CombineFullRecipeData(await SAItems.GetRecipeFullAsync(ids));
				
				// display the data
				dgvRecipeCompareAll.DataSource = OldRecipeDataToCompare;
				
			}
			
		}

	    private void dgvRecipeCompareAll_SelectionChanged(object sender, EventArgs e)
	    {
		    if (dgvRecipeCompareAll.DataSource == null)
		    {
				return;
		    }

		    if (dgvRecipeCompareAll.SelectedRows.Count != 0)
		    {
				
			    Recipe selectedItem = (Recipe) dgvRecipeCompareAll.SelectedRows[0].DataBoundItem;
			    dgvCompareRecipesNewGuildIngredients.DataSource = null;
			    dgvCompareRecipesNewIngredients.DataSource = null;
			    dgvRecipeCompareOldGuildIngredients.DataSource = null;
			    dgvRecipeCompareOldIngredients.DataSource = null;
			    if (selectedItem != null)
			    {
				    dgvRecipeCompareOldIngredients.DataSource = selectedItem.ingredients;
				    dgvRecipeCompareOldGuildIngredients.DataSource = selectedItem.guild_ingredients;
				    // get the new recipe
				    var newRecipe = NewRecipeDataToCompare.FirstOrDefault(p => p.id == selectedItem.id);
				    if (newRecipe != null)
				    {
					    dgvCompareRecipesNewGuildIngredients.DataSource = newRecipe.guild_ingredients;
					    dgvCompareRecipesNewIngredients.DataSource = newRecipe.ingredients;
				    }
			    }
		    }

	    }
    }
}


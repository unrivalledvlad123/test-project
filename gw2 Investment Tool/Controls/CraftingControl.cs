using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gw2_Investment_Tool.Classes;
using gw2_Investment_Tool.Forms;
using gw2_Investment_Tool.Models;
using gw2_Investment_Tool.ServiceAccess;

namespace gw2_Investment_Tool.Controls
{
	public partial class CraftingControl : UserControl
	{
		public List<Item> AllItems = new List<Item>();
		public Dictionary<int, int> ResultSet = new Dictionary<int, int>(); //key - itemId , value - quantity

		public CraftingControl()
		{
			InitializeComponent();
			SetGridColumns();
		//	cbLists.DataSource = MainForm.GetAllList();// this method cause a debug time exception in the editor if moved to control itself.

		}

		private async void btnGenerateLocalData_Click(object sender, EventArgs e)
		{
			var directory = Directory.GetCurrentDirectory();
		    
		    List<int> itemIds = await SAItems.GetAllrecipeIdsAsync();
			List<OutputItemId> outputItemIds = await SAItems.GetRecipeOutputIdAsync(itemIds);
			List<ItemFull> namedItems = await SAItems.GetItemNamesAsync(outputItemIds);

			List<string> lines = new List<string>();
			foreach (var item in namedItems)
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(item.id.ToString());
				sb.Append("%");
				sb.Append(item.name);
				sb.Append("%");
				sb.Append(item.rarity);
				sb.Append("%");
				sb.Append(item.level);
				lines.Add(sb.ToString());
			}
			if (lines.Count != 0)
			{
				File.WriteAllLines(directory + "\\DataFiles\\System\\LoadNames.txt", lines);
			}

			GlobalDataHolder.ItemNames = namedItems;
		    MessageBox.Show(@"Text file successfully created!", @"Success",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
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
							await GetNameFromApi(null, addForm.Item.ItemId);
							dgvItemsToCalculate.DataSource = null;
							dgvItemsToCalculate.DataSource = AllItems;
						}
						catch (Exception)
						{
							AllItems.Remove(newItem);
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

		private async void btnLoadData_Click(object sender, EventArgs e)
		{
			if (cbLists.SelectedItem == null)
				return;

			dgvItemsToCalculate.DataSource = null;
			AllItems.Clear();
			try
			{
                var directory = Directory.GetCurrentDirectory();

                string line;
				StreamReader file = new StreamReader(directory + "\\DataFiles\\Lists" + @"\" + cbLists.SelectedItem + ".txt");
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
					}
				}
				file.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					@"Directories Not Set! Please use setting button to set them first, then hit Reload data button",
					@"Load error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			await GetNameFromApi(AllItems.Select(p => p.ItemId).ToList(), null);
			dgvItemsToCalculate.DataSource = AllItems;
			labelKarmaValue.Text = CalculateTotalKarma().ToString(CultureInfo.InvariantCulture);
		}

		private void btnWhiteList_Click(object sender, EventArgs e)
		{
			WhiteListForm form = new WhiteListForm(GlobalDataHolder.WhiteListedItems);
			if (form.ShowDialog() == DialogResult.OK)
			{
				GlobalDataHolder.WhiteListedItems.Clear();
				GlobalDataHolder.WhiteListedItems = form.ItemsToSave;

                var directory = Directory.GetCurrentDirectory();

                List<string> lines = new List<string>();
				foreach (var item in GlobalDataHolder.WhiteListedItems)
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
					File.WriteAllLines(directory + "\\DataFiles\\System\\WhiteListedItems.txt", lines);
				}
				else
				{
					File.WriteAllText(directory + "\\DataFiles\\System\\WhiteListedItems.txt", string.Empty);
				}
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (dgvItemsToCalculate.SelectedRows.Count <= 0)
				return;

			Item selectedItem = (Item)dgvItemsToCalculate.SelectedRows[0].DataBoundItem;
			if (AllItems.FirstOrDefault(p => p.ItemId == selectedItem.ItemId) != null)
			{
				AllItems.Remove(selectedItem);
				dgvItemsToCalculate.DataSource = null;
				dgvItemsToCalculate.DataSource = AllItems;
				labelKarmaValue.Text = CalculateTotalKarma().ToString(CultureInfo.InvariantCulture);
			}
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
                var directory = Directory.GetCurrentDirectory();

                File.WriteAllLines(directory + "\\DataFiles\\Lists" + @"\" + cbLists.SelectedItem + ".txt", lines);
			}
		}

		private async void btnCalculate_Click(object sender, EventArgs e)
		{
			await GetRecipeFromApi(AllItems);
			List<ResultItem> itemsToBuy = await CombineAllData();
			GlobalDataHolder.TotalGold = await CalculateMargin(AllItems);
			float karma;
			float.TryParse(labelKarmaValue.Text, out karma);
			GlobalDataHolder.TotalKarma = karma;
			ResultForm resultForm = new ResultForm(itemsToBuy);
			resultForm.ShowDialog();
			ResultSet.Clear();

		}

		private void dgvItemsToCalculate_CellStyleChanged(object sender, DataGridViewCellEventArgs e)
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
				if ((bool)row.Cells["active"].Value)
				{
					total = total + (float)row.Cells["karmaTotal"].Value;
				}
			}

			try
			{
				DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dgvItemsToCalculate.CurrentCell;
				if (dgvItemsToCalculate.CurrentRow != null)
				{
					Item currentRow = dgvItemsToCalculate.CurrentRow.DataBoundItem as Item;
					flag = "checkbox";
					float total1;
					float current;
					float.TryParse(labelKarmaValue.Text, out total1);
					float.TryParse(currentRow.TotalKarma.ToString(), out current);
					if (!(bool)checkbox.EditedFormattedValue)
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


		#region Methods

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
						total = total + (float)row.Cells["karmaTotal"].Value;
					}
				}
				return total;
			}
			catch (Exception)
			{
				return float.Epsilon;
			}

		}

		public async Task GetNameFromApi(List<int> allIds, int? singleId)
		{
			if (allIds != null)
			{
				List<ItemFull> allItems = await SAItems.GetAlItemsAsync(allIds);
				foreach (var id in allIds)
				{
					ItemFull item = allItems.FirstOrDefault(p => p.id == id);
					Item sycnedItem = AllItems.FirstOrDefault(p => p.ItemId == item.id);
					if (sycnedItem != null)
					{
						sycnedItem.Name = item.name + "  " + item.level + "  " + item.rarity;
						sycnedItem.TotalKarma = (float?)(sycnedItem.KarmaPerItem * sycnedItem.Quantity);
					}
				}
			}
			else
			{
				ItemFull item = await SAItems.GetItemsAsync((int)singleId);
				Item sincedItem = AllItems.FirstOrDefault(p => p.ItemId == item.id);
				if (sincedItem != null)
				{
					sincedItem.Name = item.name + "  " + item.level + "  " + item.rarity;
					sincedItem.TotalKarma = (float?)(sincedItem.KarmaPerItem * sincedItem.Quantity);
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

		public async Task<List<ResultItem>> CombineAllData()
		{
			List<ResultItem> items = new List<ResultItem>();
			List<int> allItemIds = ResultSet.Select(pair => pair.Key).ToList();
			List<ItemFull> allItemApis = await SAItems.GetAlItemsAsync(allItemIds);
			List<ItemPrices> allItemPrices = await SAItems.GetAllItemPrices(allItemIds);
			foreach (var result in ResultSet)
			{
				ResultItem resultItem = new ResultItem();
				ItemFull item = allItemApis.FirstOrDefault(p => p.id == result.Key);
				ItemPrices prices = allItemPrices.FirstOrDefault(p => p.id == result.Key);
				if (prices != null)
				{
					resultItem.ItemId = result.Key;
					resultItem.Quantity = result.Value;
					resultItem.Name = item.name;
					resultItem.PriceEach = prices.buys.unit_price != 0 ? prices.buys.unit_price + 1 : prices.sells.unit_price + 1;
					resultItem.Total = resultItem.PriceEach * result.Value;
					resultItem.PriceFormated = ParsePrices(prices.buys.unit_price != 0 ? prices.buys.unit_price + 1 : prices.sells.unit_price + 1);
					resultItem.PriceTotalFormated = ParsePrices((prices.buys.unit_price != 0 ? prices.buys.unit_price + 1 : prices.sells.unit_price + 1) * result.Value);
					resultItem.RecalculateChecked = false;
					items.Add(resultItem);
				}
			}

			return items;
		}

		public async Task<int> CalculateMargin(List<Item> allItems)
		{
			var count = 0;
			List<int> allitemIds = allItems.Select(pair => pair.ItemId).ToList();
			List<ItemPrices> allItemPriceses = await SAItems.GetAllItemPrices(allitemIds);
			foreach (var item in allItems)
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
				result = $"{silver}s, {copper}c";
			}
			else if (gold == 0 && silver == 0)
			{
				result = $"{copper}c";
			}
			else
			{
				result = $"{gold}g, {silver}s, {copper}c";
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
		    dgvItemsToCalculate.RowHeadersVisible = false;

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


	}
}

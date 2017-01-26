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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using gw2_Investment_Tool.Classes;
using gw2_Investment_Tool.ServiceAccess;


namespace gw2_Investment_Tool.Forms
{
    public partial class MainForm : Form
    {
        public List<ResultItem> ItemsToBuy = new List<ResultItem>();
        public List<Item> AllItems = new List<Item>();
        public static List<ItemApi> ItemNames = new List<ItemApi>();
        public Dictionary<int, int> ResultSet = new Dictionary<int, int>(); //key - itemId , value - quantity
        public List<int> AllItemIds = new List<int>();
        public List<int> AllRecipeIds = new List<int>();
        public static List<WhiteListedItem> WhiteListedItems = new List<WhiteListedItem>();
        public static int TotalGold = 0;
        public static float TotalKarma = 0;

        public MainForm()
        {
            InitializeComponent();
            SetGridColumns();
            try
            {
                Load += btnLoadData_Click;
            }
            catch (Exception)
            {

                MessageBox.Show(@"File Not Found!", @"Load error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #region // <================ Events ================> 

        private async void btnLoadData_Click(object sender, EventArgs e)
        {
            try
            {
                string line;
                StreamReader file =
                    new StreamReader(ConfigurationManager.AppSettings["LoadCurrentItems"]);
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
                    bool b = decimal.TryParse(values[3], out karmaperitem);
                    decimal value = Decimal.Parse(values[3], NumberStyles.Currency, CultureInfo.InvariantCulture);
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

                string line2;
                StreamReader file2 =
                    new StreamReader(ConfigurationManager.AppSettings["LoadWhiteList"]);
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
                StreamReader file3 = new StreamReader(ConfigurationManager.AppSettings["LoadNames"]);
                while ((line3 = file3.ReadLine()) != null)
                {
                    ItemApi item = new ItemApi();
                    string[] values = line3.Split(Convert.ToChar("%"));
                    int itemId;
                    int.TryParse(values[0], out itemId);
                    item.id = itemId;
                    item.name = values[1];

                    if (ItemNames.FirstOrDefault(p => p.id == item.id) == null)
                    {
                        ItemNames.Add(item);
                    }
                }
                file.Close();
            }
            catch (Exception)
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
                    File.WriteAllLines(ConfigurationManager.AppSettings["LoadWhiteList"], lines);
                }
                else
                {
                    File.WriteAllText(ConfigurationManager.AppSettings["LoadWhiteList"], string.Empty);
                }
            }
        }

        //private void btnEdit_Click(object sender, EventArgs e)
        //{
        //    if (dgvItemsToCalculate.SelectedRows.Count <= 0)
        //        return;

        //    Item selectedItem = (Item) dgvItemsToCalculate.SelectedRows[0].DataBoundItem;
        //    AddOrEditForm addForm = new AddOrEditForm(selectedItem);

        //    if (addForm.ShowDialog() == DialogResult.OK)
        //    {
        //        Item newItem = addForm.Item;
        //        var check = AllItems.FirstOrDefault(p => p.ItemId == newItem.ItemId);
        //        if (check != null)
        //        {
        //            Item sincedItem = AllItems.FirstOrDefault(p => p.ItemId == addForm.Item.ItemId);
        //            if (sincedItem != null)
        //            {
        //                sincedItem.ItemId = addForm.Item.ItemId;
        //                sincedItem.Quantity = addForm.Item.Quantity;
        //                sincedItem.Discipline = addForm.Item.Discipline;
        //                sincedItem.KarmaPerItem = addForm.Item.KarmaPerItem;
        //                sincedItem.Active = addForm.Item.Active;
        //                sincedItem.TotalKarma = (float?) (addForm.Item.Quantity*addForm.Item.KarmaPerItem);
        //            }
        //            dgvItemsToCalculate.DataSource = null;
        //            dgvItemsToCalculate.DataSource = AllItems;
        //            labelKarmaValue.Text = CalculateTotalKarma().ToString(CultureInfo.InvariantCulture);
        //        }
        //        else
        //        {
        //            MessageBox.Show(@"Selected Item cound not be found", @"Edit error",
        //                MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

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
                File.WriteAllLines(ConfigurationManager.AppSettings["LoadCurrentItems"], lines);
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
                    row.Cells["karmaTotal"].Value = karma*quantity;
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

        #endregion

        #region // < ================ Methodts ================>

        public async Task GetNameFromApi(List<int> allIds, int? singleId)
        {
            if (allIds != null)
            {
                foreach (var id in allIds)
                {
                    ItemApi item = await SAItems.GetItemsAsync(id);
                    Item sincedItem = AllItems.FirstOrDefault(p => p.ItemId == item.id);
                    if (sincedItem != null)
                    {
                        sincedItem.Name = item.name;
                        sincedItem.TotalKarma = (float?) (sincedItem.KarmaPerItem*sincedItem.Quantity);
                    }
                }
            }
            else
            {
                ItemApi item = await SAItems.GetItemsAsync((int) singleId);
                Item sincedItem = AllItems.FirstOrDefault(p => p.ItemId == item.id);
                if (sincedItem != null)
                {
                    sincedItem.Name = item.name;
                    sincedItem.TotalKarma = (float?) (sincedItem.KarmaPerItem*sincedItem.Quantity);
                }
            }
        }

        public async Task GetRecipeFromApi(List<Item> allItems)
        {
            foreach (var item in allItems)
            {
                if (item.Active)
                {
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
                                                                    (ingredient.count*item.Quantity/
                                                                     recipeData.output_item_count);
                                }
                                else
                                {
                                    ResultSet.Add(ingredient.item_id,
                                        ingredient.count*item.Quantity/recipeData.output_item_count);
                                }
                            }
                        }
                    }
                }
            }
        }

        public float CalculateTotalKarma()
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

        public async Task CombineAllData()
        {
            foreach (var itemID in ResultSet)
            {
                ResultItem resultItem = new ResultItem();
                ItemApi item = await SAItems.GetItemsAsync(itemID.Key);
                ItemPrices prices = await SAItems.GetItemPricesAsync(itemID.Key);
                var test = item.name;
                if (prices != null)
                {
                    resultItem.ItemId = itemID.Key;
                    resultItem.Quantity = itemID.Value;
                    resultItem.Name = item.name;
                    resultItem.PriceEach = prices.buys.unit_price;
                    resultItem.Total = prices.buys.unit_price*itemID.Value;
                    resultItem.PriceFormated = ParsePrices(prices.buys.unit_price);
                    resultItem.PriceTotalFormated = ParsePrices(prices.buys.unit_price*itemID.Value);
                    resultItem.RecalculateChecked = false;
                    ItemsToBuy.Add(resultItem);
                }
            }
        }

        public async Task<int> CalculateMargin(List<Item> AllItems)
        {
            var count = 0;
            foreach (var item in AllItems)
            {
                if (item.Active)
                {
                    ItemPrices prices = await SAItems.GetItemPricesAsync(item.ItemId);
                    count = count + prices.sells.unit_price*item.Quantity;
                }

            }
            return count;
        }

        public string ParsePrices(int price)
        {
            string result;
            int copper = price%100;
            int left = price/100;
            int silver = left%100;
            int gold = left/100;
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
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gw2_Investment_Tool.Classes;
using gw2_Investment_Tool.Controls;
using gw2_Investment_Tool.ServiceAccess;

namespace gw2_Investment_Tool.Forms
{
    public partial class ResultForm : Form
    {
        public List<ResultItem> CurrnetItems = new List<ResultItem>();
        public List<ResultItem> ItemsToKeep = new List<ResultItem>();
        public List<Item> AllItems = new List<Item>();
        public Dictionary<int, int> ResultSet = new Dictionary<int, int>();

        public ResultForm(List<ResultItem> items)
        {
            InitializeComponent();
            SetGridColumns();
            List<ResultItem> tempList = new List<ResultItem>();
            foreach (var item in items)
            {
                ResultItem newItem = new ResultItem();
                newItem.ItemId = item.ItemId;
                newItem.Name = item.Name;
                newItem.PriceEach = item.PriceEach;
                newItem.PriceFormated = item.PriceFormated;
                newItem.PriceTotalFormated = item.PriceTotalFormated;
                newItem.Quantity = item.Quantity;
                newItem.RecalculateChecked = item.RecalculateChecked;
                newItem.Total = item.Total;
                CurrnetItems.Add(newItem);
                tempList.Add(newItem);
            }
			
	        
	        ParsePriceInControl((int) ((MainForm.TotalGold - CalculateTotal(items))*0.85),gvcProfitValue);
            ParsePriceInControl(CalculateTotal(items),gvcTotalValue);
			if (MainForm.TotalKarma < 1)
	        {
		        labelTotalPerKarmaValue.Text = "No Karma Used!";
		        gvcTotalPerKarmaValue.Visible = false;
	        }
	        else
	        {
		        labelTotalPerKarmaValue.Visible = false;
		        gvcTotalPerKarmaValue.Visible = true;
				ParsePriceInControl((int)((int)((MainForm.TotalGold - CalculateTotal(items)) * 0.85) / (MainForm.TotalKarma / 1000)),gvcTotalPerKarmaValue);
	        }

			labelROI.Text = (((MainForm.TotalGold - CalculateTotal(items)) * 0.85) / (CalculateTotal(items))).ToString("#.##" + "%");
			dgvResults.DataSource = null;
            dgvResults.DataSource = tempList;
        }

        public int CalculateTotal(List<ResultItem> items)
        {
            int total = 0;
            foreach (var item in items)
            {
                total = (int) (total + item.PriceEach*item.Quantity);
            }
            return total;
        }

        public string ParsePricesTotal(int price)
        {
            int copper = price%100;
            int left = price/100;
            int silver = left%100;
            int gold = left/100;
            string result = string.Format("{0} Gold, {1} Silver, {2} Copper", gold, silver, copper);
            return result;
        }

	    public void ParsePriceInControl(int price, GoldValueControl control)
	    {
			int copper = price % 100;
		    int left = price / 100;
		    int silver = left % 100;
		    int gold = left / 100;
			control.BindValues(gold,silver,copper);
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

        private async void btnRecalculate_Click(object sender, EventArgs e)
        {
            ItemsToKeep.Clear();
            ResultSet.Clear();
            AllItems.Clear();
            foreach (DataGridViewRow row in dgvResults.Rows)
            {
                Item newitem = new Item();
                newitem.ItemId = (int) row.Cells["itemId"].Value;
                newitem.Quantity = (int) row.Cells["quantity"].Value;
                newitem.Active = (bool) row.Cells["recalculate"].Value;
                newitem.Name = (string) row.Cells["name"].Value;
                AllItems.Add(newitem);
                if (!(bool) row.Cells["recalculate"].Value)
                {
                    ItemsToKeep.Add(CurrnetItems.FirstOrDefault(p => p.ItemId == (int) row.Cells["itemId"].Value));
                }
            }
	        List<int> allitemIds = MainForm.WhiteListedItems.Select(p => p.ItemId).ToList();
	        List<ItemPrices> allItemPriceses = await SAItems.GetAllItemPrices(allitemIds);
			foreach (var item in MainForm.WhiteListedItems)
            {
                ItemPrices prices = allItemPriceses.FirstOrDefault(p => p.id == item.ItemId);
                item.CurrentPrice = prices.sells.unit_price+1;
            }
            
            await GetRecipeFromApi(AllItems);
            await CombineAllData();
            ResultForm resultForm = new ResultForm(ItemsToKeep);
            resultForm.ShowDialog();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            dgvResults.DataSource = null;
        }

        public async Task GetRecipeFromApi(List<Item> allItems)
        {
            foreach (var item in allItems)
            {
                WhiteListedItem wlItem = MainForm.WhiteListedItems.FirstOrDefault(p => p.ItemId == item.ItemId);
                if (item.Active)
                {
                    if (wlItem != null && wlItem.CurrentPrice <= wlItem.Price)
                    {
                        ItemsToKeep.Add(CurrnetItems.FirstOrDefault(p => p.ItemId == item.ItemId));
                    }
                    else
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
                                        ResultSet[ingredient.item_id] = oldQuantity + (ingredient.count*item.Quantity/ recipeData.output_item_count);
                                    }
                                    else
                                    {
                                        ResultSet.Add(ingredient.item_id, ingredient.count*item.Quantity/ recipeData.output_item_count);
                                    }
                                }
                            }
                        }
                    }
                }
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
					resultItem.PriceEach = prices.buys.unit_price != 0 ? prices.buys.unit_price + 1 : prices.sells.unit_price + 1;
	                resultItem.Total = resultItem.PriceEach * result.Value;
	                resultItem.PriceFormated = ParsePrices(prices.buys.unit_price != 0 ? prices.buys.unit_price + 1 : prices.sells.unit_price + 1);
	                resultItem.PriceTotalFormated = ParsePrices((prices.buys.unit_price != 0 ? prices.buys.unit_price + 1 : prices.sells.unit_price + 1) * result.Value);
					resultItem.RecalculateChecked = false;
                    ResultItem check = ItemsToKeep.FirstOrDefault(p => p.ItemId == resultItem.ItemId);
                    if (check != null)
                    {
                        check.Quantity = check.Quantity + resultItem.Quantity;
                        check.Total = check.Total + resultItem.Total;
                        check.PriceFormated = ParsePrices(prices.buys.unit_price != 0 ? prices.buys.unit_price + 1 : prices.sells.unit_price + 1);
						check.PriceTotalFormated = ParsePrices((prices.buys.unit_price != 0 ? prices.buys.unit_price + 1 : prices.sells.unit_price + 1) * result.Value);
					}
                    else
                    {
                        ItemsToKeep.Add(resultItem);
                    }
                }
            }
        }

        private void SetGridColumns()
        {
            dgvResults.DataSource = null;
            dgvResults.Columns.Clear();
            dgvResults.AutoGenerateColumns = false;

            DataGridViewCheckBoxColumn c1 = new DataGridViewCheckBoxColumn();
            c1.Name = "recalculate";
            c1.HeaderText = "Recalculate";
            c1.DataPropertyName = "RecalculateChecked";
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvResults.Columns.Add(c1);

            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.Name = "name";
            c2.HeaderText = "Item Name";
            c2.DataPropertyName = "Name";
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResults.Columns.Add(c2);

            DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
            c3.Name = "quantity";
            c3.HeaderText = "Quantity";
            c3.DataPropertyName = "Quantity";
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvResults.Columns.Add(c3);

            DataGridViewTextBoxColumn c4 = new DataGridViewTextBoxColumn();
            c4.Name = "price";
            c4.HeaderText = "Price";
            c4.DataPropertyName = "PriceFormated";
            c4.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvResults.Columns.Add(c4);

            DataGridViewTextBoxColumn c5 = new DataGridViewTextBoxColumn();
            c5.Name = "total";
            c5.HeaderText = "Total Price";
            c5.DataPropertyName = "PriceTotalFormated";
            c5.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvResults.Columns.Add(c5);

            DataGridViewTextBoxColumn c6 = new DataGridViewTextBoxColumn();
            c6.Name = "itemId";
            c6.HeaderText = "Item ID";
            c6.DataPropertyName = "ItemId";
            c6.Visible = false;
            dgvResults.Columns.Add(c6);
        }

     }
}

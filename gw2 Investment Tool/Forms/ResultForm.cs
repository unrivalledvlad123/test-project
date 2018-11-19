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
using gw2_Investment_Tool.Models;
using gw2_Investment_Tool.ServiceAccess;

namespace gw2_Investment_Tool.Forms
{
    public partial class ResultForm : Form
    {
        public List<ResultItem> CurrnetItems = new List<ResultItem>();
        public List<ResultItem> ItemsToKeep = new List<ResultItem>();
        public List<Item> AllItems = new List<Item>();
        public List<Item> ResultSet = new List<Item>();

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
			
	        
	        ParsePriceInControl((int) ((GlobalDataHolder.TotalGold - CalculateTotal(items))*0.85),gvcProfitValue);
            ParsePriceInControl(CalculateTotal(items),gvcTotalValue);
			if (GlobalDataHolder.TotalKarma < 1)
	        {
		        labelTotalPerKarmaValue.Text = "No Karma Used!";
		        gvcTotalPerKarmaValue.Visible = false;
	        }
	        else
	        {
		        labelTotalPerKarmaValue.Visible = false;
		        gvcTotalPerKarmaValue.Visible = true;
				ParsePriceInControl((int)((int)((GlobalDataHolder.TotalGold - CalculateTotal(items)) * 0.85) / (GlobalDataHolder.TotalKarma / 1000)),gvcTotalPerKarmaValue);
	        }

			labelROI.Text = (((GlobalDataHolder.TotalGold - CalculateTotal(items)) * 0.85) / (CalculateTotal(items))).ToString("#.##" + "%");
            dgvResults.DataSource = null;
            dgvResults.DataSource = SortResult(tempList);
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
            List<ItemPrices> sellItemPriceses = await SAItems.GetAllItemPrices(ItemsToKeep.Select(p => p.ItemId).ToList());
            foreach (var item in ItemsToKeep)
            {
                if (item.RecalculateChecked)
                {
                    ItemPrices pr = sellItemPriceses.FirstOrDefault(p => p.id == item.ItemId);
                    int determinedPrice = item.CraftingPrice <= pr.sells.unit_price
                        ? pr.buys.unit_price
                        : pr.sells.unit_price;
                    item.PriceEach = determinedPrice;
                    item.PriceFormated = ParsePrices(determinedPrice);
                    item.PriceTotalFormated = ParsePrices(item.Quantity * determinedPrice);
                    item.Name = item.CraftingPrice <= pr.sells.unit_price
                        ? item.Name
                        : AdjustName(item.CraftingPrice, item.Name);

                }
                else
                {
                    item.PriceTotalFormated = ParsePrices(item.Quantity * item.PriceEach.Value);
                }

            }
            ResultForm resultForm = new ResultForm(ItemsToKeep);
            resultForm.ShowDialog();
        }

        public string AdjustName(int price, string name)
        {
            return name.Contains("Instabuy") ? name : name + $" - Instabuy ( {ParsePrices(price)} )";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            dgvResults.DataSource = null;
        }

        public async Task GetRecipeFromApi(List<Item> allItems)
        {
            List<Recipe> allRecipes = new List<Recipe>();
            List<int> allIngredientIds = new List<int>();
            List<int> ints = MainForm.WhiteListedItems.Select(p => p.ItemId).ToList();
            foreach (Item item in allItems)
            {
                int[] recipe = await SAItems.GetRecipesOutputAsync(item.ItemId);
                if (recipe.Length == 0) continue;
                var currentRecipeId = recipe[0];
                Recipe recipeData = await SAItems.GetRecipesIngredientsAsync(currentRecipeId);
                if (recipeData != null)
                {
                    allRecipes.Add(recipeData);
                }
            }

            foreach (Recipe recipe in allRecipes)
            {
                foreach (var ing in recipe.ingredients)
                {
                    allIngredientIds.Add(ing.item_id);
                    ints.Add(ing.item_id);
                }
            }

            foreach (var item in allItems)
            {
                allIngredientIds.Add(item.ItemId);
                ints.Add(item.ItemId);
            }

            List<ItemPrices> ingredientPrices = await SAItems.GetAllItemPrices(allIngredientIds.Distinct().ToList());
            List<ItemListings> allItemListings = await SAItems.GetAllItemListnings(ints.Distinct().ToList());

            foreach (var item in allItems)
            {
                WhiteListedItem wlItem = MainForm.WhiteListedItems.FirstOrDefault(p => p.ItemId == item.ItemId);
                if (item.Active)
                {
                    int remainingQuantity = item.Quantity;
                    if (wlItem != null && wlItem.CurrentPrice <= wlItem.Price)
                    {
                        ItemListings curent = allItemListings.FirstOrDefault(p => p.id == item.ItemId);
                        foreach (Prices listning in curent.sells)
                        {
                            if (listning.unit_price < wlItem.Price)
                            {
                                if (remainingQuantity > 0)
                                {
                                    if (listning.quantity >= remainingQuantity)
                                    {
                                        ResultItem check1 = ItemsToKeep.FirstOrDefault(p => p.ItemId == item.ItemId);
                                        if (check1 != null)
                                        {
                                            check1.Quantity += remainingQuantity;
                                        }
                                        else
                                        {
                                            ItemsToKeep.Add(CurrnetItems.FirstOrDefault(p => p.ItemId == item.ItemId));
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        ResultItem check = ItemsToKeep.FirstOrDefault(p => p.ItemId == item.ItemId);
                                        if (check != null)
                                        {
                                            check.Quantity += Math.Min(remainingQuantity, listning.quantity);
                                            remainingQuantity = remainingQuantity - listning.quantity;
                                        }
                                        else
                                        {
                                            ResultItem temp = CurrnetItems.FirstOrDefault(p => p.ItemId == item.ItemId);
                                            temp.Quantity = listning.quantity;
                                            remainingQuantity = remainingQuantity - listning.quantity;
                                            ItemsToKeep.Add(temp);
                                        }
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                Recipe recipeData = allRecipes.FirstOrDefault(p => p.output_item_id == item.ItemId);
                                if (recipeData != null)
                                    foreach (var ingredient in recipeData.ingredients)
                                    {
                                        Item check = ResultSet.FirstOrDefault(p => p.ItemId == ingredient.item_id);
                                        if (check != null)
                                        {
                                            check.Quantity = check.Quantity +
                                                             (ingredient.count * remainingQuantity /
                                                              recipeData.output_item_count);
                                        }
                                        else
                                        {
                                            ResultSet.Add(new Item()
                                            {
                                                ItemId = ingredient.item_id,
                                                Quantity =
                                                    ingredient.count * remainingQuantity / recipeData.output_item_count
                                            });
                                        }
                                    }
                                break;
                            }
                        }
                    }
                    else
                    {

                        // calculate recipe
                        Recipe recipeData = allRecipes.FirstOrDefault(p => p.output_item_id == item.ItemId);
                        int priceCounter = 0;
                        if (recipeData != null)
                        {
                            foreach (var ing in recipeData.ingredients)
                            {
                                var price = ingredientPrices.FirstOrDefault(p => p.id == ing.item_id);
                                priceCounter += ing.count * price.buys.unit_price;
                            }
                            item.CraftingPrice = priceCounter;
                            ItemPrices itemPrice = ingredientPrices.FirstOrDefault(p => p.id == item.ItemId);
                            if (priceCounter >= itemPrice.sells.unit_price)
                            {
                                ItemListings curent = allItemListings.FirstOrDefault(p => p.id == item.ItemId);
                                foreach (Prices listning in curent.sells)
                                {
                                    if (listning.unit_price <= priceCounter)
                                    {
                                        if (remainingQuantity > 0)
                                        {
                                            if (listning.quantity >= remainingQuantity)
                                            {
                                                ResultItem check1 =
                                                    ItemsToKeep.FirstOrDefault(p => p.ItemId == item.ItemId);
                                                if (check1 != null)
                                                {
                                                    check1.Quantity += remainingQuantity;
                                                }
                                                else
                                                {
                                                    ResultItem temp = CurrnetItems.FirstOrDefault(p => p.ItemId == item.ItemId);
                                                    temp.CraftingPrice = item.CraftingPrice.Value;
                                                    ItemsToKeep.Add(temp);
                                                }
                                                break;
                                            }
                                            else
                                            {
                                                ResultItem check =
                                                    ItemsToKeep.FirstOrDefault(p => p.ItemId == item.ItemId);
                                                if (check != null)
                                                {
                                                    check.Quantity += Math.Min(remainingQuantity, listning.quantity);
                                                    remainingQuantity = remainingQuantity - listning.quantity;
                                                }
                                                else
                                                {
                                                    ResultItem temp =
                                                        CurrnetItems.FirstOrDefault(p => p.ItemId == item.ItemId);
                                                    temp.Quantity = listning.quantity;
                                                    temp.CraftingPrice = item.CraftingPrice.Value;
                                                    remainingQuantity = remainingQuantity - listning.quantity;
                                                    ItemsToKeep.Add(temp);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        recipeData = allRecipes.FirstOrDefault(p => p.output_item_id == item.ItemId);
                                        if (recipeData != null)
                                            foreach (var ingredient in recipeData.ingredients)
                                            {
                                                Item check = ResultSet.FirstOrDefault(p => p.ItemId == ingredient.item_id);
                                                if (check != null)
                                                {
                                                    check.Quantity = check.Quantity +
                                                                     (ingredient.count * remainingQuantity /
                                                                      recipeData.output_item_count);
                                                }
                                                else
                                                {
                                                    ResultSet.Add(new Item()
                                                    {
                                                        ItemId = ingredient.item_id,
                                                        Quantity =
                                                            ingredient.count * remainingQuantity / recipeData.output_item_count
                                                    });
                                                }
                                            }
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                recipeData = allRecipes.FirstOrDefault(p => p.output_item_id == item.ItemId);
                                if (recipeData != null)
                                {
                                    foreach (var ingredient in recipeData.ingredients)
                                    {
                                        Item check = ResultSet.FirstOrDefault(p => p.ItemId == ingredient.item_id);
                                        if (check != null)
                                        {
                                            check.Quantity = check.Quantity +
                                                             (ingredient.count * remainingQuantity /
                                                              recipeData.output_item_count);
                                        }
                                        else
                                        {
                                            ResultSet.Add(new Item()
                                            {
                                                ItemId = ingredient.item_id,
                                                Quantity =
                                                    ingredient.count * remainingQuantity / recipeData.output_item_count
                                            });
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Item check = ResultSet.FirstOrDefault(p => p.ItemId == item.ItemId);
                            if (check != null)
                            {
                                check.Quantity += item.Quantity;
                            }
                            else
                            {
                                ResultSet.Add(new Item() {ItemId = item.ItemId,Quantity = item.Quantity});
                            }
                        }
                    }
                }
            }
            //foreach (Item result in ResultSet)
            //{
            //    Item item = AllItems.FirstOrDefault(p => p.ItemId == result.ItemId);
            //    if (item!=null)
            //    {
            //        result.CraftingPrice = item.CraftingPrice;
            //    }
            //}


        }

        public async Task CombineAllData()
        {
	        List<int> allitemIds = ResultSet.Select(pair => pair.ItemId).ToList();
	        List<ItemFull> allItemApis = await SAItems.GetAlItemsAsync(allitemIds);
	        List<ItemPrices> allItemPriceses = await SAItems.GetAllItemPrices(allitemIds);
			foreach (var result in ResultSet)
            {
                ResultItem resultItem = new ResultItem();
				ItemFull item = allItemApis.FirstOrDefault(p => p.id == result.ItemId);
	            ItemPrices prices = allItemPriceses.FirstOrDefault(p => p.id == result.ItemId);
				if (prices != null)
                {
                    resultItem.ItemId = result.ItemId;
                    resultItem.Quantity = result.Quantity;
                    resultItem.Name = item.name;
					resultItem.PriceEach = prices.buys.unit_price != 0 ? prices.buys.unit_price + 1 : prices.sells.unit_price + 1;
	                resultItem.Total = resultItem.PriceEach * result.Quantity;
	                resultItem.PriceFormated = ParsePrices(prices.buys.unit_price != 0 ? prices.buys.unit_price + 1 : prices.sells.unit_price + 1);
	                resultItem.PriceTotalFormated = ParsePrices((prices.buys.unit_price != 0 ? prices.buys.unit_price + 1 : prices.sells.unit_price + 1) * result.Quantity);
					resultItem.RecalculateChecked = false;
                    result.CraftingPrice = result.CraftingPrice ?? 0;
                    ResultItem check = ItemsToKeep.FirstOrDefault(p => p.ItemId == resultItem.ItemId);
                    if (check != null)
                    {
                        check.Quantity = check.Quantity + resultItem.Quantity;
                        check.Total = check.Total + resultItem.Total;
                        check.PriceFormated = ParsePrices(prices.buys.unit_price != 0 ? prices.buys.unit_price + 1 : prices.sells.unit_price + 1);
						check.PriceTotalFormated = ParsePrices((prices.buys.unit_price != 0 ? prices.buys.unit_price + 1 : prices.sells.unit_price + 1) * result.Quantity);
					}
                    else
                    {
                        ItemsToKeep.Add(resultItem);
                    }
                }
            }
        }

        #region  // < ========== Sorting =========== > //

        public List<ResultItem> SortResult(List<ResultItem> unsortedList)
        {

            List<ResultItem> ingots = new List<ResultItem>();
            List<ResultItem> insignias = new List<ResultItem>();
            List<ResultItem> inscriptions = new List<ResultItem>();
            List<ResultItem> all = new List<ResultItem>();
            List<ResultItem> jewels = new List<ResultItem>();

            foreach (ResultItem item in unsortedList)
            {
                if (item.Name.Contains("Ingot"))
                {
                    ingots.Add(item);
                }
                else if (item.Name.Contains("Insignia"))
                {
                    insignias.Add(item);
                }
                else if (item.Name.Contains("Inscription"))
                {
                    inscriptions.Add(item);
                }
                else if (item.Name.Contains("Jewel"))
                {
                    jewels.Add(item);
                }
                else
                {
                    all.Add(item);
                }
            }
            List<ResultItem> result = new List<ResultItem>();
            result.AddRange(new List<ResultItem>(ingots.OrderBy(p => p.Name)));
            result.AddRange(new List<ResultItem>(SortInsigniasInner(insignias)));
            result.AddRange(new List<ResultItem>(SortInscriptionInner(inscriptions)));
            result.AddRange(new List<ResultItem>(InnerRaritySorting(jewels)));
            result.AddRange(new List<ResultItem>(all.OrderBy(p => p.Name)));

            return result;
        }

        public List<ResultItem> SortInsigniasInner(List<ResultItem> items)
        {
            List<ResultItem> jute = new List<ResultItem>();
            List<ResultItem> wool = new List<ResultItem>();
            List<ResultItem> cotton = new List<ResultItem>();
            List<ResultItem> linen = new List<ResultItem>();
            List<ResultItem> silk = new List<ResultItem>();
            List<ResultItem> gossamer = new List<ResultItem>();
            List<ResultItem> others = new List<ResultItem>();
            foreach (ResultItem item in items)
            {
                if (item.Name.Contains("Jute"))
                {
                    jute.Add(item);
                }
                else if (item.Name.Contains("Wool"))
                {
                    wool.Add(item);
                }
                else if (item.Name.Contains("Cotton"))
                {
                    cotton.Add(item);
                }
                else if (item.Name.Contains("Linen"))
                {
                    linen.Add(item);
                }
                else if (item.Name.Contains("Silk"))
                {
                    silk.Add(item);
                }
                else if (item.Name.Contains("Gossamer"))
                {
                    gossamer.Add(item);
                }
                else
                {
                    others.Add(item);
                }
            }
            List<ResultItem> result = new List<ResultItem>();

            result.AddRange(InnerRaritySorting(jute));
            result.AddRange(InnerRaritySorting(wool));
            result.AddRange(InnerRaritySorting(cotton));
            result.AddRange(InnerRaritySorting(linen));
            result.AddRange(InnerRaritySorting(silk));
            result.AddRange(InnerRaritySorting(gossamer));
            result.AddRange(new List<ResultItem>(others.OrderBy(p => p.Name)));
            
            return result;
        }

        public List<ResultItem> SortInscriptionInner(List<ResultItem> items)
        {
            List<ResultItem> green = new List<ResultItem>();
            List<ResultItem> bronze = new List<ResultItem>();
            List<ResultItem> soft = new List<ResultItem>();
            List<ResultItem> iron = new List<ResultItem>();
            List<ResultItem> seasoned = new List<ResultItem>();
            List<ResultItem> steel = new List<ResultItem>();
            List<ResultItem> others = new List<ResultItem>();
            List<ResultItem> hard = new List<ResultItem>();
            List<ResultItem> darksteel = new List<ResultItem>();
            List<ResultItem> elder = new List<ResultItem>();
            List<ResultItem> mithril = new List<ResultItem>();
            List<ResultItem> orichalcum = new List<ResultItem>();
            foreach (ResultItem item in items)
            {
                if (item.Name.Contains("Green"))
                {
                    green.Add(item);
                }
                else if (item.Name.Contains("Bronze"))
                {
                    bronze.Add(item);
                }
                else if (item.Name.Contains("Soft"))
                {
                    soft.Add(item);
                }
                else if (item.Name.Contains("Iron"))
                {
                    iron.Add(item);
                }
                else if (item.Name.Contains("Seasoned"))
                {
                    seasoned.Add(item);
                }
                else if (item.Name.Contains("Hard"))
                {
                    hard.Add(item);
                }
                else if (item.Name.Contains("Darksteel"))
                {
                    darksteel.Add(item);
                }
                else if (item.Name.Contains("Steel"))
                {
                    steel.Add(item);
                }
                else if (item.Name.Contains("Elder"))
                {
                    elder.Add(item);
                }
                else if (item.Name.Contains("Mithril"))
                {
                    mithril.Add(item);
                }
                else if (item.Name.Contains("Orichalcum"))
                {
                    orichalcum.Add(item);
                }
                else
                {
                    others.Add(item);
                }
            }
            List<ResultItem> result = new List<ResultItem>();

            result.AddRange(InnerRaritySorting(green));
            result.AddRange(InnerRaritySorting(bronze));
            result.AddRange(InnerRaritySorting(soft));
            result.AddRange(InnerRaritySorting(iron));
            result.AddRange(InnerRaritySorting(seasoned));
            result.AddRange(InnerRaritySorting(steel));
            result.AddRange(InnerRaritySorting(hard));
            result.AddRange(InnerRaritySorting(darksteel));
            result.AddRange(InnerRaritySorting(elder));
            result.AddRange(InnerRaritySorting(mithril));
            result.AddRange(InnerRaritySorting(orichalcum));
            result.AddRange(new List<ResultItem>(others.OrderBy(p => p.Name)));

            return result;
        }

        public List<ResultItem> InnerRaritySorting(List<ResultItem> items)
        {
            List<ResultItem> all = new List<ResultItem>();
            List<ResultItem> rarity2 = new List<ResultItem>();
            List<ResultItem> rarity3 = new List<ResultItem>();
            List<ResultItem> rarity4 = new List<ResultItem>();
            List<ResultItem> rarity5 = new List<ResultItem>();
            List<ResultItem> rarity6 = new List<ResultItem>();
            List<ResultItem> rarity7 = new List<ResultItem>();

            foreach (ResultItem item in items)
            {
                if (!item.Name.Contains("Jewel"))
                {
                    if (item.Name.Contains("Embroidered") || item.Name.Contains("Plated"))
                    {
                        rarity2.Add(item);
                    }
                    else if (item.Name.Contains("Intricate") || item.Name.Contains("Imbued"))
                    {
                        rarity3.Add(item);
                    }
                    else
                    {
                        all.Add(item);
                    }
                }
                else
                {
                    if (item.Name.Contains("Adorned"))
                    {
                        rarity2.Add(item);
                    }
                    else if(item.Name.Contains("Embellished Intricate"))
                    {
                        rarity3.Add(item);
                    }
                    else if (item.Name.Contains("Embellished Gilded"))
                    {
                        rarity4.Add(item);
                    }
                    else if (item.Name.Contains("Embellished Ornate"))
                    {
                        rarity5.Add(item);
                    }
                    else if (item.Name.Contains("Embellished Brilliant"))
                    {
                        rarity6.Add(item);
                    }
                    else if (item.Name.Contains("Exquisite"))
                    {
                        rarity7.Add(item);
                    }
                    else
                    {
                        all.Add(item);
                    }
                }


            }
            List<ResultItem> result = new List<ResultItem>();
            result.AddRange(new List<ResultItem>(rarity2.OrderBy(p => p.Name)));
            result.AddRange(new List<ResultItem>(rarity3.OrderBy(p => p.Name)));
            result.AddRange(new List<ResultItem>(rarity4.OrderBy(p => p.Name)));
            result.AddRange(new List<ResultItem>(rarity5.OrderBy(p => p.Name)));
            result.AddRange(new List<ResultItem>(rarity6.OrderBy(p => p.Name)));
            result.AddRange(new List<ResultItem>(rarity7.OrderBy(p => p.Name)));
            result.AddRange(new List<ResultItem>(all.OrderBy(p => p.Name)));
            return result;
        }


        #endregion


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

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (dgvResults.DataSource != null)
            {
                foreach (DataGridViewRow row in dgvResults.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    chk.Value = true;
                } 
            }
        }
    }
}

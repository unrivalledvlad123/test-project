﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gw2_Investment_Tool.Classes;
using gw2_Investment_Tool.Models;
using gw2_Investment_Tool.Models.ExoticAndRareSalvageModels;
using gw2_Investment_Tool.ServiceAccess;

namespace gw2_Investment_Tool.Controls
{
	public partial class ExoticAndRareSalvageControl : UserControl
	{
		#region global constants

		private readonly List<int> _extractableInscriptionIds = new List<int>()
		{
			46684, 46685, 46686, 46687, 46688, 46690
		}; // a list of all salvagable Inscriptions ids

		private readonly List<int> _extractableInsigniasIds = new List<int>()
		{
			49522, 46710, 46709, 46711, 46712, 46708
		}; // a list of all salvagable Insignias ids

		private readonly List<string> _elements = new List<string>
		{
			"Any","Charm of Skill", "Charm of Brilliance", "Charm of Potence", "Symbol of Pain", "Symbol of Enhancement", "Symbol of Control"
		};

		#endregion

		// global vars to be used in other methods without refreshing the data
		public SalvageItemsFull GlobOfEctoplasm = new SalvageItemsFull();
		public SalvageItemsFull LucentMote = new SalvageItemsFull();
		public List<SalvageItemsFull> AllItems = new List<SalvageItemsFull>();
		List<UpgradeComponent> Insignias = new List<UpgradeComponent>();
		List<UpgradeComponent> Inscriptions = new List<UpgradeComponent>();
		List<SalvageItemsFull> CharmsAndSymbols = new List<SalvageItemsFull>();
		List<ExtractableUpgradeComponents> Upgrades = new List<ExtractableUpgradeComponents>();





		public ExoticAndRareSalvageControl()
		{
			InitializeComponent();
			SetGridColumns();
			cbCharm.DataSource = _elements;
			LoadSettings();
			
		}

		public async Task InitializeCollections()
		{
			// making the collections and sorting them
			AllItems = await SAItems.GetAllSalvagableItems();
			GlobOfEctoplasm = AllItems.SingleOrDefault(p => p.id == 19721);
			LucentMote = AllItems.SingleOrDefault(p => p.id == 89140);

			Upgrades = await SAItems.GetAllUpgradeComponents();
			foreach (var upd in Upgrades)
			{
				var temp = AllItems.FirstOrDefault(p => p.id == upd.id);
				if (temp != null) upd.Charm = temp.charm;
			}

			foreach (var id in _extractableInscriptionIds)
			{
				var inscriptionMatch = AllItems.FirstOrDefault(p => p.id == id);
				if (inscriptionMatch != null)
				{
					var parts = inscriptionMatch.name.Split(' ');
					var itemMatch = AllItems.FirstOrDefault(p => p.statName == parts[0]);
					UpgradeComponent uc = new UpgradeComponent
					{
						Name = inscriptionMatch.name,
						BuyPrice = inscriptionMatch.buy_price,
						Id = inscriptionMatch.id,
						Rarity = inscriptionMatch.rarity,
						SellPrice = inscriptionMatch.sell_price,
						StatId = itemMatch.statID
					};
					Inscriptions.Add(uc);
				}
			}

			foreach (var id in _extractableInsigniasIds)
			{
				var inscriptionMatch = AllItems.FirstOrDefault(p => p.id == id);
				if (inscriptionMatch != null)
				{
					var parts = inscriptionMatch.name.Split(' ');
					var itemMatch = AllItems.FirstOrDefault(p => p.statName == parts[0]);

					UpgradeComponent uc = new UpgradeComponent
					{
						Name = inscriptionMatch.name,
						BuyPrice = inscriptionMatch.buy_price,
						Id = inscriptionMatch.id,
						Rarity = inscriptionMatch.rarity,
						SellPrice = inscriptionMatch.sell_price,
						StatId = itemMatch.statID
					};

					Insignias.Add(uc);
				}
			}

			foreach (var el in _elements)
			{
				if (el == "Any")
				{
					continue;
				}
				var charm = AllItems.FirstOrDefault(p => p.name == el);
				CharmsAndSymbols.Add(charm);
			}
		}


		private void SetGridColumns()
		{
			dgvItems.DataSource = null;
			dgvItems.Columns.Clear();
			dgvItems.AutoGenerateColumns = false;
			dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			dgvItems.RowHeadersVisible = false;
			
			DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
			c2.Name = "Name";
			c2.HeaderText = "Item Name";
			c2.DataPropertyName = "Name";
			c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgvItems.Columns.Add(c2);

			DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
			c3.Name = "StatName";
			c3.HeaderText = "Stat Name";
			c3.DataPropertyName = "StatName";
			c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
			c3.Width = 200;
			dgvItems.Columns.Add(c3);

			DataGridViewTextBoxColumn c22 = new DataGridViewTextBoxColumn();
			c22.Name = "CharmName";
			c22.HeaderText = "Charm Name";
			c22.DataPropertyName = "CharmName";
			c22.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
			c3.Width = 100;
			dgvItems.Columns.Add(c22);

			DataGridViewTextBoxColumn c5 = new DataGridViewTextBoxColumn();
			c5.Name = "OrderProfit";
			c5.HeaderText = "Order Profit";
			c5.DataPropertyName = "OrderProfit";
			c5.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
			c5.Width = 80;
			dgvItems.Columns.Add(c5);

			DataGridViewTextBoxColumn c7 = new DataGridViewTextBoxColumn();
			c7.Name = "QuanityToBuyout";
			c7.HeaderText = "Quantity To Buyout";
			c7.DataPropertyName = "QuanityToBuyout";
			c7.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
			c7.Width = 50;
			dgvItems.Columns.Add(c7);

			DataGridViewTextBoxColumn c6 = new DataGridViewTextBoxColumn();
			c6.Name = "TotalBuyoutProfit";
			c6.HeaderText = "Total Profit";
			c6.DataPropertyName = "TotalBuyoutProfit";
			c6.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
			c6.Width = 80;
			dgvItems.Columns.Add(c6);
			
			DataGridViewTextBoxColumn c8 = new DataGridViewTextBoxColumn();
			c8.Name = "Buyouttill";
			c8.HeaderText = "Buyout till";
			c8.DataPropertyName = "BuyoutTill";
			c8.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
			c8.Width = 80;
			dgvItems.Columns.Add(c8);

		}

		#region Events
		private void btnSaveSettings_Click(object sender, EventArgs e)
		{
			var directory = Directory.GetCurrentDirectory();

			List<string> lines = new List<string>();
			List<Control> numerics = Utils.GetAllControls(gbRates, typeof(NumericUpDown)).ToList();
			foreach (var control in numerics)
			{
				NumericUpDown num = (NumericUpDown) control;
				StringBuilder sb = new StringBuilder();
				sb.Append(num.Name);
				sb.Append("%");
				sb.Append(num.Value);
				lines.Add(sb.ToString());
			}
			if (lines.Count != 0)
			{
				File.WriteAllLines(directory + "\\DataFiles\\System\\SalvageSettings.txt", lines);
			}
		}

		private async void btnSearch_Click(object sender, EventArgs e)
		{
			if (AllItems.Count != 0) //apply filters only
			{
				List<GridDataSalvage> data = dgvItems.DataSource as List<GridDataSalvage>;
				data = FilterResults(data);
				dgvItems.DataSource = null;
				dgvItems.DataSource = data;
				return;
			}

			// the actual sorting algorithm

			await InitializeCollections();

			List<int> idsToGetTransactions = new List<int>();
			List<GridDataSalvage> profitableItems = new List<GridDataSalvage>();

			List<SalvageItemsFull> AllWeapons =
				AllItems.Where(p => p.level >= 68 && p.type == "Weapon" && p.NoSalvage != true).ToList();
			List<SalvageItemsFull> AllArmors =
				AllItems.Where(p => p.level >= 68 && p.type == "Armor" && p.NoSalvage != true).ToList();

			// filter weapons
			CalculateProfitability(AllWeapons, Inscriptions, idsToGetTransactions, profitableItems);
			CalculateProfitability(AllArmors, Insignias, idsToGetTransactions, profitableItems);

			List<ItemListings> listings = await SAItems.GetAllItemListnings(idsToGetTransactions);

			// combine listing and item data
			foreach (var item in profitableItems)
			{
				var itemListings = listings.FirstOrDefault(p => p.id == item.Id);
				if (itemListings != null)
				{
					var goodListings = itemListings.sells.Where(p => p.unit_price < item.ValueOfItem).OrderBy(p => p.unit_price).ToList();
					if (goodListings.Count != 0)
					{
						int totalQuantity = 0;
						int totalProfit = 0;
						foreach (var listing in goodListings)
						{
							if (item.ValueOfItem/listing.unit_price*100 <= numMinProfit.Value*100)// calculate min ROI
							{
								totalQuantity = totalQuantity + listing.quantity;
								totalProfit = totalProfit + listing.quantity * item.ValueOfItem - listing.unit_price;
								item.BuyoutTill = goodListings.Last().unit_price.ToGoldFormat();
							}						
						}

						item.TotalBuyoutProfit = totalProfit.ToGoldFormat();
						item.InstantProfit = totalProfit;
						item.QuanityToBuyout = totalQuantity;
					}
				}

			}

			dgvItems.DataSource = null;
			dgvItems.DataSource = profitableItems.OrderByDescending(p => p.InstantProfit).ToList();

		}

		private void CalculateProfitability(List<SalvageItemsFull> itemCollection, List<UpgradeComponent> component,
			List<int> ids, List<GridDataSalvage> profitableItems)
		{
			foreach (var item in itemCollection)
			{
				int goldFromEctos = 0; // done
				int goldFromComponent = 0;
				int goldFromCharm = 0;
				int goldFromMotes = 0;

				SalvageItemsFull charmHolder = new SalvageItemsFull();

				switch (item.rarity)
				{
					case "Exotic":
						//calculate gold from ectos
						goldFromEctos = (int) (GlobOfEctoplasm.sell_price * (numExoticEctoDropRate.Value / 100));

						//calculate gold from component - only exotics
						if (component.Any(p => p.StatId == item.statID))
						{
							var ins = component.FirstOrDefault(p => p.StatId == item.statID);
							goldFromComponent = (int) (ins.SellPrice * (numComponentDropRate.Value / 100));
						}

						// calculate gold from charms/motes
						if (item.upgrade1 != 0)
						{
							var upgrade = Upgrades.FirstOrDefault(p => p.id == item.upgrade1);
							if (upgrade != null)
							{
								var charm = CharmsAndSymbols.FirstOrDefault(p =>
									p.name.ToLower().Contains(upgrade.Charm.ToLower()));
								charmHolder = charm;
								if (upgrade.name.Contains("Major"))
								{
									goldFromCharm = (int) (charm.sell_price * (numRareCharmDropRate.Value / 100));
									goldFromMotes = (int) (LucentMote.sell_price * (numRareMoteDropRate.Value / 100));
								}
								else if (upgrade.name.Contains("Superior"))
								{
									goldFromCharm = (int) (charm.sell_price * (numExoticCharmDroprate.Value / 100));
									goldFromMotes = (int) (LucentMote.sell_price * (numExoticMoteDropRate.Value / 100));
								}
							}
						}

						break;

					case "Rare":
						//calculate gold from ectos
						goldFromEctos = (int) (GlobOfEctoplasm.sell_price * (numRareEctoDropRate.Value / 100));

						//rares dont have component in them - skip component part

						// calculate gold from charms/motes
						var upgrade1 = Upgrades.FirstOrDefault(p => p.id == item.upgrade1);
						if (upgrade1 != null)
						{
							var charm = CharmsAndSymbols.FirstOrDefault(
								p => p.name.ToLower().Contains(upgrade1.Charm.ToLower()));
							charmHolder = charm;
							if (upgrade1.name.Contains("Major"))
							{
								goldFromCharm = (int) (charm.sell_price * (numRareCharmDropRate.Value / 100));
								goldFromMotes = (int) (LucentMote.sell_price * (numRareMoteDropRate.Value / 100));
							}
							else if (upgrade1.name.Contains("Superior"))
							{
								goldFromCharm = (int) (charm.sell_price * (numExoticCharmDroprate.Value / 100));
								goldFromMotes = (int) (LucentMote.sell_price * (numExoticMoteDropRate.Value / 100));
							}
						}

						break;
				}

				// calculate profitability
				int total = goldFromMotes + goldFromEctos + goldFromCharm + goldFromComponent;
				if (item.buy_price < total)
				{
					GridDataSalvage result = new GridDataSalvage
					{
						Id = item.id,
						Name = item.name,
						OrderProfit = ((int) (total * 0.85 - item.buy_price)).ToGoldFormat(),
						Level = item.level,
						Rarity = item.rarity,
						StatName = item.statName,
						ValueOfItem = (int) (total * 0.85)
					};
					if (charmHolder != null && charmHolder.name != null)
					{
						var parts = charmHolder.name.Split(' ');
						result.CharmName = parts[2];
					}

					if ((int) (total * 0.85 - item.buy_price) >= 0)
					{
						profitableItems.Add(result);
					}
				}

				if (item.sell_price < total)
				{
					// add id to get transactions
					ids.Add(item.id);
				}
			}


		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			GlobOfEctoplasm = new SalvageItemsFull();
			AllItems.Clear();
		}

		#endregion

		#region methods

		private void LoadSettings()
		{
			try
			{
				var directory = Directory.GetCurrentDirectory();
				List<Control> numerics = Utils.GetAllControls(gbRates, typeof(NumericUpDown)).ToList();

				string line;
				StreamReader file = new StreamReader(directory + "\\DataFiles\\System\\SalvageSettings.txt");
				while ((line = file.ReadLine()) != null)
				{
					var parts = line.Split('%');//0 -> name, 1 -> value
					var match = (NumericUpDown)numerics.FirstOrDefault(p => p.Name == parts[0]);
					decimal value;
					decimal.TryParse(parts[1], out value);
					match.Value = value;

				}
				file.Close();
			}
			catch (Exception)
			{
				// ignored
			}
		}


		public List<GridDataSalvage> FilterResults(List<GridDataSalvage> data)
		{
			//apply Filtering
			if (rbExotic.Checked)
			{
				data = data.Where(p => p.Rarity == "Exotic").ToList();
			}
			if (rbRare.Checked)
			{
				data = data.Where(p => p.Rarity == "Rare").ToList();
			}

			if (cbCharm.SelectedText != "Any")
			{
				var parts = cbCharm.Text.Split(' ');
				data = data.Where(p => p.CharmName == parts[2]).ToList();
			}
			return data;
		}

		#endregion



		public class GridDataSalvage
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public string StatName { get; set; }
			public string CharmName { get; set; }
			public string Rarity { get; set; }
			public int Level { get; set; }
			public int InstantProfit { get; set; }// used for ordering
			public string OrderProfit { get; set; }
			public string TotalBuyoutProfit { get; set; }
			public int QuanityToBuyout { get; set; }
			public string BuyoutTill { get; set; }
			public int ValueOfItem { get; set; }
		}

	}
	


}

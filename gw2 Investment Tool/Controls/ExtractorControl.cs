using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gw2_Investment_Tool.Classes;
using gw2_Investment_Tool.Models;
using gw2_Investment_Tool.ServiceAccess;

namespace gw2_Investment_Tool.Controls
{
	public partial class ExtractorControl : UserControl
	{
		public ExtractorControl()
		{
			InitializeComponent();
			SetGridColumns();
		}

		private async void btnSearch_Click(object sender, EventArgs e)
		{
			// database objects 
			List<ExtractableItems> allItems = await SAItems.GetAllExtractableItems();
			List<ExtractableUpgradeComponents> upgrades = await SAItems.GetAllUpgradeComponents();
			
			//local collections
			List<GridData> refinedResults = new List<GridData>();
			List<ExtractableItems> refinedItems = new List<ExtractableItems>();
			
			foreach (ExtractableItems item in allItems)
			{
				var upgrade = upgrades.FirstOrDefault(p => p.id == item.upgrade1);
				if (upgrade?.sell_price >= item.sell_price)
				{
					// mark for listing data download
					item.UpgradeComponent = upgrade;
					refinedItems.Add(item);
				}
			}

			//get listings for profitable items
			List<ItemListings>  allListings = await SAItems.GetAllItemListnings(refinedItems.Select( p => p.id).ToList());

			//construct the data
			foreach (var item in refinedItems)
			{
				GridData data = new GridData
				{
					ItemId = item.id,
					Name = item.name,
					UpgradeId = item.UpgradeComponent.id,
					UpgradeName = item.UpgradeComponent.name,
				};
				var itemListings = allListings.FirstOrDefault(p => p.id == item.id);
				if (itemListings.buys.Count != 0)
				{
					data.OrderProfit = (item.UpgradeComponent.sell_price - itemListings.buys.First().unit_price + 1).ToGoldFormat();
				}
				
				int quantity = 0;
				int profit = 0;
				var goodListings = itemListings.sells.Where(p => p.unit_price <= (item.UpgradeComponent.sell_price *0.85)).ToList();
				foreach (var listing in goodListings)
				{
					quantity = quantity + listing.quantity;
					profit = profit + listing.quantity * (item.UpgradeComponent.sell_price - listing.unit_price);
				}

				data.TotalBuyoutProfit = profit.ToGoldFormat();
				data.InstantProfit = profit;
				data.QuanityToBuyout = quantity;
				refinedResults.Add(data);
			}

			//apply Filtering
			if (rbMinor.Checked)
			{
				refinedResults = refinedResults.Where(p => p.UpgradeName.Contains("Minor")).ToList();
			}
			if (rbMajors.Checked)
			{
				refinedResults = refinedResults.Where(p => p.UpgradeName.Contains("Major")).ToList();
			}
			if (rbSupperiors.Checked)
			{
				refinedResults = refinedResults.Where(p => p.UpgradeName.Contains("Superior")).ToList();
			}


			if (rbRunes.Checked)
			{
				refinedResults = refinedResults.Where(p => p.UpgradeName.Contains("Rune")).ToList();
			}
			if (rbSigils.Checked)
			{
				refinedResults = refinedResults.Where(p => p.UpgradeName.Contains("Sigil")).ToList();
			}
			
			dgvExtractableitems.DataSource = null;
			var temp = refinedResults.OrderByDescending(p => p.InstantProfit).ToList();
			dgvExtractableitems.DataSource = temp;

		}

		private void SetGridColumns()
		{
			dgvExtractableitems.DataSource = null;
			dgvExtractableitems.Columns.Clear();
			dgvExtractableitems.AutoGenerateColumns = false;
			dgvExtractableitems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			dgvExtractableitems.RowHeadersVisible = false;


			DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
			c2.Name = "Name";
			c2.HeaderText = "Item Name";
			c2.DataPropertyName = "Name";
			c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgvExtractableitems.Columns.Add(c2);

			DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
			c3.Name = "UpgradeName";
			c3.HeaderText = "Upgrade Name";
			c3.DataPropertyName = "UpgradeName";
			c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
			c3.Width = 200;
			dgvExtractableitems.Columns.Add(c3);

			DataGridViewTextBoxColumn c5 = new DataGridViewTextBoxColumn();
			c5.Name = "OrderProfit";
			c5.HeaderText = "Order Profit";
			c5.DataPropertyName = "OrderProfit";
			c5.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
			c5.Width = 80;
			dgvExtractableitems.Columns.Add(c5);

			//DataGridViewTextBoxColumn c4 = new DataGridViewTextBoxColumn();
			//c4.Name = "InstantProfit";
			//c4.HeaderText = "Instant Profit";
			//c4.DataPropertyName = "InstantProfit";
			//c4.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
			//c4.Width = 80;
			//dgvExtractableitems.Columns.Add(c4);

			DataGridViewTextBoxColumn c6 = new DataGridViewTextBoxColumn();
			c6.Name = "TotalBuyoutProfit";
			c6.HeaderText = "Total Profit";
			c6.DataPropertyName = "TotalBuyoutProfit";
			c6.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
			c6.Width = 80;
			dgvExtractableitems.Columns.Add(c6);

			DataGridViewTextBoxColumn c7 = new DataGridViewTextBoxColumn();
			c7.Name = "QuanityToBuyout";
			c7.HeaderText = "Quantity To Buyout";
			c7.DataPropertyName = "QuanityToBuyout";
			c7.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
			c7.Width = 50;
			dgvExtractableitems.Columns.Add(c7);

		}

		public class GridData
		{
			public int ItemId { get; set; }
			public int UpgradeId { get; set; }
			public string Name { get; set; }
			public string UpgradeName { get; set; }
			public int InstantProfit { get; set; }
			public string OrderProfit { get; set; }
			public string TotalBuyoutProfit { get; set; }
			public int QuanityToBuyout { get; set; }

		}
	}


}

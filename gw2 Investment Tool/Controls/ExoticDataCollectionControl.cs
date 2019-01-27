using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using gw2_Investment_Tool.Models;
using gw2_Investment_Tool.ServiceAccess;
using Newtonsoft.Json;

namespace gw2_Investment_Tool.Controls
{
	public partial class ExoticDataCollectionControl : UserControl
	{
		List<GridDataModel> _currentItems = new List<GridDataModel>();

		public ExoticDataCollectionControl()
		{
			InitializeComponent();
			InitializeControls();
			SetGridColumns();
		}

		private void InitializeControls()
		{
			cbGearType.DataSource = new List<string>
			{
				"Piece of Common Unidentified Gear",
				"Piece of Unidentified Gear",
				"Piece of Rare Unidentified Gear"
			};
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			if (dialog.ShowDialog() != DialogResult.OK)
				return;

			tbLocation.Text = dialog.SafeFileName;
			var json = JsonConvert.DeserializeObject<List<JsonObjectFromFile>>(File.ReadAllText(dialog.FileName));

			foreach (var jsonItem in json)
			{
				var itemCheck = _currentItems.FirstOrDefault(p => p.ItemId == jsonItem.ID);
				if (itemCheck != null)
				{
					itemCheck.Quantity += jsonItem.Quantity;
				}
				else if (jsonItem.ID != 0 && jsonItem.Quantity != 0)
				{
					GridDataModel item = new GridDataModel();
					item.ItemId = jsonItem.ID;
					item.Quantity = jsonItem.Quantity;
					item.ItemName = jsonItem.Name;
					_currentItems.Add(item);

				}
			}

			dgvResults.DataSource = null;
			dgvResults.DataSource = _currentItems;

		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (cbGearType.SelectedItem.ToString() == string.Empty)
			{
				MessageBox.Show("Gear type not selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (_currentItems.Count != 0 && numQuantity.Value == 0)
			{
				MessageBox.Show("Quantity is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			//initialize collection
			SaveDataObject savedData = new SaveDataObject();
			savedData.Items = new List<GridDataModel>();

			// find the right file
			string gearType = cbGearType.SelectedItem.ToString();
			var directory = Directory.GetCurrentDirectory();
			if (File.Exists(directory + $"\\DataFiles\\DataCollection\\{gearType}.txt"))
			{
				StreamReader file = new StreamReader(directory + $"\\DataFiles\\DataCollection\\{gearType}.txt");

				// sort the old data
				string line;
				while ((line = file.ReadLine()) != null)
				{
					string[] values = line.Split(Convert.ToChar("%"));
					if (values[0] == "TOTALQUANTITY")
					{
						int totalQty;
						int.TryParse(values[1], out totalQty);
						savedData.TotalCount = totalQty;
					}
					else
					{
						int itemId;
						int qty;
						int.TryParse(values[0], out itemId);
						int.TryParse(values[1], out qty);

						var itemCheck = savedData.Items.FirstOrDefault(p => p.ItemId == itemId);
						if (itemCheck != null)
						{
							itemCheck.Quantity += qty;
						}
						else
						{
							GridDataModel item = new GridDataModel();
							item.ItemId = itemId;
							item.Quantity = qty;
							if (itemId != 0 && qty != 0)
							{
								savedData.Items.Add(item);
							}
						}
					}
				}

				file.Close();

				// get the new data and combine both
				savedData.TotalCount += (int) numQuantity.Value;
				foreach (var currentItem in _currentItems)
				{
					//find the item
					var match = savedData.Items.FirstOrDefault(p => p.ItemId == currentItem.ItemId);
					if (match == null)
					{
						savedData.Items.Add(currentItem);
					}
					else
					{
						match.Quantity += currentItem.Quantity;
					}
				}

				//Save the data
				List<string> lines = new List<string>();
				lines.Add($"TOTALQUANTITY%{savedData.TotalCount}");
				foreach (var item in savedData.Items)
				{
					StringBuilder sb = new StringBuilder();
					sb.Append(item.ItemId.ToString());
					sb.Append("%");
					sb.Append(item.Quantity);
					lines.Add(sb.ToString());
				}

				if (lines.Count != 0)
				{
					File.WriteAllLines(directory + $"\\DataFiles\\DataCollection\\{gearType}.txt", lines);
					//clear old data
					dgvResults.DataSource = null;
					_currentItems.Clear();

				}

			}

		}

		private async void btnLoadOldData_Click(object sender, EventArgs e)
		{
			string gearType = cbGearType.SelectedItem.ToString();
			var directory = Directory.GetCurrentDirectory();

			if (!File.Exists(directory + $"\\DataFiles\\DataCollection\\{gearType}.txt"))
				return;

			List<GridDataModel> allItems = new List<GridDataModel>();

			StreamReader file = new StreamReader(directory + $"\\DataFiles\\DataCollection\\{gearType}.txt");
			string line;
			int totalQty = 0;
			while ((line = file.ReadLine()) != null)
			{
				string[] values = line.Split(Convert.ToChar("%"));
				if (values[0] == "TOTALQUANTITY")
				{
					int.TryParse(values[1], out totalQty);
				}
				else
				{
					int itemId;
					int qty;
					int.TryParse(values[0], out itemId);
					int.TryParse(values[1], out qty);
					GridDataModel item = new GridDataModel();
					item.ItemId = itemId;
					item.Quantity = qty;
					allItems.Add(item);

				}
			}

			file.Close();

			List<ItemFull> itemsData = await SAItems.GetAlItemsAsync(allItems.Select(p => p.ItemId).ToList());
			foreach (var currentItem in allItems)
			{
				var match = itemsData.FirstOrDefault(p => p.id == currentItem.ItemId);
				if (match == null)
					continue;

				currentItem.ItemName = match.name;
			}

			dgvResults.DataSource = null;
			dgvResults.DataSource = allItems;

		}

		private void btnExportToJson_Click(object sender, EventArgs e)
		{
			var directory = Directory.GetCurrentDirectory();
			List<GridDataModel> data = dgvResults.DataSource as List<GridDataModel>;
			if (data == null || data.Count == 0)
				return;

			string json = JsonConvert.SerializeObject(data.Select(x => new {x.ItemId, x.Quantity}).OrderBy(x => x.ItemId).ToList());
			if (!string.IsNullOrWhiteSpace(json))
			{
				File.WriteAllText(directory + "\\Exports\\JsonExport.json", json);
				//clear old data
				dgvResults.DataSource = null;
			}

		}

		private void btnExportToCsv_Click(object sender, EventArgs e)
		{
			var directory = Directory.GetCurrentDirectory();
			List<GridDataModel> data = dgvResults.DataSource as List<GridDataModel>;
			if (data == null || data.Count == 0)
				return;

			List<string> lines = new List<string>();
			lines.Add("Id , Quantity");
		    data = data.OrderBy(p => p.ItemId).ToList();
			foreach (var row in data)
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(row.ItemId.ToString());
				sb.Append(" , ");
				sb.Append(row.Quantity);
				lines.Add(sb.ToString());
			}

			if (lines.Count != 0)
			{
				File.WriteAllLines(directory + "\\Exports\\CsvExport.csv", lines);
				//clear old data
				dgvResults.DataSource = null;
			}
		}

		private void SetGridColumns()
		{
			dgvResults.DataSource = null;
			dgvResults.Columns.Clear();
			dgvResults.AutoGenerateColumns = false;
			dgvResults.RowHeadersVisible = false;
			dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

			DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
			c2.Name = "name";
			c2.HeaderText = "Item Name";
			c2.DataPropertyName = "ItemName";
			c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgvResults.Columns.Add(c2);

			DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
			c3.Name = "quantity";
			c3.HeaderText = "Quantity";
			c3.DataPropertyName = "Quantity";
			c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			c3.Width = 100;
			dgvResults.Columns.Add(c3);

			DataGridViewTextBoxColumn c7 = new DataGridViewTextBoxColumn();
			c7.Name = "itemId";
			c7.HeaderText = "Item ID";
			c7.DataPropertyName = "ItemId";
			c7.Visible = false;
			dgvResults.Columns.Add(c7);

		}


		private class SaveDataObject
		{
			public List<GridDataModel> Items { get; set; }
			public int TotalCount { get; set; }
		}

		private class GridDataModel
		{
			public int ItemId { get; set; }
			public string ItemName { get; set; }
			public int Quantity { get; set; }
		}

		private class JsonObjectFromFile
		{
			public int ID { get; set; }
			public string Name { get; set; }
			public int Quantity { get; set; }
		}

	}
}

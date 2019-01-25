using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using gw2_Investment_Tool.Classes;
using gw2_Investment_Tool.Models;
using gw2_Investment_Tool.ServiceAccess;
using Newtonsoft.Json;

namespace gw2_Investment_Tool.Controls
{
	public partial class NewItemsControl : UserControl
	{
		public List<Recipe> NewRecipesFull = new List<Recipe>();


		public NewItemsControl()
		{
			InitializeComponent();
			SetGuildIngridientsGridColumns();
			SetIngridientsGridColumns();
			SetItemNameGridColumns();
		}
		
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
				NewRecipesFull = await SAItems.GetRecipeFullAsync(newItemsIDsIndexes);
				NewRecipesFull = await Shared.CombineFullRecipeData(NewRecipesFull);
				dgvNewItems.DataSource = null;
				dgvNewItems.DataSource = NewRecipesFull;
			}
		}
		
		private void btnExport_Click(object sender, EventArgs e)
		{
			var data = dgvNewItems.DataSource as List<Recipe>;
			var json = JsonConvert.SerializeObject(data);
			File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\OldData.txt", json);
		}

		private void btnFilter_Click(object sender, EventArgs e)
		{
			if (NewRecipesFull.Count == 0)
			{
				return;
			}

			if (!string.IsNullOrWhiteSpace(tbFilter.Text))
			{
				NewRecipesFull.PrepareForFilter();
				RadioButton checkedButton = groupBox1.Controls
					.OfType<RadioButton>().FirstOrDefault(x => x.Checked);

				if (checkedButton != null)
				{
					dgvNewItems.DataSource = null;
					switch (checkedButton.Name)
					{
						case "radioName":
							dgvNewItems.DataSource = NewRecipesFull.Where(p => p.OutputItemName.ToLower().Contains(tbFilter.Text.ToLower())).ToList();
							break;
						case "radioType":
							dgvNewItems.DataSource = NewRecipesFull.Where(p => p.type.ToLower().Contains(tbFilter.Text.ToLower())).ToList();
							break;
						case "radioDisciplines":
							dgvNewItems.DataSource = NewRecipesFull.Where(p => p.DisciplinesString.ToLower().Contains(tbFilter.Text.ToLower())).ToList();
							break;
						case "radioFlags":
							dgvNewItems.DataSource = NewRecipesFull.Where(p => p.FlagsString.ToLower().Contains(tbFilter.Text.ToLower())).ToList();
							break;
					}
				}
			}
			else
			{
				dgvNewItems.DataSource = null;
				dgvNewItems.DataSource = NewRecipesFull;
			}
		}

		private void dgvNewItems_SelectionChanged(object sender, EventArgs e)
		{
			if (dgvNewItems.SelectedCells.Count > 0 && dgvNewItems.SelectedCells[0].Value != null)
			{
				Recipe selectedItem =
					NewRecipesFull.FirstOrDefault(
						p => p.OutputItemName == dgvNewItems.SelectedCells[0].Value.ToString());
				dgvIngredients.DataSource = null;
				dgvGuildIngridients.DataSource = null;
				if (selectedItem != null)
				{
					dgvIngredients.DataSource = selectedItem.ingredients;
					dgvGuildIngridients.DataSource = selectedItem.guild_ingredients;
					labelType.Text = selectedItem.type;
					labelMinRating.Text = selectedItem.min_rating.ToString();
					labelDisciplines.Text = string.Join(" ", selectedItem.disciplines);
					labelFlags.Text = string.Join(" ", selectedItem.flags);
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


		#region Grid Colomns

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

		#endregion



	}
}

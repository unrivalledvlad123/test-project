using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gw2_Investment_Tool.Classes;
using gw2_Investment_Tool.Models;
using gw2_Investment_Tool.ServiceAccess;
using Newtonsoft.Json;

namespace gw2_Investment_Tool.Controls
{
	public partial class RecipeCompareControl : UserControl
	{
		public List<Recipe> OldRecipeDataToCompare = new List<Recipe>();
		public List<Recipe> NewRecipeDataToCompare = new List<Recipe>();
		public RecipeCompareControl()
		{
			InitializeComponent();
			SetAllCompareGridsColumns();
		}

	    private async void btnLoadOldData_Click(object sender, EventArgs e)
	    {
	        OpenFileDialog dialog = new OpenFileDialog();
	        if (dialog.ShowDialog() == DialogResult.OK)
	        {
	            string json = File.ReadAllText(dialog.FileName);
	            OldRecipeDataToCompare = JsonConvert.DeserializeObject<List<Recipe>>(json);

	            List<int> ids = OldRecipeDataToCompare.Select(p => p.id).ToList();
	            NewRecipeDataToCompare = await Shared.CombineFullRecipeData(await SAItems.GetRecipeFullAsync(ids));


	            List<Recipe> differences = new List<Recipe>();
	            foreach (var newRecipe in NewRecipeDataToCompare)
	            {
	                var oldRecipe = OldRecipeDataToCompare.FirstOrDefault(p => p.id == newRecipe.id);
	                foreach (var ingredient in newRecipe.ingredients)
	                {
	                    var check = oldRecipe.ingredients.FirstOrDefault(p => p.item_id == ingredient.item_id);
	                    if (check == null)
	                    {
	                        //has change
	                        differences.Add(newRecipe);
	                        break;
	                    }
	                }

	                if (newRecipe.guild_ingredients != null)
	                {
	                    foreach (var ingredient in newRecipe.guild_ingredients)
	                    {
	                        var check =
	                            oldRecipe.guild_ingredients.FirstOrDefault(p => p.upgrade_id == ingredient.upgrade_id);
	                        if (check == null)
	                        {
	                            //has change
	                            differences.Add(newRecipe);
	                            break;
	                        }
	                    }
	                }

	            }
	            // display the data
	            dgvRecipeCompareAll.DataSource = differences;

	        }
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

		private void dgvRecipeCompareAll_SelectionChanged(object sender, EventArgs e)
		{
			if (dgvRecipeCompareAll.DataSource == null)
			{
				return;
			}

			if (dgvRecipeCompareAll.SelectedRows.Count != 0)
			{

				Recipe selectedItem = (Recipe)dgvRecipeCompareAll.SelectedRows[0].DataBoundItem;
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

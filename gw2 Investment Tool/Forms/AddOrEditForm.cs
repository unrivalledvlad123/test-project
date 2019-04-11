using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using gw2_Investment_Tool.Models;

namespace gw2_Investment_Tool.Forms
{
    public partial class AddOrEditForm : Form
    {
        public Item Item;

        public AddOrEditForm(Item selectedItem)
        {
            InitializeComponent();
            SetGridColumns();
            Item = new Item();
			List<string> disciplines = new List<string>
			{
				"Weaponsmith",
				"Huntsman",
				"Artificer",
				"Armorsmith",
				"Leatherworker",
				"Tailor",
				"Jeweler",
				"Chef",
				"Scribe"
			};
	        cbDiscipline.DataSource = disciplines;

            if (selectedItem != null)
            {
                tbItemId.Text = selectedItem.ItemId.ToString();
                tbKarmaPerItem.Text = selectedItem.KarmaPerItem.ToString();
                tbQuantity.Text = selectedItem.Quantity.ToString();
                cbActive.Checked = selectedItem.Active;
            }
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            int itemId;
            int quantity;
            decimal karmaPerItem = decimal.Parse(tbKarmaPerItem.Text, CultureInfo.InvariantCulture.NumberFormat);

            int.TryParse(tbItemId.Text, out itemId);
            int.TryParse(tbQuantity.Text, out quantity);

            Item.KarmaPerItem = karmaPerItem;
            Item.Active = cbActive.Checked;
            Item.Discipline = cbDiscipline.SelectedItem.ToString();
            Item.ItemId = itemId;
            Item.Quantity = quantity;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text.Length>=4)
            {
                dgvSearchResults.DataSource = null;
	            dgvSearchResults.DataSource = MainForm.ItemNames.Where(p => p.name.ToLower().Contains(tbSearch.Text.ToLower())).ToList();
            }
        }

	    private void dgvSearchResult_CellSelected(object sender, EventArgs e)
	    {
		    if (dgvSearchResults.SelectedCells.Count > 0)
		    {
			    int index = dgvSearchResults.SelectedCells[0].RowIndex;
			    var row = dgvSearchResults.Rows[index];
				if (dgvSearchResults.SelectedCells[0].Value != null)
				{
					ItemFull item = (ItemFull)row.DataBoundItem;
					tbItemId.Text = item.id.ToString();
				}
			}
		}

	    private void SetGridColumns()
        {
            dgvSearchResults.DataSource = null;
            dgvSearchResults.Columns.Clear();
            dgvSearchResults.AutoGenerateColumns = false;
            dgvSearchResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvSearchResults.RowHeadersVisible = false;

			DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
			c1.Name = "id";
			c1.HeaderText = "id";
			c1.DataPropertyName = "id";
			c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			c1.ReadOnly = true;
			c1.Visible = false;
			dgvSearchResults.Columns.Add(c1);

			DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.Name = "name";
            c2.HeaderText = "Item Name";
            c2.DataPropertyName = "name";
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.ReadOnly = true;
            dgvSearchResults.Columns.Add(c2);

	        DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
	        c3.Name = "rarity";
	        c3.HeaderText = "Rarity";
	        c3.DataPropertyName = "Rarity";
	        c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
	        c3.ReadOnly = true;
	        dgvSearchResults.Columns.Add(c3);

	        DataGridViewTextBoxColumn c4 = new DataGridViewTextBoxColumn();
	        c4.Name = "level";
	        c4.HeaderText = "Level";
	        c4.DataPropertyName = "Level";
	        c4.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
	        c4.ReadOnly = true;
	        dgvSearchResults.Columns.Add(c4);
		}

	}
}

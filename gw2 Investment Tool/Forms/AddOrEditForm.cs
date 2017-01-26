using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using gw2_Investment_Tool.Classes;

namespace gw2_Investment_Tool.Forms
{
    public partial class AddOrEditForm : Form
    {
        public Item Item;

        public AddOrEditForm(Item SelectedItem)
        {
            InitializeComponent();
            SetGridColumns();
            Item = new Item();

            if (SelectedItem != null)
            {
                tbDiscipline.Text = SelectedItem.Discipline;
                tbItemId.Text = SelectedItem.ItemId.ToString();
                tbKarmaPerItem.Text = SelectedItem.KarmaPerItem.ToString();
                tbQuantity.Text = SelectedItem.Quantity.ToString();
                cbActive.Checked = SelectedItem.Active;
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
            Item.Discipline = tbDiscipline.Text;
            Item.ItemId = itemId;
            Item.Quantity = quantity;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text.Length>=4)
            {
                dgvSearchResults.DataSource = null;
                dgvSearchResults.DataSource = MainForm.ItemNames.Where(p => p.name.ToLower().Contains(tbSearch.Text)).ToList();
            }
        }

        private void dgvSearchResult_CellSelected(object sender, EventArgs e)
        {
            if (dgvSearchResults.SelectedCells[0].Value.ToString() != "")
            {
                ItemApi item = MainForm.ItemNames.FirstOrDefault(p => p.name == dgvSearchResults.SelectedCells[0].Value.ToString());
                tbItemId.Text = item.id.ToString();
            }
        }

        private void SetGridColumns()
        {
            dgvSearchResults.DataSource = null;
            dgvSearchResults.Columns.Clear();
            dgvSearchResults.AutoGenerateColumns = false;
            dgvSearchResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvSearchResults.RowHeadersVisible = false;

            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.Name = "name";
            c2.HeaderText = "Item Name";
            c2.DataPropertyName = "name";
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.ReadOnly = true;
            dgvSearchResults.Columns.Add(c2);
        }
    }
}

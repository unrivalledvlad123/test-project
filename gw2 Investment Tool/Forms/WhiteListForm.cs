using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gw2_Investment_Tool.Classes;
using gw2_Investment_Tool.ServiceAccess;

namespace gw2_Investment_Tool.Forms
{
    public partial class WhiteListForm : Form
    {
        public List<WhiteListedItem> ItemsToSave = new List<WhiteListedItem>();
        public List<WhiteListedItem> AllItems = new List<WhiteListedItem>();

        public WhiteListForm(List<WhiteListedItem> allItems)
        {
            InitializeComponent();
            SetGridColumns();
            SetSearchGridColumns();
            this.AllItems = allItems;
            dgvWhiteListedItems.DataSource = allItems;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvWhiteListedItems.Rows)
            {
                WhiteListedItem newitem = new WhiteListedItem();
                newitem.ItemId = (int) row.Cells["itemId"].Value;
                newitem.Price = (int) row.Cells["price"].Value;
                newitem.Active = (bool) row.Cells["Active"].Value;
                newitem.Name = (string) row.Cells["Name"].Value;
                ItemsToSave.Add(newitem);
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                WhiteListedItem newItem = new WhiteListedItem();
                int id;
                decimal price = Decimal.Parse(tbPrice.Text, NumberStyles.Currency, CultureInfo.InvariantCulture);
                int.TryParse(tbItemId.Text, out id);

                newItem.Price = (int)price;
                newItem.ItemId = id;
                newItem.Name = tbName.Text;
                newItem.Active = true;

                if (AllItems.FirstOrDefault(p => p.ItemId == newItem.ItemId) == null)
                {
                    AllItems.Add(newItem);
                    dgvWhiteListedItems.DataSource = null;
                    dgvWhiteListedItems.DataSource = AllItems;
                }
                else
                {
                    MessageBox.Show(@"Item is already added!", @"Add error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Invalid ItemID or Missing Data", @"Add error",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvWhiteListedItems.SelectedRows.Count <= 0)
                return;

            WhiteListedItem selectedItem = (WhiteListedItem) dgvWhiteListedItems.SelectedRows[0].DataBoundItem;
            if (AllItems.FirstOrDefault(p => p.ItemId == selectedItem.ItemId) != null)
            {
                AllItems.Remove(selectedItem);
                MainForm.WhiteListedItems.Remove(selectedItem);
                dgvWhiteListedItems.DataSource = null;
                dgvWhiteListedItems.DataSource = AllItems;
            }
        }

        private void SetGridColumns()
        {
            dgvWhiteListedItems.DataSource = null;
            dgvWhiteListedItems.Columns.Clear();
            dgvWhiteListedItems.AutoGenerateColumns = false;
            DataGridViewCheckBoxColumn c1 = new DataGridViewCheckBoxColumn();
            c1.Name = "active";
            c1.HeaderText = "Active";
            c1.DataPropertyName = "Active";
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            c1.Width = 30;
            dgvWhiteListedItems.Columns.Add(c1);

            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.Name = "itemId";
            c2.HeaderText = "ItemId";
            c2.DataPropertyName = "ItemId";
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvWhiteListedItems.Columns.Add(c2);

            DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
            c3.Name = "name";
            c3.HeaderText = "Name";
            c3.DataPropertyName = "Name";
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvWhiteListedItems.Columns.Add(c3);

            DataGridViewTextBoxColumn c4 = new DataGridViewTextBoxColumn();
            c4.Name = "price";
            c4.HeaderText = "Price";
            c4.DataPropertyName = "Price";
            c4.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvWhiteListedItems.Columns.Add(c4);
        }
        private void SetSearchGridColumns()
        {
            dgvResults.DataSource = null;
            dgvResults.Columns.Clear();
            dgvResults.AutoGenerateColumns = false;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvResults.RowHeadersVisible = false;

            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.Name = "name";
            c2.HeaderText = "Item Name";
            c2.DataPropertyName = "name";
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.ReadOnly = true;
            dgvResults.Columns.Add(c2);
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text.Length >= 4)
            {
                dgvResults.DataSource = null;
                dgvResults.DataSource = MainForm.ItemNames.Where(p => p.name.ToLower().Contains(tbSearch.Text.ToLower())).ToList();
            }
        }
        private void dgvSearchResult_CellSelected(object sender, EventArgs e)
        {
	        ItemFull item = MainForm.ItemNames.FirstOrDefault(p => p.name == dgvResults.SelectedCells[0].Value.ToString());
            tbItemId.Text = item.id.ToString();
            tbName.Text = dgvResults.SelectedCells[0].Value.ToString();
        }
    }
}
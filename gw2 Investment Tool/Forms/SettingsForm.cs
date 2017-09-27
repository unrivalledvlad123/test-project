using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Windows.Forms;
using gw2_Investment_Tool.Classes;
using gw2_Investment_Tool.ServiceAccess;

namespace gw2_Investment_Tool.Forms
{
    public partial class SettingsForm : Form
    {

        public SettingsForm()
        {
            InitializeComponent();
            tbCurrentItems.Text = Properties.Settings.Default.LoadCurrentItems;
            tbSearchLocation.Text = Properties.Settings.Default.LoadNames;
            tbWhiteListedItems.Text = Properties.Settings.Default.LoadWhiteList;
        }

        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            List<int> itemIds = await SAItems.GetAllrecipeIdsAsync();
            List<OutputItemId> outputItemIds = await SAItems.GetRecipeOutputIdAsync(itemIds);
            List<ItemApi> namedItems = await SAItems.GetItemNamesAsync(outputItemIds);

            List<string> lines = new List<string>();
            foreach (var item in namedItems)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(item.id.ToString());
                sb.Append("%");
                sb.Append(item.name);
                lines.Add(sb.ToString());
            }
            if (lines.Count != 0)
            {
                File.WriteAllLines(Properties.Settings.Default.LoadNames, lines);
            }
            MainForm.ItemNames = namedItems;
            MessageBox.Show(@"Text file successfuly created!", @"Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.LoadCurrentItems = tbCurrentItems.Text;
            Properties.Settings.Default.LoadNames = tbSearchLocation.Text;
            Properties.Settings.Default.LoadWhiteList = tbWhiteListedItems.Text;
            Properties.Settings.Default.Save();
        }
    }
}

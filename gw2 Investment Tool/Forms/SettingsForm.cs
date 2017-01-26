using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            tbCurrentItems.Text = ConfigurationManager.AppSettings["LoadCurrentItems"];
            tbSearchLocation.Text = ConfigurationManager.AppSettings["LoadNames"];
            tbWhiteListedItems.Text = ConfigurationManager.AppSettings["LoadWhiteList"];
        }

        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            List<int> itemIds = await SAItems.GetAllrecipeIdsAsync();
            List<OutputItemId> outputItemIds = await SAItems.GetRecipeOutputIdAsync(itemIds);
            List<ItemApi> NamedItems = await SAItems.GetItemNamesAsync(outputItemIds);

            List<string> lines = new List<string>();
            foreach (var item in NamedItems)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(item.id.ToString());
                sb.Append("%");
                sb.Append(item.name);
                lines.Add(sb.ToString());
            }
            if (lines.Count != 0)
            {
                File.WriteAllLines(ConfigurationManager.AppSettings["LoadNames"], lines);
            }
            MainForm.ItemNames = NamedItems;
            MessageBox.Show(@"Text file successfuly created!", @"Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection app = config.AppSettings;
            app.Settings.Add("LoadCurrentItems", tbCurrentItems.Text);
            app.Settings.Add("LoadWhiteList", tbWhiteListedItems.Text);
            app.Settings.Add("LoadNames", tbSearchLocation.Text);
            config.Save(ConfigurationSaveMode.Modified);

        }
    }
}

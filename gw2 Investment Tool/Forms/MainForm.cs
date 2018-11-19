using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using gw2_Investment_Tool.Classes;
using gw2_Investment_Tool.Models;
using gw2_Investment_Tool.ServiceAccess;
using Newtonsoft.Json;


namespace gw2_Investment_Tool.Forms
{
    public partial class MainForm : Form
    {
        public static List<ItemFull> ItemNames = new List<ItemFull>();
        public static List<WhiteListedItem> WhiteListedItems = new List<WhiteListedItem>();
       

        public MainForm()
        {
            InitializeComponent();
	        LoadDataInitially();
			LoadControlData();
	
        }

		#region // < =========== Metods used in controls that CANNOT be moved to the control =========> //

		// Due to some designer error, form editor cannot be initialized when these methods are defined in the control itself,
		// as the editor is trying to connect to the path in debug time, when the directory doesnt exist in the context.
	
		public void LoadControlData()
		{
			List<Control> temp = Utils.GetAllControls(this,typeof(ComboBox)).ToList();
			ComboBox cb = (ComboBox) temp.FirstOrDefault(p => p.Name == "cbLists");
			cb.DataSource = GetAllList();

		}

		public static List<string> GetAllList()
		{
			string directory = string.Empty;
			var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
			if (directoryInfo != null)
			{
				directory = directoryInfo.FullName;
			}

			List<string> alLists = new List<string>();
			var t = directory + "\\DataFiles\\Lists";
			string[] files = Directory.GetFiles(t);
			foreach (string list in files)
			{
				var temp = list.Replace(directory + "\\DataFiles\\Lists", "");
				string temp2 = temp.Replace(@"\", "");
				string temp3 = temp2.Replace(".txt", "");
				alLists.Add(temp3);
			}

			return alLists;

		}

		#endregion


		#region // < ================ Methods ================>
		public void LoadDataInitially()
	    {
		    try
		    {
			    string directory = string.Empty;
			    var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
			    if (directoryInfo != null)
			    {
				    directory = directoryInfo.FullName;
			    }

			    if (File.Exists(directory + "\\DataFiles\\System\\WhiteListedItems.txt"))
			    {
				    StreamReader file2 = new StreamReader(directory + "\\DataFiles\\System\\WhiteListedItems.txt");
				    string line2;
				    while ((line2 = file2.ReadLine()) != null)
				    {
					    WhiteListedItem item = new WhiteListedItem();
					    string[] values = line2.Split(Convert.ToChar("%"));
					    int itemId;
					    int price;
					    bool active;
					    int.TryParse(values[1], out itemId);
					    int.TryParse(values[2], out price);
					    bool.TryParse(values[3], out active);

					    item.ItemId = itemId;
					    item.Price = price;
					    item.Name = values[0];
					    item.Active = active;

					    if (WhiteListedItems.FirstOrDefault(p => p.ItemId == item.ItemId) == null)
					    {
						    WhiteListedItems.Add(item);
					    }
				    }

				    file2.Close();
			    }


			    if (File.Exists(directory + "\\DataFiles\\System\\LoadNames.txt"))
			    {
				    StreamReader file3 = new StreamReader(directory + "\\DataFiles\\System\\LoadNames.txt");
				    string line3;
				    while ((line3 = file3.ReadLine()) != null)
				    {
					    ItemFull item = new ItemFull();
					    string[] values = line3.Split(Convert.ToChar("%"));
					    int itemId;
					    int.TryParse(values[0], out itemId);
					    item.id = itemId;
					    item.name = values[1];
					    item.rarity = values[2];
					    int level;
					    int.TryParse(values[3], out level);
					    item.level = level;
					    ItemNames.Add(item);

				    }

				    file3.Close();
			    }

		    }
		    catch (Exception e)
		    {
			    MessageBox.Show("Corrupted Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		    }
	    }
		#endregion
		
	}
}


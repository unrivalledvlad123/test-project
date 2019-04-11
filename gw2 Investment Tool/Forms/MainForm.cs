using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using gw2_Investment_Tool.Classes;
using gw2_Investment_Tool.Models;

namespace gw2_Investment_Tool.Forms
{
    public partial class MainForm : Form
    {
        public static List<ItemFull> ItemNames = new List<ItemFull>();
      
        public MainForm()
        {
            InitializeComponent();
	        LoadDataInitially();
			LoadControlData();
	
        }

		#region // < =========== Metods used in controls that CANNOT be moved to the control =========> //

		// Due to some designer error, form editor cannot be initialized when these methods are defined in the control itself,
		// as the editor is trying to connect to the path in debug time, when the directory doesn't exist in the context.
	
		public void LoadControlData()
		{
			List<Control> temp = Utils.GetAllControls(this,typeof(ComboBox)).ToList();
			ComboBox cb = (ComboBox) temp.FirstOrDefault(p => p.Name == "cbLists");
			cb.DataSource = GetAllList();

		}

		public static List<string> GetAllList()
		{
			string directory = string.Empty;
		    
		    var directoryInfo = Directory.GetCurrentDirectory();
            if (directoryInfo != null)
			{
				directory = directoryInfo;
			}

			List<string> alLists = new List<string>();
			string[] files = Directory.GetFiles(directory + "\\DataFiles\\Lists");
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
                var directory = Directory.GetCurrentDirectory();
				
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


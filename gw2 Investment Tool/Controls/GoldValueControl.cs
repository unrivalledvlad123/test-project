﻿using System.Windows.Forms;

namespace gw2_Investment_Tool.Controls
{
	public partial class GoldValueControl : UserControl
	{
		public GoldValueControl()
		{
			InitializeComponent();

		}

		public void BindValues(int gold, int silver, int copper)
		{
			labelCopper.Text = copper.ToString();
			labelGold.Text = gold.ToString();
			labelSilver.Text = silver.ToString();
		}


	}
}

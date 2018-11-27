namespace gw2_Investment_Tool.Controls
{
	partial class ExoticAndRareSalvageControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.gbRates = new System.Windows.Forms.GroupBox();
			this.btnSaveSettings = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.numExoticCharmDroprate = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.numRareCharmDropRate = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.numExoticMoteDropRate = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.numRareMoteDropRate = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.numComponentDropRate = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.numExoticEctoDropRate = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.numRareEctoDropRate = new System.Windows.Forms.NumericUpDown();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.rbRare = new System.Windows.Forms.RadioButton();
			this.rbExotic = new System.Windows.Forms.RadioButton();
			this.btnSearch = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.cbCharm = new System.Windows.Forms.ComboBox();
			this.dgvItems = new System.Windows.Forms.DataGridView();
			this.label8 = new System.Windows.Forms.Label();
			this.numMinProfit = new System.Windows.Forms.NumericUpDown();
			this.gbRates.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numExoticCharmDroprate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numRareCharmDropRate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numExoticMoteDropRate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numRareMoteDropRate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numComponentDropRate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numExoticEctoDropRate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numRareEctoDropRate)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMinProfit)).BeginInit();
			this.SuspendLayout();
			// 
			// gbRates
			// 
			this.gbRates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbRates.Controls.Add(this.label8);
			this.gbRates.Controls.Add(this.numMinProfit);
			this.gbRates.Controls.Add(this.btnSaveSettings);
			this.gbRates.Controls.Add(this.label7);
			this.gbRates.Controls.Add(this.numExoticCharmDroprate);
			this.gbRates.Controls.Add(this.label6);
			this.gbRates.Controls.Add(this.numRareCharmDropRate);
			this.gbRates.Controls.Add(this.label5);
			this.gbRates.Controls.Add(this.numExoticMoteDropRate);
			this.gbRates.Controls.Add(this.label4);
			this.gbRates.Controls.Add(this.numRareMoteDropRate);
			this.gbRates.Controls.Add(this.label3);
			this.gbRates.Controls.Add(this.numComponentDropRate);
			this.gbRates.Controls.Add(this.label2);
			this.gbRates.Controls.Add(this.numExoticEctoDropRate);
			this.gbRates.Controls.Add(this.label1);
			this.gbRates.Controls.Add(this.numRareEctoDropRate);
			this.gbRates.Location = new System.Drawing.Point(3, 3);
			this.gbRates.Name = "gbRates";
			this.gbRates.Size = new System.Drawing.Size(687, 118);
			this.gbRates.TabIndex = 0;
			this.gbRates.TabStop = false;
			this.gbRates.Text = "Drop rates";
			// 
			// btnSaveSettings
			// 
			this.btnSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveSettings.Location = new System.Drawing.Point(596, 89);
			this.btnSaveSettings.Name = "btnSaveSettings";
			this.btnSaveSettings.Size = new System.Drawing.Size(85, 23);
			this.btnSaveSettings.TabIndex = 14;
			this.btnSaveSettings.Text = "Save settings";
			this.btnSaveSettings.UseVisualStyleBackColor = true;
			this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(389, 70);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(115, 13);
			this.label7.TabIndex = 13;
			this.label7.Text = "Exotic charm Drop rate";
			// 
			// numExoticCharmDroprate
			// 
			this.numExoticCharmDroprate.DecimalPlaces = 2;
			this.numExoticCharmDroprate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numExoticCharmDroprate.Location = new System.Drawing.Point(388, 92);
			this.numExoticCharmDroprate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numExoticCharmDroprate.Name = "numExoticCharmDroprate";
			this.numExoticCharmDroprate.Size = new System.Drawing.Size(120, 20);
			this.numExoticCharmDroprate.TabIndex = 12;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(263, 70);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(109, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "Rare charm Drop rate";
			// 
			// numRareCharmDropRate
			// 
			this.numRareCharmDropRate.DecimalPlaces = 2;
			this.numRareCharmDropRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numRareCharmDropRate.Location = new System.Drawing.Point(262, 92);
			this.numRareCharmDropRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numRareCharmDropRate.Name = "numRareCharmDropRate";
			this.numRareCharmDropRate.Size = new System.Drawing.Size(120, 20);
			this.numRareCharmDropRate.TabIndex = 10;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(133, 70);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(109, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "Exotic mote Drop rate";
			// 
			// numExoticMoteDropRate
			// 
			this.numExoticMoteDropRate.DecimalPlaces = 2;
			this.numExoticMoteDropRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numExoticMoteDropRate.Location = new System.Drawing.Point(132, 92);
			this.numExoticMoteDropRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numExoticMoteDropRate.Name = "numExoticMoteDropRate";
			this.numExoticMoteDropRate.Size = new System.Drawing.Size(120, 20);
			this.numExoticMoteDropRate.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 70);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(103, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Rare mote Drop rate";
			// 
			// numRareMoteDropRate
			// 
			this.numRareMoteDropRate.DecimalPlaces = 2;
			this.numRareMoteDropRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numRareMoteDropRate.Location = new System.Drawing.Point(6, 92);
			this.numRareMoteDropRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numRareMoteDropRate.Name = "numRareMoteDropRate";
			this.numRareMoteDropRate.Size = new System.Drawing.Size(120, 20);
			this.numRareMoteDropRate.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(259, 20);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(108, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Component Drop rate";
			// 
			// numComponentDropRate
			// 
			this.numComponentDropRate.DecimalPlaces = 2;
			this.numComponentDropRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numComponentDropRate.Location = new System.Drawing.Point(258, 42);
			this.numComponentDropRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numComponentDropRate.Name = "numComponentDropRate";
			this.numComponentDropRate.Size = new System.Drawing.Size(120, 20);
			this.numComponentDropRate.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(133, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(105, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Exotic ecto drop rate";
			// 
			// numExoticEctoDropRate
			// 
			this.numExoticEctoDropRate.DecimalPlaces = 2;
			this.numExoticEctoDropRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numExoticEctoDropRate.Location = new System.Drawing.Point(132, 42);
			this.numExoticEctoDropRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numExoticEctoDropRate.Name = "numExoticEctoDropRate";
			this.numExoticEctoDropRate.Size = new System.Drawing.Size(120, 20);
			this.numExoticEctoDropRate.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(99, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Rare ecto drop rate";
			// 
			// numRareEctoDropRate
			// 
			this.numRareEctoDropRate.DecimalPlaces = 2;
			this.numRareEctoDropRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numRareEctoDropRate.Location = new System.Drawing.Point(6, 42);
			this.numRareEctoDropRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numRareEctoDropRate.Name = "numRareEctoDropRate";
			this.numRareEctoDropRate.Size = new System.Drawing.Size(120, 20);
			this.numRareEctoDropRate.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.cbCharm);
			this.groupBox2.Controls.Add(this.btnRefresh);
			this.groupBox2.Controls.Add(this.btnSearch);
			this.groupBox2.Controls.Add(this.rbExotic);
			this.groupBox2.Controls.Add(this.rbRare);
			this.groupBox2.Location = new System.Drawing.Point(3, 127);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(687, 49);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Filters";
			// 
			// rbRare
			// 
			this.rbRare.AutoSize = true;
			this.rbRare.Location = new System.Drawing.Point(6, 19);
			this.rbRare.Name = "rbRare";
			this.rbRare.Size = new System.Drawing.Size(48, 17);
			this.rbRare.TabIndex = 0;
			this.rbRare.TabStop = true;
			this.rbRare.Text = "Rare";
			this.rbRare.UseVisualStyleBackColor = true;
			// 
			// rbExotic
			// 
			this.rbExotic.AutoSize = true;
			this.rbExotic.Location = new System.Drawing.Point(60, 19);
			this.rbExotic.Name = "rbExotic";
			this.rbExotic.Size = new System.Drawing.Size(59, 17);
			this.rbExotic.TabIndex = 1;
			this.rbExotic.TabStop = true;
			this.rbExotic.Text = "Exotics";
			this.rbExotic.UseVisualStyleBackColor = true;
			// 
			// btnSearch
			// 
			this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSearch.Location = new System.Drawing.Point(596, 13);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(85, 23);
			this.btnSearch.TabIndex = 2;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefresh.Location = new System.Drawing.Point(505, 13);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(85, 23);
			this.btnRefresh.TabIndex = 3;
			this.btnRefresh.Text = "Refresh";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// cbCharm
			// 
			this.cbCharm.FormattingEnabled = true;
			this.cbCharm.Location = new System.Drawing.Point(132, 15);
			this.cbCharm.Name = "cbCharm";
			this.cbCharm.Size = new System.Drawing.Size(250, 21);
			this.cbCharm.TabIndex = 4;
			// 
			// dgvItems
			// 
			this.dgvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvItems.Location = new System.Drawing.Point(3, 182);
			this.dgvItems.Name = "dgvItems";
			this.dgvItems.Size = new System.Drawing.Size(687, 417);
			this.dgvItems.TabIndex = 2;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(389, 20);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(74, 13);
			this.label8.TabIndex = 16;
			this.label8.Text = "Profit minimum";
			// 
			// numMinProfit
			// 
			this.numMinProfit.DecimalPlaces = 2;
			this.numMinProfit.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numMinProfit.Location = new System.Drawing.Point(388, 42);
			this.numMinProfit.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numMinProfit.Name = "numMinProfit";
			this.numMinProfit.Size = new System.Drawing.Size(120, 20);
			this.numMinProfit.TabIndex = 15;
			// 
			// ExoticAndRareSalvageControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.dgvItems);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.gbRates);
			this.Name = "ExoticAndRareSalvageControl";
			this.Size = new System.Drawing.Size(693, 602);
			this.gbRates.ResumeLayout(false);
			this.gbRates.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numExoticCharmDroprate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numRareCharmDropRate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numExoticMoteDropRate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numRareMoteDropRate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numComponentDropRate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numExoticEctoDropRate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numRareEctoDropRate)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMinProfit)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbRates;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.NumericUpDown numExoticCharmDroprate;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown numRareCharmDropRate;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown numExoticMoteDropRate;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numRareMoteDropRate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numComponentDropRate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numExoticEctoDropRate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numRareEctoDropRate;
		private System.Windows.Forms.Button btnSaveSettings;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.RadioButton rbExotic;
		private System.Windows.Forms.RadioButton rbRare;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.ComboBox cbCharm;
		private System.Windows.Forms.DataGridView dgvItems;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.NumericUpDown numMinProfit;
	}
}

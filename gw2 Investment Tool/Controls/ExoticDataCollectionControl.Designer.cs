namespace gw2_Investment_Tool.Controls
{
	partial class ExoticDataCollectionControl
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
			this.dialog = new System.Windows.Forms.OpenFileDialog();
			this.tbLocation = new System.Windows.Forms.TextBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.cbGearType = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.numQuantity = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.dgvResults = new System.Windows.Forms.DataGridView();
			this.btnLoadOldData = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
			this.SuspendLayout();
			// 
			// dialog
			// 
			this.dialog.FileName = "openFileDialog1";
			// 
			// tbLocation
			// 
			this.tbLocation.Location = new System.Drawing.Point(6, 19);
			this.tbLocation.Name = "tbLocation";
			this.tbLocation.Size = new System.Drawing.Size(248, 20);
			this.tbLocation.TabIndex = 0;
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(260, 17);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(92, 23);
			this.btnBrowse.TabIndex = 1;
			this.btnBrowse.Text = "Browse";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// cbGearType
			// 
			this.cbGearType.FormattingEnabled = true;
			this.cbGearType.Location = new System.Drawing.Point(3, 79);
			this.cbGearType.Name = "cbGearType";
			this.cbGearType.Size = new System.Drawing.Size(248, 21);
			this.cbGearType.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 63);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Gear type";
			// 
			// numQuantity
			// 
			this.numQuantity.Location = new System.Drawing.Point(260, 80);
			this.numQuantity.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.numQuantity.Name = "numQuantity";
			this.numQuantity.Size = new System.Drawing.Size(92, 20);
			this.numQuantity.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(257, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Quantity";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnLoadOldData);
			this.groupBox1.Controls.Add(this.btnSave);
			this.groupBox1.Controls.Add(this.tbLocation);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.btnBrowse);
			this.groupBox1.Controls.Add(this.numQuantity);
			this.groupBox1.Controls.Add(this.cbGearType);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(992, 111);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Input data";
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(800, 82);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(90, 23);
			this.btnSave.TabIndex = 7;
			this.btnSave.Text = "Save Data";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// dgvResults
			// 
			this.dgvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvResults.Location = new System.Drawing.Point(6, 120);
			this.dgvResults.Name = "dgvResults";
			this.dgvResults.Size = new System.Drawing.Size(989, 493);
			this.dgvResults.TabIndex = 8;
			// 
			// btnLoadOldData
			// 
			this.btnLoadOldData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLoadOldData.Location = new System.Drawing.Point(896, 82);
			this.btnLoadOldData.Name = "btnLoadOldData";
			this.btnLoadOldData.Size = new System.Drawing.Size(90, 23);
			this.btnLoadOldData.TabIndex = 9;
			this.btnLoadOldData.Text = "Load Old data";
			this.btnLoadOldData.UseVisualStyleBackColor = true;
			this.btnLoadOldData.Click += new System.EventHandler(this.btnLoadOldData_Click);
			// 
			// ExoticDataCollectionControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.dgvResults);
			this.Controls.Add(this.groupBox1);
			this.Name = "ExoticDataCollectionControl";
			this.Size = new System.Drawing.Size(998, 616);
			((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog dialog;
		private System.Windows.Forms.TextBox tbLocation;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.ComboBox cbGearType;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numQuantity;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.DataGridView dgvResults;
		private System.Windows.Forms.Button btnLoadOldData;
	}
}

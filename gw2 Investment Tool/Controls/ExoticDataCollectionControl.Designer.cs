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
			this.btnBrowse = new System.Windows.Forms.Button();
			this.cbGearType = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnExportToCsv = new System.Windows.Forms.Button();
			this.btnExportToJson = new System.Windows.Forms.Button();
			this.btnLoadOldData = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.dgvResults = new System.Windows.Forms.DataGridView();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
			this.SuspendLayout();
			// 
			// dialog
			// 
			this.dialog.FileName = "openFileDialog1";
			this.dialog.Multiselect = true;
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(9, 19);
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
			this.cbGearType.Location = new System.Drawing.Point(9, 84);
			this.cbGearType.Name = "cbGearType";
			this.cbGearType.Size = new System.Drawing.Size(248, 21);
			this.cbGearType.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 63);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Output destination";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnExportToCsv);
			this.groupBox1.Controls.Add(this.btnExportToJson);
			this.groupBox1.Controls.Add(this.btnLoadOldData);
			this.groupBox1.Controls.Add(this.btnSave);
			this.groupBox1.Controls.Add(this.btnBrowse);
			this.groupBox1.Controls.Add(this.cbGearType);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(992, 111);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Input data";
			// 
			// btnExportToCsv
			// 
			this.btnExportToCsv.Location = new System.Drawing.Point(947, 19);
			this.btnExportToCsv.Name = "btnExportToCsv";
			this.btnExportToCsv.Size = new System.Drawing.Size(39, 23);
			this.btnExportToCsv.TabIndex = 10;
			this.btnExportToCsv.Text = "Csv";
			this.btnExportToCsv.UseVisualStyleBackColor = true;
			this.btnExportToCsv.Click += new System.EventHandler(this.btnExportToCsv_Click);
			// 
			// btnExportToJson
			// 
			this.btnExportToJson.Location = new System.Drawing.Point(902, 19);
			this.btnExportToJson.Name = "btnExportToJson";
			this.btnExportToJson.Size = new System.Drawing.Size(39, 23);
			this.btnExportToJson.TabIndex = 11;
			this.btnExportToJson.Text = "Json";
			this.btnExportToJson.UseVisualStyleBackColor = true;
			this.btnExportToJson.Click += new System.EventHandler(this.btnExportToJson_Click);
			// 
			// btnLoadOldData
			// 
			this.btnLoadOldData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLoadOldData.Location = new System.Drawing.Point(896, 77);
			this.btnLoadOldData.Name = "btnLoadOldData";
			this.btnLoadOldData.Size = new System.Drawing.Size(90, 23);
			this.btnLoadOldData.TabIndex = 9;
			this.btnLoadOldData.Text = "Load Old data";
			this.btnLoadOldData.UseVisualStyleBackColor = true;
			this.btnLoadOldData.Click += new System.EventHandler(this.btnLoadOldData_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(800, 77);
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
			// ExoticDataCollectionControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.dgvResults);
			this.Controls.Add(this.groupBox1);
			this.Name = "ExoticDataCollectionControl";
			this.Size = new System.Drawing.Size(998, 616);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog dialog;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.ComboBox cbGearType;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.DataGridView dgvResults;
		private System.Windows.Forms.Button btnLoadOldData;
		private System.Windows.Forms.Button btnExportToJson;
		private System.Windows.Forms.Button btnExportToCsv;
	}
}

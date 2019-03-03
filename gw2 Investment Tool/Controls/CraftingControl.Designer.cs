namespace gw2_Investment_Tool.Controls
{
	partial class CraftingControl
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
            this.cbLists = new System.Windows.Forms.ComboBox();
            this.btnGenerateLocalData = new System.Windows.Forms.Button();
            this.btnWhiteList = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.dgvItemsToCalculate = new System.Windows.Forms.DataGridView();
            this.labelKarmaValue = new System.Windows.Forms.Label();
            this.labelUsedKarma = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsToCalculate)).BeginInit();
            this.SuspendLayout();
            // 
            // cbLists
            // 
            this.cbLists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbLists.FormattingEnabled = true;
            this.cbLists.Location = new System.Drawing.Point(3, 191);
            this.cbLists.Name = "cbLists";
            this.cbLists.Size = new System.Drawing.Size(417, 21);
            this.cbLists.TabIndex = 26;
            // 
            // btnGenerateLocalData
            // 
            this.btnGenerateLocalData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateLocalData.Location = new System.Drawing.Point(616, 3);
            this.btnGenerateLocalData.Name = "btnGenerateLocalData";
            this.btnGenerateLocalData.Size = new System.Drawing.Size(124, 23);
            this.btnGenerateLocalData.TabIndex = 25;
            this.btnGenerateLocalData.Text = "Generate Local Data";
            this.btnGenerateLocalData.UseVisualStyleBackColor = true;
            this.btnGenerateLocalData.Click += new System.EventHandler(this.btnGenerateLocalData_Click);
            // 
            // btnWhiteList
            // 
            this.btnWhiteList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWhiteList.Location = new System.Drawing.Point(102, 218);
            this.btnWhiteList.Name = "btnWhiteList";
            this.btnWhiteList.Size = new System.Drawing.Size(75, 23);
            this.btnWhiteList.TabIndex = 24;
            this.btnWhiteList.Text = "White List";
            this.btnWhiteList.UseVisualStyleBackColor = true;
            this.btnWhiteList.Click += new System.EventHandler(this.btnWhiteList_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(183, 218);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "Delete Item";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalculate.Location = new System.Drawing.Point(665, 218);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 22;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(264, 218);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save Data";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddItem.Location = new System.Drawing.Point(3, 218);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(93, 23);
            this.btnAddItem.TabIndex = 20;
            this.btnAddItem.Text = "Add New Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnLoadData
            // 
            this.btnLoadData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadData.Location = new System.Drawing.Point(426, 191);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadData.TabIndex = 19;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // dgvItemsToCalculate
            // 
            this.dgvItemsToCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItemsToCalculate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemsToCalculate.Location = new System.Drawing.Point(3, 247);
            this.dgvItemsToCalculate.Name = "dgvItemsToCalculate";
            this.dgvItemsToCalculate.Size = new System.Drawing.Size(737, 418);
            this.dgvItemsToCalculate.TabIndex = 18;
            this.dgvItemsToCalculate.CellStyleChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemsToCalculate_CellStyleChanged);
            // 
            // labelKarmaValue
            // 
            this.labelKarmaValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelKarmaValue.AutoSize = true;
            this.labelKarmaValue.Location = new System.Drawing.Point(703, 668);
            this.labelKarmaValue.Name = "labelKarmaValue";
            this.labelKarmaValue.Size = new System.Drawing.Size(27, 13);
            this.labelKarmaValue.TabIndex = 28;
            this.labelKarmaValue.Text = "N/A";
            // 
            // labelUsedKarma
            // 
            this.labelUsedKarma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUsedKarma.AutoSize = true;
            this.labelUsedKarma.Location = new System.Drawing.Point(602, 668);
            this.labelUsedKarma.Name = "labelUsedKarma";
            this.labelUsedKarma.Size = new System.Drawing.Size(95, 13);
            this.labelUsedKarma.TabIndex = 27;
            this.labelUsedKarma.Text = "Total Karma Used:";
            // 
            // CraftingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelKarmaValue);
            this.Controls.Add(this.labelUsedKarma);
            this.Controls.Add(this.cbLists);
            this.Controls.Add(this.btnGenerateLocalData);
            this.Controls.Add(this.btnWhiteList);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.dgvItemsToCalculate);
            this.Name = "CraftingControl";
            this.Size = new System.Drawing.Size(747, 693);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsToCalculate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbLists;
		private System.Windows.Forms.Button btnGenerateLocalData;
		private System.Windows.Forms.Button btnWhiteList;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnCalculate;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnAddItem;
		private System.Windows.Forms.Button btnLoadData;
		private System.Windows.Forms.DataGridView dgvItemsToCalculate;
		private System.Windows.Forms.Label labelKarmaValue;
		private System.Windows.Forms.Label labelUsedKarma;
	}
}

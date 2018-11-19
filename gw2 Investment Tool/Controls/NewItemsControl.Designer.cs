namespace gw2_Investment_Tool.Controls
{
	partial class NewItemsControl
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnExport = new System.Windows.Forms.Button();
			this.btnFilter = new System.Windows.Forms.Button();
			this.tbFilter = new System.Windows.Forms.TextBox();
			this.radioFlags = new System.Windows.Forms.RadioButton();
			this.radioDisciplines = new System.Windows.Forms.RadioButton();
			this.radioType = new System.Windows.Forms.RadioButton();
			this.radioName = new System.Windows.Forms.RadioButton();
			this.label14 = new System.Windows.Forms.Label();
			this.dgvGuildIngridients = new System.Windows.Forms.DataGridView();
			this.gbItem = new System.Windows.Forms.GroupBox();
			this.labelRecipeIdValue = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.labelItemIdValue = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.labelDescriptionValue = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.labelRarityValue = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.labelFlags = new System.Windows.Forms.Label();
			this.labelDisciplines = new System.Windows.Forms.Label();
			this.labelMinRating = new System.Windows.Forms.Label();
			this.labelOutputCount = new System.Windows.Forms.Label();
			this.labelType = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.labelName = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.dgvIngredients = new System.Windows.Forms.DataGridView();
			this.dgvNewItems = new System.Windows.Forms.DataGridView();
			this.btnSearch = new System.Windows.Forms.Button();
			this.tbNew = new System.Windows.Forms.TextBox();
			this.tbOld = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvGuildIngridients)).BeginInit();
			this.gbItem.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvNewItems)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnExport);
			this.groupBox1.Controls.Add(this.btnFilter);
			this.groupBox1.Controls.Add(this.tbFilter);
			this.groupBox1.Controls.Add(this.radioFlags);
			this.groupBox1.Controls.Add(this.radioDisciplines);
			this.groupBox1.Controls.Add(this.radioType);
			this.groupBox1.Controls.Add(this.radioName);
			this.groupBox1.Location = new System.Drawing.Point(6, 113);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(720, 62);
			this.groupBox1.TabIndex = 24;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Filters";
			// 
			// btnExport
			// 
			this.btnExport.Location = new System.Drawing.Point(639, 15);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(75, 23);
			this.btnExport.TabIndex = 6;
			this.btnExport.Text = "Export";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			// 
			// btnFilter
			// 
			this.btnFilter.Location = new System.Drawing.Point(401, 15);
			this.btnFilter.Name = "btnFilter";
			this.btnFilter.Size = new System.Drawing.Size(75, 23);
			this.btnFilter.TabIndex = 5;
			this.btnFilter.Text = "Filter";
			this.btnFilter.UseVisualStyleBackColor = true;
			this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
			// 
			// tbFilter
			// 
			this.tbFilter.Location = new System.Drawing.Point(9, 17);
			this.tbFilter.Name = "tbFilter";
			this.tbFilter.Size = new System.Drawing.Size(383, 20);
			this.tbFilter.TabIndex = 4;
			// 
			// radioFlags
			// 
			this.radioFlags.AutoSize = true;
			this.radioFlags.Location = new System.Drawing.Point(202, 38);
			this.radioFlags.Name = "radioFlags";
			this.radioFlags.Size = new System.Drawing.Size(50, 17);
			this.radioFlags.TabIndex = 3;
			this.radioFlags.TabStop = true;
			this.radioFlags.Text = "Flags";
			this.radioFlags.UseVisualStyleBackColor = true;
			// 
			// radioDisciplines
			// 
			this.radioDisciplines.AutoSize = true;
			this.radioDisciplines.Location = new System.Drawing.Point(125, 38);
			this.radioDisciplines.Name = "radioDisciplines";
			this.radioDisciplines.Size = new System.Drawing.Size(70, 17);
			this.radioDisciplines.TabIndex = 2;
			this.radioDisciplines.TabStop = true;
			this.radioDisciplines.Text = "Discipline";
			this.radioDisciplines.UseVisualStyleBackColor = true;
			// 
			// radioType
			// 
			this.radioType.AutoSize = true;
			this.radioType.Location = new System.Drawing.Point(69, 38);
			this.radioType.Name = "radioType";
			this.radioType.Size = new System.Drawing.Size(49, 17);
			this.radioType.TabIndex = 1;
			this.radioType.TabStop = true;
			this.radioType.Text = "Type";
			this.radioType.UseVisualStyleBackColor = true;
			// 
			// radioName
			// 
			this.radioName.AutoSize = true;
			this.radioName.Location = new System.Drawing.Point(10, 38);
			this.radioName.Name = "radioName";
			this.radioName.Size = new System.Drawing.Size(53, 17);
			this.radioName.TabIndex = 0;
			this.radioName.TabStop = true;
			this.radioName.Text = "Name";
			this.radioName.UseVisualStyleBackColor = true;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(404, 323);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(85, 13);
			this.label14.TabIndex = 23;
			this.label14.Text = "Guild ingredients";
			// 
			// dgvGuildIngridients
			// 
			this.dgvGuildIngridients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvGuildIngridients.Location = new System.Drawing.Point(404, 339);
			this.dgvGuildIngridients.Name = "dgvGuildIngridients";
			this.dgvGuildIngridients.ReadOnly = true;
			this.dgvGuildIngridients.Size = new System.Drawing.Size(322, 140);
			this.dgvGuildIngridients.TabIndex = 22;
			// 
			// gbItem
			// 
			this.gbItem.Controls.Add(this.labelRecipeIdValue);
			this.gbItem.Controls.Add(this.label13);
			this.gbItem.Controls.Add(this.labelItemIdValue);
			this.gbItem.Controls.Add(this.label12);
			this.gbItem.Controls.Add(this.labelDescriptionValue);
			this.gbItem.Controls.Add(this.label11);
			this.gbItem.Controls.Add(this.labelRarityValue);
			this.gbItem.Controls.Add(this.label5);
			this.gbItem.Controls.Add(this.labelFlags);
			this.gbItem.Controls.Add(this.labelDisciplines);
			this.gbItem.Controls.Add(this.labelMinRating);
			this.gbItem.Controls.Add(this.labelOutputCount);
			this.gbItem.Controls.Add(this.labelType);
			this.gbItem.Controls.Add(this.label10);
			this.gbItem.Controls.Add(this.label9);
			this.gbItem.Controls.Add(this.label8);
			this.gbItem.Controls.Add(this.label7);
			this.gbItem.Controls.Add(this.label6);
			this.gbItem.Controls.Add(this.labelName);
			this.gbItem.Controls.Add(this.label4);
			this.gbItem.Location = new System.Drawing.Point(2, 485);
			this.gbItem.Name = "gbItem";
			this.gbItem.Size = new System.Drawing.Size(721, 160);
			this.gbItem.TabIndex = 21;
			this.gbItem.TabStop = false;
			this.gbItem.Text = "Item Details";
			// 
			// labelRecipeIdValue
			// 
			this.labelRecipeIdValue.AutoSize = true;
			this.labelRecipeIdValue.Location = new System.Drawing.Point(460, 79);
			this.labelRecipeIdValue.Name = "labelRecipeIdValue";
			this.labelRecipeIdValue.Size = new System.Drawing.Size(27, 13);
			this.labelRecipeIdValue.TabIndex = 19;
			this.labelRecipeIdValue.Text = "N/A";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(395, 79);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(55, 13);
			this.label13.TabIndex = 18;
			this.label13.Text = "RecipeID:";
			// 
			// labelItemIdValue
			// 
			this.labelItemIdValue.AutoSize = true;
			this.labelItemIdValue.Location = new System.Drawing.Point(460, 133);
			this.labelItemIdValue.Name = "labelItemIdValue";
			this.labelItemIdValue.Size = new System.Drawing.Size(27, 13);
			this.labelItemIdValue.TabIndex = 17;
			this.labelItemIdValue.Text = "N/A";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(395, 133);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(41, 13);
			this.label12.TabIndex = 16;
			this.label12.Text = "ItemID:";
			// 
			// labelDescriptionValue
			// 
			this.labelDescriptionValue.AutoSize = true;
			this.labelDescriptionValue.Location = new System.Drawing.Point(460, 20);
			this.labelDescriptionValue.MaximumSize = new System.Drawing.Size(260, 0);
			this.labelDescriptionValue.Name = "labelDescriptionValue";
			this.labelDescriptionValue.Size = new System.Drawing.Size(27, 13);
			this.labelDescriptionValue.TabIndex = 15;
			this.labelDescriptionValue.Text = "N/A";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(395, 20);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(63, 13);
			this.label11.TabIndex = 14;
			this.label11.Text = "Description:";
			// 
			// labelRarityValue
			// 
			this.labelRarityValue.AutoSize = true;
			this.labelRarityValue.Location = new System.Drawing.Point(460, 50);
			this.labelRarityValue.Name = "labelRarityValue";
			this.labelRarityValue.Size = new System.Drawing.Size(27, 13);
			this.labelRarityValue.TabIndex = 13;
			this.labelRarityValue.Text = "N/A";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(395, 50);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(37, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Rarity:";
			// 
			// labelFlags
			// 
			this.labelFlags.AutoSize = true;
			this.labelFlags.Location = new System.Drawing.Point(460, 107);
			this.labelFlags.Name = "labelFlags";
			this.labelFlags.Size = new System.Drawing.Size(27, 13);
			this.labelFlags.TabIndex = 11;
			this.labelFlags.Text = "N/A";
			// 
			// labelDisciplines
			// 
			this.labelDisciplines.AutoSize = true;
			this.labelDisciplines.Location = new System.Drawing.Point(86, 133);
			this.labelDisciplines.Name = "labelDisciplines";
			this.labelDisciplines.Size = new System.Drawing.Size(27, 13);
			this.labelDisciplines.TabIndex = 10;
			this.labelDisciplines.Text = "N/A";
			// 
			// labelMinRating
			// 
			this.labelMinRating.AutoSize = true;
			this.labelMinRating.Location = new System.Drawing.Point(86, 107);
			this.labelMinRating.Name = "labelMinRating";
			this.labelMinRating.Size = new System.Drawing.Size(27, 13);
			this.labelMinRating.TabIndex = 9;
			this.labelMinRating.Text = "N/A";
			// 
			// labelOutputCount
			// 
			this.labelOutputCount.AutoSize = true;
			this.labelOutputCount.Location = new System.Drawing.Point(86, 79);
			this.labelOutputCount.Name = "labelOutputCount";
			this.labelOutputCount.Size = new System.Drawing.Size(27, 13);
			this.labelOutputCount.TabIndex = 8;
			this.labelOutputCount.Text = "N/A";
			// 
			// labelType
			// 
			this.labelType.AutoSize = true;
			this.labelType.Location = new System.Drawing.Point(86, 50);
			this.labelType.Name = "labelType";
			this.labelType.Size = new System.Drawing.Size(27, 13);
			this.labelType.TabIndex = 7;
			this.labelType.Text = "N/A";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(395, 107);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(35, 13);
			this.label10.TabIndex = 6;
			this.label10.Text = "Flags:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(7, 133);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(60, 13);
			this.label9.TabIndex = 5;
			this.label9.Text = "Discpilines:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(7, 107);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 13);
			this.label8.TabIndex = 4;
			this.label8.Text = "Min rating:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(7, 79);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 13);
			this.label7.TabIndex = 3;
			this.label7.Text = "Output count:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(7, 50);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(34, 13);
			this.label6.TabIndex = 2;
			this.label6.Text = "Type:";
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(86, 20);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(27, 13);
			this.labelName.TabIndex = 1;
			this.labelName.Text = "N/A";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 20);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Name: ";
			// 
			// dgvIngredients
			// 
			this.dgvIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvIngredients.Location = new System.Drawing.Point(403, 181);
			this.dgvIngredients.Name = "dgvIngredients";
			this.dgvIngredients.ReadOnly = true;
			this.dgvIngredients.Size = new System.Drawing.Size(323, 139);
			this.dgvIngredients.TabIndex = 20;
			// 
			// dgvNewItems
			// 
			this.dgvNewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvNewItems.Location = new System.Drawing.Point(6, 181);
			this.dgvNewItems.Name = "dgvNewItems";
			this.dgvNewItems.ReadOnly = true;
			this.dgvNewItems.Size = new System.Drawing.Size(392, 298);
			this.dgvNewItems.TabIndex = 19;
			this.dgvNewItems.SelectionChanged += new System.EventHandler(this.dgvNewItems_SelectionChanged);
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(6, 81);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 18;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// tbNew
			// 
			this.tbNew.Location = new System.Drawing.Point(112, 55);
			this.tbNew.Name = "tbNew";
			this.tbNew.Size = new System.Drawing.Size(100, 20);
			this.tbNew.TabIndex = 17;
			// 
			// tbOld
			// 
			this.tbOld.Location = new System.Drawing.Point(6, 55);
			this.tbOld.Name = "tbOld";
			this.tbOld.Size = new System.Drawing.Size(100, 20);
			this.tbOld.TabIndex = 16;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(109, 39);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 13);
			this.label3.TabIndex = 15;
			this.label3.Text = "New index";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 13);
			this.label2.TabIndex = 14;
			this.label2.Text = "Old Index";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.MaximumSize = new System.Drawing.Size(730, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(727, 26);
			this.label1.TabIndex = 13;
			this.label1.Text = "This tool will show you all new craftable items from the latest patch. Note that " +
    "some of them may not be shown initialy, if the are not discovered by players yet" +
    ".";
			// 
			// NewItemsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.dgvGuildIngridients);
			this.Controls.Add(this.gbItem);
			this.Controls.Add(this.dgvIngredients);
			this.Controls.Add(this.dgvNewItems);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.tbNew);
			this.Controls.Add(this.tbOld);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "NewItemsControl";
			this.Size = new System.Drawing.Size(731, 653);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvGuildIngridients)).EndInit();
			this.gbItem.ResumeLayout(false);
			this.gbItem.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvNewItems)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnExport;
		private System.Windows.Forms.Button btnFilter;
		private System.Windows.Forms.TextBox tbFilter;
		private System.Windows.Forms.RadioButton radioFlags;
		private System.Windows.Forms.RadioButton radioDisciplines;
		private System.Windows.Forms.RadioButton radioType;
		private System.Windows.Forms.RadioButton radioName;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.DataGridView dgvGuildIngridients;
		private System.Windows.Forms.GroupBox gbItem;
		private System.Windows.Forms.Label labelRecipeIdValue;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label labelItemIdValue;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label labelDescriptionValue;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label labelRarityValue;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label labelFlags;
		private System.Windows.Forms.Label labelDisciplines;
		private System.Windows.Forms.Label labelMinRating;
		private System.Windows.Forms.Label labelOutputCount;
		private System.Windows.Forms.Label labelType;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGridView dgvIngredients;
		private System.Windows.Forms.DataGridView dgvNewItems;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.TextBox tbNew;
		private System.Windows.Forms.TextBox tbOld;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}

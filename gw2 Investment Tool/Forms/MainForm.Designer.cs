using System.Windows.Forms;

namespace gw2_Investment_Tool.Forms
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.Crafting = new System.Windows.Forms.TabPage();
			this.cbLists = new System.Windows.Forms.ComboBox();
			this.btnSettings = new System.Windows.Forms.Button();
			this.btnWhiteList = new System.Windows.Forms.Button();
			this.labelDelete = new System.Windows.Forms.Label();
			this.btnDelete = new System.Windows.Forms.Button();
			this.labelSave = new System.Windows.Forms.Label();
			this.labelCalculate = new System.Windows.Forms.Label();
			this.labelEdit = new System.Windows.Forms.Label();
			this.labelAddNewItem = new System.Windows.Forms.Label();
			this.labelLoadData = new System.Windows.Forms.Label();
			this.btnCalculate = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnAddItem = new System.Windows.Forms.Button();
			this.btnLoadData = new System.Windows.Forms.Button();
			this.dgvItemsToCalculate = new System.Windows.Forms.DataGridView();
			this.NewItems = new System.Windows.Forms.TabPage();
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
			this.TBD = new System.Windows.Forms.TabPage();
			this.dgvRecipeCompareOldGuildIngredients = new System.Windows.Forms.DataGridView();
			this.dgvCompareRecipesNewGuildIngredients = new System.Windows.Forms.DataGridView();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.dgvRecipeCompareOldIngredients = new System.Windows.Forms.DataGridView();
			this.dgvCompareRecipesNewIngredients = new System.Windows.Forms.DataGridView();
			this.dgvRecipeCompareAll = new System.Windows.Forms.DataGridView();
			this.label15 = new System.Windows.Forms.Label();
			this.btnLoadOldData = new System.Windows.Forms.Button();
			this.itemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.itemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.itemQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.discipline = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.karmaPerItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.karmaTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.labelUsedKarma = new System.Windows.Forms.Label();
			this.labelKarmaValue = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.Crafting.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvItemsToCalculate)).BeginInit();
			this.NewItems.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvGuildIngridients)).BeginInit();
			this.gbItem.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvNewItems)).BeginInit();
			this.TBD.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvRecipeCompareOldGuildIngredients)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCompareRecipesNewGuildIngredients)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvRecipeCompareOldIngredients)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCompareRecipesNewIngredients)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvRecipeCompareAll)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.Crafting);
			this.tabControl1.Controls.Add(this.NewItems);
			this.tabControl1.Controls.Add(this.TBD);
			this.tabControl1.Location = new System.Drawing.Point(12, 2);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(745, 684);
			this.tabControl1.TabIndex = 0;
			// 
			// Crafting
			// 
			this.Crafting.Controls.Add(this.cbLists);
			this.Crafting.Controls.Add(this.btnSettings);
			this.Crafting.Controls.Add(this.btnWhiteList);
			this.Crafting.Controls.Add(this.labelDelete);
			this.Crafting.Controls.Add(this.btnDelete);
			this.Crafting.Controls.Add(this.labelSave);
			this.Crafting.Controls.Add(this.labelCalculate);
			this.Crafting.Controls.Add(this.labelEdit);
			this.Crafting.Controls.Add(this.labelAddNewItem);
			this.Crafting.Controls.Add(this.labelLoadData);
			this.Crafting.Controls.Add(this.btnCalculate);
			this.Crafting.Controls.Add(this.btnSave);
			this.Crafting.Controls.Add(this.btnAddItem);
			this.Crafting.Controls.Add(this.btnLoadData);
			this.Crafting.Controls.Add(this.dgvItemsToCalculate);
			this.Crafting.Location = new System.Drawing.Point(4, 22);
			this.Crafting.Name = "Crafting";
			this.Crafting.Padding = new System.Windows.Forms.Padding(3);
			this.Crafting.Size = new System.Drawing.Size(737, 658);
			this.Crafting.TabIndex = 0;
			this.Crafting.Text = "Crafting";
			this.Crafting.UseVisualStyleBackColor = true;
			// 
			// cbLists
			// 
			this.cbLists.FormattingEnabled = true;
			this.cbLists.Location = new System.Drawing.Point(10, 159);
			this.cbLists.Name = "cbLists";
			this.cbLists.Size = new System.Drawing.Size(417, 21);
			this.cbLists.TabIndex = 17;
			// 
			// btnSettings
			// 
			this.btnSettings.Location = new System.Drawing.Point(656, 7);
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.Size = new System.Drawing.Size(75, 23);
			this.btnSettings.TabIndex = 16;
			this.btnSettings.Text = "Settings";
			this.btnSettings.UseVisualStyleBackColor = true;
			this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
			// 
			// btnWhiteList
			// 
			this.btnWhiteList.Location = new System.Drawing.Point(109, 186);
			this.btnWhiteList.Name = "btnWhiteList";
			this.btnWhiteList.Size = new System.Drawing.Size(75, 23);
			this.btnWhiteList.TabIndex = 15;
			this.btnWhiteList.Text = "White List";
			this.btnWhiteList.UseVisualStyleBackColor = true;
			this.btnWhiteList.Click += new System.EventHandler(this.btnWhiteList_Click);
			// 
			// labelDelete
			// 
			this.labelDelete.AutoSize = true;
			this.labelDelete.Location = new System.Drawing.Point(7, 72);
			this.labelDelete.Name = "labelDelete";
			this.labelDelete.Size = new System.Drawing.Size(281, 13);
			this.labelDelete.TabIndex = 13;
			this.labelDelete.Text = "Use \"Delete Item\" button to delete currently selected item.";
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(190, 186);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 12;
			this.btnDelete.Text = "Delete Item";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// labelSave
			// 
			this.labelSave.AutoSize = true;
			this.labelSave.Location = new System.Drawing.Point(7, 59);
			this.labelSave.Name = "labelSave";
			this.labelSave.Size = new System.Drawing.Size(282, 13);
			this.labelSave.TabIndex = 11;
			this.labelSave.Text = "Use \"Save Data\" button to save current data for later use.";
			// 
			// labelCalculate
			// 
			this.labelCalculate.AutoSize = true;
			this.labelCalculate.Location = new System.Drawing.Point(7, 46);
			this.labelCalculate.Name = "labelCalculate";
			this.labelCalculate.Size = new System.Drawing.Size(230, 13);
			this.labelCalculate.TabIndex = 10;
			this.labelCalculate.Text = "Use \"Calculate\" button to calculate crafting list.";
			// 
			// labelEdit
			// 
			this.labelEdit.AutoSize = true;
			this.labelEdit.Location = new System.Drawing.Point(7, 33);
			this.labelEdit.Name = "labelEdit";
			this.labelEdit.Size = new System.Drawing.Size(280, 13);
			this.labelEdit.TabIndex = 9;
			this.labelEdit.Text = "Use \"White List\" button to add a item to Whitelisted items.";
			// 
			// labelAddNewItem
			// 
			this.labelAddNewItem.AutoSize = true;
			this.labelAddNewItem.Location = new System.Drawing.Point(7, 20);
			this.labelAddNewItem.Name = "labelAddNewItem";
			this.labelAddNewItem.Size = new System.Drawing.Size(332, 13);
			this.labelAddNewItem.TabIndex = 8;
			this.labelAddNewItem.Text = "Use \"Add New Item\" button to add new item into crafting calculation.";
			// 
			// labelLoadData
			// 
			this.labelLoadData.AutoSize = true;
			this.labelLoadData.Location = new System.Drawing.Point(7, 7);
			this.labelLoadData.Name = "labelLoadData";
			this.labelLoadData.Size = new System.Drawing.Size(266, 13);
			this.labelLoadData.TabIndex = 7;
			this.labelLoadData.Text = "Use \"Reload Data\" button to reload the data(manualy)!";
			// 
			// btnCalculate
			// 
			this.btnCalculate.Location = new System.Drawing.Point(656, 186);
			this.btnCalculate.Name = "btnCalculate";
			this.btnCalculate.Size = new System.Drawing.Size(75, 23);
			this.btnCalculate.TabIndex = 6;
			this.btnCalculate.Text = "Calculate";
			this.btnCalculate.UseVisualStyleBackColor = true;
			this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(271, 186);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 5;
			this.btnSave.Text = "Save Data";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnAddItem
			// 
			this.btnAddItem.Location = new System.Drawing.Point(10, 186);
			this.btnAddItem.Name = "btnAddItem";
			this.btnAddItem.Size = new System.Drawing.Size(93, 23);
			this.btnAddItem.TabIndex = 3;
			this.btnAddItem.Text = "Add New Item";
			this.btnAddItem.UseVisualStyleBackColor = true;
			this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
			// 
			// btnLoadData
			// 
			this.btnLoadData.Location = new System.Drawing.Point(433, 159);
			this.btnLoadData.Name = "btnLoadData";
			this.btnLoadData.Size = new System.Drawing.Size(75, 23);
			this.btnLoadData.TabIndex = 2;
			this.btnLoadData.Text = "Load Data";
			this.btnLoadData.UseVisualStyleBackColor = true;
			this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
			// 
			// dgvItemsToCalculate
			// 
			this.dgvItemsToCalculate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvItemsToCalculate.Location = new System.Drawing.Point(0, 215);
			this.dgvItemsToCalculate.Name = "dgvItemsToCalculate";
			this.dgvItemsToCalculate.ReadOnly = true;
			this.dgvItemsToCalculate.Size = new System.Drawing.Size(737, 443);
			this.dgvItemsToCalculate.TabIndex = 1;
			this.dgvItemsToCalculate.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemsToCalculate_OnCellValueChanged);
			// 
			// NewItems
			// 
			this.NewItems.Controls.Add(this.groupBox1);
			this.NewItems.Controls.Add(this.label14);
			this.NewItems.Controls.Add(this.dgvGuildIngridients);
			this.NewItems.Controls.Add(this.gbItem);
			this.NewItems.Controls.Add(this.dgvIngredients);
			this.NewItems.Controls.Add(this.dgvNewItems);
			this.NewItems.Controls.Add(this.btnSearch);
			this.NewItems.Controls.Add(this.tbNew);
			this.NewItems.Controls.Add(this.tbOld);
			this.NewItems.Controls.Add(this.label3);
			this.NewItems.Controls.Add(this.label2);
			this.NewItems.Controls.Add(this.label1);
			this.NewItems.Location = new System.Drawing.Point(4, 22);
			this.NewItems.Name = "NewItems";
			this.NewItems.Padding = new System.Windows.Forms.Padding(3);
			this.NewItems.Size = new System.Drawing.Size(737, 658);
			this.NewItems.TabIndex = 1;
			this.NewItems.Text = "New Items";
			this.NewItems.UseVisualStyleBackColor = true;
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
			this.groupBox1.Location = new System.Drawing.Point(10, 120);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(720, 62);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Filters";
			// 
			// btnExport
			// 
			this.btnExport.Location = new System.Drawing.Point(639, 14);
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
			this.label14.Location = new System.Drawing.Point(408, 330);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(85, 13);
			this.label14.TabIndex = 10;
			this.label14.Text = "Guild ingredients";
			// 
			// dgvGuildIngridients
			// 
			this.dgvGuildIngridients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvGuildIngridients.Location = new System.Drawing.Point(408, 346);
			this.dgvGuildIngridients.Name = "dgvGuildIngridients";
			this.dgvGuildIngridients.ReadOnly = true;
			this.dgvGuildIngridients.Size = new System.Drawing.Size(322, 140);
			this.dgvGuildIngridients.TabIndex = 9;
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
			this.gbItem.Location = new System.Drawing.Point(6, 492);
			this.gbItem.Name = "gbItem";
			this.gbItem.Size = new System.Drawing.Size(721, 160);
			this.gbItem.TabIndex = 8;
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
			this.dgvIngredients.Location = new System.Drawing.Point(407, 188);
			this.dgvIngredients.Name = "dgvIngredients";
			this.dgvIngredients.ReadOnly = true;
			this.dgvIngredients.Size = new System.Drawing.Size(323, 139);
			this.dgvIngredients.TabIndex = 7;
			// 
			// dgvNewItems
			// 
			this.dgvNewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvNewItems.Location = new System.Drawing.Point(10, 188);
			this.dgvNewItems.Name = "dgvNewItems";
			this.dgvNewItems.ReadOnly = true;
			this.dgvNewItems.Size = new System.Drawing.Size(392, 298);
			this.dgvNewItems.TabIndex = 6;
			this.dgvNewItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNewItems_CellSelected);
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(10, 88);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 5;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// tbNew
			// 
			this.tbNew.Location = new System.Drawing.Point(116, 62);
			this.tbNew.Name = "tbNew";
			this.tbNew.Size = new System.Drawing.Size(100, 20);
			this.tbNew.TabIndex = 4;
			// 
			// tbOld
			// 
			this.tbOld.Location = new System.Drawing.Point(10, 62);
			this.tbOld.Name = "tbOld";
			this.tbOld.Size = new System.Drawing.Size(100, 20);
			this.tbOld.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(113, 46);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "New index";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Old Index";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 7);
			this.label1.MaximumSize = new System.Drawing.Size(730, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(727, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "This tool will show you all new craftable items from the latest patch. Note that " +
    "some of them may not be shown initialy, if the are not discovered by players yet" +
    ".";
			// 
			// TBD
			// 
			this.TBD.Controls.Add(this.dgvRecipeCompareOldGuildIngredients);
			this.TBD.Controls.Add(this.dgvCompareRecipesNewGuildIngredients);
			this.TBD.Controls.Add(this.label17);
			this.TBD.Controls.Add(this.label16);
			this.TBD.Controls.Add(this.dgvRecipeCompareOldIngredients);
			this.TBD.Controls.Add(this.dgvCompareRecipesNewIngredients);
			this.TBD.Controls.Add(this.dgvRecipeCompareAll);
			this.TBD.Controls.Add(this.label15);
			this.TBD.Controls.Add(this.btnLoadOldData);
			this.TBD.Location = new System.Drawing.Point(4, 22);
			this.TBD.Name = "TBD";
			this.TBD.Padding = new System.Windows.Forms.Padding(3);
			this.TBD.Size = new System.Drawing.Size(737, 658);
			this.TBD.TabIndex = 2;
			this.TBD.Text = "TBD";
			this.TBD.UseVisualStyleBackColor = true;
			// 
			// dgvRecipeCompareOldGuildIngredients
			// 
			this.dgvRecipeCompareOldGuildIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvRecipeCompareOldGuildIngredients.Location = new System.Drawing.Point(380, 496);
			this.dgvRecipeCompareOldGuildIngredients.Name = "dgvRecipeCompareOldGuildIngredients";
			this.dgvRecipeCompareOldGuildIngredients.ReadOnly = true;
			this.dgvRecipeCompareOldGuildIngredients.Size = new System.Drawing.Size(351, 150);
			this.dgvRecipeCompareOldGuildIngredients.TabIndex = 8;
			// 
			// dgvCompareRecipesNewGuildIngredients
			// 
			this.dgvCompareRecipesNewGuildIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCompareRecipesNewGuildIngredients.Location = new System.Drawing.Point(6, 496);
			this.dgvCompareRecipesNewGuildIngredients.Name = "dgvCompareRecipesNewGuildIngredients";
			this.dgvCompareRecipesNewGuildIngredients.ReadOnly = true;
			this.dgvCompareRecipesNewGuildIngredients.Size = new System.Drawing.Size(351, 150);
			this.dgvCompareRecipesNewGuildIngredients.TabIndex = 7;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(378, 321);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(109, 13);
			this.label17.TabIndex = 6;
			this.label17.Text = "Old recipe ingredients";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(3, 321);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(115, 13);
			this.label16.TabIndex = 5;
			this.label16.Text = "New recipe ingredients";
			// 
			// dgvRecipeCompareOldIngredients
			// 
			this.dgvRecipeCompareOldIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvRecipeCompareOldIngredients.Location = new System.Drawing.Point(381, 340);
			this.dgvRecipeCompareOldIngredients.Name = "dgvRecipeCompareOldIngredients";
			this.dgvRecipeCompareOldIngredients.ReadOnly = true;
			this.dgvRecipeCompareOldIngredients.Size = new System.Drawing.Size(350, 150);
			this.dgvRecipeCompareOldIngredients.TabIndex = 4;
			// 
			// dgvCompareRecipesNewIngredients
			// 
			this.dgvCompareRecipesNewIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCompareRecipesNewIngredients.Location = new System.Drawing.Point(6, 340);
			this.dgvCompareRecipesNewIngredients.Name = "dgvCompareRecipesNewIngredients";
			this.dgvCompareRecipesNewIngredients.ReadOnly = true;
			this.dgvCompareRecipesNewIngredients.Size = new System.Drawing.Size(351, 150);
			this.dgvCompareRecipesNewIngredients.TabIndex = 3;
			// 
			// dgvRecipeCompareAll
			// 
			this.dgvRecipeCompareAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvRecipeCompareAll.Location = new System.Drawing.Point(6, 75);
			this.dgvRecipeCompareAll.Name = "dgvRecipeCompareAll";
			this.dgvRecipeCompareAll.ReadOnly = true;
			this.dgvRecipeCompareAll.Size = new System.Drawing.Size(725, 241);
			this.dgvRecipeCompareAll.TabIndex = 2;
			this.dgvRecipeCompareAll.SelectionChanged += new System.EventHandler(this.dgvRecipeCompareAll_SelectionChanged);
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(7, 7);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(724, 36);
			this.label15.TabIndex = 1;
			this.label15.Text = "Instructions: load the old data json with the button. This tool will show you the" +
    " difference between the data you loaded and the current crafting recipe for the " +
    "item";
			// 
			// btnLoadOldData
			// 
			this.btnLoadOldData.Location = new System.Drawing.Point(6, 46);
			this.btnLoadOldData.Name = "btnLoadOldData";
			this.btnLoadOldData.Size = new System.Drawing.Size(75, 23);
			this.btnLoadOldData.TabIndex = 0;
			this.btnLoadOldData.Text = "LoadOldData";
			this.btnLoadOldData.UseVisualStyleBackColor = true;
			this.btnLoadOldData.Click += new System.EventHandler(this.btnLoadOldData_Click);
			// 
			// itemName
			// 
			this.itemName.Name = "itemName";
			// 
			// itemId
			// 
			this.itemId.Name = "itemId";
			// 
			// itemQuantity
			// 
			this.itemQuantity.Name = "itemQuantity";
			// 
			// discipline
			// 
			this.discipline.Name = "discipline";
			// 
			// karmaPerItem
			// 
			this.karmaPerItem.Name = "karmaPerItem";
			// 
			// karmaTotal
			// 
			this.karmaTotal.Name = "karmaTotal";
			// 
			// labelUsedKarma
			// 
			this.labelUsedKarma.AutoSize = true;
			this.labelUsedKarma.Location = new System.Drawing.Point(595, 689);
			this.labelUsedKarma.Name = "labelUsedKarma";
			this.labelUsedKarma.Size = new System.Drawing.Size(95, 13);
			this.labelUsedKarma.TabIndex = 1;
			this.labelUsedKarma.Text = "Total Karma Used:";
			// 
			// labelKarmaValue
			// 
			this.labelKarmaValue.AutoSize = true;
			this.labelKarmaValue.Location = new System.Drawing.Point(696, 689);
			this.labelKarmaValue.Name = "labelKarmaValue";
			this.labelKarmaValue.Size = new System.Drawing.Size(27, 13);
			this.labelKarmaValue.TabIndex = 2;
			this.labelKarmaValue.Text = "N/A";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(766, 711);
			this.Controls.Add(this.labelKarmaValue);
			this.Controls.Add(this.labelUsedKarma);
			this.Controls.Add(this.tabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "GW2 Investment Tool";
			this.tabControl1.ResumeLayout(false);
			this.Crafting.ResumeLayout(false);
			this.Crafting.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvItemsToCalculate)).EndInit();
			this.NewItems.ResumeLayout(false);
			this.NewItems.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvGuildIngridients)).EndInit();
			this.gbItem.ResumeLayout(false);
			this.gbItem.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvNewItems)).EndInit();
			this.TBD.ResumeLayout(false);
			this.TBD.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvRecipeCompareOldGuildIngredients)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCompareRecipesNewGuildIngredients)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvRecipeCompareOldIngredients)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCompareRecipesNewIngredients)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvRecipeCompareAll)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Crafting;

        private System.Windows.Forms.TabPage NewItems;


        private System.Windows.Forms.DataGridView dgvItemsToCalculate;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnSave;
       // private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Label labelUsedKarma;
        private System.Windows.Forms.Label labelKarmaValue;
        private System.Windows.Forms.Label labelLoadData;
        private System.Windows.Forms.Label labelAddNewItem;
        private System.Windows.Forms.Label labelSave;
        private System.Windows.Forms.Label labelCalculate;
        private System.Windows.Forms.Label labelEdit;
        private DataGridViewTextBoxColumn itemName;
        private DataGridViewTextBoxColumn itemId;
        private DataGridViewTextBoxColumn itemQuantity;
        private DataGridViewTextBoxColumn discipline;
        private DataGridViewTextBoxColumn karmaPerItem;
        private DataGridViewTextBoxColumn karmaTotal;

        #endregion

        private Button btnDelete;
        private Label labelDelete;
        private Button btnWhiteList;
        private Button btnSettings;
        private Label label1;
        private TextBox tbNew;
        private TextBox tbOld;
        private Label label3;
        private Label label2;
        private TabPage TBD;
        private Button btnSearch;
        private GroupBox gbItem;
        private Label label4;
        private DataGridView dgvIngredients;
        private DataGridView dgvNewItems;
        private Label label6;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private DataGridView dgvGuildIngridients;
        private Label labelFlags;
        private Label labelDisciplines;
        private Label labelMinRating;
        private Label labelOutputCount;
        private Label labelType;
        private Label labelName;
        private Label labelRarityValue;
        private Label label5;
        private Label labelDescriptionValue;
        private Label label11;
        private Label labelItemIdValue;
        private Label label12;
        private Label labelRecipeIdValue;
        private Label label13;
		private ComboBox cbLists;
		private GroupBox groupBox1;
		private TextBox tbFilter;
		private RadioButton radioFlags;
		private RadioButton radioDisciplines;
		private RadioButton radioType;
		private RadioButton radioName;
		private Label label14;
		private Button btnFilter;
		private Button btnExport;
		private Button btnLoadOldData;
		protected internal Label label15;
		private DataGridView dgvRecipeCompareAll;
		private Label label17;
		private Label label16;
		private DataGridView dgvRecipeCompareOldIngredients;
		private DataGridView dgvCompareRecipesNewIngredients;
		private DataGridView dgvRecipeCompareOldGuildIngredients;
		private DataGridView dgvCompareRecipesNewGuildIngredients;
	}
}
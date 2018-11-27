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
			this.tabCrafting = new System.Windows.Forms.TabPage();
			this.label18 = new System.Windows.Forms.Label();
			this.craftingControl1 = new gw2_Investment_Tool.Controls.CraftingControl();
			this.NewItems = new System.Windows.Forms.TabPage();
			this.newItemsControl1 = new gw2_Investment_Tool.Controls.NewItemsControl();
			this.compareRecipes = new System.Windows.Forms.TabPage();
			this.recipeCompareControl1 = new gw2_Investment_Tool.Controls.RecipeCompareControl();
			this.extractorTab = new System.Windows.Forms.TabPage();
			this.extractorControl1 = new gw2_Investment_Tool.Controls.ExtractorControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.exoticAndRareSalvageControl1 = new gw2_Investment_Tool.Controls.ExoticAndRareSalvageControl();
			this.itemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.itemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.itemQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.discipline = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.karmaPerItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.karmaTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabControl1.SuspendLayout();
			this.tabCrafting.SuspendLayout();
			this.NewItems.SuspendLayout();
			this.compareRecipes.SuspendLayout();
			this.extractorTab.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabCrafting);
			this.tabControl1.Controls.Add(this.NewItems);
			this.tabControl1.Controls.Add(this.compareRecipes);
			this.tabControl1.Controls.Add(this.extractorTab);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Location = new System.Drawing.Point(4, 2);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(759, 706);
			this.tabControl1.TabIndex = 0;
			// 
			// tabCrafting
			// 
			this.tabCrafting.Controls.Add(this.label18);
			this.tabCrafting.Controls.Add(this.craftingControl1);
			this.tabCrafting.Location = new System.Drawing.Point(4, 22);
			this.tabCrafting.Name = "tabCrafting";
			this.tabCrafting.Padding = new System.Windows.Forms.Padding(3);
			this.tabCrafting.Size = new System.Drawing.Size(751, 680);
			this.tabCrafting.TabIndex = 3;
			this.tabCrafting.Text = "Crafting";
			this.tabCrafting.UseVisualStyleBackColor = true;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(6, 3);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(464, 13);
			this.label18.TabIndex = 1;
			this.label18.Text = "use \"Generate Local Data\" to generate local data to be used in the future (Reduce" +
    " waiting times)";
			// 
			// craftingControl1
			// 
			this.craftingControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.craftingControl1.Location = new System.Drawing.Point(3, 3);
			this.craftingControl1.Name = "craftingControl1";
			this.craftingControl1.Size = new System.Drawing.Size(745, 674);
			this.craftingControl1.TabIndex = 0;
			// 
			// NewItems
			// 
			this.NewItems.Controls.Add(this.newItemsControl1);
			this.NewItems.Location = new System.Drawing.Point(4, 22);
			this.NewItems.Name = "NewItems";
			this.NewItems.Padding = new System.Windows.Forms.Padding(3);
			this.NewItems.Size = new System.Drawing.Size(751, 680);
			this.NewItems.TabIndex = 1;
			this.NewItems.Text = "New Items";
			this.NewItems.UseVisualStyleBackColor = true;
			// 
			// newItemsControl1
			// 
			this.newItemsControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.newItemsControl1.Location = new System.Drawing.Point(3, 3);
			this.newItemsControl1.Name = "newItemsControl1";
			this.newItemsControl1.Size = new System.Drawing.Size(745, 674);
			this.newItemsControl1.TabIndex = 0;
			// 
			// compareRecipes
			// 
			this.compareRecipes.Controls.Add(this.recipeCompareControl1);
			this.compareRecipes.Location = new System.Drawing.Point(4, 22);
			this.compareRecipes.Name = "compareRecipes";
			this.compareRecipes.Padding = new System.Windows.Forms.Padding(3);
			this.compareRecipes.Size = new System.Drawing.Size(751, 680);
			this.compareRecipes.TabIndex = 2;
			this.compareRecipes.Text = "Compare recipes";
			this.compareRecipes.UseVisualStyleBackColor = true;
			// 
			// recipeCompareControl1
			// 
			this.recipeCompareControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.recipeCompareControl1.Location = new System.Drawing.Point(3, 3);
			this.recipeCompareControl1.Name = "recipeCompareControl1";
			this.recipeCompareControl1.Size = new System.Drawing.Size(745, 674);
			this.recipeCompareControl1.TabIndex = 0;
			// 
			// extractorTab
			// 
			this.extractorTab.Controls.Add(this.extractorControl1);
			this.extractorTab.Location = new System.Drawing.Point(4, 22);
			this.extractorTab.Name = "extractorTab";
			this.extractorTab.Padding = new System.Windows.Forms.Padding(3);
			this.extractorTab.Size = new System.Drawing.Size(751, 680);
			this.extractorTab.TabIndex = 4;
			this.extractorTab.Text = "Extraction Profitablility";
			this.extractorTab.UseVisualStyleBackColor = true;
			// 
			// extractorControl1
			// 
			this.extractorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.extractorControl1.Location = new System.Drawing.Point(3, 3);
			this.extractorControl1.Name = "extractorControl1";
			this.extractorControl1.Size = new System.Drawing.Size(745, 674);
			this.extractorControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.exoticAndRareSalvageControl1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(751, 680);
			this.tabPage1.TabIndex = 5;
			this.tabPage1.Text = "Exotic Salvage";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// exoticAndRareSalvageControl1
			// 
			this.exoticAndRareSalvageControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.exoticAndRareSalvageControl1.Location = new System.Drawing.Point(3, 3);
			this.exoticAndRareSalvageControl1.Name = "exoticAndRareSalvageControl1";
			this.exoticAndRareSalvageControl1.Size = new System.Drawing.Size(745, 674);
			this.exoticAndRareSalvageControl1.TabIndex = 0;
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
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(766, 711);
			this.Controls.Add(this.tabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "GW2 Investment Tool";
			this.tabControl1.ResumeLayout(false);
			this.tabCrafting.ResumeLayout(false);
			this.tabCrafting.PerformLayout();
			this.NewItems.ResumeLayout(false);
			this.compareRecipes.ResumeLayout(false);
			this.extractorTab.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.ResumeLayout(false);

        }
        private System.Windows.Forms.TabControl tabControl1;

        private System.Windows.Forms.TabPage NewItems;
        private DataGridViewTextBoxColumn itemName;
        private DataGridViewTextBoxColumn itemId;
        private DataGridViewTextBoxColumn itemQuantity;
        private DataGridViewTextBoxColumn discipline;
        private DataGridViewTextBoxColumn karmaPerItem;
        private DataGridViewTextBoxColumn karmaTotal;

        #endregion
        private TabPage compareRecipes;
		private TabPage tabCrafting;
		private Controls.CraftingControl craftingControl1;
		private Label label18;
		private Controls.NewItemsControl newItemsControl1;
		private Controls.RecipeCompareControl recipeCompareControl1;
		private TabPage extractorTab;
		private Controls.ExtractorControl extractorControl1;
		private TabPage tabPage1;
		private Controls.ExoticAndRareSalvageControl exoticAndRareSalvageControl1;
	}
}
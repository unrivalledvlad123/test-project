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
			this.NewItems = new System.Windows.Forms.TabPage();
			this.TBD = new System.Windows.Forms.TabPage();
			this.itemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.itemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.itemQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.discipline = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.karmaPerItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.karmaTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.craftingControl1 = new gw2_Investment_Tool.Controls.CraftingControl();
			this.newItemsControl1 = new gw2_Investment_Tool.Controls.NewItemsControl();
			this.recipeCompareControl1 = new gw2_Investment_Tool.Controls.RecipeCompareControl();
			this.tabControl1.SuspendLayout();
			this.tabCrafting.SuspendLayout();
			this.NewItems.SuspendLayout();
			this.TBD.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabCrafting);
			this.tabControl1.Controls.Add(this.NewItems);
			this.tabControl1.Controls.Add(this.TBD);
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
			this.label18.Size = new System.Drawing.Size(208, 13);
			this.label18.TabIndex = 1;
			this.label18.Text = "use \"Generate Local Data\" to generate da";
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
			// TBD
			// 
			this.TBD.Controls.Add(this.recipeCompareControl1);
			this.TBD.Location = new System.Drawing.Point(4, 22);
			this.TBD.Name = "TBD";
			this.TBD.Padding = new System.Windows.Forms.Padding(3);
			this.TBD.Size = new System.Drawing.Size(751, 680);
			this.TBD.TabIndex = 2;
			this.TBD.Text = "Compare recipes";
			this.TBD.UseVisualStyleBackColor = true;
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
			this.TBD.ResumeLayout(false);
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
        private TabPage TBD;
		private TabPage tabCrafting;
		private Controls.CraftingControl craftingControl1;
		private Label label18;
		private Controls.NewItemsControl newItemsControl1;
		private Controls.RecipeCompareControl recipeCompareControl1;
	}
}
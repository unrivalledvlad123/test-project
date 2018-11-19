namespace gw2_Investment_Tool.Controls
{
	partial class RecipeCompareControl
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
			this.dgvRecipeCompareOldGuildIngredients = new System.Windows.Forms.DataGridView();
			this.dgvCompareRecipesNewGuildIngredients = new System.Windows.Forms.DataGridView();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.dgvRecipeCompareOldIngredients = new System.Windows.Forms.DataGridView();
			this.dgvCompareRecipesNewIngredients = new System.Windows.Forms.DataGridView();
			this.dgvRecipeCompareAll = new System.Windows.Forms.DataGridView();
			this.label15 = new System.Windows.Forms.Label();
			this.btnLoadOldData = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvRecipeCompareOldGuildIngredients)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCompareRecipesNewGuildIngredients)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvRecipeCompareOldIngredients)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCompareRecipesNewIngredients)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvRecipeCompareAll)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvRecipeCompareOldGuildIngredients
			// 
			this.dgvRecipeCompareOldGuildIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvRecipeCompareOldGuildIngredients.Location = new System.Drawing.Point(376, 489);
			this.dgvRecipeCompareOldGuildIngredients.Name = "dgvRecipeCompareOldGuildIngredients";
			this.dgvRecipeCompareOldGuildIngredients.ReadOnly = true;
			this.dgvRecipeCompareOldGuildIngredients.Size = new System.Drawing.Size(351, 150);
			this.dgvRecipeCompareOldGuildIngredients.TabIndex = 17;
			// 
			// dgvCompareRecipesNewGuildIngredients
			// 
			this.dgvCompareRecipesNewGuildIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCompareRecipesNewGuildIngredients.Location = new System.Drawing.Point(2, 489);
			this.dgvCompareRecipesNewGuildIngredients.Name = "dgvCompareRecipesNewGuildIngredients";
			this.dgvCompareRecipesNewGuildIngredients.ReadOnly = true;
			this.dgvCompareRecipesNewGuildIngredients.Size = new System.Drawing.Size(351, 150);
			this.dgvCompareRecipesNewGuildIngredients.TabIndex = 16;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(374, 314);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(109, 13);
			this.label17.TabIndex = 15;
			this.label17.Text = "Old recipe ingredients";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(-1, 314);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(115, 13);
			this.label16.TabIndex = 14;
			this.label16.Text = "New recipe ingredients";
			// 
			// dgvRecipeCompareOldIngredients
			// 
			this.dgvRecipeCompareOldIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvRecipeCompareOldIngredients.Location = new System.Drawing.Point(377, 333);
			this.dgvRecipeCompareOldIngredients.Name = "dgvRecipeCompareOldIngredients";
			this.dgvRecipeCompareOldIngredients.ReadOnly = true;
			this.dgvRecipeCompareOldIngredients.Size = new System.Drawing.Size(350, 150);
			this.dgvRecipeCompareOldIngredients.TabIndex = 13;
			// 
			// dgvCompareRecipesNewIngredients
			// 
			this.dgvCompareRecipesNewIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCompareRecipesNewIngredients.Location = new System.Drawing.Point(2, 333);
			this.dgvCompareRecipesNewIngredients.Name = "dgvCompareRecipesNewIngredients";
			this.dgvCompareRecipesNewIngredients.ReadOnly = true;
			this.dgvCompareRecipesNewIngredients.Size = new System.Drawing.Size(351, 150);
			this.dgvCompareRecipesNewIngredients.TabIndex = 12;
			// 
			// dgvRecipeCompareAll
			// 
			this.dgvRecipeCompareAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvRecipeCompareAll.Location = new System.Drawing.Point(2, 68);
			this.dgvRecipeCompareAll.Name = "dgvRecipeCompareAll";
			this.dgvRecipeCompareAll.ReadOnly = true;
			this.dgvRecipeCompareAll.Size = new System.Drawing.Size(725, 241);
			this.dgvRecipeCompareAll.TabIndex = 11;
			this.dgvRecipeCompareAll.SelectionChanged += new System.EventHandler(this.dgvRecipeCompareAll_SelectionChanged);
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(3, 0);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(724, 36);
			this.label15.TabIndex = 10;
			this.label15.Text = "Instructions: load the old data json with the button. This tool will show you the" +
    " difference between the data you loaded and the current crafting recipe for the " +
    "item";
			// 
			// btnLoadOldData
			// 
			this.btnLoadOldData.Location = new System.Drawing.Point(2, 39);
			this.btnLoadOldData.Name = "btnLoadOldData";
			this.btnLoadOldData.Size = new System.Drawing.Size(75, 23);
			this.btnLoadOldData.TabIndex = 9;
			this.btnLoadOldData.Text = "LoadOldData";
			this.btnLoadOldData.UseVisualStyleBackColor = true;
			this.btnLoadOldData.Click += new System.EventHandler(this.btnLoadOldData_Click);
			// 
			// RecipeCompareControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.dgvRecipeCompareOldGuildIngredients);
			this.Controls.Add(this.dgvCompareRecipesNewGuildIngredients);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.dgvRecipeCompareOldIngredients);
			this.Controls.Add(this.dgvCompareRecipesNewIngredients);
			this.Controls.Add(this.dgvRecipeCompareAll);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.btnLoadOldData);
			this.Name = "RecipeCompareControl";
			this.Size = new System.Drawing.Size(733, 645);
			((System.ComponentModel.ISupportInitialize)(this.dgvRecipeCompareOldGuildIngredients)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCompareRecipesNewGuildIngredients)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvRecipeCompareOldIngredients)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCompareRecipesNewIngredients)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvRecipeCompareAll)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvRecipeCompareOldGuildIngredients;
		private System.Windows.Forms.DataGridView dgvCompareRecipesNewGuildIngredients;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.DataGridView dgvRecipeCompareOldIngredients;
		private System.Windows.Forms.DataGridView dgvCompareRecipesNewIngredients;
		private System.Windows.Forms.DataGridView dgvRecipeCompareAll;
		protected internal System.Windows.Forms.Label label15;
		private System.Windows.Forms.Button btnLoadOldData;
	}
}

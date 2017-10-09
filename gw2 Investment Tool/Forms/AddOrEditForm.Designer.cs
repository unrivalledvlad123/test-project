using System;
using System.Windows.Forms;

namespace gw2_Investment_Tool.Forms
{
    partial class AddOrEditForm
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
			this.tbItemId = new System.Windows.Forms.TextBox();
			this.tbQuantity = new System.Windows.Forms.TextBox();
			this.tbDiscipline = new System.Windows.Forms.TextBox();
			this.labelItemId = new System.Windows.Forms.Label();
			this.labelQuantity = new System.Windows.Forms.Label();
			this.labelDiscipline = new System.Windows.Forms.Label();
			this.labelKarmaPerItem = new System.Windows.Forms.Label();
			this.cbActive = new System.Windows.Forms.CheckBox();
			this.labelActive = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.tbKarmaPerItem = new System.Windows.Forms.TextBox();
			this.tbSearch = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dgvSearchResults = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).BeginInit();
			this.SuspendLayout();
			// 
			// tbItemId
			// 
			this.tbItemId.Location = new System.Drawing.Point(107, 284);
			this.tbItemId.Name = "tbItemId";
			this.tbItemId.Size = new System.Drawing.Size(284, 20);
			this.tbItemId.TabIndex = 0;
			// 
			// tbQuantity
			// 
			this.tbQuantity.Location = new System.Drawing.Point(107, 317);
			this.tbQuantity.Name = "tbQuantity";
			this.tbQuantity.Size = new System.Drawing.Size(284, 20);
			this.tbQuantity.TabIndex = 1;
			// 
			// tbDiscipline
			// 
			this.tbDiscipline.Location = new System.Drawing.Point(107, 352);
			this.tbDiscipline.Name = "tbDiscipline";
			this.tbDiscipline.Size = new System.Drawing.Size(284, 20);
			this.tbDiscipline.TabIndex = 2;
			// 
			// labelItemId
			// 
			this.labelItemId.AutoSize = true;
			this.labelItemId.Location = new System.Drawing.Point(13, 287);
			this.labelItemId.Name = "labelItemId";
			this.labelItemId.Size = new System.Drawing.Size(45, 13);
			this.labelItemId.TabIndex = 4;
			this.labelItemId.Text = "Item ID*";
			// 
			// labelQuantity
			// 
			this.labelQuantity.AutoSize = true;
			this.labelQuantity.Location = new System.Drawing.Point(13, 320);
			this.labelQuantity.Name = "labelQuantity";
			this.labelQuantity.Size = new System.Drawing.Size(50, 13);
			this.labelQuantity.TabIndex = 5;
			this.labelQuantity.Text = "Quantity*";
			// 
			// labelDiscipline
			// 
			this.labelDiscipline.AutoSize = true;
			this.labelDiscipline.Location = new System.Drawing.Point(13, 355);
			this.labelDiscipline.Name = "labelDiscipline";
			this.labelDiscipline.Size = new System.Drawing.Size(52, 13);
			this.labelDiscipline.TabIndex = 6;
			this.labelDiscipline.Text = "Discipline";
			// 
			// labelKarmaPerItem
			// 
			this.labelKarmaPerItem.AutoSize = true;
			this.labelKarmaPerItem.Location = new System.Drawing.Point(13, 391);
			this.labelKarmaPerItem.Name = "labelKarmaPerItem";
			this.labelKarmaPerItem.Size = new System.Drawing.Size(79, 13);
			this.labelKarmaPerItem.TabIndex = 7;
			this.labelKarmaPerItem.Text = "Karma Per Item";
			// 
			// cbActive
			// 
			this.cbActive.AutoSize = true;
			this.cbActive.Location = new System.Drawing.Point(107, 424);
			this.cbActive.Name = "cbActive";
			this.cbActive.Size = new System.Drawing.Size(15, 14);
			this.cbActive.TabIndex = 8;
			this.cbActive.UseVisualStyleBackColor = true;
			// 
			// labelActive
			// 
			this.labelActive.AutoSize = true;
			this.labelActive.Location = new System.Drawing.Point(13, 424);
			this.labelActive.Name = "labelActive";
			this.labelActive.Size = new System.Drawing.Size(80, 13);
			this.labelActive.TabIndex = 9;
			this.labelActive.Text = "Active/Inactive";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(316, 494);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 10;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Location = new System.Drawing.Point(235, 494);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 11;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// tbKarmaPerItem
			// 
			this.tbKarmaPerItem.Location = new System.Drawing.Point(107, 388);
			this.tbKarmaPerItem.Name = "tbKarmaPerItem";
			this.tbKarmaPerItem.Size = new System.Drawing.Size(284, 20);
			this.tbKarmaPerItem.TabIndex = 12;
			this.tbKarmaPerItem.Text = "0";
			// 
			// tbSearch
			// 
			this.tbSearch.Location = new System.Drawing.Point(16, 55);
			this.tbSearch.Name = "tbSearch";
			this.tbSearch.Size = new System.Drawing.Size(375, 20);
			this.tbSearch.TabIndex = 13;
			this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.MaximumSize = new System.Drawing.Size(220, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(213, 39);
			this.label1.TabIndex = 14;
			this.label1.Text = "To search by item name you must 1st generate a local database from the settings m" +
    "enu.";
			// 
			// dgvSearchResults
			// 
			this.dgvSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSearchResults.Location = new System.Drawing.Point(16, 81);
			this.dgvSearchResults.Name = "dgvSearchResults";
			this.dgvSearchResults.Size = new System.Drawing.Size(375, 185);
			this.dgvSearchResults.TabIndex = 15;
			this.dgvSearchResults.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearchResult_CellSelected);
			// 
			// AddOrEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(403, 529);
			this.Controls.Add(this.dgvSearchResults);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbSearch);
			this.Controls.Add(this.tbKarmaPerItem);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.labelActive);
			this.Controls.Add(this.cbActive);
			this.Controls.Add(this.labelKarmaPerItem);
			this.Controls.Add(this.labelDiscipline);
			this.Controls.Add(this.labelQuantity);
			this.Controls.Add(this.labelItemId);
			this.Controls.Add(this.tbDiscipline);
			this.Controls.Add(this.tbQuantity);
			this.Controls.Add(this.tbItemId);
			this.Name = "AddOrEditForm";
			this.Text = "Add / Edit Item";
			((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbItemId;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.TextBox tbDiscipline;
        private System.Windows.Forms.Label labelItemId;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.Label labelDiscipline;
        private System.Windows.Forms.Label labelKarmaPerItem;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.Label labelActive;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbKarmaPerItem;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSearchResults;
	}
}
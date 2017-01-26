using System.Windows.Forms;

namespace gw2_Investment_Tool
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Crafting = new System.Windows.Forms.TabPage();
            this.labelSave = new System.Windows.Forms.Label();
            this.labelCalculate = new System.Windows.Forms.Label();
            this.labelEdit = new System.Windows.Forms.Label();
            this.labelAddNewItem = new System.Windows.Forms.Label();
            this.labelLoadData = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.dgvItemsToCalculate = new System.Windows.Forms.DataGridView();
            this.itemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discipline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.karmaPerItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.karmaTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TBD = new System.Windows.Forms.TabPage();
            this.labelUsedKarma = new System.Windows.Forms.Label();
            this.labelKarmaValue = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.Crafting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsToCalculate)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Crafting);
            this.tabControl1.Controls.Add(this.TBD);
            this.tabControl1.Location = new System.Drawing.Point(12, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(745, 503);
            this.tabControl1.TabIndex = 0;
            // 
            // Crafting
            // 
            this.Crafting.Controls.Add(this.labelSave);
            this.Crafting.Controls.Add(this.labelCalculate);
            this.Crafting.Controls.Add(this.labelEdit);
            this.Crafting.Controls.Add(this.labelAddNewItem);
            this.Crafting.Controls.Add(this.labelLoadData);
            this.Crafting.Controls.Add(this.btnCalculate);
            this.Crafting.Controls.Add(this.btnSave);
            this.Crafting.Controls.Add(this.btnEdit);
            this.Crafting.Controls.Add(this.btnAddItem);
            this.Crafting.Controls.Add(this.btnLoadData);
            this.Crafting.Controls.Add(this.dgvItemsToCalculate);
            this.Crafting.Location = new System.Drawing.Point(4, 22);
            this.Crafting.Name = "Crafting";
            this.Crafting.Padding = new System.Windows.Forms.Padding(3);
            this.Crafting.Size = new System.Drawing.Size(737, 477);
            this.Crafting.TabIndex = 0;
            this.Crafting.Text = "Crafting";
            this.Crafting.UseVisualStyleBackColor = true;
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
            this.labelEdit.Size = new System.Drawing.Size(256, 13);
            this.labelEdit.TabIndex = 9;
            this.labelEdit.Text = "Use \"Edit Item\" button to edit currently selected item.";
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
            this.labelLoadData.Size = new System.Drawing.Size(233, 13);
            this.labelLoadData.TabIndex = 7;
            this.labelLoadData.Text = "Use \"Load Data\" button to initialy load the data.";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(267, 186);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 6;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(348, 186);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save Data";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(186, 186);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit Item";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(87, 186);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(93, 23);
            this.btnAddItem.TabIndex = 3;
            this.btnAddItem.Text = "Add New Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(6, 186);
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
            this.dgvItemsToCalculate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemName,
            this.itemId,
            this.itemQuantity,
            this.discipline,
            this.karmaPerItem,
            this.karmaTotal});
            this.dgvItemsToCalculate.Location = new System.Drawing.Point(0, 215);
            this.dgvItemsToCalculate.Name = "dgvItemsToCalculate";
            this.dgvItemsToCalculate.Size = new System.Drawing.Size(731, 259);
            this.dgvItemsToCalculate.TabIndex = 1;
            // 
            // itemName
            // 
            this.itemName.HeaderText = "Item Name";
            this.itemName.Name = "itemName";
            this.itemName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.itemName.Width = 200;
            // 
            // itemId
            // 
            this.itemId.HeaderText = "Item ID";
            this.itemId.Name = "itemId";
            // 
            // itemQuantity
            // 
            this.itemQuantity.HeaderText = "Quantity";
            this.itemQuantity.Name = "itemQuantity";
            // 
            // discipline
            // 
            this.discipline.HeaderText = "Discipline";
            this.discipline.Name = "discipline";
            // 
            // karmaPerItem
            // 
            this.karmaPerItem.HeaderText = "Karma per Item";
            this.karmaPerItem.Name = "karmaPerItem";
            // 
            // karmaTotal
            // 
            this.karmaTotal.HeaderText = "Karma Total";
            this.karmaTotal.Name = "karmaTotal";
            // 
            // TBD
            // 
            this.TBD.Location = new System.Drawing.Point(4, 22);
            this.TBD.Name = "TBD";
            this.TBD.Padding = new System.Windows.Forms.Padding(3);
            this.TBD.Size = new System.Drawing.Size(737, 477);
            this.TBD.TabIndex = 1;
            this.TBD.Text = "TBD";
            this.TBD.UseVisualStyleBackColor = true;
            // 
            // labelUsedKarma
            // 
            this.labelUsedKarma.AutoSize = true;
            this.labelUsedKarma.Location = new System.Drawing.Point(556, 512);
            this.labelUsedKarma.Name = "labelUsedKarma";
            this.labelUsedKarma.Size = new System.Drawing.Size(95, 13);
            this.labelUsedKarma.TabIndex = 1;
            this.labelUsedKarma.Text = "Total Karma Used:";
            // 
            // labelKarmaValue
            // 
            this.labelKarmaValue.AutoSize = true;
            this.labelKarmaValue.Location = new System.Drawing.Point(695, 512);
            this.labelKarmaValue.Name = "labelKarmaValue";
            this.labelKarmaValue.Size = new System.Drawing.Size(27, 13);
            this.labelKarmaValue.TabIndex = 2;
            this.labelKarmaValue.Text = "N/A";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 536);
            this.Controls.Add(this.labelKarmaValue);
            this.Controls.Add(this.labelUsedKarma);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "GW2 Investment Tool";
            this.tabControl1.ResumeLayout(false);
            this.Crafting.ResumeLayout(false);
            this.Crafting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsToCalculate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Crafting;

        private System.Windows.Forms.TabPage TBD;
            

        private System.Windows.Forms.DataGridView dgvItemsToCalculate;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
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
    }
}


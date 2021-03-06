﻿namespace gw2_Investment_Tool.Forms
{
    partial class ResultForm
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
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colomn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelTotal = new System.Windows.Forms.Label();
            this.btnRecalculate = new System.Windows.Forms.Button();
            this.labelProfit = new System.Windows.Forms.Label();
            this.labelTotalPerKarmaValue = new System.Windows.Forms.Label();
            this.labelText1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelROI = new System.Windows.Forms.Label();
            this.gvcTotalValue = new gw2_Investment_Tool.Controls.GoldValueControl();
            this.gvcTotalPerKarmaValue = new gw2_Investment_Tool.Controls.GoldValueControl();
            this.gvcProfitValue = new gw2_Investment_Tool.Controls.GoldValueControl();
            this.btnSelectAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvResults
            // 
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Colomn3,
            this.Column4});
            this.dgvResults.Location = new System.Drawing.Point(12, 46);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.Size = new System.Drawing.Size(644, 537);
            this.dgvResults.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.Name = "Column2";
            // 
            // Colomn3
            // 
            this.Colomn3.Name = "Colomn3";
            // 
            // Column4
            // 
            this.Column4.Name = "Column4";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(442, 636);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(58, 13);
            this.labelTotal.TabIndex = 1;
            this.labelTotal.Text = "Total Cost:";
            // 
            // btnRecalculate
            // 
            this.btnRecalculate.Location = new System.Drawing.Point(12, 589);
            this.btnRecalculate.Name = "btnRecalculate";
            this.btnRecalculate.Size = new System.Drawing.Size(75, 23);
            this.btnRecalculate.TabIndex = 3;
            this.btnRecalculate.Text = "Recalculate";
            this.btnRecalculate.UseVisualStyleBackColor = true;
            this.btnRecalculate.Click += new System.EventHandler(this.btnRecalculate_Click);
            // 
            // labelProfit
            // 
            this.labelProfit.AutoSize = true;
            this.labelProfit.Location = new System.Drawing.Point(12, 615);
            this.labelProfit.Name = "labelProfit";
            this.labelProfit.Size = new System.Drawing.Size(101, 13);
            this.labelProfit.TabIndex = 4;
            this.labelProfit.Text = "Total profit after tax:";
            // 
            // labelTotalPerKarmaValue
            // 
            this.labelTotalPerKarmaValue.AutoSize = true;
            this.labelTotalPerKarmaValue.Location = new System.Drawing.Point(129, 636);
            this.labelTotalPerKarmaValue.Name = "labelTotalPerKarmaValue";
            this.labelTotalPerKarmaValue.Size = new System.Drawing.Size(146, 13);
            this.labelTotalPerKarmaValue.TabIndex = 7;
            this.labelTotalPerKarmaValue.Text = "34 Gold, 43 Silver, 44 Copper";
            // 
            // labelText1
            // 
            this.labelText1.AutoSize = true;
            this.labelText1.Location = new System.Drawing.Point(12, 636);
            this.labelText1.Name = "labelText1";
            this.labelText1.Size = new System.Drawing.Size(114, 13);
            this.labelText1.TabIndex = 8;
            this.labelText1.Text = "Profit per 1000 karma :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(442, 615);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "ROI:";
            // 
            // labelROI
            // 
            this.labelROI.AutoSize = true;
            this.labelROI.Location = new System.Drawing.Point(503, 615);
            this.labelROI.Name = "labelROI";
            this.labelROI.Size = new System.Drawing.Size(35, 13);
            this.labelROI.TabIndex = 10;
            this.labelROI.Text = "label2";
            // 
            // gvcTotalValue
            // 
            this.gvcTotalValue.Location = new System.Drawing.Point(506, 634);
            this.gvcTotalValue.Name = "gvcTotalValue";
            this.gvcTotalValue.Size = new System.Drawing.Size(133, 15);
            this.gvcTotalValue.TabIndex = 13;
            // 
            // gvcTotalPerKarmaValue
            // 
            this.gvcTotalPerKarmaValue.Location = new System.Drawing.Point(132, 634);
            this.gvcTotalPerKarmaValue.Name = "gvcTotalPerKarmaValue";
            this.gvcTotalPerKarmaValue.Size = new System.Drawing.Size(133, 15);
            this.gvcTotalPerKarmaValue.TabIndex = 12;
            // 
            // gvcProfitValue
            // 
            this.gvcProfitValue.Location = new System.Drawing.Point(132, 613);
            this.gvcProfitValue.Name = "gvcProfitValue";
            this.gvcProfitValue.Size = new System.Drawing.Size(133, 15);
            this.gvcProfitValue.TabIndex = 11;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(93, 589);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 14;
            this.btnSelectAll.Text = "Select all";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 658);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.gvcTotalValue);
            this.Controls.Add(this.gvcTotalPerKarmaValue);
            this.Controls.Add(this.gvcProfitValue);
            this.Controls.Add(this.labelROI);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelText1);
            this.Controls.Add(this.labelTotalPerKarmaValue);
            this.Controls.Add(this.labelProfit);
            this.Controls.Add(this.btnRecalculate);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.dgvResults);
            this.Name = "ResultForm";
            this.Text = "Items to Buy";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colomn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button btnRecalculate;
        private System.Windows.Forms.Label labelProfit;
        private System.Windows.Forms.Label labelTotalPerKarmaValue;
        private System.Windows.Forms.Label labelText1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelROI;
		private Controls.GoldValueControl gvcProfitValue;
		private Controls.GoldValueControl gvcTotalPerKarmaValue;
		private Controls.GoldValueControl gvcTotalValue;
        private System.Windows.Forms.Button btnSelectAll;
    }
}
namespace gw2_Investment_Tool.Controls
{
	partial class ExtractorControl
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
            this.dgvExtractableitems = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSupperiors = new System.Windows.Forms.RadioButton();
            this.rbMajors = new System.Windows.Forms.RadioButton();
            this.rbMinor = new System.Windows.Forms.RadioButton();
            this.rbRunes = new System.Windows.Forms.RadioButton();
            this.rbSigils = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnReload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtractableitems)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvExtractableitems
            // 
            this.dgvExtractableitems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExtractableitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExtractableitems.Location = new System.Drawing.Point(3, 55);
            this.dgvExtractableitems.Name = "dgvExtractableitems";
            this.dgvExtractableitems.Size = new System.Drawing.Size(645, 596);
            this.dgvExtractableitems.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(573, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSupperiors);
            this.groupBox1.Controls.Add(this.rbMajors);
            this.groupBox1.Controls.Add(this.rbMinor);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 46);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // rbSupperiors
            // 
            this.rbSupperiors.AutoSize = true;
            this.rbSupperiors.Location = new System.Drawing.Point(176, 19);
            this.rbSupperiors.Name = "rbSupperiors";
            this.rbSupperiors.Size = new System.Drawing.Size(97, 17);
            this.rbSupperiors.TabIndex = 2;
            this.rbSupperiors.TabStop = true;
            this.rbSupperiors.Text = "Supperiors only";
            this.rbSupperiors.UseVisualStyleBackColor = true;
            // 
            // rbMajors
            // 
            this.rbMajors.AutoSize = true;
            this.rbMajors.Location = new System.Drawing.Point(91, 19);
            this.rbMajors.Name = "rbMajors";
            this.rbMajors.Size = new System.Drawing.Size(78, 17);
            this.rbMajors.TabIndex = 1;
            this.rbMajors.TabStop = true;
            this.rbMajors.Text = "Majors only";
            this.rbMajors.UseVisualStyleBackColor = true;
            // 
            // rbMinor
            // 
            this.rbMinor.AutoSize = true;
            this.rbMinor.Location = new System.Drawing.Point(6, 19);
            this.rbMinor.Name = "rbMinor";
            this.rbMinor.Size = new System.Drawing.Size(78, 17);
            this.rbMinor.TabIndex = 0;
            this.rbMinor.TabStop = true;
            this.rbMinor.Text = "Minors only";
            this.rbMinor.UseVisualStyleBackColor = true;
            // 
            // rbRunes
            // 
            this.rbRunes.AutoSize = true;
            this.rbRunes.Location = new System.Drawing.Point(6, 19);
            this.rbRunes.Name = "rbRunes";
            this.rbRunes.Size = new System.Drawing.Size(56, 17);
            this.rbRunes.TabIndex = 3;
            this.rbRunes.TabStop = true;
            this.rbRunes.Text = "Runes";
            this.rbRunes.UseVisualStyleBackColor = true;
            // 
            // rbSigils
            // 
            this.rbSigils.AutoSize = true;
            this.rbSigils.Location = new System.Drawing.Point(91, 19);
            this.rbSigils.Name = "rbSigils";
            this.rbSigils.Size = new System.Drawing.Size(49, 17);
            this.rbSigils.TabIndex = 4;
            this.rbSigils.TabStop = true;
            this.rbSigils.Text = "Sigils";
            this.rbSigils.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbSigils);
            this.groupBox2.Controls.Add(this.rbRunes);
            this.groupBox2.Location = new System.Drawing.Point(363, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(204, 46);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(573, 26);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 4;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // ExtractorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvExtractableitems);
            this.Name = "ExtractorControl";
            this.Size = new System.Drawing.Size(651, 654);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtractableitems)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvExtractableitems;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbSupperiors;
		private System.Windows.Forms.RadioButton rbMajors;
		private System.Windows.Forms.RadioButton rbMinor;
		private System.Windows.Forms.RadioButton rbSigils;
		private System.Windows.Forms.RadioButton rbRunes;
		private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnReload;
    }
}

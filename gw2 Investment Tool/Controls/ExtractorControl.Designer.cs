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
			this.rbMinor = new System.Windows.Forms.RadioButton();
			this.rbMajors = new System.Windows.Forms.RadioButton();
			this.rbSupperiors = new System.Windows.Forms.RadioButton();
			this.rbRunes = new System.Windows.Forms.RadioButton();
			this.rbSigils = new System.Windows.Forms.RadioButton();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
			((System.ComponentModel.ISupportInitialize)(this.dgvExtractableitems)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgvExtractableitems
			// 
			this.dgvExtractableitems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvExtractableitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvExtractableitems.Location = new System.Drawing.Point(3, 70);
			this.dgvExtractableitems.Name = "dgvExtractableitems";
			this.dgvExtractableitems.Size = new System.Drawing.Size(645, 581);
			this.dgvExtractableitems.TabIndex = 0;
			// 
			// btnSearch
			// 
			this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSearch.Location = new System.Drawing.Point(573, 41);
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
			this.groupBox1.Size = new System.Drawing.Size(354, 61);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Filter";
			// 
			// rbMinor
			// 
			this.rbMinor.AutoSize = true;
			this.rbMinor.Location = new System.Drawing.Point(7, 38);
			this.rbMinor.Name = "rbMinor";
			this.rbMinor.Size = new System.Drawing.Size(78, 17);
			this.rbMinor.TabIndex = 0;
			this.rbMinor.TabStop = true;
			this.rbMinor.Text = "Minors only";
			this.rbMinor.UseVisualStyleBackColor = true;
			// 
			// rbMajors
			// 
			this.rbMajors.AutoSize = true;
			this.rbMajors.Location = new System.Drawing.Point(92, 38);
			this.rbMajors.Name = "rbMajors";
			this.rbMajors.Size = new System.Drawing.Size(78, 17);
			this.rbMajors.TabIndex = 1;
			this.rbMajors.TabStop = true;
			this.rbMajors.Text = "Majors only";
			this.rbMajors.UseVisualStyleBackColor = true;
			// 
			// rbSupperiors
			// 
			this.rbSupperiors.AutoSize = true;
			this.rbSupperiors.Location = new System.Drawing.Point(177, 38);
			this.rbSupperiors.Name = "rbSupperiors";
			this.rbSupperiors.Size = new System.Drawing.Size(97, 17);
			this.rbSupperiors.TabIndex = 2;
			this.rbSupperiors.TabStop = true;
			this.rbSupperiors.Text = "Supperiors only";
			this.rbSupperiors.UseVisualStyleBackColor = true;
			// 
			// rbRunes
			// 
			this.rbRunes.AutoSize = true;
			this.rbRunes.Location = new System.Drawing.Point(6, 38);
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
			this.rbSigils.Location = new System.Drawing.Point(91, 38);
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
			this.groupBox2.Size = new System.Drawing.Size(204, 61);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			// 
			// ExtractorControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.ComponentModel.BackgroundWorker backgroundWorker2;
	}
}

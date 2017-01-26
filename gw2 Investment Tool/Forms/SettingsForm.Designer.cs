

namespace gw2_Investment_Tool.Forms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCurrentItems = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbWhiteListedItems = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSearchLocation = new System.Windows.Forms.TextBox();
            this.btnSaveExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.MaximumSize = new System.Drawing.Size(258, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 104);
            this.label1.TabIndex = 1;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(186, 113);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(84, 23);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(btnGenerate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Current Item location:";
            // 
            // tbCurrentItems
            // 
            tbCurrentItems.Location = new System.Drawing.Point(15, 158);
            this.tbCurrentItems.Name = "tbCurrentItems";
            this.tbCurrentItems.Size = new System.Drawing.Size(255, 20);
            this.tbCurrentItems.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Whitelisted Item location:";
            // 
            // tbWhiteListedItems
            // 
            this.tbWhiteListedItems.Location = new System.Drawing.Point(15, 201);
            this.tbWhiteListedItems.Name = "tbWhiteListedItems";
            this.tbWhiteListedItems.Size = new System.Drawing.Size(255, 20);
            this.tbWhiteListedItems.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Name Search File location:";
            // 
            // tbSearchLocation
            // 
            this.tbSearchLocation.Location = new System.Drawing.Point(15, 250);
            this.tbSearchLocation.Name = "tbSearchLocation";
            this.tbSearchLocation.Size = new System.Drawing.Size(255, 20);
            this.tbSearchLocation.TabIndex = 9;
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSaveExit.Location = new System.Drawing.Point(186, 332);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(84, 23);
            this.btnSaveExit.TabIndex = 10;
            this.btnSaveExit.Text = "Save and Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 367);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.tbSearchLocation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbWhiteListedItems);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCurrentItems);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label1);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCurrentItems;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbWhiteListedItems;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSearchLocation;
        private System.Windows.Forms.Button btnSaveExit;
    }
}
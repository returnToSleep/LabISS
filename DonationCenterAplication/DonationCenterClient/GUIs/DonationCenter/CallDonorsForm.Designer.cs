namespace Client.GUIs.DonationCenter
{
    partial class CallDonorsForm
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
            this.warningLabel = new System.Windows.Forms.Label();
            this.donorList = new NishBox.MultiLineListBox();
            this.contactButton = new System.Windows.Forms.Button();
            this.forwardButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.warningLabel.Location = new System.Drawing.Point(2, 9);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(468, 20);
            this.warningLabel.TabIndex = 0;
            this.warningLabel.Text = "Nu exista suficient sange pe stoc pentru a satisface cererea: ";
            // 
            // donorList
            // 
            this.donorList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.donorList.FormattingEnabled = true;
            this.donorList.Location = new System.Drawing.Point(6, 156);
            this.donorList.Name = "donorList";
            this.donorList.ScrollAlwaysVisible = true;
            this.donorList.Size = new System.Drawing.Size(521, 410);
            this.donorList.TabIndex = 1;
            // 
            // contactButton
            // 
            this.contactButton.Location = new System.Drawing.Point(375, 588);
            this.contactButton.Name = "contactButton";
            this.contactButton.Size = new System.Drawing.Size(152, 44);
            this.contactButton.TabIndex = 2;
            this.contactButton.Text = "Contactere donator";
            this.contactButton.UseVisualStyleBackColor = true;
            this.contactButton.Click += new System.EventHandler(this.contactButton_Click);
            // 
            // forwardButton
            // 
            this.forwardButton.Location = new System.Drawing.Point(235, 589);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(134, 43);
            this.forwardButton.TabIndex = 3;
            this.forwardButton.Text = "Trimitere cerere";
            this.forwardButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 588);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(114, 44);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Anulare";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Donatori disponibili";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CallDonorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(539, 644);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.forwardButton);
            this.Controls.Add(this.contactButton);
            this.Controls.Add(this.donorList);
            this.Controls.Add(this.warningLabel);
            this.Name = "CallDonorsForm";
            this.Text = "Nu exista suficient sange";
            this.Load += new System.EventHandler(this.CallDonorsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label warningLabel;
        private NishBox.MultiLineListBox donorList;
        private System.Windows.Forms.Button contactButton;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
    }
}
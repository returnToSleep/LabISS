namespace Client.GUIs.DonorGUI
{
    partial class doneWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(doneWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.donationCenterLabel = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stept 3 out of 3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(470, 90);
            this.label2.TabIndex = 1;
            this.label2.Text = "Your account has been created! The only thing left to do is come to the\r\n\r\ncenter" +
    " in order to have the mediacal exam and donate!\r\n\r\nHave a nice day!";
            // 
            // donationCenterLabel
            // 
            this.donationCenterLabel.AutoSize = true;
            this.donationCenterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.donationCenterLabel.ForeColor = System.Drawing.Color.Black;
            this.donationCenterLabel.Location = new System.Drawing.Point(12, 76);
            this.donationCenterLabel.Name = "donationCenterLabel";
            this.donationCenterLabel.Size = new System.Drawing.Size(149, 18);
            this.donationCenterLabel.TabIndex = 3;
            this.donationCenterLabel.Text = "donationCenterName";
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.ForeColor = System.Drawing.Color.Black;
            this.submitButton.Location = new System.Drawing.Point(349, 187);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(179, 37);
            this.submitButton.TabIndex = 4;
            this.submitButton.Text = "Log In window";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // doneWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(540, 236);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.donationCenterLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "doneWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label donationCenterLabel;
        private System.Windows.Forms.Button submitButton;
    }
}
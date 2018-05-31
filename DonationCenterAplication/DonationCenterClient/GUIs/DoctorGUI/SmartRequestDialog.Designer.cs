namespace Client.GUIs.DoctorGUIs
{
    partial class SmartRequestDialog
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
            this.messageLabel = new System.Windows.Forms.Label();
            this.gatheredButton = new System.Windows.Forms.Button();
            this.originalButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLabel.Location = new System.Drawing.Point(14, 9);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(559, 54);
            this.messageLabel.TabIndex = 0;
            this.messageLabel.Text = "Not enough blood mathing your request has been found across all dontaion centers." +
    "\r\nOnly \" + gatheredAmmount + \"ml have been found\r\nWhat would you like to do?";
            // 
            // gatheredButton
            // 
            this.gatheredButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gatheredButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gatheredButton.Location = new System.Drawing.Point(17, 103);
            this.gatheredButton.Name = "gatheredButton";
            this.gatheredButton.Size = new System.Drawing.Size(556, 35);
            this.gatheredButton.TabIndex = 1;
            this.gatheredButton.Text = "Send requests for the gathered ammount";
            this.gatheredButton.UseVisualStyleBackColor = false;
            this.gatheredButton.Click += new System.EventHandler(this.gatheredButton_Click);
            // 
            // originalButton
            // 
            this.originalButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.originalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.originalButton.Location = new System.Drawing.Point(17, 144);
            this.originalButton.Name = "originalButton";
            this.originalButton.Size = new System.Drawing.Size(556, 35);
            this.originalButton.TabIndex = 2;
            this.originalButton.Text = "Send requests for the original ammount";
            this.originalButton.UseVisualStyleBackColor = false;
            this.originalButton.Click += new System.EventHandler(this.originalButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(17, 185);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(556, 35);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // SmartRequestDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(585, 237);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.originalButton);
            this.Controls.Add(this.gatheredButton);
            this.Controls.Add(this.messageLabel);
            this.Name = "SmartRequestDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Button gatheredButton;
        private System.Windows.Forms.Button originalButton;
        private System.Windows.Forms.Button cancelButton;
    }
}
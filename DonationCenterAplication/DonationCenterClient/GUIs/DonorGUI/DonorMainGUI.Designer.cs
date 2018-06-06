using Client.Utils;

namespace Client.GUIs.DonorGUI
{
    partial class DonorMainGUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DonorMainGUI));
            this.donationHistoryList = new Client.Utils.SafeNishBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.noOfDonationsLabel = new System.Windows.Forms.Label();
            this.donorBloodTypeLabel = new System.Windows.Forms.Label();
            this.donorNameLabel = new System.Windows.Forms.Label();
            this.fillFormButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.cnpLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.residenceLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.donationInformationLabel = new System.Windows.Forms.Label();
            this.logOutButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // donationHistoryList
            // 
            this.donationHistoryList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.donationHistoryList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.donationHistoryList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donationHistoryList.FormattingEnabled = true;
            this.donationHistoryList.Location = new System.Drawing.Point(6, 68);
            this.donationHistoryList.Name = "donationHistoryList";
            this.donationHistoryList.ScrollAlwaysVisible = true;
            this.donationHistoryList.Size = new System.Drawing.Size(1069, 434);
            this.donationHistoryList.TabIndex = 0;
            this.donationHistoryList.SelectedIndexChanged += new System.EventHandler(this.donationHistoryList_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.donationHistoryList);
            this.groupBox1.Controls.Add(this.noOfDonationsLabel);
            this.groupBox1.Controls.Add(this.donorBloodTypeLabel);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox1.Location = new System.Drawing.Point(12, 217);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1081, 508);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Donation history";
            // 
            // noOfDonationsLabel
            // 
            this.noOfDonationsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.noOfDonationsLabel.AutoSize = true;
            this.noOfDonationsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noOfDonationsLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.noOfDonationsLabel.Location = new System.Drawing.Point(315, 48);
            this.noOfDonationsLabel.Name = "noOfDonationsLabel";
            this.noOfDonationsLabel.Size = new System.Drawing.Size(148, 17);
            this.noOfDonationsLabel.TabIndex = 8;
            this.noOfDonationsLabel.Text = "Number of donations: ";
            // 
            // donorBloodTypeLabel
            // 
            this.donorBloodTypeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.donorBloodTypeLabel.AutoSize = true;
            this.donorBloodTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donorBloodTypeLabel.ForeColor = System.Drawing.Color.Black;
            this.donorBloodTypeLabel.Location = new System.Drawing.Point(6, 48);
            this.donorBloodTypeLabel.Name = "donorBloodTypeLabel";
            this.donorBloodTypeLabel.Size = new System.Drawing.Size(79, 17);
            this.donorBloodTypeLabel.TabIndex = 3;
            this.donorBloodTypeLabel.Text = "Blood type:";
            // 
            // donorNameLabel
            // 
            this.donorNameLabel.AutoSize = true;
            this.donorNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donorNameLabel.ForeColor = System.Drawing.Color.Black;
            this.donorNameLabel.Location = new System.Drawing.Point(6, 40);
            this.donorNameLabel.Name = "donorNameLabel";
            this.donorNameLabel.Size = new System.Drawing.Size(53, 17);
            this.donorNameLabel.TabIndex = 2;
            this.donorNameLabel.Text = "Name: ";
            // 
            // fillFormButton
            // 
            this.fillFormButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fillFormButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.fillFormButton.Enabled = false;
            this.fillFormButton.ForeColor = System.Drawing.Color.DarkRed;
            this.fillFormButton.Location = new System.Drawing.Point(653, 26);
            this.fillFormButton.Name = "fillFormButton";
            this.fillFormButton.Size = new System.Drawing.Size(238, 43);
            this.fillFormButton.TabIndex = 4;
            this.fillFormButton.Text = "Fill in donation\r\nform\r\n";
            this.fillFormButton.UseVisualStyleBackColor = false;
            this.fillFormButton.Click += new System.EventHandler(this.fillFormButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.refreshButton.ForeColor = System.Drawing.Color.DarkRed;
            this.refreshButton.Location = new System.Drawing.Point(897, 26);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(190, 43);
            this.refreshButton.TabIndex = 5;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // cnpLabel
            // 
            this.cnpLabel.AutoSize = true;
            this.cnpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cnpLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cnpLabel.Location = new System.Drawing.Point(6, 80);
            this.cnpLabel.Name = "cnpLabel";
            this.cnpLabel.Size = new System.Drawing.Size(40, 17);
            this.cnpLabel.TabIndex = 6;
            this.cnpLabel.Text = "CNP:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.emailLabel);
            this.groupBox2.Controls.Add(this.residenceLabel);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.donorNameLabel);
            this.groupBox2.Controls.Add(this.cnpLabel);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox2.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(635, 199);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Info";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.emailLabel.Location = new System.Drawing.Point(6, 120);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(46, 17);
            this.emailLabel.TabIndex = 10;
            this.emailLabel.Text = "Email:";
            // 
            // residenceLabel
            // 
            this.residenceLabel.AutoSize = true;
            this.residenceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.residenceLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.residenceLabel.Location = new System.Drawing.Point(6, 164);
            this.residenceLabel.Name = "residenceLabel";
            this.residenceLabel.Size = new System.Drawing.Size(83, 17);
            this.residenceLabel.TabIndex = 9;
            this.residenceLabel.Text = "Residentce:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(532, 158);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 35);
            this.button1.TabIndex = 7;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.donationInformationLabel);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox3.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox3.Location = new System.Drawing.Point(653, 75);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(434, 136);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Next donation";
            // 
            // donationInformationLabel
            // 
            this.donationInformationLabel.AutoSize = true;
            this.donationInformationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donationInformationLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.donationInformationLabel.Location = new System.Drawing.Point(15, 67);
            this.donationInformationLabel.Name = "donationInformationLabel";
            this.donationInformationLabel.Size = new System.Drawing.Size(120, 18);
            this.donationInformationLabel.TabIndex = 0;
            this.donationInformationLabel.Text = "Informatii donatie";
            // 
            // logOutButton
            // 
            this.logOutButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.logOutButton.Location = new System.Drawing.Point(970, 731);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(123, 29);
            this.logOutButton.TabIndex = 9;
            this.logOutButton.Text = "Log out";
            this.logOutButton.UseVisualStyleBackColor = false;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 731);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "*Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce rhoncus, nulla al" +
    "iquet \r\nscelerisque malesuada, neque mauris porta elit, sed faucibus leo magna a" +
    "t nibh. ";
            // 
            // refreshTimer
            // 
            this.refreshTimer.Enabled = true;
            this.refreshTimer.Interval = 60000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // DonorMainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1105, 772);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.fillFormButton);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DonorMainGUI";
            this.Text = "DonorGUI";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SafeNishBox donationHistoryList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label donorNameLabel;
        private System.Windows.Forms.Label donorBloodTypeLabel;
        private System.Windows.Forms.Button fillFormButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Label cnpLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label donationInformationLabel;
        private System.Windows.Forms.Label noOfDonationsLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label residenceLabel;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer refreshTimer;
    }
}
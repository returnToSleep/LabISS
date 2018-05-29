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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CallDonorsForm));
            this.warningLabel = new System.Windows.Forms.Label();
            this.donorList = new NishBox.MultiLineListBox();
            this.contactButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gMapAvailableDonors = new GMap.NET.WindowsForms.GMapControl();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.warningLabel.Location = new System.Drawing.Point(8, 9);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(468, 20);
            this.warningLabel.TabIndex = 0;
            this.warningLabel.Text = "Nu exista suficient sange pe stoc pentru a satisface cererea: ";
            // 
            // donorList
            // 
            this.donorList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.donorList.FormattingEnabled = true;
            this.donorList.Location = new System.Drawing.Point(6, 34);
            this.donorList.Name = "donorList";
            this.donorList.ScrollAlwaysVisible = true;
            this.donorList.Size = new System.Drawing.Size(458, 488);
            this.donorList.TabIndex = 1;
            this.donorList.SelectedIndexChanged += new System.EventHandler(this.donorList_SelectedIndexChanged);
            // 
            // contactButton
            // 
            this.contactButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.contactButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactButton.ForeColor = System.Drawing.Color.Black;
            this.contactButton.Location = new System.Drawing.Point(873, 661);
            this.contactButton.Name = "contactButton";
            this.contactButton.Size = new System.Drawing.Size(165, 44);
            this.contactButton.TabIndex = 2;
            this.contactButton.Text = "Contactere donator";
            this.contactButton.UseVisualStyleBackColor = false;
            this.contactButton.Click += new System.EventHandler(this.contactButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.Color.Black;
            this.cancelButton.Location = new System.Drawing.Point(753, 661);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(114, 44);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Anulare";
            this.cancelButton.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gMapAvailableDonors);
            this.groupBox1.Controls.Add(this.donorList);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox1.Location = new System.Drawing.Point(12, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1026, 538);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Donatori disponibili";
            // 
            // gMapAvailableDonors
            // 
            this.gMapAvailableDonors.Bearing = 0F;
            this.gMapAvailableDonors.CanDragMap = true;
            this.gMapAvailableDonors.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapAvailableDonors.GrayScaleMode = false;
            this.gMapAvailableDonors.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapAvailableDonors.LevelsKeepInMemmory = 5;
            this.gMapAvailableDonors.Location = new System.Drawing.Point(470, 34);
            this.gMapAvailableDonors.MarkersEnabled = true;
            this.gMapAvailableDonors.MaxZoom = 15;
            this.gMapAvailableDonors.MinZoom = 15;
            this.gMapAvailableDonors.MouseWheelZoomEnabled = true;
            this.gMapAvailableDonors.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapAvailableDonors.Name = "gMapAvailableDonors";
            this.gMapAvailableDonors.NegativeMode = false;
            this.gMapAvailableDonors.PolygonsEnabled = true;
            this.gMapAvailableDonors.RetryLoadTile = 0;
            this.gMapAvailableDonors.RoutesEnabled = true;
            this.gMapAvailableDonors.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapAvailableDonors.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapAvailableDonors.ShowTileGridLines = false;
            this.gMapAvailableDonors.Size = new System.Drawing.Size(550, 488);
            this.gMapAvailableDonors.TabIndex = 2;
            this.gMapAvailableDonors.Zoom = 0D;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(14, 661);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 40);
            this.label1.TabIndex = 6;
            this.label1.Text = "*Donatorii disponibili sunt sortati in functie de \r\ndistanta fata de centrul de d" +
    "onatie";
            // 
            // CallDonorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1050, 717);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.contactButton);
            this.Controls.Add(this.warningLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CallDonorsForm";
            this.Text = "Nu exista suficient sange";
            this.Load += new System.EventHandler(this.CallDonorsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label warningLabel;
        private NishBox.MultiLineListBox donorList;
        private System.Windows.Forms.Button contactButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private GMap.NET.WindowsForms.GMapControl gMapAvailableDonors;
        private System.Windows.Forms.Label label1;
    }
}
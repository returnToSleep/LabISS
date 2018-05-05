namespace Client.GUIs
{
    partial class DonationCenterGUI
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
            this.selectionTab = new System.Windows.Forms.TabControl();
            this.donorPage = new System.Windows.Forms.TabPage();
            this.donorList = new NishBox.MultiLineListBox();
            this.gMapDonors = new GMap.NET.WindowsForms.GMapControl();
            this.doctorPage = new System.Windows.Forms.TabPage();
            this.sendBloodButton = new System.Windows.Forms.Button();
            this.availableBloodList = new System.Windows.Forms.ListBox();
            this.doctorRequestList = new System.Windows.Forms.ListBox();
            this.pendingPage = new System.Windows.Forms.TabPage();
            this.donorNotOkButton = new System.Windows.Forms.Button();
            this.donorOkButton = new System.Windows.Forms.Button();
            this.gMapControl2 = new GMap.NET.WindowsForms.GMapControl();
            this.pendingDonorList = new System.Windows.Forms.ListBox();
            this.bloodStockPage = new System.Windows.Forms.TabPage();
            this.trombLabel = new System.Windows.Forms.Label();
            this.plasmaLabel = new System.Windows.Forms.Label();
            this.redBloodLable = new System.Windows.Forms.Label();
            this.stockTrombList = new System.Windows.Forms.ListBox();
            this.stockPlasmaList = new System.Windows.Forms.ListBox();
            this.stockRedList = new System.Windows.Forms.ListBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.selectionTab.SuspendLayout();
            this.donorPage.SuspendLayout();
            this.doctorPage.SuspendLayout();
            this.pendingPage.SuspendLayout();
            this.bloodStockPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectionTab
            // 
            this.selectionTab.Controls.Add(this.donorPage);
            this.selectionTab.Controls.Add(this.doctorPage);
            this.selectionTab.Controls.Add(this.pendingPage);
            this.selectionTab.Controls.Add(this.bloodStockPage);
            this.selectionTab.Font = new System.Drawing.Font("Arial Unicode MS", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectionTab.Location = new System.Drawing.Point(12, 39);
            this.selectionTab.Name = "selectionTab";
            this.selectionTab.SelectedIndex = 0;
            this.selectionTab.Size = new System.Drawing.Size(1086, 605);
            this.selectionTab.TabIndex = 1;
            // 
            // donorPage
            // 
            this.donorPage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.donorPage.Controls.Add(this.donorList);
            this.donorPage.Controls.Add(this.gMapDonors);
            this.donorPage.Location = new System.Drawing.Point(4, 27);
            this.donorPage.Name = "donorPage";
            this.donorPage.Padding = new System.Windows.Forms.Padding(3);
            this.donorPage.Size = new System.Drawing.Size(1078, 574);
            this.donorPage.TabIndex = 0;
            this.donorPage.Text = "Donatori";
            // 
            // donorList
            // 
            this.donorList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.donorList.Font = new System.Drawing.Font("Arial Unicode MS", 13F, System.Drawing.FontStyle.Bold);
            this.donorList.FormattingEnabled = true;
            this.donorList.Location = new System.Drawing.Point(6, 6);
            this.donorList.Name = "donorList";
            this.donorList.ScrollAlwaysVisible = true;
            this.donorList.Size = new System.Drawing.Size(548, 554);
            this.donorList.TabIndex = 1;
            this.donorList.SelectedIndexChanged += new System.EventHandler(this.donorList_SelectedIndexChanged);
            // 
            // gMapDonors
            // 
            this.gMapDonors.Bearing = 0F;
            this.gMapDonors.CanDragMap = true;
            this.gMapDonors.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapDonors.GrayScaleMode = false;
            this.gMapDonors.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapDonors.LevelsKeepInMemmory = 5;
            this.gMapDonors.Location = new System.Drawing.Point(560, 12);
            this.gMapDonors.MarkersEnabled = true;
            this.gMapDonors.MaxZoom = 17;
            this.gMapDonors.MinZoom = 17;
            this.gMapDonors.MouseWheelZoomEnabled = true;
            this.gMapDonors.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapDonors.Name = "gMapDonors";
            this.gMapDonors.NegativeMode = false;
            this.gMapDonors.PolygonsEnabled = true;
            this.gMapDonors.RetryLoadTile = 0;
            this.gMapDonors.RoutesEnabled = true;
            this.gMapDonors.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapDonors.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapDonors.ShowTileGridLines = false;
            this.gMapDonors.Size = new System.Drawing.Size(498, 551);
            this.gMapDonors.TabIndex = 0;
            this.gMapDonors.Zoom = 0D;
            // 
            // doctorPage
            // 
            this.doctorPage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.doctorPage.Controls.Add(this.sendBloodButton);
            this.doctorPage.Controls.Add(this.availableBloodList);
            this.doctorPage.Controls.Add(this.doctorRequestList);
            this.doctorPage.Location = new System.Drawing.Point(4, 27);
            this.doctorPage.Name = "doctorPage";
            this.doctorPage.Padding = new System.Windows.Forms.Padding(3);
            this.doctorPage.Size = new System.Drawing.Size(1078, 574);
            this.doctorPage.TabIndex = 1;
            this.doctorPage.Text = "Cereri de la doctori";
            // 
            // sendBloodButton
            // 
            this.sendBloodButton.Location = new System.Drawing.Point(978, 6);
            this.sendBloodButton.Name = "sendBloodButton";
            this.sendBloodButton.Size = new System.Drawing.Size(94, 41);
            this.sendBloodButton.TabIndex = 2;
            this.sendBloodButton.Text = "Trimitere";
            this.sendBloodButton.UseVisualStyleBackColor = true;
            // 
            // availableBloodList
            // 
            this.availableBloodList.FormattingEnabled = true;
            this.availableBloodList.ItemHeight = 18;
            this.availableBloodList.Location = new System.Drawing.Point(554, 50);
            this.availableBloodList.Name = "availableBloodList";
            this.availableBloodList.Size = new System.Drawing.Size(518, 544);
            this.availableBloodList.TabIndex = 1;
            // 
            // doctorRequestList
            // 
            this.doctorRequestList.FormattingEnabled = true;
            this.doctorRequestList.ItemHeight = 18;
            this.doctorRequestList.Location = new System.Drawing.Point(6, 50);
            this.doctorRequestList.Name = "doctorRequestList";
            this.doctorRequestList.Size = new System.Drawing.Size(542, 544);
            this.doctorRequestList.TabIndex = 0;
            this.doctorRequestList.SelectedIndexChanged += new System.EventHandler(this.doctorRequestList_SelectedIndexChanged);
            // 
            // pendingPage
            // 
            this.pendingPage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pendingPage.Controls.Add(this.donorNotOkButton);
            this.pendingPage.Controls.Add(this.donorOkButton);
            this.pendingPage.Controls.Add(this.gMapControl2);
            this.pendingPage.Controls.Add(this.pendingDonorList);
            this.pendingPage.Location = new System.Drawing.Point(4, 27);
            this.pendingPage.Name = "pendingPage";
            this.pendingPage.Padding = new System.Windows.Forms.Padding(3);
            this.pendingPage.Size = new System.Drawing.Size(1078, 574);
            this.pendingPage.TabIndex = 2;
            this.pendingPage.Text = "Persoane in asteptare";
            // 
            // donorNotOkButton
            // 
            this.donorNotOkButton.Location = new System.Drawing.Point(114, 6);
            this.donorNotOkButton.Name = "donorNotOkButton";
            this.donorNotOkButton.Size = new System.Drawing.Size(86, 34);
            this.donorNotOkButton.TabIndex = 3;
            this.donorNotOkButton.Text = "Neapt";
            this.donorNotOkButton.UseVisualStyleBackColor = true;
            // 
            // donorOkButton
            // 
            this.donorOkButton.Location = new System.Drawing.Point(16, 6);
            this.donorOkButton.Name = "donorOkButton";
            this.donorOkButton.Size = new System.Drawing.Size(92, 34);
            this.donorOkButton.TabIndex = 2;
            this.donorOkButton.Text = "Apt";
            this.donorOkButton.UseVisualStyleBackColor = true;
            // 
            // gMapControl2
            // 
            this.gMapControl2.Bearing = 0F;
            this.gMapControl2.CanDragMap = true;
            this.gMapControl2.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl2.GrayScaleMode = false;
            this.gMapControl2.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl2.LevelsKeepInMemmory = 5;
            this.gMapControl2.Location = new System.Drawing.Point(514, 42);
            this.gMapControl2.MarkersEnabled = true;
            this.gMapControl2.MaxZoom = 2;
            this.gMapControl2.MinZoom = 2;
            this.gMapControl2.MouseWheelZoomEnabled = true;
            this.gMapControl2.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl2.Name = "gMapControl2";
            this.gMapControl2.NegativeMode = false;
            this.gMapControl2.PolygonsEnabled = true;
            this.gMapControl2.RetryLoadTile = 0;
            this.gMapControl2.RoutesEnabled = true;
            this.gMapControl2.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl2.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl2.ShowTileGridLines = false;
            this.gMapControl2.Size = new System.Drawing.Size(543, 544);
            this.gMapControl2.TabIndex = 1;
            this.gMapControl2.Zoom = 0D;
            // 
            // pendingDonorList
            // 
            this.pendingDonorList.FormattingEnabled = true;
            this.pendingDonorList.ItemHeight = 18;
            this.pendingDonorList.Location = new System.Drawing.Point(16, 42);
            this.pendingDonorList.Name = "pendingDonorList";
            this.pendingDonorList.Size = new System.Drawing.Size(492, 544);
            this.pendingDonorList.TabIndex = 0;
            // 
            // bloodStockPage
            // 
            this.bloodStockPage.BackColor = System.Drawing.Color.LightGray;
            this.bloodStockPage.Controls.Add(this.trombLabel);
            this.bloodStockPage.Controls.Add(this.plasmaLabel);
            this.bloodStockPage.Controls.Add(this.redBloodLable);
            this.bloodStockPage.Controls.Add(this.stockTrombList);
            this.bloodStockPage.Controls.Add(this.stockPlasmaList);
            this.bloodStockPage.Controls.Add(this.stockRedList);
            this.bloodStockPage.Location = new System.Drawing.Point(4, 27);
            this.bloodStockPage.Name = "bloodStockPage";
            this.bloodStockPage.Padding = new System.Windows.Forms.Padding(3);
            this.bloodStockPage.Size = new System.Drawing.Size(1078, 574);
            this.bloodStockPage.TabIndex = 3;
            this.bloodStockPage.Text = "Stocuri";
            // 
            // trombLabel
            // 
            this.trombLabel.AutoSize = true;
            this.trombLabel.Location = new System.Drawing.Point(729, 13);
            this.trombLabel.Name = "trombLabel";
            this.trombLabel.Size = new System.Drawing.Size(90, 19);
            this.trombLabel.TabIndex = 5;
            this.trombLabel.Text = "Trombocite";
            // 
            // plasmaLabel
            // 
            this.plasmaLabel.AutoSize = true;
            this.plasmaLabel.Location = new System.Drawing.Point(361, 13);
            this.plasmaLabel.Name = "plasmaLabel";
            this.plasmaLabel.Size = new System.Drawing.Size(61, 19);
            this.plasmaLabel.TabIndex = 4;
            this.plasmaLabel.Text = "Plasma";
            // 
            // redBloodLable
            // 
            this.redBloodLable.AutoSize = true;
            this.redBloodLable.Location = new System.Drawing.Point(24, 13);
            this.redBloodLable.Name = "redBloodLable";
            this.redBloodLable.Size = new System.Drawing.Size(91, 19);
            this.redBloodLable.TabIndex = 3;
            this.redBloodLable.Text = "Celule rosii";
            // 
            // stockTrombList
            // 
            this.stockTrombList.FormattingEnabled = true;
            this.stockTrombList.ItemHeight = 18;
            this.stockTrombList.Location = new System.Drawing.Point(729, 35);
            this.stockTrombList.Name = "stockTrombList";
            this.stockTrombList.Size = new System.Drawing.Size(324, 544);
            this.stockTrombList.TabIndex = 2;
            // 
            // stockPlasmaList
            // 
            this.stockPlasmaList.FormattingEnabled = true;
            this.stockPlasmaList.ItemHeight = 18;
            this.stockPlasmaList.Location = new System.Drawing.Point(361, 35);
            this.stockPlasmaList.Name = "stockPlasmaList";
            this.stockPlasmaList.Size = new System.Drawing.Size(362, 544);
            this.stockPlasmaList.TabIndex = 1;
            // 
            // stockRedList
            // 
            this.stockRedList.BackColor = System.Drawing.SystemColors.Window;
            this.stockRedList.FormattingEnabled = true;
            this.stockRedList.ItemHeight = 18;
            this.stockRedList.Location = new System.Drawing.Point(28, 35);
            this.stockRedList.Name = "stockRedList";
            this.stockRedList.Size = new System.Drawing.Size(327, 544);
            this.stockRedList.TabIndex = 0;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(962, 12);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(129, 41);
            this.refreshButton.TabIndex = 3;
            this.refreshButton.Text = "Reinprospatare";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // DonationCenterGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1110, 656);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.selectionTab);
            this.Name = "DonationCenterGUI";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.DonationCenterGUI_Load);
            this.selectionTab.ResumeLayout(false);
            this.donorPage.ResumeLayout(false);
            this.doctorPage.ResumeLayout(false);
            this.pendingPage.ResumeLayout(false);
            this.bloodStockPage.ResumeLayout(false);
            this.bloodStockPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl selectionTab;
        private System.Windows.Forms.TabPage donorPage;
        private GMap.NET.WindowsForms.GMapControl gMapDonors;
        private System.Windows.Forms.TabPage doctorPage;
        private System.Windows.Forms.Button sendBloodButton;
        private System.Windows.Forms.ListBox availableBloodList;
        private System.Windows.Forms.ListBox doctorRequestList;
        private System.Windows.Forms.TabPage pendingPage;
        private System.Windows.Forms.TabPage bloodStockPage;
        private System.Windows.Forms.ListBox stockTrombList;
        private System.Windows.Forms.ListBox stockPlasmaList;
        private System.Windows.Forms.ListBox stockRedList;
        private GMap.NET.WindowsForms.GMapControl gMapControl2;
        private System.Windows.Forms.ListBox pendingDonorList;
        private System.Windows.Forms.Label redBloodLable;
        private System.Windows.Forms.Label trombLabel;
        private System.Windows.Forms.Label plasmaLabel;
        private System.Windows.Forms.Button donorNotOkButton;
        private System.Windows.Forms.Button donorOkButton;
        private System.Windows.Forms.Button refreshButton;
        private NishBox.MultiLineListBox donorList;
    }
}
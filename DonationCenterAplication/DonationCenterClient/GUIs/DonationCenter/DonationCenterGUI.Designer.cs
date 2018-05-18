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
            this.potentialBloodLabel = new System.Windows.Forms.Label();
            this.requestLabel = new System.Windows.Forms.Label();
            this.sendBloodButton = new System.Windows.Forms.Button();
            this.potentialBlood = new NishBox.MultiLineListBox();
            this.doctorRequestList = new NishBox.MultiLineListBox();
            this.pendingPage = new System.Windows.Forms.TabPage();
            this.pendingDonorList = new NishBox.MultiLineListBox();
            this.donorNotOkButton = new System.Windows.Forms.Button();
            this.donorOkButton = new System.Windows.Forms.Button();
            this.gMapPendingDonors = new GMap.NET.WindowsForms.GMapControl();
            this.bloodStockPage = new System.Windows.Forms.TabPage();
            this.stockTrombList = new NishBox.MultiLineListBox();
            this.stockPlasmaList = new NishBox.MultiLineListBox();
            this.stockRedCellList = new NishBox.MultiLineListBox();
            this.trombLabel = new System.Windows.Forms.Label();
            this.plasmaLabel = new System.Windows.Forms.Label();
            this.redBloodLable = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
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
            this.donorPage.BackColor = System.Drawing.SystemColors.Control;
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
            this.donorList.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
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
            this.gMapDonors.MaxZoom = 15;
            this.gMapDonors.MinZoom = 15;
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
            this.gMapDonors.Size = new System.Drawing.Size(512, 551);
            this.gMapDonors.TabIndex = 0;
            this.gMapDonors.Zoom = 0D;
            // 
            // doctorPage
            // 
            this.doctorPage.BackColor = System.Drawing.SystemColors.Control;
            this.doctorPage.Controls.Add(this.potentialBloodLabel);
            this.doctorPage.Controls.Add(this.requestLabel);
            this.doctorPage.Controls.Add(this.sendBloodButton);
            this.doctorPage.Controls.Add(this.potentialBlood);
            this.doctorPage.Controls.Add(this.doctorRequestList);
            this.doctorPage.Location = new System.Drawing.Point(4, 27);
            this.doctorPage.Name = "doctorPage";
            this.doctorPage.Padding = new System.Windows.Forms.Padding(3);
            this.doctorPage.Size = new System.Drawing.Size(1078, 574);
            this.doctorPage.TabIndex = 1;
            this.doctorPage.Text = "Cereri de la doctori";
            this.doctorPage.Click += new System.EventHandler(this.doctorPage_Click);
            // 
            // potentialBloodLabel
            // 
            this.potentialBloodLabel.AutoSize = true;
            this.potentialBloodLabel.Location = new System.Drawing.Point(549, 25);
            this.potentialBloodLabel.Name = "potentialBloodLabel";
            this.potentialBloodLabel.Size = new System.Drawing.Size(264, 19);
            this.potentialBloodLabel.TabIndex = 4;
            this.potentialBloodLabel.Text = "Componente care satisfac cererea ";
            this.potentialBloodLabel.Click += new System.EventHandler(this.potentialBloodLabel_Click);
            // 
            // requestLabel
            // 
            this.requestLabel.AutoSize = true;
            this.requestLabel.Location = new System.Drawing.Point(11, 25);
            this.requestLabel.Name = "requestLabel";
            this.requestLabel.Size = new System.Drawing.Size(150, 19);
            this.requestLabel.TabIndex = 3;
            this.requestLabel.Text = "Cereri de la doctori";
            // 
            // sendBloodButton
            // 
            this.sendBloodButton.Location = new System.Drawing.Point(911, 10);
            this.sendBloodButton.Name = "sendBloodButton";
            this.sendBloodButton.Size = new System.Drawing.Size(152, 38);
            this.sendBloodButton.TabIndex = 2;
            this.sendBloodButton.Text = "Trimitere";
            this.sendBloodButton.UseVisualStyleBackColor = true;
            // 
            // potentialBlood
            // 
            this.potentialBlood.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.potentialBlood.FormattingEnabled = true;
            this.potentialBlood.Location = new System.Drawing.Point(553, 54);
            this.potentialBlood.Name = "potentialBlood";
            this.potentialBlood.ScrollAlwaysVisible = true;
            this.potentialBlood.Size = new System.Drawing.Size(510, 501);
            this.potentialBlood.TabIndex = 1;
            this.potentialBlood.SelectedIndexChanged += new System.EventHandler(this.multiLineListBox1_SelectedIndexChanged);
            // 
            // doctorRequestList
            // 
            this.doctorRequestList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.doctorRequestList.FormattingEnabled = true;
            this.doctorRequestList.Location = new System.Drawing.Point(15, 50);
            this.doctorRequestList.Name = "doctorRequestList";
            this.doctorRequestList.ScrollAlwaysVisible = true;
            this.doctorRequestList.Size = new System.Drawing.Size(532, 506);
            this.doctorRequestList.TabIndex = 0;
            this.doctorRequestList.SelectedIndexChanged += new System.EventHandler(this.doctorRequestList_SelectedIndexChanged_1);
            // 
            // pendingPage
            // 
            this.pendingPage.BackColor = System.Drawing.Color.Transparent;
            this.pendingPage.Controls.Add(this.pendingDonorList);
            this.pendingPage.Controls.Add(this.donorNotOkButton);
            this.pendingPage.Controls.Add(this.donorOkButton);
            this.pendingPage.Controls.Add(this.gMapPendingDonors);
            this.pendingPage.Location = new System.Drawing.Point(4, 27);
            this.pendingPage.Name = "pendingPage";
            this.pendingPage.Padding = new System.Windows.Forms.Padding(3);
            this.pendingPage.Size = new System.Drawing.Size(1078, 574);
            this.pendingPage.TabIndex = 2;
            this.pendingPage.Text = "Persoane in asteptare";
            // 
            // pendingDonorList
            // 
            this.pendingDonorList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.pendingDonorList.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.pendingDonorList.FormattingEnabled = true;
            this.pendingDonorList.Location = new System.Drawing.Point(17, 42);
            this.pendingDonorList.Name = "pendingDonorList";
            this.pendingDonorList.ScrollAlwaysVisible = true;
            this.pendingDonorList.Size = new System.Drawing.Size(491, 514);
            this.pendingDonorList.TabIndex = 4;
            this.pendingDonorList.SelectedIndexChanged += new System.EventHandler(this.pendingDonorList_SelectedIndexChanged);
            // 
            // donorNotOkButton
            // 
            this.donorNotOkButton.BackColor = System.Drawing.Color.Crimson;
            this.donorNotOkButton.Location = new System.Drawing.Point(114, 6);
            this.donorNotOkButton.Name = "donorNotOkButton";
            this.donorNotOkButton.Size = new System.Drawing.Size(86, 34);
            this.donorNotOkButton.TabIndex = 3;
            this.donorNotOkButton.Text = "Neapt";
            this.donorNotOkButton.UseVisualStyleBackColor = false;
            this.donorNotOkButton.Click += new System.EventHandler(this.donorNotOkButton_Click);
            // 
            // donorOkButton
            // 
            this.donorOkButton.BackColor = System.Drawing.Color.ForestGreen;
            this.donorOkButton.Location = new System.Drawing.Point(16, 6);
            this.donorOkButton.Name = "donorOkButton";
            this.donorOkButton.Size = new System.Drawing.Size(92, 34);
            this.donorOkButton.TabIndex = 2;
            this.donorOkButton.Text = "Apt";
            this.donorOkButton.UseVisualStyleBackColor = false;
            this.donorOkButton.Click += new System.EventHandler(this.donorOkButton_Click);
            // 
            // gMapPendingDonors
            // 
            this.gMapPendingDonors.Bearing = 0F;
            this.gMapPendingDonors.CanDragMap = true;
            this.gMapPendingDonors.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapPendingDonors.GrayScaleMode = false;
            this.gMapPendingDonors.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapPendingDonors.LevelsKeepInMemmory = 5;
            this.gMapPendingDonors.Location = new System.Drawing.Point(514, 42);
            this.gMapPendingDonors.MarkersEnabled = true;
            this.gMapPendingDonors.MaxZoom = 15;
            this.gMapPendingDonors.MinZoom = 15;
            this.gMapPendingDonors.MouseWheelZoomEnabled = true;
            this.gMapPendingDonors.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapPendingDonors.Name = "gMapPendingDonors";
            this.gMapPendingDonors.NegativeMode = false;
            this.gMapPendingDonors.PolygonsEnabled = true;
            this.gMapPendingDonors.RetryLoadTile = 0;
            this.gMapPendingDonors.RoutesEnabled = true;
            this.gMapPendingDonors.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapPendingDonors.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapPendingDonors.ShowTileGridLines = false;
            this.gMapPendingDonors.Size = new System.Drawing.Size(543, 514);
            this.gMapPendingDonors.TabIndex = 1;
            this.gMapPendingDonors.Zoom = 0D;
            // 
            // bloodStockPage
            // 
            this.bloodStockPage.BackColor = System.Drawing.Color.LightGray;
            this.bloodStockPage.Controls.Add(this.stockTrombList);
            this.bloodStockPage.Controls.Add(this.stockPlasmaList);
            this.bloodStockPage.Controls.Add(this.stockRedCellList);
            this.bloodStockPage.Controls.Add(this.trombLabel);
            this.bloodStockPage.Controls.Add(this.plasmaLabel);
            this.bloodStockPage.Controls.Add(this.redBloodLable);
            this.bloodStockPage.Location = new System.Drawing.Point(4, 27);
            this.bloodStockPage.Name = "bloodStockPage";
            this.bloodStockPage.Padding = new System.Windows.Forms.Padding(3);
            this.bloodStockPage.Size = new System.Drawing.Size(1078, 574);
            this.bloodStockPage.TabIndex = 3;
            this.bloodStockPage.Text = "Stocuri";
            // 
            // stockTrombList
            // 
            this.stockTrombList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.stockTrombList.FormattingEnabled = true;
            this.stockTrombList.Location = new System.Drawing.Point(743, 35);
            this.stockTrombList.Name = "stockTrombList";
            this.stockTrombList.ScrollAlwaysVisible = true;
            this.stockTrombList.Size = new System.Drawing.Size(329, 519);
            this.stockTrombList.TabIndex = 8;
            // 
            // stockPlasmaList
            // 
            this.stockPlasmaList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.stockPlasmaList.FormattingEnabled = true;
            this.stockPlasmaList.Location = new System.Drawing.Point(389, 35);
            this.stockPlasmaList.Name = "stockPlasmaList";
            this.stockPlasmaList.ScrollAlwaysVisible = true;
            this.stockPlasmaList.Size = new System.Drawing.Size(348, 523);
            this.stockPlasmaList.TabIndex = 7;
            // 
            // stockRedCellList
            // 
            this.stockRedCellList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.stockRedCellList.FormattingEnabled = true;
            this.stockRedCellList.Location = new System.Drawing.Point(28, 35);
            this.stockRedCellList.Name = "stockRedCellList";
            this.stockRedCellList.ScrollAlwaysVisible = true;
            this.stockRedCellList.Size = new System.Drawing.Size(355, 525);
            this.stockRedCellList.TabIndex = 6;
            // 
            // trombLabel
            // 
            this.trombLabel.AutoSize = true;
            this.trombLabel.Location = new System.Drawing.Point(739, 13);
            this.trombLabel.Name = "trombLabel";
            this.trombLabel.Size = new System.Drawing.Size(90, 19);
            this.trombLabel.TabIndex = 5;
            this.trombLabel.Text = "Trombocite";
            // 
            // plasmaLabel
            // 
            this.plasmaLabel.AutoSize = true;
            this.plasmaLabel.Location = new System.Drawing.Point(385, 13);
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
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.nameLabel.Location = new System.Drawing.Point(19, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(196, 24);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Donation center name";
            // 
            // DonationCenterGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1110, 656);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.selectionTab);
            this.Name = "DonationCenterGUI";
            this.Text = "Centru de donatie";
            this.Load += new System.EventHandler(this.DonationCenterGUI_Load);
            this.selectionTab.ResumeLayout(false);
            this.donorPage.ResumeLayout(false);
            this.doctorPage.ResumeLayout(false);
            this.doctorPage.PerformLayout();
            this.pendingPage.ResumeLayout(false);
            this.bloodStockPage.ResumeLayout(false);
            this.bloodStockPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl selectionTab;
        private System.Windows.Forms.TabPage donorPage;
        private GMap.NET.WindowsForms.GMapControl gMapDonors;
        private System.Windows.Forms.TabPage doctorPage;
        private System.Windows.Forms.TabPage pendingPage;
        private System.Windows.Forms.TabPage bloodStockPage;
        private GMap.NET.WindowsForms.GMapControl gMapPendingDonors;
        private System.Windows.Forms.Label redBloodLable;
        private System.Windows.Forms.Label trombLabel;
        private System.Windows.Forms.Label plasmaLabel;
        private System.Windows.Forms.Button donorNotOkButton;
        private System.Windows.Forms.Button donorOkButton;
        private System.Windows.Forms.Button refreshButton;
        private NishBox.MultiLineListBox donorList;
        private System.Windows.Forms.Label nameLabel;
        private NishBox.MultiLineListBox pendingDonorList;
        private NishBox.MultiLineListBox potentialBlood;
        private NishBox.MultiLineListBox doctorRequestList;
        private System.Windows.Forms.Label potentialBloodLabel;
        private System.Windows.Forms.Label requestLabel;
        private System.Windows.Forms.Button sendBloodButton;
        private NishBox.MultiLineListBox stockTrombList;
        private NishBox.MultiLineListBox stockPlasmaList;
        private NishBox.MultiLineListBox stockRedCellList;
    }
}
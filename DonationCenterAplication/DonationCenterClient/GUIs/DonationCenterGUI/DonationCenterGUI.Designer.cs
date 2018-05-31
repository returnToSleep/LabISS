using Client.Utils;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DonationCenterGUI));
            this.selectionTab = new System.Windows.Forms.TabControl();
            this.donorPage = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.donorList = new Client.Utils.SafeNishBox();
            this.gMapDonors = new GMap.NET.WindowsForms.GMapControl();
            this.pendingPage = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pendingDonorList = new Client.Utils.SafeNishBox();
            this.donorNotOkButton = new System.Windows.Forms.Button();
            this.donorOkButton = new System.Windows.Forms.Button();
            this.gMapPendingDonors = new GMap.NET.WindowsForms.GMapControl();
            this.doctorPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.doctorRequestList = new Client.Utils.SafeNishBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gMapRouteToDoctor = new GMap.NET.WindowsForms.GMapControl();
            this.sendBloodButton = new System.Windows.Forms.Button();
            this.potentialBloodTextBox = new System.Windows.Forms.RichTextBox();
            this.bloodStockPage = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.stocksDataGridView = new System.Windows.Forms.DataGridView();
            this.compoenetSelectComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.logOutButton = new System.Windows.Forms.Button();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.label33 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.selectionTab.SuspendLayout();
            this.donorPage.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.pendingPage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.doctorPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.bloodStockPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // selectionTab
            // 
            this.selectionTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectionTab.Controls.Add(this.donorPage);
            this.selectionTab.Controls.Add(this.pendingPage);
            this.selectionTab.Controls.Add(this.doctorPage);
            this.selectionTab.Controls.Add(this.bloodStockPage);
            this.selectionTab.Font = new System.Drawing.Font("Arial Unicode MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectionTab.Location = new System.Drawing.Point(12, 76);
            this.selectionTab.Name = "selectionTab";
            this.selectionTab.SelectedIndex = 0;
            this.selectionTab.Size = new System.Drawing.Size(1153, 593);
            this.selectionTab.TabIndex = 1;
            // 
            // donorPage
            // 
            this.donorPage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.donorPage.Controls.Add(this.groupBox4);
            this.donorPage.Controls.Add(this.gMapDonors);
            this.donorPage.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donorPage.Location = new System.Drawing.Point(4, 33);
            this.donorPage.Name = "donorPage";
            this.donorPage.Padding = new System.Windows.Forms.Padding(3);
            this.donorPage.Size = new System.Drawing.Size(1145, 556);
            this.donorPage.TabIndex = 0;
            this.donorPage.Text = "Donors";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.donorList);
            this.groupBox4.Font = new System.Drawing.Font("Arial Unicode MS", 11F);
            this.groupBox4.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(450, 540);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Donors";
            // 
            // donorList
            // 
            this.donorList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.donorList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.donorList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.donorList.FormattingEnabled = true;
            this.donorList.Location = new System.Drawing.Point(6, 39);
            this.donorList.Name = "donorList";
            this.donorList.ScrollAlwaysVisible = true;
            this.donorList.Size = new System.Drawing.Size(438, 495);
            this.donorList.TabIndex = 1;
            this.donorList.SelectedIndexChanged += new System.EventHandler(this.donorList_SelectedIndexChanged);
            // 
            // gMapDonors
            // 
            this.gMapDonors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMapDonors.Bearing = 0F;
            this.gMapDonors.CanDragMap = true;
            this.gMapDonors.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapDonors.GrayScaleMode = false;
            this.gMapDonors.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapDonors.LevelsKeepInMemmory = 5;
            this.gMapDonors.Location = new System.Drawing.Point(462, 18);
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
            this.gMapDonors.Size = new System.Drawing.Size(677, 528);
            this.gMapDonors.TabIndex = 0;
            this.gMapDonors.Zoom = 0D;
            // 
            // pendingPage
            // 
            this.pendingPage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pendingPage.Controls.Add(this.groupBox3);
            this.pendingPage.Controls.Add(this.gMapPendingDonors);
            this.pendingPage.Location = new System.Drawing.Point(4, 33);
            this.pendingPage.Name = "pendingPage";
            this.pendingPage.Padding = new System.Windows.Forms.Padding(3);
            this.pendingPage.Size = new System.Drawing.Size(1145, 556);
            this.pendingPage.TabIndex = 2;
            this.pendingPage.Text = "Pending persons";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.pendingDonorList);
            this.groupBox3.Controls.Add(this.donorNotOkButton);
            this.groupBox3.Controls.Add(this.donorOkButton);
            this.groupBox3.Font = new System.Drawing.Font("Arial Unicode MS", 11F);
            this.groupBox3.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(450, 540);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pending persons";
            // 
            // pendingDonorList
            // 
            this.pendingDonorList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pendingDonorList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.pendingDonorList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.pendingDonorList.FormattingEnabled = true;
            this.pendingDonorList.Location = new System.Drawing.Point(6, 71);
            this.pendingDonorList.Name = "pendingDonorList";
            this.pendingDonorList.ScrollAlwaysVisible = true;
            this.pendingDonorList.Size = new System.Drawing.Size(438, 462);
            this.pendingDonorList.TabIndex = 4;
            this.pendingDonorList.SelectedIndexChanged += new System.EventHandler(this.pendingDonorList_SelectedIndexChanged);
            // 
            // donorNotOkButton
            // 
            this.donorNotOkButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.donorNotOkButton.ForeColor = System.Drawing.Color.Black;
            this.donorNotOkButton.Location = new System.Drawing.Point(104, 31);
            this.donorNotOkButton.Name = "donorNotOkButton";
            this.donorNotOkButton.Size = new System.Drawing.Size(86, 34);
            this.donorNotOkButton.TabIndex = 3;
            this.donorNotOkButton.Text = "Unfit";
            this.donorNotOkButton.UseVisualStyleBackColor = false;
            this.donorNotOkButton.Click += new System.EventHandler(this.donorNotOkButton_Click);
            // 
            // donorOkButton
            // 
            this.donorOkButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.donorOkButton.ForeColor = System.Drawing.Color.Black;
            this.donorOkButton.Location = new System.Drawing.Point(6, 31);
            this.donorOkButton.Name = "donorOkButton";
            this.donorOkButton.Size = new System.Drawing.Size(92, 34);
            this.donorOkButton.TabIndex = 2;
            this.donorOkButton.Text = "Fit";
            this.donorOkButton.UseVisualStyleBackColor = false;
            this.donorOkButton.Click += new System.EventHandler(this.donorOkButton_Click);
            // 
            // gMapPendingDonors
            // 
            this.gMapPendingDonors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMapPendingDonors.Bearing = 0F;
            this.gMapPendingDonors.CanDragMap = true;
            this.gMapPendingDonors.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapPendingDonors.GrayScaleMode = false;
            this.gMapPendingDonors.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapPendingDonors.LevelsKeepInMemmory = 5;
            this.gMapPendingDonors.Location = new System.Drawing.Point(462, 18);
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
            this.gMapPendingDonors.Size = new System.Drawing.Size(677, 528);
            this.gMapPendingDonors.TabIndex = 1;
            this.gMapPendingDonors.Zoom = 0D;
            // 
            // doctorPage
            // 
            this.doctorPage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.doctorPage.Controls.Add(this.groupBox2);
            this.doctorPage.Controls.Add(this.groupBox1);
            this.doctorPage.Location = new System.Drawing.Point(4, 33);
            this.doctorPage.Name = "doctorPage";
            this.doctorPage.Padding = new System.Windows.Forms.Padding(3);
            this.doctorPage.Size = new System.Drawing.Size(1145, 556);
            this.doctorPage.TabIndex = 1;
            this.doctorPage.Text = "Requests from doctors";
            this.doctorPage.Click += new System.EventHandler(this.doctorPage_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.doctorRequestList);
            this.groupBox2.Font = new System.Drawing.Font("Arial Unicode MS", 11F);
            this.groupBox2.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 540);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Requests from doctors";
            // 
            // doctorRequestList
            // 
            this.doctorRequestList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.doctorRequestList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.doctorRequestList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.doctorRequestList.FormattingEnabled = true;
            this.doctorRequestList.Location = new System.Drawing.Point(6, 37);
            this.doctorRequestList.Name = "doctorRequestList";
            this.doctorRequestList.ScrollAlwaysVisible = true;
            this.doctorRequestList.Size = new System.Drawing.Size(438, 493);
            this.doctorRequestList.TabIndex = 0;
            this.doctorRequestList.SelectedIndexChanged += new System.EventHandler(this.doctorRequestList_SelectedIndexChanged_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.gMapRouteToDoctor);
            this.groupBox1.Controls.Add(this.sendBloodButton);
            this.groupBox1.Controls.Add(this.potentialBloodTextBox);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox1.Location = new System.Drawing.Point(462, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(677, 540);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Components which match the request";
            // 
            // gMapRouteToDoctor
            // 
            this.gMapRouteToDoctor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMapRouteToDoctor.Bearing = 0F;
            this.gMapRouteToDoctor.CanDragMap = true;
            this.gMapRouteToDoctor.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapRouteToDoctor.GrayScaleMode = false;
            this.gMapRouteToDoctor.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapRouteToDoctor.LevelsKeepInMemmory = 5;
            this.gMapRouteToDoctor.Location = new System.Drawing.Point(6, 89);
            this.gMapRouteToDoctor.MarkersEnabled = true;
            this.gMapRouteToDoctor.MaxZoom = 15;
            this.gMapRouteToDoctor.MinZoom = 15;
            this.gMapRouteToDoctor.MouseWheelZoomEnabled = true;
            this.gMapRouteToDoctor.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapRouteToDoctor.Name = "gMapRouteToDoctor";
            this.gMapRouteToDoctor.NegativeMode = false;
            this.gMapRouteToDoctor.PolygonsEnabled = true;
            this.gMapRouteToDoctor.RetryLoadTile = 0;
            this.gMapRouteToDoctor.RoutesEnabled = true;
            this.gMapRouteToDoctor.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapRouteToDoctor.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapRouteToDoctor.ShowTileGridLines = false;
            this.gMapRouteToDoctor.Size = new System.Drawing.Size(665, 441);
            this.gMapRouteToDoctor.TabIndex = 4;
            this.gMapRouteToDoctor.Zoom = 0D;
            this.gMapRouteToDoctor.Load += new System.EventHandler(this.gMapRouteToDoctor_Load);
            // 
            // sendBloodButton
            // 
            this.sendBloodButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sendBloodButton.Enabled = false;
            this.sendBloodButton.Font = new System.Drawing.Font("Arial Unicode MS", 9.2F);
            this.sendBloodButton.ForeColor = System.Drawing.Color.Black;
            this.sendBloodButton.Location = new System.Drawing.Point(6, 37);
            this.sendBloodButton.Name = "sendBloodButton";
            this.sendBloodButton.Size = new System.Drawing.Size(152, 46);
            this.sendBloodButton.TabIndex = 2;
            this.sendBloodButton.Text = "Send";
            this.sendBloodButton.UseVisualStyleBackColor = false;
            this.sendBloodButton.Click += new System.EventHandler(this.sendBloodButton_Click);
            // 
            // potentialBloodTextBox
            // 
            this.potentialBloodTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.potentialBloodTextBox.Location = new System.Drawing.Point(164, 37);
            this.potentialBloodTextBox.Name = "potentialBloodTextBox";
            this.potentialBloodTextBox.Size = new System.Drawing.Size(507, 46);
            this.potentialBloodTextBox.TabIndex = 0;
            this.potentialBloodTextBox.Text = "";
            this.potentialBloodTextBox.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // bloodStockPage
            // 
            this.bloodStockPage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bloodStockPage.Controls.Add(this.label3);
            this.bloodStockPage.Controls.Add(this.stocksDataGridView);
            this.bloodStockPage.Controls.Add(this.compoenetSelectComboBox);
            this.bloodStockPage.Controls.Add(this.label2);
            this.bloodStockPage.Location = new System.Drawing.Point(4, 33);
            this.bloodStockPage.Name = "bloodStockPage";
            this.bloodStockPage.Padding = new System.Windows.Forms.Padding(3);
            this.bloodStockPage.Size = new System.Drawing.Size(1145, 556);
            this.bloodStockPage.TabIndex = 3;
            this.bloodStockPage.Text = "Component stocks";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(258, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "stocks";
            // 
            // stocksDataGridView
            // 
            this.stocksDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stocksDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.stocksDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.stocksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stocksDataGridView.Location = new System.Drawing.Point(11, 48);
            this.stocksDataGridView.Name = "stocksDataGridView";
            this.stocksDataGridView.ReadOnly = true;
            this.stocksDataGridView.RowTemplate.Height = 24;
            this.stocksDataGridView.Size = new System.Drawing.Size(1128, 502);
            this.stocksDataGridView.TabIndex = 3;
            // 
            // compoenetSelectComboBox
            // 
            this.compoenetSelectComboBox.FormattingEnabled = true;
            this.compoenetSelectComboBox.Items.AddRange(new object[] {
            "Red cells",
            "Trombocytes",
            "Plasma"});
            this.compoenetSelectComboBox.Location = new System.Drawing.Point(66, 10);
            this.compoenetSelectComboBox.Name = "compoenetSelectComboBox";
            this.compoenetSelectComboBox.Size = new System.Drawing.Size(186, 32);
            this.compoenetSelectComboBox.TabIndex = 2;
            this.compoenetSelectComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(6, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "View";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 680);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "*Request are sorted by priority";
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.refreshButton.ForeColor = System.Drawing.Color.Black;
            this.refreshButton.Location = new System.Drawing.Point(1032, 12);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(129, 41);
            this.refreshButton.TabIndex = 3;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.nameLabel.Location = new System.Drawing.Point(7, 17);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(203, 25);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Donation center name";
            // 
            // logOutButton
            // 
            this.logOutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.logOutButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.logOutButton.Location = new System.Drawing.Point(1042, 677);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(123, 29);
            this.logOutButton.TabIndex = 5;
            this.logOutButton.Text = "Log out";
            this.logOutButton.UseVisualStyleBackColor = false;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Enabled = true;
            this.refreshTimer.Interval = 60000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(9, 56);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(275, 17);
            this.label33.TabIndex = 10;
            this.label33.Text = "NB! All quantities are measured in mililiters";
            // 
            // DonationCenterGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1177, 719);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.selectionTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DonationCenterGUI";
            this.Load += new System.EventHandler(this.DonationCenterGUI_Load);
            this.selectionTab.ResumeLayout(false);
            this.donorPage.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.pendingPage.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.doctorPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.bloodStockPage.ResumeLayout(false);
            this.bloodStockPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDataGridView)).EndInit();
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
        private System.Windows.Forms.Button donorNotOkButton;
        private System.Windows.Forms.Button donorOkButton;
        private System.Windows.Forms.Button refreshButton;
        private SafeNishBox donorList;
        private System.Windows.Forms.Label nameLabel;
        private SafeNishBox pendingDonorList;
        private SafeNishBox doctorRequestList;
        private System.Windows.Forms.Button sendBloodButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox potentialBloodTextBox;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.Label label1;
        private GMap.NET.WindowsForms.GMapControl gMapRouteToDoctor;
        private System.Windows.Forms.ComboBox compoenetSelectComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView stocksDataGridView;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label3;
    }
}
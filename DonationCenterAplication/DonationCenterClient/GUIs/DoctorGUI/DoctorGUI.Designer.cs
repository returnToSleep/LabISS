namespace Client.GUIs
{
    partial class DoctorGUI
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.bloodStockPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.trombQuantity = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.red0NQauntity = new System.Windows.Forms.TextBox();
            this.redABNQauntity = new System.Windows.Forms.TextBox();
            this.redBNQauntity = new System.Windows.Forms.TextBox();
            this.redANQauntity = new System.Windows.Forms.TextBox();
            this.red0PQauntity = new System.Windows.Forms.TextBox();
            this.redABPQauntity = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.redBPQauntity = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.redAPQauntity = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Plasma0Quantity = new System.Windows.Forms.TextBox();
            this.PlasmaABQuantity = new System.Windows.Forms.TextBox();
            this.PlasmaBQuantity = new System.Windows.Forms.TextBox();
            this.PlasmaAQuantity = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.gMapStocks = new GMap.NET.WindowsForms.GMapControl();
            this.refreshButton = new System.Windows.Forms.Button();
            this.selectionTab = new System.Windows.Forms.TabControl();
            this.requestPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.quantity = new System.Windows.Forms.TextBox();
            this.antigen = new System.Windows.Forms.TextBox();
            this.rh = new System.Windows.Forms.TextBox();
            this.cnp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.component = new System.Windows.Forms.ComboBox();
            this.priority = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.gMapDoctors = new GMap.NET.WindowsForms.GMapControl();
            this.deliveryTab = new System.Windows.Forms.TabPage();
            this.label24 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.noAcceptBloodButton = new System.Windows.Forms.Button();
            this.acceptBloodButton = new System.Windows.Forms.Button();
            this.deliveredBloodList = new NishBox.MultiLineListBox();
            this.requestList = new NishBox.MultiLineListBox();
            this.bloodStockPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.selectionTab.SuspendLayout();
            this.requestPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.deliveryTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.nameLabel.Location = new System.Drawing.Point(19, 10);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(39, 24);
            this.nameLabel.TabIndex = 7;
            this.nameLabel.Text = "Dr. ";
            // 
            // bloodStockPage
            // 
            this.bloodStockPage.BackColor = System.Drawing.Color.Transparent;
            this.bloodStockPage.Controls.Add(this.groupBox2);
            this.bloodStockPage.Controls.Add(this.gMapStocks);
            this.bloodStockPage.Location = new System.Drawing.Point(4, 25);
            this.bloodStockPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bloodStockPage.Name = "bloodStockPage";
            this.bloodStockPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bloodStockPage.Size = new System.Drawing.Size(1159, 672);
            this.bloodStockPage.TabIndex = 3;
            this.bloodStockPage.Text = "Stocuri";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.comboBox4);
            this.groupBox2.Location = new System.Drawing.Point(770, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(378, 653);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalii comanda";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.trombQuantity);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Location = new System.Drawing.Point(19, 570);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(353, 77);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Trombocite";
            // 
            // trombQuantity
            // 
            this.trombQuantity.Location = new System.Drawing.Point(151, 39);
            this.trombQuantity.Name = "trombQuantity";
            this.trombQuantity.Size = new System.Drawing.Size(195, 22);
            this.trombQuantity.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 17);
            this.label9.TabIndex = 22;
            this.label9.Text = "Cantitate";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.red0NQauntity);
            this.groupBox4.Controls.Add(this.redABNQauntity);
            this.groupBox4.Controls.Add(this.redBNQauntity);
            this.groupBox4.Controls.Add(this.redANQauntity);
            this.groupBox4.Controls.Add(this.red0PQauntity);
            this.groupBox4.Controls.Add(this.redABPQauntity);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.redBPQauntity);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.redAPQauntity);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Location = new System.Drawing.Point(16, 264);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(355, 300);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Hematii";
            // 
            // red0NQauntity
            // 
            this.red0NQauntity.Location = new System.Drawing.Point(154, 259);
            this.red0NQauntity.Name = "red0NQauntity";
            this.red0NQauntity.Size = new System.Drawing.Size(195, 22);
            this.red0NQauntity.TabIndex = 21;
            // 
            // redABNQauntity
            // 
            this.redABNQauntity.Location = new System.Drawing.Point(154, 231);
            this.redABNQauntity.Name = "redABNQauntity";
            this.redABNQauntity.Size = new System.Drawing.Size(195, 22);
            this.redABNQauntity.TabIndex = 20;
            // 
            // redBNQauntity
            // 
            this.redBNQauntity.Location = new System.Drawing.Point(154, 203);
            this.redBNQauntity.Name = "redBNQauntity";
            this.redBNQauntity.Size = new System.Drawing.Size(195, 22);
            this.redBNQauntity.TabIndex = 19;
            // 
            // redANQauntity
            // 
            this.redANQauntity.Location = new System.Drawing.Point(155, 176);
            this.redANQauntity.Name = "redANQauntity";
            this.redANQauntity.Size = new System.Drawing.Size(195, 22);
            this.redANQauntity.TabIndex = 18;
            // 
            // red0PQauntity
            // 
            this.red0PQauntity.Location = new System.Drawing.Point(154, 121);
            this.red0PQauntity.Name = "red0PQauntity";
            this.red0PQauntity.Size = new System.Drawing.Size(195, 22);
            this.red0PQauntity.TabIndex = 17;
            // 
            // redABPQauntity
            // 
            this.redABPQauntity.Location = new System.Drawing.Point(154, 93);
            this.redABPQauntity.Name = "redABPQauntity";
            this.redABPQauntity.Size = new System.Drawing.Size(195, 22);
            this.redABPQauntity.TabIndex = 16;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(27, 262);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(23, 17);
            this.label23.TabIndex = 17;
            this.label23.Text = "0-";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(26, 206);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(24, 17);
            this.label22.TabIndex = 16;
            this.label22.Text = "B-";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(26, 179);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(24, 17);
            this.label20.TabIndex = 14;
            this.label20.Text = "A-";
            // 
            // redBPQauntity
            // 
            this.redBPQauntity.Location = new System.Drawing.Point(154, 65);
            this.redBPQauntity.Name = "redBPQauntity";
            this.redBPQauntity.Size = new System.Drawing.Size(195, 22);
            this.redBPQauntity.TabIndex = 15;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(24, 234);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(34, 17);
            this.label21.TabIndex = 15;
            this.label21.Text = "AB-";
            // 
            // redAPQauntity
            // 
            this.redAPQauntity.Location = new System.Drawing.Point(155, 37);
            this.redAPQauntity.Name = "redAPQauntity";
            this.redAPQauntity.Size = new System.Drawing.Size(195, 22);
            this.redAPQauntity.TabIndex = 14;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(25, 124);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(26, 17);
            this.label19.TabIndex = 13;
            this.label19.Text = "0+";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(24, 68);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(27, 17);
            this.label18.TabIndex = 12;
            this.label18.Text = "B+";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(22, 96);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 17);
            this.label17.TabIndex = 11;
            this.label17.Text = "AB+";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(24, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(27, 17);
            this.label15.TabIndex = 10;
            this.label15.Text = "A+";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Plasma0Quantity);
            this.groupBox3.Controls.Add(this.PlasmaABQuantity);
            this.groupBox3.Controls.Add(this.PlasmaBQuantity);
            this.groupBox3.Controls.Add(this.PlasmaAQuantity);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(16, 91);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(356, 167);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Plasma";
            // 
            // Plasma0Quantity
            // 
            this.Plasma0Quantity.Location = new System.Drawing.Point(155, 120);
            this.Plasma0Quantity.Name = "Plasma0Quantity";
            this.Plasma0Quantity.Size = new System.Drawing.Size(195, 22);
            this.Plasma0Quantity.TabIndex = 13;
            // 
            // PlasmaABQuantity
            // 
            this.PlasmaABQuantity.Location = new System.Drawing.Point(155, 92);
            this.PlasmaABQuantity.Name = "PlasmaABQuantity";
            this.PlasmaABQuantity.Size = new System.Drawing.Size(195, 22);
            this.PlasmaABQuantity.TabIndex = 12;
            // 
            // PlasmaBQuantity
            // 
            this.PlasmaBQuantity.Location = new System.Drawing.Point(155, 64);
            this.PlasmaBQuantity.Name = "PlasmaBQuantity";
            this.PlasmaBQuantity.Size = new System.Drawing.Size(195, 22);
            this.PlasmaBQuantity.TabIndex = 11;
            // 
            // PlasmaAQuantity
            // 
            this.PlasmaAQuantity.Location = new System.Drawing.Point(155, 31);
            this.PlasmaAQuantity.Name = "PlasmaAQuantity";
            this.PlasmaAQuantity.Size = new System.Drawing.Size(195, 22);
            this.PlasmaAQuantity.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 123);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 17);
            this.label13.TabIndex = 8;
            this.label13.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 95);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 17);
            this.label12.TabIndex = 7;
            this.label12.Text = "AB";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 17);
            this.label11.TabIndex = 6;
            this.label11.Text = "B";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 17);
            this.label10.TabIndex = 5;
            this.label10.Text = "A";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(19, 60);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 17);
            this.label16.TabIndex = 3;
            this.label16.Text = "Centru";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(171, 53);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(200, 24);
            this.comboBox4.TabIndex = 2;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // gMapStocks
            // 
            this.gMapStocks.Bearing = 0F;
            this.gMapStocks.CanDragMap = true;
            this.gMapStocks.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapStocks.GrayScaleMode = false;
            this.gMapStocks.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapStocks.LevelsKeepInMemmory = 5;
            this.gMapStocks.Location = new System.Drawing.Point(7, 5);
            this.gMapStocks.MarkersEnabled = true;
            this.gMapStocks.MaxZoom = 15;
            this.gMapStocks.MinZoom = 15;
            this.gMapStocks.MouseWheelZoomEnabled = true;
            this.gMapStocks.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapStocks.Name = "gMapStocks";
            this.gMapStocks.NegativeMode = false;
            this.gMapStocks.PolygonsEnabled = true;
            this.gMapStocks.RetryLoadTile = 0;
            this.gMapStocks.RoutesEnabled = true;
            this.gMapStocks.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapStocks.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapStocks.ShowTileGridLines = false;
            this.gMapStocks.Size = new System.Drawing.Size(757, 662);
            this.gMapStocks.TabIndex = 9;
            this.gMapStocks.Zoom = 0D;
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.SystemColors.Control;
            this.refreshButton.Location = new System.Drawing.Point(1039, 11);
            this.refreshButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(129, 41);
            this.refreshButton.TabIndex = 6;
            this.refreshButton.Text = "Reinprospatare";
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // selectionTab
            // 
            this.selectionTab.Controls.Add(this.bloodStockPage);
            this.selectionTab.Controls.Add(this.requestPage);
            this.selectionTab.Controls.Add(this.deliveryTab);
            this.selectionTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectionTab.Location = new System.Drawing.Point(12, 41);
            this.selectionTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selectionTab.Name = "selectionTab";
            this.selectionTab.SelectedIndex = 0;
            this.selectionTab.Size = new System.Drawing.Size(1167, 701);
            this.selectionTab.TabIndex = 5;
            // 
            // requestPage
            // 
            this.requestPage.Controls.Add(this.groupBox1);
            this.requestPage.Controls.Add(this.gMapDoctors);
            this.requestPage.Location = new System.Drawing.Point(4, 25);
            this.requestPage.Margin = new System.Windows.Forms.Padding(4);
            this.requestPage.Name = "requestPage";
            this.requestPage.Padding = new System.Windows.Forms.Padding(4);
            this.requestPage.Size = new System.Drawing.Size(1159, 672);
            this.requestPage.TabIndex = 4;
            this.requestPage.Text = "Comanda compoenente";
            this.requestPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.quantity);
            this.groupBox1.Controls.Add(this.antigen);
            this.groupBox1.Controls.Add(this.rh);
            this.groupBox1.Controls.Add(this.cnp);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.component);
            this.groupBox1.Controls.Add(this.priority);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(767, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 333);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalii comanda";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F);
            this.label8.Location = new System.Drawing.Point(6, 313);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "* - campuri optionale";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(242, 298);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "Trimite";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // quantity
            // 
            this.quantity.Location = new System.Drawing.Point(154, 228);
            this.quantity.Margin = new System.Windows.Forms.Padding(4);
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(220, 22);
            this.quantity.TabIndex = 4;
            // 
            // antigen
            // 
            this.antigen.Location = new System.Drawing.Point(154, 170);
            this.antigen.Margin = new System.Windows.Forms.Padding(4);
            this.antigen.Name = "antigen";
            this.antigen.Size = new System.Drawing.Size(220, 22);
            this.antigen.TabIndex = 4;
            // 
            // rh
            // 
            this.rh.Location = new System.Drawing.Point(154, 198);
            this.rh.Margin = new System.Windows.Forms.Padding(4);
            this.rh.Name = "rh";
            this.rh.Size = new System.Drawing.Size(220, 22);
            this.rh.TabIndex = 4;
            // 
            // cnp
            // 
            this.cnp.Location = new System.Drawing.Point(154, 108);
            this.cnp.Margin = new System.Windows.Forms.Padding(4);
            this.cnp.Name = "cnp";
            this.cnp.Size = new System.Drawing.Size(220, 22);
            this.cnp.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 233);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Cantitate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 203);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "RH*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 173);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tip*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 141);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Componenta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 111);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "CNP Pacient";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Prioritate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Centru";
            // 
            // component
            // 
            this.component.FormattingEnabled = true;
            this.component.Items.AddRange(new object[] {
            "RedBloodCell",
            "Plasma",
            "Trombocyte"});
            this.component.Location = new System.Drawing.Point(154, 138);
            this.component.Margin = new System.Windows.Forms.Padding(4);
            this.component.Name = "component";
            this.component.Size = new System.Drawing.Size(220, 24);
            this.component.TabIndex = 2;
            this.component.SelectedIndexChanged += new System.EventHandler(this.component_SelectedIndexChanged);
            // 
            // priority
            // 
            this.priority.FormattingEnabled = true;
            this.priority.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.priority.Location = new System.Drawing.Point(154, 76);
            this.priority.Margin = new System.Windows.Forms.Padding(4);
            this.priority.Name = "priority";
            this.priority.Size = new System.Drawing.Size(220, 24);
            this.priority.TabIndex = 2;
            this.priority.SelectedIndexChanged += new System.EventHandler(this.priority_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(154, 47);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(220, 24);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // gMapDoctors
            // 
            this.gMapDoctors.Bearing = 0F;
            this.gMapDoctors.CanDragMap = true;
            this.gMapDoctors.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapDoctors.GrayScaleMode = false;
            this.gMapDoctors.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapDoctors.LevelsKeepInMemmory = 5;
            this.gMapDoctors.Location = new System.Drawing.Point(7, 6);
            this.gMapDoctors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gMapDoctors.MarkersEnabled = true;
            this.gMapDoctors.MaxZoom = 15;
            this.gMapDoctors.MinZoom = 15;
            this.gMapDoctors.MouseWheelZoomEnabled = true;
            this.gMapDoctors.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapDoctors.Name = "gMapDoctors";
            this.gMapDoctors.NegativeMode = false;
            this.gMapDoctors.PolygonsEnabled = true;
            this.gMapDoctors.RetryLoadTile = 0;
            this.gMapDoctors.RoutesEnabled = true;
            this.gMapDoctors.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapDoctors.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapDoctors.ShowTileGridLines = false;
            this.gMapDoctors.Size = new System.Drawing.Size(754, 660);
            this.gMapDoctors.TabIndex = 1;
            this.gMapDoctors.Zoom = 0D;
            // 
            // deliveryTab
            // 
            this.deliveryTab.Controls.Add(this.label24);
            this.deliveryTab.Controls.Add(this.label14);
            this.deliveryTab.Controls.Add(this.noAcceptBloodButton);
            this.deliveryTab.Controls.Add(this.acceptBloodButton);
            this.deliveryTab.Controls.Add(this.deliveredBloodList);
            this.deliveryTab.Controls.Add(this.requestList);
            this.deliveryTab.Location = new System.Drawing.Point(4, 25);
            this.deliveryTab.Name = "deliveryTab";
            this.deliveryTab.Size = new System.Drawing.Size(1159, 672);
            this.deliveryTab.TabIndex = 5;
            this.deliveryTab.Text = "Comenzi";
            this.deliveryTab.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(585, 30);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(257, 17);
            this.label24.TabIndex = 5;
            this.label24.Text = "Componente care satisfac cererea";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 17);
            this.label14.TabIndex = 4;
            this.label14.Text = "Comenzi plasate";
            // 
            // noAcceptBloodButton
            // 
            this.noAcceptBloodButton.BackColor = System.Drawing.Color.Crimson;
            this.noAcceptBloodButton.Location = new System.Drawing.Point(892, 3);
            this.noAcceptBloodButton.Name = "noAcceptBloodButton";
            this.noAcceptBloodButton.Size = new System.Drawing.Size(125, 41);
            this.noAcceptBloodButton.TabIndex = 3;
            this.noAcceptBloodButton.Text = "Refuz";
            this.noAcceptBloodButton.UseVisualStyleBackColor = false;
            this.noAcceptBloodButton.Click += new System.EventHandler(this.noAcceptBloodButton_Click);
            // 
            // acceptBloodButton
            // 
            this.acceptBloodButton.BackColor = System.Drawing.Color.GreenYellow;
            this.acceptBloodButton.Location = new System.Drawing.Point(1023, 3);
            this.acceptBloodButton.Name = "acceptBloodButton";
            this.acceptBloodButton.Size = new System.Drawing.Size(125, 41);
            this.acceptBloodButton.TabIndex = 2;
            this.acceptBloodButton.Text = "Acceptare";
            this.acceptBloodButton.UseVisualStyleBackColor = false;
            this.acceptBloodButton.Click += new System.EventHandler(this.acceptBloodButton_Click);
            // 
            // deliveredBloodList
            // 
            this.deliveredBloodList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.deliveredBloodList.FormattingEnabled = true;
            this.deliveredBloodList.Location = new System.Drawing.Point(588, 50);
            this.deliveredBloodList.Name = "deliveredBloodList";
            this.deliveredBloodList.ScrollAlwaysVisible = true;
            this.deliveredBloodList.Size = new System.Drawing.Size(560, 613);
            this.deliveredBloodList.TabIndex = 1;
            // 
            // requestList
            // 
            this.requestList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.requestList.FormattingEnabled = true;
            this.requestList.Location = new System.Drawing.Point(7, 50);
            this.requestList.Name = "requestList";
            this.requestList.ScrollAlwaysVisible = true;
            this.requestList.Size = new System.Drawing.Size(575, 616);
            this.requestList.TabIndex = 0;
            this.requestList.SelectedIndexChanged += new System.EventHandler(this.requestList_SelectedIndexChanged);
            // 
            // DoctorGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 753);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.selectionTab);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DoctorGUI";
            this.Text = "DoctorGUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DoctorGUI_FormClosed);
            this.bloodStockPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.selectionTab.ResumeLayout(false);
            this.requestPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.deliveryTab.ResumeLayout(false);
            this.deliveryTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TabPage bloodStockPage;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.TabControl selectionTab;
        private System.Windows.Forms.TabPage requestPage;
        private GMap.NET.WindowsForms.GMapControl gMapDoctors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox cnp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox component;
        private System.Windows.Forms.ComboBox priority;
        private System.Windows.Forms.TextBox quantity;
        private System.Windows.Forms.TextBox antigen;
        private System.Windows.Forms.TextBox rh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox4;
        private GMap.NET.WindowsForms.GMapControl gMapStocks;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox red0PQauntity;
        private System.Windows.Forms.TextBox redABPQauntity;
        private System.Windows.Forms.TextBox redBPQauntity;
        private System.Windows.Forms.TextBox redAPQauntity;
        private System.Windows.Forms.TextBox red0NQauntity;
        private System.Windows.Forms.TextBox redABNQauntity;
        private System.Windows.Forms.TextBox redBNQauntity;
        private System.Windows.Forms.TextBox redANQauntity;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox Plasma0Quantity;
        private System.Windows.Forms.TextBox PlasmaABQuantity;
        private System.Windows.Forms.TextBox PlasmaBQuantity;
        private System.Windows.Forms.TextBox PlasmaAQuantity;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox trombQuantity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage deliveryTab;
        private System.Windows.Forms.Button noAcceptBloodButton;
        private System.Windows.Forms.Button acceptBloodButton;
        private NishBox.MultiLineListBox deliveredBloodList;
        private NishBox.MultiLineListBox requestList;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label14;
    }
}
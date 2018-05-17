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
            this.stockTrombList = new NishBox.MultiLineListBox();
            this.stockPlasmaList = new NishBox.MultiLineListBox();
            this.stockRedCellList = new NishBox.MultiLineListBox();
            this.trombLabel = new System.Windows.Forms.Label();
            this.plasmaLabel = new System.Windows.Forms.Label();
            this.redBloodLable = new System.Windows.Forms.Label();
            this.bloodStockPage = new System.Windows.Forms.TabPage();
            this.refreshButton = new System.Windows.Forms.Button();
            this.selectionTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gMapDoctors = new GMap.NET.WindowsForms.GMapControl();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.priority = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cnp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.component = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rh = new System.Windows.Forms.TextBox();
            this.antigen = new System.Windows.Forms.TextBox();
            this.quantity = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.bloodStockPage.SuspendLayout();
            this.selectionTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.nameLabel.Location = new System.Drawing.Point(14, 8);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(154, 18);
            this.nameLabel.TabIndex = 7;
            this.nameLabel.Text = "Donation center name";
            // 
            // stockTrombList
            // 
            this.stockTrombList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.stockTrombList.FormattingEnabled = true;
            this.stockTrombList.Location = new System.Drawing.Point(540, 29);
            this.stockTrombList.Margin = new System.Windows.Forms.Padding(2);
            this.stockTrombList.Name = "stockTrombList";
            this.stockTrombList.ScrollAlwaysVisible = true;
            this.stockTrombList.Size = new System.Drawing.Size(262, 426);
            this.stockTrombList.TabIndex = 8;
            // 
            // stockPlasmaList
            // 
            this.stockPlasmaList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.stockPlasmaList.FormattingEnabled = true;
            this.stockPlasmaList.Location = new System.Drawing.Point(274, 28);
            this.stockPlasmaList.Margin = new System.Windows.Forms.Padding(2);
            this.stockPlasmaList.Name = "stockPlasmaList";
            this.stockPlasmaList.ScrollAlwaysVisible = true;
            this.stockPlasmaList.Size = new System.Drawing.Size(262, 426);
            this.stockPlasmaList.TabIndex = 7;
            // 
            // stockRedCellList
            // 
            this.stockRedCellList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.stockRedCellList.FormattingEnabled = true;
            this.stockRedCellList.Location = new System.Drawing.Point(21, 28);
            this.stockRedCellList.Margin = new System.Windows.Forms.Padding(2);
            this.stockRedCellList.Name = "stockRedCellList";
            this.stockRedCellList.ScrollAlwaysVisible = true;
            this.stockRedCellList.Size = new System.Drawing.Size(249, 427);
            this.stockRedCellList.TabIndex = 6;
            // 
            // trombLabel
            // 
            this.trombLabel.AutoSize = true;
            this.trombLabel.Location = new System.Drawing.Point(536, 11);
            this.trombLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.trombLabel.Name = "trombLabel";
            this.trombLabel.Size = new System.Drawing.Size(70, 13);
            this.trombLabel.TabIndex = 5;
            this.trombLabel.Text = "Trombocite";
            // 
            // plasmaLabel
            // 
            this.plasmaLabel.AutoSize = true;
            this.plasmaLabel.Location = new System.Drawing.Point(271, 11);
            this.plasmaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.plasmaLabel.Name = "plasmaLabel";
            this.plasmaLabel.Size = new System.Drawing.Size(47, 13);
            this.plasmaLabel.TabIndex = 4;
            this.plasmaLabel.Text = "Plasma";
            // 
            // redBloodLable
            // 
            this.redBloodLable.AutoSize = true;
            this.redBloodLable.Location = new System.Drawing.Point(18, 11);
            this.redBloodLable.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.redBloodLable.Name = "redBloodLable";
            this.redBloodLable.Size = new System.Drawing.Size(69, 13);
            this.redBloodLable.TabIndex = 3;
            this.redBloodLable.Text = "Celule rosii";
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
            this.bloodStockPage.Location = new System.Drawing.Point(4, 22);
            this.bloodStockPage.Margin = new System.Windows.Forms.Padding(2);
            this.bloodStockPage.Name = "bloodStockPage";
            this.bloodStockPage.Padding = new System.Windows.Forms.Padding(2);
            this.bloodStockPage.Size = new System.Drawing.Size(806, 466);
            this.bloodStockPage.TabIndex = 3;
            this.bloodStockPage.Text = "Stocuri";
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(722, 11);
            this.refreshButton.Margin = new System.Windows.Forms.Padding(2);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(97, 33);
            this.refreshButton.TabIndex = 6;
            this.refreshButton.Text = "Reinprospatare";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // selectionTab
            // 
            this.selectionTab.Controls.Add(this.bloodStockPage);
            this.selectionTab.Controls.Add(this.tabPage1);
            this.selectionTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectionTab.Location = new System.Drawing.Point(9, 33);
            this.selectionTab.Margin = new System.Windows.Forms.Padding(2);
            this.selectionTab.Name = "selectionTab";
            this.selectionTab.SelectedIndex = 0;
            this.selectionTab.Size = new System.Drawing.Size(814, 492);
            this.selectionTab.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.quantity);
            this.tabPage1.Controls.Add(this.antigen);
            this.tabPage1.Controls.Add(this.rh);
            this.tabPage1.Controls.Add(this.cnp);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.component);
            this.tabPage1.Controls.Add(this.priority);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.gMapDoctors);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(806, 466);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gMapDoctors
            // 
            this.gMapDoctors.Bearing = 0F;
            this.gMapDoctors.CanDragMap = true;
            this.gMapDoctors.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapDoctors.GrayScaleMode = false;
            this.gMapDoctors.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapDoctors.LevelsKeepInMemmory = 5;
            this.gMapDoctors.Location = new System.Drawing.Point(5, 5);
            this.gMapDoctors.Margin = new System.Windows.Forms.Padding(2);
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
            this.gMapDoctors.Size = new System.Drawing.Size(550, 456);
            this.gMapDoctors.TabIndex = 1;
            this.gMapDoctors.Zoom = 0D;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(645, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(155, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(560, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Spital";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(560, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Prioritate";
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
            this.priority.Location = new System.Drawing.Point(645, 49);
            this.priority.Name = "priority";
            this.priority.Size = new System.Drawing.Size(155, 21);
            this.priority.TabIndex = 2;
            this.priority.SelectedIndexChanged += new System.EventHandler(this.priority_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(560, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "CNP Pacient";
            // 
            // cnp
            // 
            this.cnp.Location = new System.Drawing.Point(645, 85);
            this.cnp.Name = "cnp";
            this.cnp.Size = new System.Drawing.Size(155, 19);
            this.cnp.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(558, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Componenta";
            // 
            // component
            // 
            this.component.FormattingEnabled = true;
            this.component.Items.AddRange(new object[] {
            "RedBloodCell",
            "Plasma",
            "Trombocyte"});
            this.component.Location = new System.Drawing.Point(645, 124);
            this.component.Name = "component";
            this.component.Size = new System.Drawing.Size(155, 21);
            this.component.TabIndex = 2;
            this.component.SelectedIndexChanged += new System.EventHandler(this.component_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(560, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Antigen";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(560, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "RH";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(560, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Cantitate";
            // 
            // rh
            // 
            this.rh.Location = new System.Drawing.Point(645, 207);
            this.rh.Name = "rh";
            this.rh.Size = new System.Drawing.Size(155, 19);
            this.rh.TabIndex = 4;
            // 
            // antigen
            // 
            this.antigen.Location = new System.Drawing.Point(645, 167);
            this.antigen.Name = "antigen";
            this.antigen.Size = new System.Drawing.Size(155, 19);
            this.antigen.TabIndex = 4;
            // 
            // quantity
            // 
            this.quantity.Location = new System.Drawing.Point(645, 245);
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(155, 19);
            this.quantity.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(725, 286);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Trimite";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DoctorGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 533);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.selectionTab);
            this.Name = "DoctorGUI";
            this.Text = "DoctorGUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DoctorGUI_FormClosed);
            this.bloodStockPage.ResumeLayout(false);
            this.bloodStockPage.PerformLayout();
            this.selectionTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private NishBox.MultiLineListBox stockTrombList;
        private NishBox.MultiLineListBox stockPlasmaList;
        private NishBox.MultiLineListBox stockRedCellList;
        private System.Windows.Forms.Label trombLabel;
        private System.Windows.Forms.Label plasmaLabel;
        private System.Windows.Forms.Label redBloodLable;
        private System.Windows.Forms.TabPage bloodStockPage;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.TabControl selectionTab;
        private System.Windows.Forms.TabPage tabPage1;
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
    }
}
namespace DonationCenterServer.Forms
{
    partial class DonationCenterCRUD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DonationCenterCRUD));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.locYTextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.locXTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.nameTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gMapDonationCenterSelect = new GMap.NET.WindowsForms.GMapControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(488, 15);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(515, 661);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.locYTextbox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.locXTextbox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.nameTextbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(464, 283);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adaugare centru de donatie";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(102, 236);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 39);
            this.button2.TabIndex = 10;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // locYTextbox
            // 
            this.locYTextbox.Location = new System.Drawing.Point(253, 70);
            this.locYTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.locYTextbox.Name = "locYTextbox";
            this.locYTextbox.Size = new System.Drawing.Size(172, 34);
            this.locYTextbox.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(248, 37);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 29);
            this.label5.TabIndex = 9;
            this.label5.Text = "Loc Y";
            // 
            // locXTextbox
            // 
            this.locXTextbox.Location = new System.Drawing.Point(29, 70);
            this.locXTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.locXTextbox.Name = "locXTextbox";
            this.locXTextbox.Size = new System.Drawing.Size(172, 34);
            this.locXTextbox.TabIndex = 1;
            this.locXTextbox.TextChanged += new System.EventHandler(this.locXTextbox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 37);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "Loc X";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(283, 236);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 39);
            this.button1.TabIndex = 6;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nameTextbox
            // 
            this.nameTextbox.Location = new System.Drawing.Point(29, 156);
            this.nameTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.nameTextbox.Name = "nameTextbox";
            this.nameTextbox.Size = new System.Drawing.Size(399, 34);
            this.nameTextbox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 123);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // gMapDonationCenterSelect
            // 
            this.gMapDonationCenterSelect.Bearing = 0F;
            this.gMapDonationCenterSelect.CanDragMap = true;
            this.gMapDonationCenterSelect.EmptyTileColor = System.Drawing.Color.Transparent;
            this.gMapDonationCenterSelect.GrayScaleMode = false;
            this.gMapDonationCenterSelect.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapDonationCenterSelect.LevelsKeepInMemmory = 5;
            this.gMapDonationCenterSelect.Location = new System.Drawing.Point(16, 305);
            this.gMapDonationCenterSelect.MarkersEnabled = true;
            this.gMapDonationCenterSelect.MaxZoom = 15;
            this.gMapDonationCenterSelect.MinZoom = 15;
            this.gMapDonationCenterSelect.MouseWheelZoomEnabled = true;
            this.gMapDonationCenterSelect.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapDonationCenterSelect.Name = "gMapDonationCenterSelect";
            this.gMapDonationCenterSelect.NegativeMode = false;
            this.gMapDonationCenterSelect.PolygonsEnabled = true;
            this.gMapDonationCenterSelect.RetryLoadTile = 0;
            this.gMapDonationCenterSelect.RoutesEnabled = true;
            this.gMapDonationCenterSelect.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapDonationCenterSelect.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapDonationCenterSelect.ShowTileGridLines = false;
            this.gMapDonationCenterSelect.Size = new System.Drawing.Size(464, 371);
            this.gMapDonationCenterSelect.TabIndex = 2;
            this.gMapDonationCenterSelect.Zoom = 0D;
            this.gMapDonationCenterSelect.LocationChanged += new System.EventHandler(this.gMapDonationCenterSelect_LocationChanged);
            this.gMapDonationCenterSelect.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gMapDonationCenterSelect_MouseClick);
            this.gMapDonationCenterSelect.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gMapDonationCenterSelect_MouseMove);
            // 
            // DonationCenterCRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 690);
            this.Controls.Add(this.gMapDonationCenterSelect);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DonationCenterCRUD";
            this.Text = "Donation Center CRUD";
            this.Load += new System.EventHandler(this.DonationCenterCRUD_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox nameTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox locYTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox locXTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private GMap.NET.WindowsForms.GMapControl gMapDonationCenterSelect;
    }
}
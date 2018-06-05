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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.locYTextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.locXTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.nameTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gMapDonationCenterSelect = new GMap.NET.WindowsForms.GMapControl();
            this.donationCenterList = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.locYTextbox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.locXTextbox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Controls.Add(this.nameTextbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(464, 245);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Donation center management";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.ForeColor = System.Drawing.Color.Black;
            this.deleteButton.Location = new System.Drawing.Point(210, 202);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(119, 35);
            this.deleteButton.TabIndex = 10;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // locYTextbox
            // 
            this.locYTextbox.Enabled = false;
            this.locYTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locYTextbox.ForeColor = System.Drawing.Color.Black;
            this.locYTextbox.Location = new System.Drawing.Point(8, 113);
            this.locYTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.locYTextbox.Name = "locYTextbox";
            this.locYTextbox.Size = new System.Drawing.Size(448, 24);
            this.locYTextbox.TabIndex = 2;
            this.locYTextbox.TextChanged += new System.EventHandler(this.locYTextbox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(8, 91);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Loc Y";
            // 
            // locXTextbox
            // 
            this.locXTextbox.Enabled = false;
            this.locXTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locXTextbox.ForeColor = System.Drawing.Color.Black;
            this.locXTextbox.Location = new System.Drawing.Point(8, 63);
            this.locXTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.locXTextbox.Name = "locXTextbox";
            this.locXTextbox.Size = new System.Drawing.Size(448, 24);
            this.locXTextbox.TabIndex = 1;
            this.locXTextbox.TextChanged += new System.EventHandler(this.locXTextbox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(8, 41);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Loc X";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.ForeColor = System.Drawing.Color.Black;
            this.addButton.Location = new System.Drawing.Point(337, 202);
            this.addButton.Margin = new System.Windows.Forms.Padding(4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(119, 35);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // nameTextbox
            // 
            this.nameTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextbox.ForeColor = System.Drawing.Color.Black;
            this.nameTextbox.Location = new System.Drawing.Point(8, 165);
            this.nameTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.nameTextbox.Name = "nameTextbox";
            this.nameTextbox.Size = new System.Drawing.Size(448, 24);
            this.nameTextbox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 143);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // gMapDonationCenterSelect
            // 
            this.gMapDonationCenterSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMapDonationCenterSelect.Bearing = 0F;
            this.gMapDonationCenterSelect.CanDragMap = true;
            this.gMapDonationCenterSelect.EmptyTileColor = System.Drawing.Color.Transparent;
            this.gMapDonationCenterSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gMapDonationCenterSelect.GrayScaleMode = false;
            this.gMapDonationCenterSelect.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapDonationCenterSelect.LevelsKeepInMemmory = 5;
            this.gMapDonationCenterSelect.Location = new System.Drawing.Point(487, 25);
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
            this.gMapDonationCenterSelect.Size = new System.Drawing.Size(520, 652);
            this.gMapDonationCenterSelect.TabIndex = 2;
            this.gMapDonationCenterSelect.Zoom = 0D;
            this.gMapDonationCenterSelect.LocationChanged += new System.EventHandler(this.gMapDonationCenterSelect_LocationChanged);
            this.gMapDonationCenterSelect.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gMapDonationCenterSelect_MouseClick);
            this.gMapDonationCenterSelect.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gMapDonationCenterSelect_MouseMove);
            // 
            // donationCenterList
            // 
            this.donationCenterList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.donationCenterList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donationCenterList.FormattingEnabled = true;
            this.donationCenterList.ItemHeight = 20;
            this.donationCenterList.Location = new System.Drawing.Point(16, 265);
            this.donationCenterList.Name = "donationCenterList";
            this.donationCenterList.Size = new System.Drawing.Size(464, 404);
            this.donationCenterList.TabIndex = 3;
            this.donationCenterList.SelectedIndexChanged += new System.EventHandler(this.donationCenterList_SelectedIndexChanged);
            // 
            // DonationCenterCRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1019, 690);
            this.Controls.Add(this.donationCenterList);
            this.Controls.Add(this.gMapDonationCenterSelect);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DonationCenterCRUD";
            this.Load += new System.EventHandler(this.DonationCenterCRUD_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox nameTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox locYTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox locXTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button deleteButton;
        private GMap.NET.WindowsForms.GMapControl gMapDonationCenterSelect;
        private System.Windows.Forms.ListBox donationCenterList;
    }
}
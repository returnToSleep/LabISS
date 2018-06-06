namespace DonationCenterServer.Forms
{
    partial class DoctorCRUD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctorCRUD));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hospitalTextBox = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.locYTextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.locXTextbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.specialityTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gMapDoctorSelect = new GMap.NET.WindowsForms.GMapControl();
            this.doctorList = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.hospitalTextBox);
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Controls.Add(this.locYTextbox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.locXTextbox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.specialityTextbox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nameTextbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox1.Location = new System.Drawing.Point(16, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(464, 254);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Doctor Management";
            // 
            // hospitalTextBox
            // 
            this.hospitalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hospitalTextBox.ForeColor = System.Drawing.Color.Black;
            this.hospitalTextBox.Location = new System.Drawing.Point(94, 166);
            this.hospitalTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.hospitalTextBox.Name = "hospitalTextBox";
            this.hospitalTextBox.Size = new System.Drawing.Size(362, 24);
            this.hospitalTextBox.TabIndex = 29;
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.ForeColor = System.Drawing.Color.Black;
            this.deleteButton.Location = new System.Drawing.Point(210, 211);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(119, 35);
            this.deleteButton.TabIndex = 28;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.ForeColor = System.Drawing.Color.Black;
            this.addButton.Location = new System.Drawing.Point(337, 211);
            this.addButton.Margin = new System.Windows.Forms.Padding(4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(119, 35);
            this.addButton.TabIndex = 27;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // locYTextbox
            // 
            this.locYTextbox.Enabled = false;
            this.locYTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locYTextbox.ForeColor = System.Drawing.Color.Black;
            this.locYTextbox.Location = new System.Drawing.Point(94, 70);
            this.locYTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.locYTextbox.Name = "locYTextbox";
            this.locYTextbox.Size = new System.Drawing.Size(362, 24);
            this.locYTextbox.TabIndex = 18;
            this.locYTextbox.TextChanged += new System.EventHandler(this.locYTextbox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(9, 73);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = "Loc Y";
            // 
            // locXTextbox
            // 
            this.locXTextbox.Enabled = false;
            this.locXTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locXTextbox.ForeColor = System.Drawing.Color.Black;
            this.locXTextbox.Location = new System.Drawing.Point(94, 38);
            this.locXTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.locXTextbox.Name = "locXTextbox";
            this.locXTextbox.Size = new System.Drawing.Size(362, 24);
            this.locXTextbox.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(8, 41);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 18);
            this.label6.TabIndex = 19;
            this.label6.Text = "Loc X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(9, 169);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hospital";
            // 
            // specialityTextbox
            // 
            this.specialityTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specialityTextbox.ForeColor = System.Drawing.Color.Black;
            this.specialityTextbox.Location = new System.Drawing.Point(94, 134);
            this.specialityTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.specialityTextbox.Name = "specialityTextbox";
            this.specialityTextbox.Size = new System.Drawing.Size(362, 24);
            this.specialityTextbox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 137);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Specilaity";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // nameTextbox
            // 
            this.nameTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextbox.ForeColor = System.Drawing.Color.Black;
            this.nameTextbox.Location = new System.Drawing.Point(94, 102);
            this.nameTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.nameTextbox.Name = "nameTextbox";
            this.nameTextbox.Size = new System.Drawing.Size(362, 24);
            this.nameTextbox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // gMapDoctorSelect
            // 
            this.gMapDoctorSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMapDoctorSelect.Bearing = 0F;
            this.gMapDoctorSelect.CanDragMap = true;
            this.gMapDoctorSelect.EmptyTileColor = System.Drawing.Color.Transparent;
            this.gMapDoctorSelect.GrayScaleMode = false;
            this.gMapDoctorSelect.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapDoctorSelect.LevelsKeepInMemmory = 5;
            this.gMapDoctorSelect.Location = new System.Drawing.Point(486, 22);
            this.gMapDoctorSelect.MarkersEnabled = true;
            this.gMapDoctorSelect.MaxZoom = 15;
            this.gMapDoctorSelect.MinZoom = 15;
            this.gMapDoctorSelect.MouseWheelZoomEnabled = true;
            this.gMapDoctorSelect.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapDoctorSelect.Name = "gMapDoctorSelect";
            this.gMapDoctorSelect.NegativeMode = false;
            this.gMapDoctorSelect.PolygonsEnabled = true;
            this.gMapDoctorSelect.RetryLoadTile = 0;
            this.gMapDoctorSelect.RoutesEnabled = true;
            this.gMapDoctorSelect.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapDoctorSelect.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapDoctorSelect.ShowTileGridLines = false;
            this.gMapDoctorSelect.Size = new System.Drawing.Size(519, 656);
            this.gMapDoctorSelect.TabIndex = 2;
            this.gMapDoctorSelect.Zoom = 0D;
            this.gMapDoctorSelect.Load += new System.EventHandler(this.gMapDoctorSelect_Load);
            this.gMapDoctorSelect.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gMapDoctorSelect_MouseMove);
            // 
            // doctorList
            // 
            this.doctorList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.doctorList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doctorList.FormattingEnabled = true;
            this.doctorList.ItemHeight = 20;
            this.doctorList.Location = new System.Drawing.Point(16, 274);
            this.doctorList.Name = "doctorList";
            this.doctorList.Size = new System.Drawing.Size(464, 404);
            this.doctorList.TabIndex = 3;
            this.doctorList.SelectedIndexChanged += new System.EventHandler(this.doctorList_SelectedIndexChanged);
            // 
            // DoctorCRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1019, 690);
            this.Controls.Add(this.doctorList);
            this.Controls.Add(this.gMapDoctorSelect);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DoctorCRUD";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox specialityTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameTextbox;
        private System.Windows.Forms.Label label1;
        private GMap.NET.WindowsForms.GMapControl gMapDoctorSelect;
        private System.Windows.Forms.TextBox locYTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox locXTextbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox hospitalTextBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ListBox doctorList;
    }
}
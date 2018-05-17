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
            this.refreshButton = new System.Windows.Forms.Button();
            this.bloodStockPage = new System.Windows.Forms.TabPage();
            this.stockTrombList = new NishBox.MultiLineListBox();
            this.stockPlasmaList = new NishBox.MultiLineListBox();
            this.trombLabel = new System.Windows.Forms.Label();
            this.plasmaLabel = new System.Windows.Forms.Label();
            this.redBloodLable = new System.Windows.Forms.Label();
            this.selectionTab = new System.Windows.Forms.TabControl();
            this.stockRedCellList = new NishBox.MultiLineListBox();
            this.bloodStockPage.SuspendLayout();
            this.selectionTab.SuspendLayout();
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
            this.nameLabel.Click += new System.EventHandler(this.nameLabel_Click);
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
            // bloodStockPage
            // 
            this.bloodStockPage.BackColor = System.Drawing.Color.LightGray;
            this.bloodStockPage.Controls.Add(this.stockRedCellList);
            this.bloodStockPage.Controls.Add(this.stockTrombList);
            this.bloodStockPage.Controls.Add(this.stockPlasmaList);
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
            // stockTrombList
            // 
            this.stockTrombList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.stockTrombList.FormattingEnabled = true;
            this.stockTrombList.Location = new System.Drawing.Point(539, 28);
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
            // selectionTab
            // 
            this.selectionTab.Controls.Add(this.bloodStockPage);
            this.selectionTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectionTab.Location = new System.Drawing.Point(9, 33);
            this.selectionTab.Margin = new System.Windows.Forms.Padding(2);
            this.selectionTab.Name = "selectionTab";
            this.selectionTab.SelectedIndex = 0;
            this.selectionTab.Size = new System.Drawing.Size(814, 492);
            this.selectionTab.TabIndex = 5;
            this.selectionTab.SelectedIndexChanged += new System.EventHandler(this.selectionTab_SelectedIndexChanged);
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
            this.stockRedCellList.TabIndex = 9;
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.TabPage bloodStockPage;
        private NishBox.MultiLineListBox stockTrombList;
        private NishBox.MultiLineListBox stockPlasmaList;
        private System.Windows.Forms.Label trombLabel;
        private System.Windows.Forms.Label plasmaLabel;
        private System.Windows.Forms.Label redBloodLable;
        private System.Windows.Forms.TabControl selectionTab;
        private NishBox.MultiLineListBox stockRedCellList;
    }
}
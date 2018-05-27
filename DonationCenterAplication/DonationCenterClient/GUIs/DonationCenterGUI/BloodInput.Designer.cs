namespace Client.GUIs.DonationCenter
{
    partial class BloodInput
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rhPanel = new System.Windows.Forms.Panel();
            this.rhNegative = new System.Windows.Forms.RadioButton();
            this.rhPositive = new System.Windows.Forms.RadioButton();
            this.antigenPanel = new System.Windows.Forms.Panel();
            this.redNone = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.redA = new System.Windows.Forms.RadioButton();
            this.redAB = new System.Windows.Forms.RadioButton();
            this.redB = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bloodPulse = new System.Windows.Forms.TextBox();
            this.bloodPressure = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.plasmaQuantity = new System.Windows.Forms.TextBox();
            this.redQuantity = new System.Windows.Forms.TextBox();
            this.trombQuantity = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.rhPanel.SuspendLayout();
            this.antigenPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(14, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "RH";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cantitate plasma";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(6, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Cantitate trombocite";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(6, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Cantitate celule rosii";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(6, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(252, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Presiunea sistolica a donatorului";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(6, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(267, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Pulsul donatorului (Batai pe minut)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rhPanel);
            this.groupBox1.Controls.Add(this.antigenPanel);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox1.Location = new System.Drawing.Point(17, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(474, 231);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grupa Sanguina";
            // 
            // rhPanel
            // 
            this.rhPanel.Controls.Add(this.rhNegative);
            this.rhPanel.Controls.Add(this.rhPositive);
            this.rhPanel.Controls.Add(this.label3);
            this.rhPanel.Location = new System.Drawing.Point(6, 123);
            this.rhPanel.Name = "rhPanel";
            this.rhPanel.Size = new System.Drawing.Size(180, 96);
            this.rhPanel.TabIndex = 15;
            this.rhPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.rhPanel_Paint);
            // 
            // rhNegative
            // 
            this.rhNegative.AutoSize = true;
            this.rhNegative.ForeColor = System.Drawing.Color.Black;
            this.rhNegative.Location = new System.Drawing.Point(98, 49);
            this.rhNegative.Name = "rhNegative";
            this.rhNegative.Size = new System.Drawing.Size(77, 21);
            this.rhNegative.TabIndex = 11;
            this.rhNegative.Text = "Negativ";
            this.rhNegative.UseVisualStyleBackColor = true;
            // 
            // rhPositive
            // 
            this.rhPositive.AutoSize = true;
            this.rhPositive.Checked = true;
            this.rhPositive.ForeColor = System.Drawing.Color.Black;
            this.rhPositive.Location = new System.Drawing.Point(10, 49);
            this.rhPositive.Name = "rhPositive";
            this.rhPositive.Size = new System.Drawing.Size(70, 21);
            this.rhPositive.TabIndex = 10;
            this.rhPositive.TabStop = true;
            this.rhPositive.Text = "Pozitiv";
            this.rhPositive.UseVisualStyleBackColor = true;
            // 
            // antigenPanel
            // 
            this.antigenPanel.Controls.Add(this.redNone);
            this.antigenPanel.Controls.Add(this.label1);
            this.antigenPanel.Controls.Add(this.redA);
            this.antigenPanel.Controls.Add(this.redAB);
            this.antigenPanel.Controls.Add(this.redB);
            this.antigenPanel.Location = new System.Drawing.Point(6, 21);
            this.antigenPanel.Name = "antigenPanel";
            this.antigenPanel.Size = new System.Drawing.Size(254, 96);
            this.antigenPanel.TabIndex = 13;
            this.antigenPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.antigenPanel_Paint);
            // 
            // redNone
            // 
            this.redNone.AutoSize = true;
            this.redNone.ForeColor = System.Drawing.Color.Black;
            this.redNone.Location = new System.Drawing.Point(151, 56);
            this.redNone.Name = "redNone";
            this.redNone.Size = new System.Drawing.Size(37, 21);
            this.redNone.TabIndex = 12;
            this.redNone.Text = "0";
            this.redNone.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipul antigenilor";
            // 
            // redA
            // 
            this.redA.AutoSize = true;
            this.redA.Checked = true;
            this.redA.ForeColor = System.Drawing.Color.Black;
            this.redA.Location = new System.Drawing.Point(10, 56);
            this.redA.Name = "redA";
            this.redA.Size = new System.Drawing.Size(38, 21);
            this.redA.TabIndex = 4;
            this.redA.TabStop = true;
            this.redA.Text = "A";
            this.redA.UseVisualStyleBackColor = true;
            // 
            // redAB
            // 
            this.redAB.AutoSize = true;
            this.redAB.ForeColor = System.Drawing.Color.Black;
            this.redAB.Location = new System.Drawing.Point(98, 56);
            this.redAB.Name = "redAB";
            this.redAB.Size = new System.Drawing.Size(47, 21);
            this.redAB.TabIndex = 6;
            this.redAB.Text = "AB";
            this.redAB.UseVisualStyleBackColor = true;
            // 
            // redB
            // 
            this.redB.AutoSize = true;
            this.redB.ForeColor = System.Drawing.Color.Black;
            this.redB.Location = new System.Drawing.Point(54, 56);
            this.redB.Name = "redB";
            this.redB.Size = new System.Drawing.Size(38, 21);
            this.redB.TabIndex = 5;
            this.redB.Text = "B";
            this.redB.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bloodPulse);
            this.groupBox2.Controls.Add(this.bloodPressure);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox2.Location = new System.Drawing.Point(17, 262);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(474, 110);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Date Donator";
            // 
            // bloodPulse
            // 
            this.bloodPulse.Location = new System.Drawing.Point(329, 70);
            this.bloodPulse.Name = "bloodPulse";
            this.bloodPulse.Size = new System.Drawing.Size(126, 22);
            this.bloodPulse.TabIndex = 10;
            // 
            // bloodPressure
            // 
            this.bloodPressure.Location = new System.Drawing.Point(328, 29);
            this.bloodPressure.Name = "bloodPressure";
            this.bloodPressure.Size = new System.Drawing.Size(126, 22);
            this.bloodPressure.TabIndex = 9;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.plasmaQuantity);
            this.groupBox3.Controls.Add(this.redQuantity);
            this.groupBox3.Controls.Add(this.trombQuantity);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox3.Location = new System.Drawing.Point(17, 391);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(474, 152);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cantitati";
            // 
            // plasmaQuantity
            // 
            this.plasmaQuantity.Location = new System.Drawing.Point(324, 108);
            this.plasmaQuantity.Name = "plasmaQuantity";
            this.plasmaQuantity.Size = new System.Drawing.Size(126, 22);
            this.plasmaQuantity.TabIndex = 9;
            // 
            // redQuantity
            // 
            this.redQuantity.Location = new System.Drawing.Point(325, 71);
            this.redQuantity.Name = "redQuantity";
            this.redQuantity.Size = new System.Drawing.Size(125, 22);
            this.redQuantity.TabIndex = 8;
            // 
            // trombQuantity
            // 
            this.trombQuantity.Location = new System.Drawing.Point(325, 33);
            this.trombQuantity.Name = "trombQuantity";
            this.trombQuantity.Size = new System.Drawing.Size(126, 22);
            this.trombQuantity.TabIndex = 7;
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.saveButton.Location = new System.Drawing.Point(393, 549);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(98, 36);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Salvare";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancelButton.ForeColor = System.Drawing.Color.Black;
            this.cancelButton.Location = new System.Drawing.Point(289, 549);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(98, 36);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Anulare";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // BloodInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(503, 603);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "BloodInput";
            this.Text = "Introducere date";
            this.groupBox1.ResumeLayout(false);
            this.rhPanel.ResumeLayout(false);
            this.rhPanel.PerformLayout();
            this.antigenPanel.ResumeLayout(false);
            this.antigenPanel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox bloodPulse;
        private System.Windows.Forms.TextBox bloodPressure;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox plasmaQuantity;
        private System.Windows.Forms.TextBox redQuantity;
        private System.Windows.Forms.TextBox trombQuantity;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.RadioButton rhNegative;
        private System.Windows.Forms.RadioButton rhPositive;
        private System.Windows.Forms.Panel antigenPanel;
        private System.Windows.Forms.RadioButton redNone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton redA;
        private System.Windows.Forms.RadioButton redAB;
        private System.Windows.Forms.RadioButton redB;
        private System.Windows.Forms.Panel rhPanel;
    }
}
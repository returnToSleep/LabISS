﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GUIs.DonorGUI
{
    public partial class doneWindow : Form
    {
        
        public doneWindow(string donationCenterName)
        {
            InitializeComponent();
            this.donationCenterLabel.Text = donationCenterName;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }
    }
}
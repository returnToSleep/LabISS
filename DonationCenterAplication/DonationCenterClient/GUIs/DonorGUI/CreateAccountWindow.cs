using Client.Utils;
using Common.Model;
using DonationCenterAplication.Remoting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GUIs.DonorGUI
{
    public partial class CreateAccountWindow : Form
    {

        IService service;

        public CreateAccountWindow(IService service)
        {
            this.service = service;
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CreateAccountWindow_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AccountWindow a = new AccountWindow(service);
            a.ShowDialog();

            DialogResult = a.DialogResult;

            if (a.DialogResult == DialogResult.OK)
            {

                Donor d = a.returnDonor;
                string user = a.user;
                string pass = a.pass1;

                LogInfo logInfo = new LogInfo(user, pass, d.cnp, "Donor");

                Thread th = new Thread(
                                unused => EmailService.sendCreateMesage(d.email, logInfo)
                              );

                th.Start();
                

                service.AddToDatabase(d);
                service.AddToDatabase(logInfo);
            }
            Close();
            
        }
    }
}

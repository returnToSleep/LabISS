using Client.Controller;
using Common.Model;
using DonationCenterAplication.Remoting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Client.GUIs.LogIn
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
            passTextBox.PasswordChar = '*';

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            string users = userTextBox.Text;
            string pass = passTextBox.Text;

            TcpClientChannel channel = new TcpClientChannel();
            ChannelServices.RegisterChannel(channel, false);
            IService service = (IService)(Activator.GetObject(typeof(IService),
                "tcp://localhost:9999/IService"
                ));

            LogInController logIn = new LogInController(users, pass, service);

            LogInfo info = logIn.getAccount();
            if (info == null)
            {

                //TODO show error
                ChannelServices.UnregisterChannel(channel);
                return;
            }


            if (info.type.Equals("Doctor"))
            {
                //TODO Doctor GUI
            }

            if (info.type.Equals("Donation"))
            {
            
                Common.Model.DonationCenter donationCenter = service.GetOneFromDatabase<Common.Model.DonationCenter>(info.varId);
                DonationCenterController donationController = new DonationCenterController(service, donationCenter);

                this.Hide();
                new DonationCenterGUI(donationController).ShowDialog();

            }

            if (info.type.Equals("Donor"))
            {
                //TODO Donor GUI
            }

        }
    }
}

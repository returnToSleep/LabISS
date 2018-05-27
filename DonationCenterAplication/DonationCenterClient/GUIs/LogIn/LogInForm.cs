using Client.Controller;
using Common.Model;
using Controller;
using DonationCenterAplication.Remoting;
using Model;
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
using Client.GUIs.DonorGUI;
using Common.Exceptions;

namespace Client.GUIs.LogIn
{
    public partial class LogInForm : Form
    {

        IService service;

        public LogInForm()
        {
            InitializeComponent();
            passTextBox.PasswordChar = '*';
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;


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
            service = (IService)(Activator.GetObject(typeof(IService),
                "tcp://localhost:9999/IService"
                ));


            LogInController logIn = new LogInController(users, pass, service);
            LogInfo info = null;

            try
            {
                info = logIn.getAccount();
                
            }catch (ControllerException cE) 
            {
                MessageBox.Show(cE.Message, "Oops!");
                ChannelServices.UnregisterChannel(channel);
                return;
            }
            if (info == null)
            {
                MessageBox.Show("Nume sau parola gresita");
                ChannelServices.UnregisterChannel(channel);
                return;
            }


            if (info.type.Equals("Doctor"))
            {
                try
                {
                    Doctor doctor = service.GetOneFromDatabase<Doctor>(info.intId);
                    DoctorController doctorController = new DoctorController(service, doctor);

                    DoctorGUI form = new DoctorGUI(doctorController);
                    Hide();
                    form.ShowDialog();

                    if (form.DialogResult == DialogResult.Abort)
                    {

                        ChannelServices.UnregisterChannel(channel);
                        Show();
                    }

                } catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("Nu se poate efectua conexiunea la server.\n Va rugam reveniti mai tarziu", "Oops!");

                    ChannelServices.UnregisterChannel(channel);
                }
            }

            else if (info.type.Equals("Donation"))
            {

                try
                {
                    Common.Model.DonationCenter donationCenter = service.GetOneFromDatabase<Common.Model.DonationCenter>(info.varId);
                    DonationCenterController donationController = new DonationCenterController(service, donationCenter);

                    this.Hide();
                    DonationCenterGUI form = new DonationCenterGUI(donationController);
                    form.ShowDialog();

                    if (form.DialogResult == DialogResult.Abort)
                    {

                        ChannelServices.UnregisterChannel(channel);
                        Show();
                    }
                }
                catch (RemotingException)
                {
                    MessageBox.Show("Nu se poate efectua conexiunea la server.\n Va rugam reveniti mai tarziu", "Oops!");

                    ChannelServices.UnregisterChannel(channel);
                }

            }

            else if (info.type.Equals("Donor"))
            {

                try
                {
                    Donor donor = service.GetOneFromDatabase<Donor>(info.varId);
                    DonorController controller = new DonorController(service, donor);

                    Form form = new DonorMainGUI(controller);
                    Hide();
                    form.ShowDialog();

                    if (form.DialogResult == DialogResult.Abort)
                    {

                        ChannelServices.UnregisterChannel(channel);
                        Show();
                    }

                }
                catch (RemotingException)
                {
                    MessageBox.Show("Nu se poate efectua conexiunea la server.\n Va rugam reveniti mai tarziu", "Oops!");

                    ChannelServices.UnregisterChannel(channel);
                }
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {

            TcpClientChannel channel = new TcpClientChannel();
            ChannelServices.RegisterChannel(channel, false);
            service = (IService)(Activator.GetObject(typeof(IService),
                "tcp://localhost:9999/IService"
                ));
            CreateAccountWindow a = new CreateAccountWindow(service);
            a.ShowDialog();

            if (a.DialogResult == DialogResult.Abort)
            {
                Close();
            }

            if (a.DialogResult == DialogResult.OK)
            {
                Show();
            }

            ChannelServices.UnregisterChannel(channel);
        }
    }
}

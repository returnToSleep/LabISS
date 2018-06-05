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
using System.Net.Sockets;

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
                "tcp://25.56.133.78:9999/IService"
                ));


            LogInController logIn = new LogInController(users, pass, service);
            LogInfo info = null;

            try
            {
                info = logIn.getAccount();
                
            }
            catch (NoSuchUserException nsuE) 
            {
                MessageBox.Show(nsuE.Message, "Oops!");
                ChannelServices.UnregisterChannel(channel);
                return;
            }
            catch (ControllerException)
            {
                MessageBox.Show("Can not connect to server\nPlease try again later", "Oops!");
                ChannelServices.UnregisterChannel(channel);
                return;
            }

            if (info == null)
            {
                MessageBox.Show("Wrong password", "Oops!");
                ChannelServices.UnregisterChannel(channel);
                return;
            }


            if (info.type.Equals("Doctor"))
            {
                try
                {
                    Doctor doctor = service.GetOneFromDatabase<Doctor>(info.intId);
                    DoctorController doctorController = new DoctorController(service, doctor);
                    Hide();
                    DoctorGUIs.DoctorGUI form = new DoctorGUIs.DoctorGUI(doctorController);

                    form.ShowDialog();

                    userTextBox.Text = "";
                    passTextBox.Text = "";

                    if (form.DialogResult == DialogResult.Abort)
                    {

                        ChannelServices.UnregisterChannel(channel);
                        Show();
                    }
                    else
                    {
                        Close();
                    }
                 

                } catch (RemotingException)
                {
                    MessageBox.Show("Can not connect to server\nPlease try again later", "Oops!");

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



                    userTextBox.Text = "";
                    passTextBox.Text = "";

                    DonationCenterGUI form = new DonationCenterGUI(donationController);
                    form.ShowDialog();



                    if (form.DialogResult == DialogResult.Abort)
                    {

                        ChannelServices.UnregisterChannel(channel);
                        Show();
                    }
                    else
                    {
                        Close();
                    }
                }
                catch (RemotingException)
                {
                    MessageBox.Show("Can not connect to server\nPlease try again later", "Oops!");

                    ChannelServices.UnregisterChannel(channel);
                }

            }

            else if (info.type.Equals("Donor"))
            {

                try
                {
                    Donor donor = service.GetOneFromDatabase<Donor>(info.varId);
                    DonorController controller = new DonorController(service, donor);

                    userTextBox.Text = "";
                    passTextBox.Text = "";

                    Form form = new DonorMainGUI(controller);
                    Hide();
                    form.ShowDialog();

                    if (form.DialogResult == DialogResult.Abort)
                    {

                        ChannelServices.UnregisterChannel(channel);
                        Show();
                    }
                    else
                    {
                        Close();
                    }

                }
                catch (RemotingException)
                {
                    MessageBox.Show("Can not connect to server\nPlease try again later", "Oops!");

                    ChannelServices.UnregisterChannel(channel);
                }
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {

            TcpClientChannel channel = new TcpClientChannel();
            ChannelServices.RegisterChannel(channel, false);
            service = (IService)(Activator.GetObject(typeof(IService),
                "tcp://25.56.133.78:9999/IService"
                ));
            CreateAccountWindow a = new CreateAccountWindow(service);
            Hide();


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

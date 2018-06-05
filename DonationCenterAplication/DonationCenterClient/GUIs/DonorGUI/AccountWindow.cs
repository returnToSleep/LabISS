using Common.Exceptions;
using Common.Model;
using DonationCenterAplication.Remoting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GUIs.DonorGUI
{
    public partial class AccountWindow : Form
    {

        public string user { get; set; }
        public string pass1 { get; set; }
        public string pass2 { get; set; }
        public Donor returnDonor{ get; set; }
        IService service;

        public AccountWindow(IService service)
        {
            this.service = service;
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            user = userTextBox.Text;
            pass1 = pass1TextBox.Text;
            pass2 = pass2TextBox.Text;

            if (user == "" || pass1 == "" || pass2 == "")
            {
                MessageBox.Show("Va rugam sa introduceti datele", "Date incorecte");
                return;
            }


            if (!pass1.Equals(pass2))
            {
                MessageBox.Show("Ati introdus date diferite in campurile de parole", "Date incorecte");
                pass1TextBox.Clear();
                pass2TextBox.Clear();
                return; 
            }

            LogInfo usernameTaken;
            IList<LogInfo> logInfoList = null;
            try
            {
               logInfoList = service.GetAllFromDatabase<LogInfo>();
            } catch (RemotingException rmE)
            {
                MessageBox.Show(rmE.Message, "Oops!");
                return;
            } catch (SocketException)
            {
                MessageBox.Show("Can not establish a connection to the server!\nPlease try again later", "Oops!");
                return;
            }
            try
            {
                usernameTaken = logInfoList.First(x => x.username == user);
            }
            catch
            {
                usernameTaken = null;
            }

            if (usernameTaken != null)
            {
                MessageBox.Show("The username is already in use", "Invalid data");
                userTextBox.Clear();
                pass1TextBox.Clear();
                pass2TextBox.Clear();
                return;
            }

            this.Hide();
            DonorFormGUI form = new DonorFormGUI(service);
            form.ShowDialog();

            DialogResult = form.DialogResult;
            returnDonor = form.returnDonor;

            Close();

        }
    }
}

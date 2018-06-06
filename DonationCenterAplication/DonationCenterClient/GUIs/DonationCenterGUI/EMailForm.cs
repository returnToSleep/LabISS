using Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GUIs.DonationCenter
{
    public partial class EMailForm : Form
    {
        

        public string eMail { get; set; }
        public string eMailSubject { get; set; }
        public string eMailText { get; set; }
        public List<string> attachedFiles { get; set; }

        public EMailForm(Donor donor, bool isFit, string donationCenterName, bool bloodTypeIsUnknown)
        {

            attachedFiles = new List<string>();

            InitializeComponent();

            emailTextBox.Text = donor.email;
            subjectTextBox.Text = isFit ? "Thank you for your donation!" : "Medical exam results";

           
            string missMister = (donor.cnp[0] == '1') ? "mister " : "miss ";

            string bloodType = bloodTypeIsUnknown ? "Your blood type is " + donor.bloodType + ".\n" : "";

            if (isFit)
            {
                eMailBox.Text = "Dear " + missMister + donor.name + ",\n\n\n"
                    + "We would like to inform you that the results of the medical exam are pozitive.\n"
                    + "You may see the details of your donation on your profile."
                    + bloodType
                    + "The harvested blood will be added to our stocks and will be delivered to a hospital\n"
                    + "when needed.\n" 
                    + "Thank you for your donation!\n\n" 
                    + "We wish you a good day!, \n"
                    + "Respectfully, " + donationCenterName;
            }
            else
            {
                eMailBox.Text = "Dear " +missMister + donor.name + ",\n\n\n"
                    + "We regret to inform you that you have been deemed unfit to donate blood.\n"
                    + bloodType
                    + "Thank you for making time for a donation.\n\n"
                    + "Best regards, \n"
                    + donationCenterName;
            }

        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            eMail = emailTextBox.Text;
            eMailSubject = subjectTextBox.Text;
            eMailText = eMailBox.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void attachButton_Click(object sender, EventArgs e)
        {
            if (fileBrowser.ShowDialog() == DialogResult.OK) 
            {

                string fileName = fileBrowser.FileName;

                try
                {
                    FileStream handler = File.Open(fileName, FileMode.Open);
                    attachedFiles.Add(fileName);
                    handler.Close();
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Could not attach file", "Invalid attachement");
                }

            }
            MessageBox.Show("The file has been attached", "Success");

        }

        private void eMailBox_MouseEnter(object sender, EventArgs e)
        {
           
        }
    }
}

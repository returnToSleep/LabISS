using Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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


        public EMailForm(Donor donor, bool isFit, string donationCenterName, bool bloodTypeIsUnknown)
        {
            InitializeComponent();

            emailTextBox.Text = donor.email;
            subjectTextBox.Text = isFit ? "Multumim pentur donatie!" : "Rezultate analize";

            string missMister1 = (donor.cnp[0] == '1') ? "Stimate " : "Stimata ";
            string missMister2 = (donor.cnp[0] == '1') ? "domn " : "doamna ";

            string bloodType = bloodTypeIsUnknown ? "Grupa dumneavoastra de sange este " + donor.bloodType + ".\n" : "";

            if (isFit)
            {
                eMailBox.Text = missMister1 + missMister2 + donor.name + ",\n\n\n"
                    + "Va aducem la cunostinta faptul ca rezultatele analizelor sunt pozitive.\n"
                    + "Puteti vedea detataliile legate de donatia pe profilul dumneavoastra."
                    + bloodType
                    + "Sangele recoltat ureamaza sa fie adaugat in stoc si va fii livrat catre un spital\n"
                    + "atunci cand este nevoie.\n" 
                    + "Multumim pentru donatia dumneavoastra!\n\n" 
                    + "Va dorim o zi buna in continoare, \n"
                    + "Centrul de donatii " + donationCenterName;
            }
            else
            {
                eMailBox.Text = missMister1 + missMister2 + donor.name + ",\n\n\n"
                    + "Cu parare de rau, trebuie sa va anuntam ca rezultatele analizelor sunt negative.\n"
                    + bloodType
                    + "Multumim pentru ca v-ati facut timp pentru a dona sange.\n\n"
                    + "Toate cele bune, \n"
                    + "Centrul de donatii " + donationCenterName;
            }

        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            eMail = emailTextBox.Text;
            eMailSubject = subjectTextBox.Text;
            eMailText = emailTextBox.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

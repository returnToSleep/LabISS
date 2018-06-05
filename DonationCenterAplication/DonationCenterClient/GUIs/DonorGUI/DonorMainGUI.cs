using Common.Model;
using Controller;
using DonationCenterAplication.Remoting;
using System;
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
    public partial class DonorMainGUI : Form
    {
        
        DonorController controller;

        public DonorMainGUI(DonorController controller)
        {


            this.controller = controller;
            InitializeComponent();

            string bloodType = controller.donor.bloodType == null ? "?" : controller.donor.bloodType;

            string rh = controller.donor.rh ? " Pozitive" : " Negative";

            string[] splitAddr = controller.donor.location.addressString.Split(',');

            #region Donor Data
            donorNameLabel.Text += " " + controller.donor.name;
            cnpLabel.Text += " " + controller.donor.cnp;
            residenceLabel.Text += " " + splitAddr[0] + ", Street " + splitAddr[1] + " No. " + splitAddr[2];
            emailLabel.Text += " " + controller.donor.email;
            donorBloodTypeLabel.Text += bloodType == "?" ? "?" : " " + bloodType + rh;
            #endregion

            populateDonationHistory();
            canDonorDonate();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }

        private void refreshLabels()
        {
            string noDon = controller.getDonationHistory().Count == 0 ? "0" : controller.getDonationHistory().Count.ToString();

            noOfDonationsLabel.Text = "Number of donations: " + noDon.ToString();

            string bloodType = controller.donor.bloodType == null ? "?" : controller.donor.bloodType;

            string rh = controller.donor.rh ? " Pozitive" : " Negative";

            string concreteBloodType = bloodType == "?" ? "?" : (bloodType + rh);

            donorBloodTypeLabel.Text = "Blood type: " + concreteBloodType;

            emailLabel.Text = "Email: " + controller.donor.email;

            string[] splitAddr = controller.donor.location.addressString.Split(',');


            residenceLabel.Text = "Residence: " + splitAddr[0] + ", Street " + splitAddr[1] + " No. " + splitAddr[2];
            emailLabel.Text = "Email: " + controller.donor.email;

            donorNameLabel.Text = "Name: " + controller.donor.name;
        }

        private void populateDonationHistory()
        {

            donationHistoryList.Items.Clear();

         
            foreach (Donation d in controller.getDonationHistory()) {
                donationHistoryList.Items.Add(d);
            }
        }

        private void fillFormButton_Click(object sender, EventArgs e)
        {
            DonorFormGUI donorForm = new DonorFormGUI(controller);
            donorForm.ShowDialog();

            if(donorForm.DialogResult == DialogResult.Yes)
            {
                controller.service.DeleteFromDatabase(controller.service.GetOneFromDatabase<Donor>(donorForm.returnDonor.cnp));
                donorForm.returnDonor.isPending = true;
                controller.service.AddToDatabase(donorForm.returnDonor);
                refreshData();
            }
        }

        private void canDonorDonate()
        {
            string donationInfoString = controller.isDonorFit();

            fillFormButton.Enabled = donationInfoString == "You can donate!";

            donationInformationLabel.Text = donationInfoString;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        private void refreshData()
        { 
            controller.refresh();
            canDonorDonate();
            refreshLabels();
            populateDonationHistory();
        }

        private void donationFormToolTip_Popup(object sender, PopupEventArgs e)
        {
           
        }

        private void donationHistoryList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataEditWindow dataEdit = new dataEditWindow(controller);
            dataEdit.ShowDialog();

            if (dataEdit.DialogResult == DialogResult.OK)
            {
                controller.service.UpdateOneFromDatabase(dataEdit.returnDonor);
                MessageBox.Show("The Changes have been saved.", "Great succes!");
                refreshData();
            }
            else
            {
                return;
            }
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            refreshData();
        }
    }
}

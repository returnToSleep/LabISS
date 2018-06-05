using Common.Exceptions;
using Common.Model;
using Common.Validators;
using Controller;
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
    public partial class dataEditWindow : Form
    {
        DonorController controller;
        public Donor returnDonor { get; set; }
        public string returnCnp { get; set; }

        public dataEditWindow(DonorController controller)
        {
            this.controller = controller;

            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }

        private void dataEditWindow_Load(object sender, EventArgs e)
        {
            donorNameTextBox.Text = controller.donor.name;

            donorCnpTextBox.Text = controller.donor.cnp;

            birthDateDayTextBox.Text = controller.donor.birthdate.Day.ToString();
            birthDateMonthTextBox.Text = controller.donor.birthdate.Month.ToString();
            bithDateYearTextBox.Text = controller.donor.birthdate.Year.ToString();

            string[] addressSplit = controller.donor.address.Split(',');

            addressCityTextBox.Text = addressSplit[0];
            addressStreetTextBox.Text = addressSplit[1];
            addressNumberTextBox.Text = addressSplit[2];


            string[] resiSplit = controller.donor.location.addressString.Split(',');

            resiCityTextBox.Text = resiSplit[0];
            resiStreetTextBox.Text = resiSplit[1];
            resiNumberTextBox.Text = resiSplit[2];

            donorCnpTextBox.Enabled = false;

            emailTextBox.Text = controller.donor.email;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {


            string name = donorNameTextBox.Text;
            string cnp = donorCnpTextBox.Text;

            string address = "";
            address += addressCityTextBox.Text + ",";
            address += addressStreetTextBox.Text + ",";
            address += addressNumberTextBox.Text;

            string residence = "";
            residence += resiCityTextBox.Text + ",";
            residence += resiStreetTextBox.Text + ",";
            residence += resiNumberTextBox.Text;

            string email = emailTextBox.Text;

            string err = "";

            DateTime birthday = new DateTime(1, 1, 1);

            try
            {
                int year = int.Parse(bithDateYearTextBox.Text);
                int month = int.Parse(birthDateMonthTextBox.Text);
                int day = int.Parse(birthDateDayTextBox.Text);
                birthday = new DateTime(year, month, day);
            }
            catch (FormatException)
            {
                err += "Incorrect date of birth";
            }
            if (cnp != controller.donor.cnp)
            {
                try
                {
                    returnCnp = controller.donor.cnp;
                    Donor search = controller.service.GetOneFromDatabase<Donor>(cnp);
                    MessageBox.Show("The CNP you entered is already in use", "Invalid CNP");
                    return;
                }
                catch (RemotingException) { }
            }

            gMapDonationCenter.SetPositionByKeywords(residence);
            double lat = gMapDonationCenter.Position.Lat;
            double lon = gMapDonationCenter.Position.Lng;
            
            Location location = new Location(residence, lat, lon);

            returnDonor = new Donor(cnp, name, birthday, address, location, email);
            returnDonor.donationCenter_id = controller.donor.donationCenter_id;
            returnDonor.isPending = controller.donor.isPending;
            returnDonor.bloodType = controller.donor.bloodType;

            err = DonorValidator.validate(returnDonor);
            

            if (err == "")
            {

                if (returnCnp == null)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    DialogResult = DialogResult.Yes;
                    Close();
                }
                
            }
            else
            {
                MessageBox.Show(err, "Invalide data");
                return;
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }
    }
}

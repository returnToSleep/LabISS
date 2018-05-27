using Common.Model;
using Common.Validators;
using Model;
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
    public partial class BloodInput : Form
    {

        private string donationCenterId;
        private Donor donor;
        private bool bloodTypeIsKnown;

        public Plasma plasma{ get; set; }
        public RedBloodCell red { get; set; }
        public Trombocyte tromb { get; set; }
        public Donation donation { get; set; }
        public string bloodType { get; set; }
        

        public BloodInput(string donationCenterId, Donor donor, bool bloodTypeIsKnown)
        {
            this.donationCenterId = donationCenterId;
            this.donor = donor;
            this.bloodTypeIsKnown = bloodTypeIsKnown;
            InitializeComponent();

            if (bloodTypeIsKnown)
            {
                groupBox1.Visible = false;
                this.MinimumSize = new Size(this.Width, this.Height - groupBox1.Height);
                this.Height = this.Height - groupBox1.Height;

                groupBox3.Location = new Point(groupBox2.Location.X, groupBox2.Location.Y - 100);
                groupBox2.Location = new Point(groupBox1.Location.X, groupBox1.Location.Y);
                
                cancelButton.Location = new Point(cancelButton.Location.X, cancelButton.Location.Y - groupBox1.Height);
                saveButton.Location = new Point(saveButton.Location.X, saveButton.Location.Y - groupBox1.Height);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string antigen = "0";
            bool rh = false;
            string antibody = "AB";

            if (!bloodTypeIsKnown)
            {

                antigen = antigenPanel.Controls.OfType<RadioButton>()
                                          .FirstOrDefault(r => r.Checked).Text;
                bloodType = antigen;
                rh = rhPositive.Checked;
            }
            else
            {
                antigen = donor.bloodType;
                rh = donor.rh;
            }
                          

            if (antigen == "A")
                antibody = "B";

            if (antigen == "B")
                antibody = "A";

            if (antigen == "AB")
                antibody = "0";

            if (antigen == "0")
                antibody = "AB";


            string err = BloodInputValidator.validatePulsePressure(bloodPulse.Text, bloodPressure.Text);

            if (err != "")
            {
                MessageBox.Show(err, "Date invalide");
                return;
            }


            int pressure = int.Parse(bloodPressure.Text);
            int pulse = int.Parse(bloodPulse.Text);

            err = BloodInputValidator.validateBlood(redQuantity.Text, trombQuantity.Text, plasmaQuantity.Text);

            if (err != "")
            {
                MessageBox.Show(err, "Date invalide");
                return;
            }

            float redQ = float.Parse(redQuantity.Text);
            float trombQ = float.Parse(trombQuantity.Text);
            float plasmaQ = float.Parse(plasmaQuantity.Text);

            donor.bloodType = antigen;
            donor.rh = rh;

            plasma = new Plasma(antibody, this.donationCenterId, donor.cnp, plasmaQ, DateTime.Now.Date, donor.email);
            tromb = new Trombocyte(this.donationCenterId, donor.cnp, trombQ, DateTime.Now.Date, donor.email);
            red = new RedBloodCell(antigen, donor.rh, this.donationCenterId, donor.cnp, redQ, DateTime.Now.Date, donor.email);
            donation = new Donation(donor.cnp, redQ + trombQ + plasmaQ, pulse, pressure, DateTime.Now.Date, plasmaQ, redQ, trombQ);
           
            plasma.donatedFor = donor.donatedFor;
            red.donatedFor = donor.donatedFor;
            tromb.donatedFor = donor.donatedFor;
            donation.pacientName = donor.donatedFor;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void antigenPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void rhPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

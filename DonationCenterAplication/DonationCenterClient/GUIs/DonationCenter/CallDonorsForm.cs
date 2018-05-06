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
    public partial class CallDonorsForm : Form
    {

        private IList<Donor> availableDonors;


        public IList<Donor> contactedDonors { get; set;}


        public CallDonorsForm(IList<Donor> availableDonors, DoctorRequest request)
        {
            this.availableDonors = availableDonors;

            contactedDonors = new List<Donor>();

            InitializeComponent();

            warningLabel.Text += " " + request.ToString();

        }

        private void CallDonorsForm_Load(object sender, EventArgs e)
        {

        }

        

        private void contactButton_Click(object sender, EventArgs e)
        {
            Donor d = (Donor)donorList.SelectedItem;
            contactedDonors.Add(d);
            donorList.Items.Remove(d);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

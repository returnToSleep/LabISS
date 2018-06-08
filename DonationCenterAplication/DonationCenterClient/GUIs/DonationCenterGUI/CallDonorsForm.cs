using Client.Utils;
using Common.Model;
using GMap.NET;
using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GUIs.DonationCenter
{
    public partial class CallDonorsForm : Form
    {
        private Donor lastSelectedDonor;
        private IList<Donor> availableDonors;
        private DoctorRequest req;


        public CallDonorsForm(IList<Donor> availableDonors, DoctorRequest request)
        {
            this.availableDonors = availableDonors.Reverse().ToList();
            req = request;


            InitializeComponent();

            gMapAvailableDonors.Manager.Mode = AccessMode.ServerOnly;
            gMapAvailableDonors.MapProvider = GMapProviders.BingMap;
            gMapAvailableDonors.DragButton = MouseButtons.Left;
            gMapAvailableDonors.DisableFocusOnMouseEnter = true;

            warningLabel.Text += "\n" + request.ToString();
            populateDonorList();

        }

        private void populateDonorList()
        {
            foreach (Donor d in availableDonors.Reverse()) {
                donorList.Items.Add(d);
            }
        }

        private void CallDonorsForm_Load(object sender, EventArgs e)
        {

        }

        

        private void contactButton_Click(object sender, EventArgs e)
        {
            Donor d = this.lastSelectedDonor;

            donorList.Items.Remove(d);

            Thread th = new Thread(unsused => EmailService.sendNotEnoughtBloodMail(d, req));
            th.Start();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void donorList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (donorList.Items.Count == 0 || (Donor)donorList.SelectedItem == null)
            {
                return;
            }


            Donor d = (Donor)donorList.SelectedItem;

            this.lastSelectedDonor = d;

            double lat = d.location.latitude;
            double lon = d.location.longitude;

            gMapAvailableDonors.Position = new PointLatLng(lat, lon);
            gMapAvailableDonors.Zoom = 15;

        }

        private void gMapAvailableDonors_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}

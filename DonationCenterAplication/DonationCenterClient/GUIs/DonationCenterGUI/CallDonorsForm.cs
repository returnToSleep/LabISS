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

        private IList<Donor> availableDonors;
        private DoctorRequest req;


        public CallDonorsForm(IList<Donor> availableDonors, DoctorRequest request)
        {
            this.availableDonors = availableDonors;
            req = request;

            InitializeComponent();

            gMapAvailableDonors.Manager.Mode = AccessMode.ServerOnly;
            gMapAvailableDonors.MapProvider = GMapProviders.GoogleMap;
            gMapAvailableDonors.DragButton = MouseButtons.Left;

            warningLabel.Text += " " + request.ToString();
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
            Donor d = (Donor)donorList.SelectedItem;
            donorList.Items.Remove(d);

            Thread th = new Thread(unsused => EmailService.sendNotEnoughtBloodMail(d, req));
            th.Start();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void donorList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (donorList.Items.Count == 0)
            {
                return;
            }


            Donor d = (Donor)donorList.SelectedItem;

            double lat = d.location.latitude;
            double lon = d.location.longitude;

            gMapAvailableDonors.Position = new PointLatLng(lat, lon);
            gMapAvailableDonors.Zoom = 15;

        }
    }
}

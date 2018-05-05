using Client.Controller;
using Common.Model;
using GMap.NET;
using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GUIs
{
    public partial class DonationCenterGUI : Form
    {

        DonationCenterController controller;

        Dictionary<string, Donor> donorMap;
        Dictionary<string, DoctorRequest> doctorRequestMap;

        public DonationCenterGUI(DonationCenterController controller)
        {
            GMapProvider.WebProxy = WebRequest.GetSystemWebProxy();
            GMapProvider.WebProxy.Credentials = CredentialCache.DefaultNetworkCredentials;


            //not use proxy
            GMapProvider.WebProxy = null;

            this.controller = controller;
            this.donorMap = new Dictionary<string, Donor>();
            InitializeComponent();

            gMapDonors.Manager.Mode = AccessMode.ServerOnly;
            gMapDonors.MapProvider = GMapProviders.OpenStreetMap;

        }

        private void DonationCenterGUI_Load(object sender, EventArgs e)
        {
            #region Tab1 - Donors
            foreach (Donor d in this.controller.getDonatedDonors())
            {
                donorMap.Add(d.ToString(), d);
            }

            this.donorList.DataSource = this.controller.donationCenter.donors;
            #endregion

            #region Tab2 - Requests

            foreach (DoctorRequest d in this.controller.donationCenter.requests)
            {
                doctorRequestMap.Add(d.ToString(), d);
            }

            this.doctorRequestList.DataSource = this.controller.donationCenter.requests;

            #endregion


        }

        private void donorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Location l = donorMap[this.donorList.SelectedItem.ToString()].location;
            this.gMapDonors.Position = new PointLatLng(l.latitude, l.longitude);
            this.gMapDonors.Zoom = 18;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            this.controller.service.Refresh(this.controller.donationCenter);
        }

        private void doctorRequestList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

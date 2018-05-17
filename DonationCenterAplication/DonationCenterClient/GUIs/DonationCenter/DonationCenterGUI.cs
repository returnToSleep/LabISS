using Client.Controller;
using Client.GUIs.DonationCenter;
using Common.Model;
using GMap.NET;
using GMap.NET.MapProviders;
using Model;
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
    
        public DonationCenterGUI(DonationCenterController controller)
        {
            GMapProvider.WebProxy = WebRequest.GetSystemWebProxy();
            GMapProvider.WebProxy.Credentials = CredentialCache.DefaultNetworkCredentials;


            //not use proxy
            GMapProvider.WebProxy = null;

            this.controller = controller;
            
            InitializeComponent();
            

            nameLabel.Text = controller.donationCenter.name;

            gMapDonors.Manager.Mode = AccessMode.ServerOnly;
            gMapDonors.MapProvider = GMapProviders.OpenStreetMap;

            gMapPendingDonors.Manager.Mode = AccessMode.ServerOnly;
            gMapPendingDonors.MapProvider = GMapProviders.OpenStreetMap;


        }

        private void RefreshLists()
        {

            donorList.Items.Clear();
            pendingDonorList.Items.Clear();
            doctorRequestList.Items.Clear();

            stockRedCellList.Items.Clear();
            stockPlasmaList.Items.Clear();
            stockTrombList.Items.Clear();

            controller.Refresh();


            IList<Donor> lst = controller.getDonatedDonors();

            foreach (Donor d in lst)
            {
                donorList.Items.Add(d);
            }

            IList<DoctorRequest> dlst = controller.donationCenter.requests;

            foreach (DoctorRequest d in dlst)
            {
                doctorRequestList.Items.Add(d);
            }

            IList<Donor> plst = controller.getPendingDonors();
            foreach (Donor d in plst)
            {
                pendingDonorList.Items.Add(d);
            }

            IList<Trombocyte> tlst = controller.donationCenter.trombocyteList;
            foreach (Trombocyte t in tlst)
            {
                stockTrombList.Items.Add(t);
            }

            IList<Plasma> plaslst = controller.donationCenter.plasmaList;
            foreach (Plasma p in plaslst)
            {
                stockPlasmaList.Items.Add(p);
            }

            IList<RedBloodCell> rlst = controller.donationCenter.redBloodCellList;
            foreach (RedBloodCell r in rlst)
            {
                stockRedCellList.Items.Add(r);
            }

  
        }

        private void DonationCenterGUI_Load(object sender, EventArgs e)
        {
            RefreshLists();
        }


        private void donorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Donor selected = (Donor)donorList.SelectedItem;
            Location l = selected.location;

            gMapDonors.Position = new PointLatLng(l.latitude, l.longitude);
            gMapDonors.Zoom = 15;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            controller.service.Refresh(controller.donationCenter);
            RefreshLists();
        }

        private void doctorRequestList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pendingDonorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pendingDonorList.Items.Count != 0)
            {
                Donor selected = (Donor)pendingDonorList.SelectedItem;

                if (selected != null)
                {

                    Location l = selected.location;
                    gMapPendingDonors.Position = new PointLatLng(l.latitude, l.longitude);
                    gMapPendingDonors.Zoom = 15;
                }
                else
                {
                    pendingDonorList.SelectedIndex = 0;
                }

            }

            else
            {
                gMapPendingDonors.Position = new PointLatLng(0, 0);
            }

        }

        private void multiLineListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void doctorPage_Click(object sender, EventArgs e)
        {

        }

        private void potentialBloodLabel_Click(object sender, EventArgs e)
        {

        }

        private void donorOkButton_Click(object sender, EventArgs e)
        {
            Donor selected = (Donor)pendingDonorList.SelectedItem;
            
            
            BloodInput bloodInput = new BloodInput(controller.donationCenter.id, selected, selected.bloodType != null);
            if (bloodInput.ShowDialog() == DialogResult.OK)
            {


                EMailForm eMailForm = new EMailForm(selected, true, controller.donationCenter.name, selected.bloodType == null);
                if (eMailForm.ShowDialog() == DialogResult.OK)
                {

                    controller.evaluateDonor(true, selected);

                    controller.addBloodToStock(bloodInput.plasma);
                    controller.addBloodToStock(bloodInput.red);
                    controller.addBloodToStock(bloodInput.tromb);
                    controller.addDonationToDonor(selected, bloodInput.donation, bloodInput.bloodType);

                    string address = eMailForm.eMail;
                    string subject = eMailForm.eMailSubject;
                    string content = eMailForm.eMailText;
                    //TODO notify donor controller
                }

                else
                {
                    return;
                }

            }
            else
            {
                return;
            }

            RefreshLists();
        }

        private void donorNotOkButton_Click(object sender, EventArgs e)
        {
            Donor selected = (Donor)pendingDonorList.SelectedItem;
            EMailForm eMailForm = new EMailForm(selected, false, controller.donationCenter.name, selected.bloodType == null);

            if (eMailForm.ShowDialog() == DialogResult.OK)
            {
                controller.evaluateDonor(false, selected);

                string address = eMailForm.eMail;
                string subject = eMailForm.eMailSubject;
                string content = eMailForm.eMailText;
                //TODO notify donor controller
            }
            else
            {
                return;
            }

            RefreshLists();
        }


        private void fillPotentialBloodList<T>(List<T> lst)
        {
            potentialBlood.Items.Clear();
            foreach (T r in lst)
            {
                potentialBlood.Items.Add(r);
            }
        }

        private void doctorRequestList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DoctorRequest selected = (DoctorRequest)doctorRequestList.SelectedItem;
            string type = selected.requestString.Split(',')[0];

            if (type == "Plasma")
            {
                List<Plasma> comp = controller.getAvailableBloodForRequest<Plasma>(selected);
                if (comp.Count == 0)
                {
                    CallDonorsForm callForm = new CallDonorsForm(controller.getAvailableDonorsForRequest(selected), selected);
                    callForm.ShowDialog();
                }
                fillPotentialBloodList(comp);
            }
            if (type == "Red")
            {
                List<RedBloodCell> comp = controller.getAvailableBloodForRequest<RedBloodCell>(selected);
                if (comp.Count == 0)
                {
                    CallDonorsForm callForm = new CallDonorsForm(controller.getAvailableDonorsForRequest(selected), selected);
                    callForm.ShowDialog();
                }
                fillPotentialBloodList(comp);
            }
            if (type == "Tromb")
            {
                List<Trombocyte> comp = controller.getAvailableBloodForRequest<Trombocyte>(selected);
                if (comp.Count == 0)
                {
                    CallDonorsForm callForm = new CallDonorsForm(controller.getAvailableDonorsForRequest(selected), selected);
                    callForm.ShowDialog();
                }
                fillPotentialBloodList(comp);
            }

        }
    }
}

using Client.Controller;
using Client.GUIs.DonationCenter;
using Client.Utils;
using Common.Model;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GUIs
{
    public partial class DonationCenterGUI : Form
    {
        
        DonationCenterController controller;
        string selectedComponent;
        

        string ComponentForRequest; 
    
        public DonationCenterGUI(DonationCenterController controller)
        {

            controller.donationCenter.setLatLon();

            GMapProvider.WebProxy = WebRequest.GetSystemWebProxy();
            GMapProvider.WebProxy.Credentials = CredentialCache.DefaultNetworkCredentials;

            controller.refreshBloodStock();

            //not use proxy
            //GMapProvider.WebProxy = null;

            this.controller = controller;
            
            InitializeComponent();
            

            nameLabel.Text = controller.donationCenter.name;
            

            gMapDonors.Manager.Mode = AccessMode.ServerOnly;
            gMapDonors.MapProvider = GMapProviders.BingMap;
            gMapDonors.DragButton = MouseButtons.Left;

            gMapPendingDonors.Manager.Mode = AccessMode.ServerOnly;
            gMapPendingDonors.MapProvider = GMapProviders.BingMap;
            gMapPendingDonors.DragButton = MouseButtons.Left;

            gMapRouteToDoctor.Manager.Mode = AccessMode.ServerOnly;
            gMapRouteToDoctor.MapProvider = GMapProviders.BingMap;
            gMapRouteToDoctor.DragButton = MouseButtons.Left;

            populateDonorMarkers();

            compoenetSelectComboBox.SelectedIndex = 0;
            selectedComponent = compoenetSelectComboBox.SelectedText;

            controller.donationCenter.setLatLon();
            gMapPendingDonors.Position = new PointLatLng(controller.donationCenter.lat, controller.donationCenter.lon);
            gMapPendingDonors.Zoom = 15;

            selectedComponent = "Celule Rosii";
            fillComponentList();

        }

 
        private void RefreshLists()
        {



            donorList.Items.Clear();
            pendingDonorList.Items.Clear();
            doctorRequestList.Items.Clear();
            
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

            fillComponentList();

            populateDonorMarkers();

            donorOkButton.Enabled = pendingDonorList.Items.Count != 0;
            donorNotOkButton.Enabled = donorOkButton.Enabled;


        }


        private void populateDonorMarkers()
        {

            try
            {
                gMapRouteToDoctor.Overlays.Remove(gMapRouteToDoctor.Overlays.First(x => x.Id == "donorMarkers"));
            }
            catch { }

            GMapOverlay markes = new GMapOverlay("donorMarkers");


            controller.getDonatedDonors().ToList().ForEach(
                donor =>
                {

                    GMapMarker doctorMarker = new GMarkerGoogle(
                           new PointLatLng(donor.location.latitude, donor.location.longitude),
                           GMarkerGoogleType.blue);

                    doctorMarker.ToolTipText = donor.ToString();

                    doctorMarker.ToolTip.Stroke.Color = Color.White;
                    doctorMarker.ToolTip.Foreground = Brushes.Black;


                    markes.Markers.Add(doctorMarker);
                });

            gMapDonors.Overlays.Add(markes);
        }

        private void centerMap()
        {
            controller.donationCenter.setLatLon();
            gMapDonors.Position = new PointLatLng(controller.donationCenter.lat, controller.donationCenter.lon);
            gMapDonors.Zoom = 15;
        }

        private void DonationCenterGUI_Load(object sender, EventArgs e)
        {
            RefreshLists();

            if (donorList.Items.Count >= 1)
            {
                donorList.SelectedIndex = 0;
            }
            else
            {
                centerMap();
            }

            if (pendingDonorList.Items.Count >= 1)
            {
                pendingDonorList.SelectedIndex = 0;
            }
            else
            {
                centerMap();
            }

            if (doctorRequestList.Items.Count >= 1)
            {
                doctorRequestList.SelectedIndex = 0;
            }
            else
            {
                centerMap();
            }


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
                    string body = eMailForm.eMailText;

                    Thread th = new Thread(
                        unused => EmailService.sendMail(controller.donationCenter.name, address, subject, body)
                        );
                    th.Start();
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
                string body = eMailForm.eMailText;
                
      
                Thread th = new Thread(
                        unused => EmailService.sendMail(controller.donationCenter.name, address, subject, body)
                        );
                th.Start();
            }
            else
            {
                return;
            }

            RefreshLists();
        }


        private void fillPotentialBloodList(string comp)
        {
            ComponentForRequest = comp; 
            potentialBloodTextBox.Text = comp; 
        }

        private void getAvailableDonorsForRequest(string comp, DoctorRequest selected)
        {
            if (comp == null)
            {
                
                IList<Donor> availableDonors = controller.getAvailableDonorsForRequest(selected);

                if (availableDonors.Count == 0)
                {
                    fillPotentialBloodList("Nu exista suficient sange pe stoc si nu exista donatori disponibili");
                    return;
                }


                CallDonorsForm callForm = new CallDonorsForm(availableDonors, selected);
                callForm.ShowDialog();
                return;
            }
            fillPotentialBloodList(comp);
        }


        private void doctorRequestList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DoctorRequest selected = (DoctorRequest)doctorRequestList.SelectedItem;

            Doctor doctor = controller.service.GetOneFromDatabase<Doctor>(selected.doctor_id);

            double doctorLat = doctor.location.latitude;
            double doctorLon = doctor.location.longitude;

            controller.donationCenter.setLatLon();

            double donationCenterLat = controller.donationCenter.lat;
            double donationCenterLon = controller.donationCenter.lon;

            try
            {
                gMapRouteToDoctor.Overlays.Remove(gMapRouteToDoctor.Overlays.First(x => x.Id == "markers"));
            }
            catch { }

            GMapOverlay markes = new GMapOverlay("markers");

            GMapMarker doctorMarker = new GMarkerGoogle(
                   new PointLatLng(doctorLat, doctorLon),
                   GMarkerGoogleType.blue);

            doctorMarker.ToolTipText = selected.hospital;

            doctorMarker.ToolTip.Stroke.Color = Color.White;
            doctorMarker.ToolTip.Foreground = Brushes.Black;


            GMapMarker donationCenterMarker = new GMarkerGoogle(
                   new PointLatLng(donationCenterLat, donationCenterLon),
                   GMarkerGoogleType.red);

            donationCenterMarker.ToolTipText = "Centrul nostru!";

            donationCenterMarker.ToolTip.Stroke.Color = Color.White;
            donationCenterMarker.ToolTip.Foreground = Brushes.Black;


            markes.Markers.Add(doctorMarker);
            markes.Markers.Add(donationCenterMarker);

            gMapRouteToDoctor.Overlays.Add(markes);

            #region RouteCalculation
            try
            {
                gMapRouteToDoctor.Overlays.Remove(gMapRouteToDoctor.Overlays.First(x => x.Id == "requestRoute"));
            }
            catch { }


            MapRoute route = OpenStreetMapProvider.Instance.GetRoute(
            new PointLatLng(doctorLat, doctorLon), new PointLatLng(donationCenterLat, donationCenterLon), false, false, 15);

            GMapRoute r = new GMapRoute(route.Points, "Route to donation center");

            GMapOverlay routesOverlay = new GMapOverlay("requestRoute");

            routesOverlay.Routes.Add(r);

            gMapRouteToDoctor.Overlays.Add(routesOverlay);

            gMapRouteToDoctor.Position = new PointLatLng(doctorLat, doctorLon);
            gMapRouteToDoctor.Zoom = 15;
            #endregion


            sendBloodButton.Enabled = !selected.isBeeingDelivered;
            

            string type = selected.requestString.Split(',')[0];

            string comp = null;

            if (type == "Plasma")
            {
                comp = controller.getAvailableBloodForRequest(selected);
                
            }
            if (type == "Red")
            {
                comp = controller.getAvailableBloodForRequest(selected);
               
            }
            if (type == "Tromb")
            {
                comp = controller.getAvailableBloodForRequest(selected);
            }

            sendBloodButton.Enabled = false;

            if (comp != null)
            {
                sendBloodButton.Enabled = true;
            }

            getAvailableDonorsForRequest(comp, selected);

        }


        private void sendBloodButton_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Comanda a fost expediata!", "Suces!");

            var emailList = controller.sendBlood(ComponentForRequest, (DoctorRequest)doctorRequestList.SelectedItem);

            foreach(Tuple<string, DoctorRequest> tup in emailList)
            {
                Thread th = new Thread(
                              unused => EmailService.sendBloodDispatchingMail(tup.Item1, tup.Item2)
                            );

                th.Start();
            }

            RefreshLists();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }

        private void gMapRouteToDoctor_Load(object sender, EventArgs e)
        {

        }


        private void fillComponentList()
        {
            stocksDataGridView.Columns.Clear();

            string type = selectedComponent;

            stocksDataGridView.Rows.Clear();

            if (type == "Celule Rosii")
            {
                stocksDataGridView.ColumnCount = 5;

                stocksDataGridView.Columns[0].HeaderText = "Antigen";
                stocksDataGridView.Columns[1].HeaderText = "Rh";
                stocksDataGridView.Columns[2].HeaderText = "Cantitate";
                stocksDataGridView.Columns[3].HeaderText = "Expira la";
                stocksDataGridView.Columns[4].HeaderText = "Donat pentru";


                controller.donationCenter.redBloodCellList
                    .ToList()
                    .ForEach(x => stocksDataGridView.Rows.Add(new string[] {x.antigen, x.rh? "pozitiv": "negativ", x.ammount.ToString(), x.getExpirationDate().Date.ToString(), x.donatedFor}));
            }

            if (type == "Plasma")
            {
                stocksDataGridView.ColumnCount = 4;

                stocksDataGridView.Columns[0].HeaderText = "Anticorpi";
                stocksDataGridView.Columns[1].HeaderText = "Cantitate";
                stocksDataGridView.Columns[2].HeaderText = "Expira la";
                stocksDataGridView.Columns[3].HeaderText = "Donat pentru";


                controller.donationCenter.plasmaList
                   .ToList()
                   .ForEach(x => stocksDataGridView.Rows.Add(new string[] { x.antibody, x.ammount.ToString(), x.getExpirationDate().Date.ToString(), x.donatedFor }));


            }

            if (type == "Trombocite")
            {
                stocksDataGridView.ColumnCount = 3;

                stocksDataGridView.Columns[0].HeaderText = "Cantitate";
                stocksDataGridView.Columns[1].HeaderText = "Expira la";
                stocksDataGridView.Columns[2].HeaderText = "Donat pentru";



                controller.donationCenter.trombocyteList
                   .ToList()
                   .ForEach(x => stocksDataGridView.Rows.Add(new string[] {x.ammount.ToString(), x.getExpirationDate().Date.ToString(), x.donatedFor }));


            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedComponent = (string)compoenetSelectComboBox.SelectedItem;
            fillComponentList();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshLists();
        }
    }
}

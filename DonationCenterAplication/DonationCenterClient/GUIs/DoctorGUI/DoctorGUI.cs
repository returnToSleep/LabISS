using Common.Model;
using Common.Validators;
using Controller;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace Client.GUIs
{
    public partial class DoctorGUI : Form
    {
        DoctorController controller;
        public DoctorGUI(DoctorController controller)
        {
            InitializeComponent();
            this.controller = controller;
            RefreshLists();
            gMapDoctors.Manager.Mode = AccessMode.ServerOnly;
            gMapDoctors.MapProvider = GMapProviders.GoogleMap;
            gMapDoctors.DragButton = MouseButtons.Left;

            gMapStocks.Manager.Mode = AccessMode.ServerOnly;
            gMapStocks.MapProvider = GMapProviders.GoogleMap;
            gMapStocks.DragButton = MouseButtons.Left;

            populateDonationCenterList();
            populateRequestList();
            populatePacientList();

            nameLabel.Text += " " + controller.doctor.name;

            comboBox1.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            priority.SelectedIndex = 0;
            component.SelectedIndex = 0;

            Text = controller.doctor.hospital;

        }

        

        public void populateRequestList()
        {

            requestList.Items.Clear();

            IList<DoctorRequest> requestLiat = controller.doctor.requests;
            foreach (DoctorRequest r in requestLiat)
            {
                requestList.Items.Add(r);
            }

        }

        public void populatePacientList()
        {
            pacientMultiList.Items.Clear();

            HashSet<string> pacientList = controller.getPacients();
            foreach (string r in pacientList)
            {
                pacientMultiList.Items.Add(r);
            }
        }

        public void populateDonationCenterList()
        {
            this.comboBox1.Items.Clear();
            this.comboBox4.Items.Clear();



            GMapOverlay markersStock = new GMapOverlay("markersStock");
            GMapOverlay markersRequest = new GMapOverlay("markersRequest");

            this.controller.service.GetAllFromDatabase<Common.Model.DonationCenter>().ToList().ForEach(dc =>
            {
                this.comboBox1.Items.Add(dc);
                this.comboBox4.Items.Add(dc);


                dc.setLatLon();

                double lat = dc.lat;
                double lon = dc.lon;

                GMapMarker marker = new GMarkerGoogle(
                    new PointLatLng(lat, lon),
                    GMarkerGoogleType.red);

                marker.ToolTipText = dc.name;
                marker.ToolTip.Stroke.Color = Color.White;
                marker.ToolTip.Foreground = Brushes.Black;

                markersStock.Markers.Add(marker);
                markersRequest.Markers.Add(marker);


            });

            GMapMarker doctorMarker = new GMarkerGoogle(
                   new PointLatLng(controller.doctor.location.latitude, controller.doctor.location.longitude),
                   GMarkerGoogleType.blue);

            doctorMarker.ToolTipText = "Spitalul dumneavoastra";
            doctorMarker.ToolTip.Stroke.Color = Color.White;
            doctorMarker.ToolTip.Foreground = Brushes.Black;

            markersStock.Markers.Add(doctorMarker);
            markersRequest.Markers.Add(doctorMarker);

            gMapDoctors.Overlays.Add(markersRequest);
            gMapStocks.Overlays.Add(markersStock);
        }
        private void RefreshLists()
        { 
            controller.refresh();
            populateRequestList();
            populatePacientList();
            populateDonationCenterList();
        }

        private void DoctorGUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        { 
            RefreshLists();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Common.Model.DonationCenter donationCenter = (Common.Model.DonationCenter)comboBox1.SelectedItem;

            double doctorLat = controller.doctor.location.latitude;
            double doctorLon = controller.doctor.location.longitude;


            double donationCenterLat = donationCenter.lat;
            double donationCenterLon = donationCenter.lon;


            try
            {
                gMapDoctors.Overlays.Remove(gMapDoctors.Overlays.First(x => x.Id == "requestRoute"));
            }
            catch { }

            MapRoute route = OpenStreetMapProvider.Instance.GetRoute(
            new PointLatLng(doctorLat, doctorLon), new PointLatLng(donationCenterLat, donationCenterLon), false, false, 15);

            GMapRoute r = new GMapRoute(route.Points, "Route to donation center");

            GMapOverlay routesOverlay = new GMapOverlay("requestRoute");

            routesOverlay.Routes.Add(r);

            gMapDoctors.Overlays.Add(routesOverlay);
            
            gMapDoctors.Position = new PointLatLng(donationCenterLat, donationCenterLon);
            gMapDoctors.Zoom = 15;
        }

        private void component_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.component.SelectedIndex == 0)
            {
                this.rh.Enabled = true;
                this.antigen.Enabled = true;
            }
            if (this.component.SelectedIndex == 1)
                this.rh.Enabled = false;

            if (this.component.SelectedIndex == 2)
            {
                this.rh.Enabled = false;
                this.antigen.Enabled = false;
            }
        }

        private void priority_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

            Common.Model.DonationCenter donationCenter = (Common.Model.DonationCenter)comboBox4.SelectedItem;

            double doctorLat = controller.doctor.location.latitude;
            double doctorLon = controller.doctor.location.longitude;

            double donationCenterLat = donationCenter.lat;
            double donationCenterLon = donationCenter.lon;

            try
            {
                gMapStocks.Overlays.Remove(gMapStocks.Overlays.First(x => x.Id == "stockRoute"));
            }
            catch { }
        
            MapRoute route = OpenStreetMapProvider.Instance.GetRoute(
            new PointLatLng(doctorLat, doctorLon), new PointLatLng(donationCenterLat, donationCenterLon), false, false, 15);

            GMapRoute r = new GMapRoute(route.Points, "Route to donation center");
            GMapOverlay routesOverlay = new GMapOverlay("stockRoute");
            routesOverlay.Routes.Add(r);


            gMapStocks.Overlays.Add(routesOverlay);

            PlasmaAQuantity.Text = donationCenter.getPlasmaQuantity("A").ToString();
            PlasmaBQuantity.Text = donationCenter.getPlasmaQuantity("B").ToString();
            PlasmaABQuantity.Text = donationCenter.getPlasmaQuantity("AB").ToString();
            Plasma0Quantity.Text = donationCenter.getPlasmaQuantity("0").ToString();

            redAPQauntity.Text = donationCenter.getRedQuantity("A", true).ToString();
            redBPQauntity.Text = donationCenter.getRedQuantity("B", true).ToString();
            redABPQauntity.Text = donationCenter.getRedQuantity("AB", true).ToString();
            red0PQauntity.Text = donationCenter.getRedQuantity("0", true).ToString();

            redANQauntity.Text = donationCenter.getRedQuantity("A", false).ToString();
            redBNQauntity.Text = donationCenter.getRedQuantity("B", false).ToString();
            redABNQauntity.Text = donationCenter.getRedQuantity("AB", false).ToString();
            red0NQauntity.Text = donationCenter.getRedQuantity("0", false).ToString();

            trombQuantity.Text = donationCenter.getTrombQuantity().ToString();

            string[] loc = donationCenter.id.Split(',');

            gMapStocks.Position = new PointLatLng(double.Parse(loc[0]), double.Parse(loc[1]));
            gMapStocks.Zoom = 15;

        }

 
        private void requestList_SelectedIndexChanged(object sender, EventArgs e)
        {
            deliveredBloodList.Items.Clear();

            try {
                deliveredBloodList.Items.Add(controller.matchBloodWithRequest((DoctorRequest)requestList.SelectedItem));
                noAcceptBloodButton.Enabled = true;
                acceptBloodButton.Enabled = true;
            }
            catch (System.ArgumentNullException){
                deliveredBloodList.Items.Add("Comanda este in asteptare");
                acceptBloodButton.Enabled = false;
                noAcceptBloodButton.Enabled = false;
            }
        }

        private void acceptBloodButton_Click(object sender, EventArgs e)
        {
            DoctorRequest dR = (DoctorRequest)requestList.SelectedItem;

            if (dR.requestString.Split(',')[0] == "Plasma")
            {
                controller.acceptBlood(dR, (Plasma)deliveredBloodList.Items[0], true);
            }
            if (dR.requestString.Split(',')[0] == "Red")
            {
                controller.acceptBlood(dR, (RedBloodCell)deliveredBloodList.Items[0], true);
            }
            if (dR.requestString.Split(',')[0] == "Tromb")
            {
                controller.acceptBlood(dR, (Trombocyte)deliveredBloodList.Items[0], true);
            }

            MessageBox.Show("Comanda a fost acceptata!", "Suces!");

            RefreshLists();

        }

        private void noAcceptBloodButton_Click(object sender, EventArgs e)
        {
            DoctorRequest dR = (DoctorRequest)requestList.SelectedItem;

            if (dR.requestString.Split(',')[0] == "Plasma")
            {
                controller.acceptBlood(dR, (Plasma)deliveredBloodList.Items[0], false);
            }
            if (dR.requestString.Split(',')[0] == "Red")
            {
                controller.acceptBlood(dR, (RedBloodCell)deliveredBloodList.Items[0], false);
            }
            if (dR.requestString.Split(',')[0] == "Tromb")
            {
                controller.acceptBlood(dR, (Trombocyte)deliveredBloodList.Items[0], false);
            }

            RefreshLists();

            MessageBox.Show("Comanda a fost retrimisa!", "Ne cerem scuze");

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void multiLineListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            foreach(Control c in pacientStatusGroupBox.Controls)
            {
                c.Enabled = true;
            }


            string selectedPacient = (string)pacientMultiList.SelectedItem;

            var result = controller.getBloodDonatedForPacient(selectedPacient);
            var totalNeeded = controller.getRequiredBloodForPacient(selectedPacient);


            pacientNameLabel.Text = "Componente donate pentru " + selectedPacient;

          

            pacientTrombTextBox.Text = result.Item1.ToString();
            pacientPlasmaTExtBox.Text = result.Item2.ToString();
            pacientRedTextBox.Text = result.Item3.ToString();



            trombProgress.Maximum = (int)totalNeeded.Item1;
            plasmaProgress.Maximum = (int)totalNeeded.Item2;
            redProgress.Maximum = (int)totalNeeded.Item3;


            trombProgress.Value = totalNeeded.Item1 < result.Item1 ? (int)totalNeeded.Item1 : (int)result.Item1;
            plasmaProgress.Value = totalNeeded.Item2 < result.Item2 ? (int)totalNeeded.Item2 : (int)result.Item2;
            redProgress.Value = totalNeeded.Item3 < result.Item3 ? (int)totalNeeded.Item3 : (int)result.Item3;

            if (totalNeeded.Item1 == 0)
            {
                pacientTrombTextBox.Text = "Nu este nevoie";
                pacientTrombTextBox.Enabled = false;
                trombProgress.Enabled = false;

            }
            if (totalNeeded.Item2 == 0)
            {
                pacientPlasmaTExtBox.Text = "Nu este nevoie";
                pacientPlasmaTExtBox.Enabled = false;
                plasmaProgress.Enabled = false;
            }
            if (totalNeeded.Item3 == 0)
            {
                pacientRedTextBox.Text = "Nu este nevoie";
                pacientRedTextBox.Enabled = false;
                redProgress.Enabled = false;
            }


        }

        private void sendRequestButton_Click(object sender, EventArgs e)
        {


            string err = RequestValidator.validateNameQuantity(this.cnp.Text, quantity.Text);

            if (err != "")
            {
                MessageBox.Show(err, "Date invalide");
                return;
            }


            string donationCenterName = this.comboBox1.Items[this.comboBox1.SelectedIndex].ToString();
            var donationCenter = this.controller.service.GetAllFromDatabase<Common.Model.DonationCenter>().Where(dc => dc.name == donationCenterName).FirstOrDefault();

            List<string> loc = donationCenter.id.Split(',').ToList();
            Location location = new Location
            {
                latitude = Convert.ToDouble(loc[0]),
                longitude = Convert.ToDouble(loc[1])
            };

            string priority = this.priority.Items[this.priority.SelectedIndex].ToString();

            if (priority == "Mare")
                priority = "1";

            if (priority == "Medie")
                priority = "2";

            if (priority == "Scazuta")
                priority = "3";

            string pacientName = this.cnp.Text.ToString();

            IList<Donor> donorList = controller.service.GetAllFromDatabase<Donor>();
            try
            {
                Donor donor = donorList.First(x => x.name == pacientName);
                priority = "0";
            }
            catch (Exception) { }


            string request = "";

            if (this.component.SelectedIndex == 0)
                request += "Red" + ',' + this.antigen.Text.ToString() + ',' + rh.Checked.ToString() + ',' + this.quantity.Text.ToString();

            if (this.component.SelectedIndex == 1)
                request += "Plasma" + ',' + this.antigen.Text.ToString() + ',' + this.quantity.Text.ToString();

            if (this.component.SelectedIndex == 2)
                request += "Tromb" + ',' + this.quantity.Text.ToString();


            this.controller.makeRequest(location, Convert.ToInt32(priority), "PACIENT NAME", pacientName, request, donationCenterName);
            MessageBox.Show("Cerere trimisa", "Suces!");

            this.priority.SelectedIndex = 0;
            this.component.SelectedIndex = 0;
            this.cnp.Text = "";
            this.quantity.Text = "";
            this.antigen.Text = "";
            this.rh.Text = "";
        }

        private void gMapStocks_Load(object sender, EventArgs e)
        {

        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }

        private void trombProgress_Click(object sender, EventArgs e)
        {

        }

        private void pacientRedTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pacientPlasmaTExtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void gMapStocks_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (item.ToolTipText != "Spitalul dumneavoastra")
            {
                foreach (object donationCenter in comboBox4.Items)
                {
                    Common.Model.DonationCenter d = (Common.Model.DonationCenter)donationCenter;

                    if (d.name == item.ToolTipText)
                    {
                        comboBox4.SelectedItem = donationCenter;
                        comboBox1.SelectedItem = donationCenter;
                        return;
                    }

                }
            }
        }

        private void gMapDoctors_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (item.ToolTipText != "Spitalul dumneavoastra")
            {
                foreach (object donationCenter in comboBox1.Items)
                {
                    Common.Model.DonationCenter d = (Common.Model.DonationCenter)donationCenter;

                    if (d.name == item.ToolTipText)
                    {
                        comboBox1.SelectedItem = donationCenter;
                        comboBox4.SelectedItem = donationCenter;
                        return;
                    }

                }
            }
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshLists();
        }

        private void label33_Click(object sender, EventArgs e)
        {

        }
    }
}

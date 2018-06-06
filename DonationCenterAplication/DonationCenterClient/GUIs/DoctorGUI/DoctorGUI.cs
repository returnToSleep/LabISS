using Client.Utils;
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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Client.GUIs.DoctorGUIs
{
    public partial class DoctorGUI : Form
    {

        bool isSmartRequest = false;
        List<Tuple<string, double, string>> smartRequestList;
       

        DoctorController controller;
        public DoctorGUI(DoctorController controller)
        {
            InitializeComponent();
            this.controller = controller;
      
            gMapDoctors.Manager.Mode = AccessMode.ServerOnly;
            gMapDoctors.MapProvider = GMapProviders.BingMap;
            gMapDoctors.DragButton = MouseButtons.Left;
            gMapDoctors.DisableFocusOnMouseEnter = true;

            gMapStocks.Manager.Mode = AccessMode.ServerOnly;
            gMapStocks.MapProvider = GMapProviders.BingMap;
            gMapStocks.DragButton = MouseButtons.Left;
            gMapStocks.DisableFocusOnMouseEnter = true;

            populateDonationCenterList();
            donatedForComboBox.SelectedIndex = 0;
            avaibleComponentsDonationCenterComboBox.SelectedIndex = 0;

            comboBox4.SelectedIndex = 0;
            
            populateRequestList();

            populatePacientList();

            nameLabel.Text += " " + controller.doctor.name;

            populateRequestChart();

            priority.SelectedIndex = 0;
            component.SelectedIndex = 0;
        
            donatedForComboBox.SelectedIndex = 0;
            avaibleComponentsDonationCenterComboBox.SelectedIndex = 0;

            Text = controller.doctor.hospital;

        }

        public void populateRequestChart()
        {
            IList<Common.Model.DonationCenter> donationCenterList = controller.service.GetAllFromDatabase<Common.Model.DonationCenter>();

            Series series = new Series("pieChart");
            series.ChartType = SeriesChartType.Pie;

            
            series["PieLineColor"] = "Black";


            donationCenterList.ToList()
                .ForEach(x =>
                {
                    DataPoint p = new DataPoint();
                    p.SetValueY(100);
                    p.LegendText = x.name;
                    series.Points.Add(p);
                }
                );

            requestChart.Series.Add(series);

        }

        public void populateRequestList()
        {

            requestList.Items.Clear();

            IList<DoctorRequest> reqList = controller.doctor.requests.OrderBy(x => x.priority).ToList();

            reqList = controller.sortRequests(reqList.ToList());

            foreach (DoctorRequest r in reqList)
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

            if (pacientList.Count == 0)
            {

                donatedForGroupBox.Hide();
                avaialbeGroupBox.Hide();
            }
            else
            {
        
                pacientMultiList.SelectedIndex = 0;

            }

        }

        public void populateDonationCenterList()
        {
         
            this.comboBox4.Items.Clear();
            this.donatedForComboBox.Items.Clear();
            this.avaibleComponentsDonationCenterComboBox.Items.Clear();


            GMapOverlay markersStock = new GMapOverlay("markersStock");
            GMapOverlay markersRequest = new GMapOverlay("markersRequest");

            this.controller.service.GetAllFromDatabase<Common.Model.DonationCenter>().ToList().ForEach(dc =>
            {
              
                this.comboBox4.Items.Add(dc);
                this.donatedForComboBox.Items.Add(dc);
                this.avaibleComponentsDonationCenterComboBox.Items.Add(dc);

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

            doctorMarker.ToolTipText = "Your hospital";
            doctorMarker.ToolTip.Stroke.Color = Color.White;
            doctorMarker.ToolTip.Foreground = Brushes.Black;

            markersStock.Markers.Add(doctorMarker);
            markersRequest.Markers.Add(doctorMarker);

            gMapDoctors.Overlays.Add(markersRequest);
            gMapStocks.Overlays.Add(markersStock);
        }
        private void RefreshLists()
        {

            if (requestList.Items.Count == 0)
            {
                deliveredBloodList.Items.Clear();
            }
            
            controller.refresh();
            populateRequestList();
            populatePacientList();
            populateDonationCenterList();
        }


        private void refreshButton_Click(object sender, EventArgs e)
        { 
            RefreshLists();
        }

      

        private void component_SelectedIndexChanged(object sender, EventArgs e)
        {

            resetSmartRequest();

            this.rh.Enabled = true;
            this.antigen.Enabled = true;

            isSmartRequest = false;

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
            isSmartRequest = false;
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

            gMapDoctors.Position = new PointLatLng(double.Parse(loc[0]), double.Parse(loc[1]));
            gMapDoctors.Zoom = 15;


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
                deliveredBloodList.Items.Add("Request pending..");
                acceptBloodButton.Enabled = false;
                noAcceptBloodButton.Enabled = false;
            }
        }

        private void acceptBloodButton_Click(object sender, EventArgs e)
        {
            DoctorRequest dR = (DoctorRequest)requestList.SelectedItem;
            try
            {
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

                MessageBox.Show("The package has been accepted!", "Succes!");
            }
            catch(Exception exc)
            {
                Console.WriteLine("Exception:" + exc.ToString());
            }
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

            MessageBox.Show("Delivered component has been sent back to the donation center!", "We apologize");

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void multiLineListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            donatedForGroupBox.Show();
            avaialbeGroupBox.Show();

            foreach(Control c in pacientStatusGroupBox.Controls)
            {
                c.Enabled = true;
            }


            string selectedPacient = (string)pacientMultiList.SelectedItem;

            string donationCenterId;

            try
            {
                Common.Model.DonationCenter donationCenter = (Common.Model.DonationCenter)donatedForComboBox.SelectedItem;
                donationCenterId = donationCenter.id;
            }
            catch (NullReferenceException)
            {
                if (donatedForComboBox.Items.Count == 0)
                {
                    return;
                }

                Common.Model.DonationCenter donationCenter = (Common.Model.DonationCenter)donatedForComboBox.Items[0];
                donationCenterId = donationCenter.id;
            }

            var result = controller.getBloodDonatedForPacient(selectedPacient, donationCenterId);
            var totalNeeded = controller.getRequiredBloodForPacient(selectedPacient);


            donatedForGroupBox.Text = "Components donated for " + selectedPacient;

          

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
                pacientTrombTextBox.Text = "Not needed";
                pacientTrombTextBox.Enabled = false;
                trombProgress.Enabled = false;

            }
            if (totalNeeded.Item2 == 0)
            {
                pacientPlasmaTExtBox.Text = "Not needed";
                pacientPlasmaTExtBox.Enabled = false;
                plasmaProgress.Enabled = false;
            }
            if (totalNeeded.Item3 == 0)
            {
                pacientRedTextBox.Text = "Not needed";
                pacientRedTextBox.Enabled = false;
                redProgress.Enabled = false;
            }



            foreach (Control c in pacientStatusGroupBox.Controls)
            {
                c.Enabled = true;
            }

            
            result = controller.getAvailableBloodForPacient(selectedPacient, donationCenterId);
            
            availableTrombTextBox.Text = result.Item1.ToString();
            availablePlasmaTextBox.Text = result.Item2.ToString();
            availableRedTextBox.Text = result.Item3.ToString();



            availableTrombProgress.Maximum = (int)totalNeeded.Item1;
            availablePlasmaProgress.Maximum = (int)totalNeeded.Item2;
            availableRedProgress.Maximum = (int)totalNeeded.Item3;


            availableTrombProgress.Value = totalNeeded.Item1 < result.Item1 ? (int)totalNeeded.Item1 : (int)result.Item1;
            availablePlasmaProgress.Value = totalNeeded.Item2 < result.Item2 ? (int)totalNeeded.Item2 : (int)result.Item2;
            availableRedProgress.Value = totalNeeded.Item3 < result.Item3 ? (int)totalNeeded.Item3 : (int)result.Item3;

            if (totalNeeded.Item1 == 0)
            {
                availableTrombTextBox.Text = "Not needed";
                availableTrombTextBox.Enabled = false;
                availableTrombProgress.Enabled = false;

            }
            if (totalNeeded.Item2 == 0)
            {
                availablePlasmaTextBox.Text = "Not needed";
                availablePlasmaTextBox.Enabled = false;
                availablePlasmaProgress.Enabled = false;
            }
            if (totalNeeded.Item3 == 0)
            {
                availableRedTextBox.Text = "Not needed";
                availableRedTextBox.Enabled = false;
                availableRedProgress.Enabled = false;
            }




        }

        private void sendRequestButton_Click(object sender, EventArgs e)
        {

            if (!isSmartRequest)
            {
            
                isSmartRequest = true;

                string name = cnp.Text;
                string comp = (string)component.SelectedItem;
                string anti = (string)antigen.SelectedItem;
                bool r = rh.Checked;

                if (comp == "Red Cells")
                    comp = "Red";

                if (comp == "Trombocytes")
                    comp = "Tromb";


                string err = RequestValidator.validateNameQuantity(this.cnp.Text, quantity.Text);

                if (err != "")
                {
                    MessageBox.Show(err, "Invalid data");
                    isSmartRequest = false;
                    sendRequestButton.Text = "Smart Request";
                    return;
                }


                smartRequestList = controller.getBestRequest(name, comp, (string)antigen.SelectedItem, rh.Checked, float.Parse(quantity.Text));

                double gatheredAmmount = smartRequestList.Select(x => x.Item2).Sum();


                if (gatheredAmmount == 0)
                {
                    MessageBox.Show("There is absolutely no blood matching the request available across all donation centers.", "No blood");
                    resetSmartRequest();
                    return;
                }


                if (gatheredAmmount < float.Parse(quantity.Text))
                {

                    
                    //Message.SmartRequestMessageBox diag = new Message.SmartRequestMessageBox("Not enough blood mathing your request has been found across all dontaion centers.\nOnly " + gatheredAmmount + "ml have been found\nWhat would you like to do?");
                    
                    SmartRequestDialog reqDiag = new SmartRequestDialog("Not enough blood mathing your request has been found across all dontaion centers.\nOnly " + gatheredAmmount + "ml have been found\nWhat would you like to do?", false);
                    reqDiag.ShowDialog();

                    if (reqDiag.DialogResult == DialogResult.Cancel)
                    {
                        resetSmartRequest();
                        return;
                    }

                    if (reqDiag.DialogResult == DialogResult.Yes)
                    {
                        smartRequestList = controller.getBestRequest(name, comp, (string)antigen.SelectedItem, rh.Checked, (float)gatheredAmmount);
                    }
                    if (reqDiag.DialogResult == DialogResult.No)
                    {
                        smartRequestList = controller.getBestRequest(name, comp, (string)antigen.SelectedItem, rh.Checked, (float)gatheredAmmount);
                        smartRequestList.AddRange(controller.getOriginalAmmountRequest(name, comp, (string)antigen.SelectedItem, rh.Checked, float.Parse(quantity.Text) - (float)gatheredAmmount));
                    }
                }
                

                requestChart.Series[0].Points.ToList()
                    .ForEach(x => x.SetValueY(0));


                smartRequestList.Where(x => x.Item2 != 0).ToList().ForEach(
                    x => {
                        requestChart.Series[0].Points.First(y => y.LegendText == x.Item1).SetValueY(x.Item2);
                        requestChart.Series[0].Points.First(y => y.LegendText == x.Item1).Label = x.Item2.ToString() + "ml";
                        }
                    );

                sendRequestButton.Text = "Send";
                requestChart.Update();
                requestChart.Refresh();
            }
            else
            {

                string name = cnp.Text;
                string comp = (string)component.SelectedItem;
                string anti = (string)antigen.SelectedItem;
                bool r = rh.Checked;

                if (comp == "Red Cells")
                    comp = "Red";

                if (comp == "Trombocytes")
                    comp = "Tromb";


                isSmartRequest = false;
                smartRequestList.Where(x => x.Item2 != 0).ToList().ForEach(req =>
                {


                    List<string> loc = req.Item3.Split(',').ToList();
                    Location location = new Location
                    {
                        latitude = Convert.ToDouble(loc[0]),
                        longitude = Convert.ToDouble(loc[1])
                    };

                    string priority = this.priority.Items[this.priority.SelectedIndex].ToString();

                    if (priority == "High")
                        priority = "1";

                    if (priority == "Medium")
                        priority = "2";

                    if (priority == "Low")
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

                    if (comp == "Red")
                        request += comp + ',' + anti + ',' + r.ToString() + ',' + req.Item2;

                    if (comp == "Plasma")
                        request += comp + ',' + anti + ',' + req.Item2;

                    if (comp == "Tromb")
                        request += comp + ',' + req.Item2;


                    this.controller.makeRequest(location, Convert.ToInt32(priority), "PACIENT NAME", pacientName, request, req.Item1);

                });

                MessageBox.Show("All the requests have been sent!", "Succes!");
                RefreshLists();

                this.priority.SelectedIndex = 0;
                this.component.SelectedIndex = 0;
                this.cnp.Text = "";
                this.quantity.Text = "";
                this.antigen.Text = "";
                this.rh.Text = "";
            }
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
            if (item.ToolTipText != "Your hospital")
            {
                foreach (object donationCenter in comboBox4.Items)
                {
                    Common.Model.DonationCenter d = (Common.Model.DonationCenter)donationCenter;

                    if (d.name == item.ToolTipText)
                    {
                        comboBox4.SelectedItem = donationCenter;
                        return;
                    }

                }
            }
        }

        private void gMapDoctors_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (item.ToolTipText != "Your hospital")
            {
                foreach (object donationCenter in comboBox4.Items)
                {
                    Common.Model.DonationCenter d = (Common.Model.DonationCenter)donationCenter;

                    if (d.name == item.ToolTipText)
                    {
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

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            if (!e.Cancel && this.Owner != null) this.Owner.TopMost = true;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (this.Owner != null)
            {
                this.Owner.TopMost = false;
            }
        }

        private void donatedForComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Control c in donatedForGroupBox.Controls)
            {
                c.Enabled = true;
            }


            string selectedPacient = (string)pacientMultiList.SelectedItem;

            Common.Model.DonationCenter donationCenter = (Common.Model.DonationCenter)donatedForComboBox.SelectedItem;
            string donationCenterId = donationCenter.id;

            var result = controller.getBloodDonatedForPacient(selectedPacient, donationCenterId);
            var totalNeeded = controller.getRequiredBloodForPacient(selectedPacient);


            donatedForGroupBox.Text = "Components donated for " + selectedPacient;



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
                pacientTrombTextBox.Text = "Not needed";
                pacientTrombTextBox.Enabled = false;
                trombProgress.Enabled = false;

            }
            if (totalNeeded.Item2 == 0)
            {
                pacientPlasmaTExtBox.Text = "Not needed";
                pacientPlasmaTExtBox.Enabled = false;
                plasmaProgress.Enabled = false;
            }
            if (totalNeeded.Item3 == 0)
            {
                pacientRedTextBox.Text = "Not needed";
                pacientRedTextBox.Enabled = false;
                redProgress.Enabled = false;
            }


        }

        private void avaibleComponentsDonationCenterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            foreach (Control c in avaialbeGroupBox.Controls)
            {
                c.Enabled = true;
            }


            Common.Model.DonationCenter donationCeter = (Common.Model.DonationCenter)avaibleComponentsDonationCenterComboBox.SelectedItem;


            string pacientName = (string)pacientMultiList.SelectedItem;

            var result = controller.getAvailableBloodForPacient(pacientName, donationCeter.id);
            var totalNeeded = controller.getRequiredBloodForPacient((string)pacientMultiList.SelectedItem);


            availableTrombTextBox.Text = result.Item1.ToString();
            availablePlasmaTextBox.Text = result.Item2.ToString();
            availableRedTextBox.Text = result.Item3.ToString();



            availableTrombProgress.Maximum = (int)totalNeeded.Item1;
            availablePlasmaProgress.Maximum = (int)totalNeeded.Item2;
            availableRedProgress.Maximum = (int)totalNeeded.Item3;


            availableTrombProgress.Value = totalNeeded.Item1 < result.Item1 ? (int)totalNeeded.Item1 : (int)result.Item1;
            availablePlasmaProgress.Value = totalNeeded.Item2 < result.Item2 ? (int)totalNeeded.Item2 : (int)result.Item2;
            availableRedProgress.Value = totalNeeded.Item3 < result.Item3 ? (int)totalNeeded.Item3 : (int)result.Item3;

            if (totalNeeded.Item1 == 0)
            {
                availableTrombTextBox.Text = "Not needed";
                availableTrombTextBox.Enabled = false;
                availableTrombProgress.Enabled = false;

            }
            if (totalNeeded.Item2 == 0)
            {
                availablePlasmaTextBox.Text = "Not needed";
                availablePlasmaTextBox.Enabled = false;
                availablePlasmaProgress.Enabled = false;
            }
            if (totalNeeded.Item3 == 0)
            {
                availableRedTextBox.Text = "Not needed";
                availableRedTextBox.Enabled = false;
                availableRedProgress.Enabled = false;
            }
        }

        private void resetSmartRequest()
        {
            requestChart.Series[0].Points.ToList()
                .ForEach(x => {
                    x.SetValueY(100);
                    x.Label = "";
                    });

             isSmartRequest = false;
            sendRequestButton.Text = "Smart request";
        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void pacientTrombTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void plasmaProgress_Click(object sender, EventArgs e)
        {

        }

        private void redProgress_Click(object sender, EventArgs e)
        {

        }

        private void gMapDoctors_Load(object sender, EventArgs e)
        {

        }

        private void cnp_TextChanged(object sender, EventArgs e)
        {
            resetSmartRequest();
        }

        private void antigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetSmartRequest();
        }

        private void rh_CheckedChanged(object sender, EventArgs e)
        {
            resetSmartRequest();
        }

        private void quantity_TextChanged(object sender, EventArgs e)
        {
            resetSmartRequest();
        }

        private void DoctorGUI_Load(object sender, EventArgs e)
        {

        }

        private void managaRequestsButton_Click(object sender, EventArgs e)
        {

        }

        private void nonpendingOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void requestList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
        }

        private void requestList_MouseUp(object sender, MouseEventArgs e)
        {
            return;
        }

        private void deleteSingleRequestMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                controller.deleteRequest((DoctorRequest)requestList.SelectedItem);
                RefreshLists();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops!");
            }
        }

        private void deleteAllRequests_Click(object sender, EventArgs e)
        {
            try
            {
                controller.deleteAllRequests((DoctorRequest)requestList.SelectedItem);
                RefreshLists();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops!");
            }
        }

        private void showOnlyForAComponentntToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshLists();
        }

        private void requestManagementMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}

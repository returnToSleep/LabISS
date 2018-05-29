using System;
using System.Linq;
using System.Windows.Forms;
using Common.Model;
using DonationCenterAplication.Remoting;
using System.Globalization;
using GMap.NET;
using GMap.NET.MapProviders;
using Common.Validators;
using Controller;
using System.Collections;
using System.Collections.Generic;
using Common.Exceptions;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Drawing;

namespace Client.GUIs.DonorGUI
{
    public partial class DonorFormGUI : Form
    {

        public Donor returnDonor { set;  get; }

        IService service;
        bool isFirstTime;
        string selectedDonationCenter_id;
        DonorController controller;

        IList<Common.Model.DonationCenter> donationCenterList;


        public void initializeMap()
        {

            gMapDonationCenter.Manager.Mode = AccessMode.ServerOnly;
            gMapDonationCenter.MapProvider = GMapProviders.GoogleMap;

        }

        public DonorFormGUI(IService service) 
        {
            this.service = service;
            this.isFirstTime = true;
            InitializeComponent();
            initializeMap();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }

        public DonorFormGUI(DonorController controller)
        {
            this.controller = controller;
            this.service = controller.service;
            isFirstTime = false;
            InitializeComponent();
            initializeMap();

        }



        private void DonorFormGUI_Load(object sender, EventArgs e)
        {


            donationCenterList = service.GetAllFromDatabase<Common.Model.DonationCenter>().ToList();
            
            foreach(Common.Model.DonationCenter don in donationCenterList)
            {
                donationCenterComboBox1.Items.Add(don);
            }


            donationCenterComboBox1.SelectedIndex = 0;

            if (isFirstTime)
            {
                stepLabel.Text = "Pasul 2 din 3";
            }
            else
            {
                stepLabel.Text = "Completare formular";
                
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

                emailTextBox.Text = controller.donor.email;

                donorCnpTextBox.Enabled = false;
            }


            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ro-RO");
        }

     
        private void donationCenterComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Common.Model.DonationCenter donationCenter = (Common.Model.DonationCenter)donationCenterComboBox1.SelectedItem;
            selectedDonationCenter_id = donationCenter.id;

            string[] locSplit = donationCenter.id.Split(',');
            double lat = double.Parse(locSplit[0]);
            double lon = double.Parse(locSplit[1]);

            try
            {
                gMapDonationCenter.Overlays.Remove(gMapDonationCenter.Overlays.First(x => x.Id == "requestRoute"));
            }
            catch { }

            try
            {
                gMapDonationCenter.Overlays.Remove(gMapDonationCenter.Overlays.First(x => x.Id == "markers"));
            }
            catch { }

            if (resiCityTextBox.Text != "" && resiStreetTextBox.Text != "" && resiNumberTextBox.Text != "")
            {

                string streetAux = "";
                
                if (resiStreetTextBox.Text.Split(' ')[0] != "Strada")
                {
                    streetAux = "Strada ";
                }
               

                string address = resiCityTextBox.Text + "," + streetAux + resiStreetTextBox.Text + "," + resiNumberTextBox.Text;

                gMapDonationCenter.SetPositionByKeywords(address);
                gMapDonationCenter.Zoom = 15;

                double donorLat = gMapDonationCenter.Position.Lat;
                double donorLon = gMapDonationCenter.Position.Lng;


                GMapOverlay markers = new GMapOverlay("markers");

                GMapMarker donationCenterMarker = new GMarkerGoogle(
                    new PointLatLng(lat, lon),
                    GMarkerGoogleType.red);

                donationCenterMarker.ToolTipText = donationCenter.name;

                donationCenterMarker.ToolTip.Stroke.Color = Color.White;
                donationCenterMarker.ToolTip.Foreground = Brushes.Black;

                GMapMarker donorMarker = new GMarkerGoogle(
                    new PointLatLng(donorLat, donorLon),
                    GMarkerGoogleType.blue);

                donorMarker.ToolTipText = "Dumneavoastra!";


                donorMarker.ToolTip.Stroke.Color = Color.White;
                donorMarker.ToolTip.Foreground = Brushes.Black;


                markers.Markers.Add(donationCenterMarker);
                markers.Markers.Add(donorMarker);

                gMapDonationCenter.Overlays.Add(markers);

                MapRoute route = OpenStreetMapProvider.Instance.GetRoute(
                new PointLatLng(donorLat, donorLon), new PointLatLng(lat, lon), false, false, 15);

                GMapRoute r = new GMapRoute(route.Points, "Route to donation center");
                
                r.Stroke.Color = Color.BlueViolet;
            

                GMapOverlay routesOverlay = new GMapOverlay("requestRoute");

                routesOverlay.Routes.Add(r);

                gMapDonationCenter.Overlays.Add(routesOverlay);




            }



            gMapDonationCenter.Position = new PointLatLng(lat, lon);
            gMapDonationCenter.Zoom = 15;

        }

        private void submitButton_Click(object sender, EventArgs e)
        {
        
            if (!disseaseCheckBox.Checked)
            {
                MessageBox.Show("Nu ati confirmat ca nu suferiti sau" + " ati suferit de afeciunile mentionate.\n\n" +
                    "In cazul in care suferiti de una sau mai" + " multe dintre afectiunile precizate\n" + 
                    "sangele dumneavoastra ar pune in pericol" + " vietiile celor care necesita transfuzii.\n\n" +
                    "Multumim pentru intelegere.", "Formular incomplet");
                return;
            }


        


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

            try
            {
                int.Parse(addressNumberTextBox.Text);
            }
            catch
            {
                err += "\nNumarul strazii in adresa este invalid";
            }

            try
            {
                int.Parse(resiNumberTextBox.Text);
            }
            catch
            {
                err += "Numarul strazii in adresa de resedinta este invalid";
            }


            DateTime birthday = new DateTime(1, 1, 1);

            try
            {
                int year = int.Parse(bithDateYearTextBox.Text);
                int month = int.Parse(birthDateMonthTextBox.Text);
                int day = int.Parse(birthDateDayTextBox.Text);
                birthday = new DateTime(year, month, day);
            }
            catch (Exception) {
                err += "\nData nasterii este completata gresit";
            }

            if (isFirstTime || cnp != controller.donor.cnp)
            {
                try
                {
                    Donor search = service.GetOneFromDatabase<Donor>(cnp);
                    MessageBox.Show("Ati introdus CNP-ul unei alte persoane", "CNP invalid");
                    return;
                }
                catch (Exception){}
            }

            gMapDonationCenter.SetPositionByKeywords(residence);
            double lat = gMapDonationCenter.Position.Lat;
            double lon = gMapDonationCenter.Position.Lng;

            Common.Model.DonationCenter donationCenter = (Common.Model.DonationCenter)donationCenterComboBox1.SelectedItem;


            Location location = new Location(residence, lat, lon);

            returnDonor = new Donor(cnp, name, birthday, address, location, email);
            returnDonor.donationCenter_id = donationCenter.id;


            err = DonorValidator.validate(returnDonor);

            if (donatedForCheckBox.Checked)
            {
                string donatedFor = donatedForTextBox.Text;
                err += donatedFor == "" ? "\nAti ales optiunea \"Donez pentru cineva anume\" fara sa precizati numele persoanei" : "";
                returnDonor.donatedFor = donatedFor;
            }


            if (err == "")
            {
                DialogResult = DialogResult.OK;

                if (isFirstTime)
                {

                    doneWindow d = new doneWindow(donationCenter.name);
                    Hide();
                    d.ShowDialog();

                    DialogResult = d.DialogResult;
                    Close();
                }
                else
                {

                    returnDonor.isPending = true;
                    returnDonor.bloodType = controller.donor.bloodType;
                    MessageBox.Show("Formularul a fost trimis!\nVa asteptam in decursul saptamanii viitoare la: " + donationCenter.name, "Multumim!");
                    DialogResult = DialogResult.Yes;
                    Close();
                }
            }
            else
            {
                MessageBox.Show(err, "Date invalide");
                return;
            }

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            donatedForTextBox.Enabled = donatedForCheckBox.Checked;
        }
    }
}

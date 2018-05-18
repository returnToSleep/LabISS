using Common.Model;
using Controller;
using GMap.NET;
using GMap.NET.MapProviders;
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
            gMapDoctors.MapProvider = GMapProviders.OpenStreetMap;

            gMapStocks.Manager.Mode = AccessMode.ServerOnly;
            gMapStocks.MapProvider = GMapProviders.OpenStreetMap;

            populateDonationCenterList();
            populateRequestList();

            nameLabel.Text += " " + controller.doctor.name;

            comboBox1.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            priority.SelectedIndex = 0;
            component.SelectedIndex = 0;

        }

        public void populateRequestList()
        {
          

        }

        public void populateDonationCenterList()
        {
            this.controller.service.GetAllFromDatabase<Common.Model.DonationCenter>().ToList().ForEach(dc => {
                this.comboBox1.Items.Add(dc.name);
                this.comboBox4.Items.Add(dc.name);
                });

        }


        private void RefreshLists()
        {
           

            requestList.Items.Clear();

            IList<DoctorRequest> requestLiat = controller.doctor.requests;
            foreach (DoctorRequest r in requestLiat)
            {
                requestList.Items.Add(r);
            }
            


        }

        private void DoctorGUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {

            controller.refresh();
            RefreshLists();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string donationCenterName = this.comboBox1.Items[this.comboBox1.SelectedIndex].ToString();
            var donationCenter = this.controller.service.GetAllFromDatabase<Common.Model.DonationCenter>().First(dc => dc.name == donationCenterName);

            string[] loc = donationCenter.id.Split(',');

            gMapDoctors.Position = new PointLatLng(double.Parse(loc[0]), double.Parse(loc[1]));
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

        private void button1_Click(object sender, EventArgs e)
        {
            string donationCenterName = this.comboBox1.Items[this.comboBox1.SelectedIndex].ToString();
            var donationCenter = this.controller.service.GetAllFromDatabase<Common.Model.DonationCenter>().Where(dc => dc.name == donationCenterName).FirstOrDefault();

            List<string> loc = donationCenter.id.Split(',').ToList();
            Location location = new Location
            {
                latitude = Convert.ToDouble(loc[0]),
                longitude = Convert.ToDouble(loc[1])
            };

            string priority = this.priority.Items[this.priority.SelectedIndex].ToString();
            string pacientCNP = this.cnp.Text.ToString();

            var donor = this.controller.service.GetAllFromDatabase<Donor>().Where(d => d.cnp == pacientCNP);
            if(donor != null)
            {
                priority = "0";
            }

            string request = "";

            if (this.component.SelectedIndex == 0)
                request += "Red" + ',' + this.antigen.Text.ToString() + ',' + this.rh.Text.ToString() + ',' + this.quantity.Text.ToString();

            if (this.component.SelectedIndex == 1)
                request += "Plasma" + ',' + this.antigen.Text.ToString() + ',' + this.quantity.Text.ToString();

            if (this.component.SelectedIndex == 2)
                request += "Tromb" + ',' + this.quantity.Text.ToString();


            this.controller.makeRequest(location, Convert.ToInt32(priority), "PACIENT NAME", pacientCNP, request);
            MessageBox.Show("Cerere trimisa");
            this.comboBox1.SelectedIndex = 0;
            this.priority.SelectedIndex = 0;
            this.component.SelectedIndex = 0;
            this.cnp.Text = "";
            this.quantity.Text = "";
            this.antigen.Text = "";
            this.rh.Text = "";
        }

    

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string donationCenterName = this.comboBox4.Items[this.comboBox4.SelectedIndex].ToString();
            var donationCenter = this.controller.service.GetAllFromDatabase<Common.Model.DonationCenter>().First(dc => dc.name == donationCenterName);


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

            MessageBox.Show("Comanda a fost acceptata!");

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

            MessageBox.Show("Comanda a fost retrimisa!");

        }

    }
}

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
            populateHospitalList();
            this.comboBox1.SelectedIndex = 0;
            this.priority.SelectedIndex = 0;
            this.component.SelectedIndex = 0;
        }


        public void populateHospitalList()
        {
            this.controller.service.GetAllFromDatabase<Common.Model.DonationCenter>().ToList().ForEach(dc => {
                this.comboBox1.Items.Add(dc.name);
                });

        }


        private void RefreshLists()
        {

            stockRedCellList.Items.Clear();
            stockPlasmaList.Items.Clear();
            stockTrombList.Items.Clear();

            //controller.Refresh();

            IList<Trombocyte> tlst = controller.doctor.trombocyteList;
            foreach (Trombocyte t in tlst)
            {
                stockTrombList.Items.Add(t);
            }

            IList<Plasma> plaslst = controller.doctor.plasmaList;
            foreach (Plasma p in plaslst)
            {
                stockPlasmaList.Items.Add(p);
            }

            IList<RedBloodCell> rlst = controller.doctor.redBloodCellList;
            foreach (RedBloodCell r in rlst)
            {
                stockRedCellList.Items.Add(r);
            }


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
            string donationCenterName = this.comboBox1.Items[this.comboBox1.SelectedIndex].ToString();
            var donationCenter = this.controller.service.GetAllFromDatabase<Common.Model.DonationCenter>().Where(dc => dc.name == donationCenterName).FirstOrDefault();

            List<string> loc = donationCenter.id.Split(',').ToList<string>();

            gMapDoctors.Position = new PointLatLng(Convert.ToDouble(loc[0]), Convert.ToDouble(loc[0]));
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

            List<string> loc = donationCenter.id.Split(',').ToList<string>();
            Location location = new Location
            {
                latitude = Convert.ToDouble(loc[0]),
                longitude = Convert.ToDouble(loc[1])
            };
            string priority = this.priority.Items[this.priority.SelectedIndex].ToString();
            string pacientCNP = this.cnp.Text.ToString();
            var donor = this.controller.service.GetAllFromDatabase<Donor>().Where(d => d.cnp == pacientCNP);
            if(donor == null)
            {
                MessageBox.Show("No such donor!");
                return;
            }
            string request = "";
            if (this.component.SelectedIndex == 0)
                request += "Red" + ',' + this.antigen.Text.ToString() + ',' + this.rh.Text.ToString() + ',' + this.quantity.Text.ToString();
            if (this.component.SelectedIndex == 1)
                request += "Plasma" + ',' + this.antigen.Text.ToString() + ',' + this.quantity.Text.ToString();

            if (this.component.SelectedIndex == 2)
                request += "Tromb" + ',' + this.quantity.Text.ToString();
            this.controller.makeRequest(location, Convert.ToInt32(priority), pacientCNP, request);
            MessageBox.Show("Cerere trimisa");
            this.comboBox1.SelectedIndex = 0;
            this.priority.SelectedIndex = 0;
            this.component.SelectedIndex = 0;
            this.cnp.Text = "";
            this.quantity.Text = "";
            this.antigen.Text = "";
            this.rh.Text = "";
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DonationCenterAplication.ORM;
using Common.Model;
using Repository;
using GMap.NET;
using GMap.NET.MapProviders;

namespace DonationCenterServer.Forms
{
    public partial class DonationCenterCRUD : Form
    {
        public DonationCenterCRUD()
        {
            InitializeComponent();

            gMapDonationCenterSelect.Manager.Mode = AccessMode.ServerOnly;
            gMapDonationCenterSelect.MapProvider = GMapProviders.BingMap;
            gMapDonationCenterSelect.Zoom = 15;
            gMapDonationCenterSelect.DisableFocusOnMouseEnter = true;

            gMapDonationCenterSelect.SetPositionByKeywords("Cluj-Napoca");
            gMapDonationCenterSelect.DragButton = MouseButtons.Left;

            
        }

        private void DonationCenterCRUD_Load(object sender, EventArgs e)
        {
            RepositoryBase repo = new RepositoryBase();
            update(repo);
        }


        private void button1_Click(object sender, EventArgs e)
        {



            DonationCenter dc = read();
            clearTextBoxes();

            if (addButton.Text == "Add")
            {
                if (dc != null)
                {
                    RepositoryBase repo = new RepositoryBase();

                    int no = 0;
                    bool goOn = true;
                    string username = "";
                    string name = dc.name.Replace(" ", "");

                    while (goOn)
                    {
                        try
                        { 
                            username = name + no.ToString();
                            repo.Save(new LogInfo(username, "1234", dc.id, "Donation"));
                            goOn = false;
                        }
                        catch (Exception) { }
                    }
                    repo.Save(dc);

                    MessageBox.Show("New donation center account created.\nUser: " + username + "\nPassword: 1234", "Success");

                    update(repo);
                }
            }
            else
            {
                if (dc != null)
                {
                    RepositoryBase repo = new RepositoryBase();
                    repo.Delete(dc);
                    repo.Save(dc);

                    MessageBox.Show("The donation center has been updated", "Success");

                    update(repo);
                }
            }
        }

        private DonationCenter read()
        {
            nameTextbox.BackColor = Color.Empty;
            bool ok = true;
            #region Validation
            float dummy;
            if (!float.TryParse(locXTextbox.Text, out dummy))
            {
                locXTextbox.BackColor = Color.Red;
                ok = false;
            }
            if (!float.TryParse(locYTextbox.Text, out dummy))
            {
                locYTextbox.BackColor = Color.Red;
                ok = false;
            }

            if (string.IsNullOrEmpty(nameTextbox.Text))
            {
                nameTextbox.BackColor = Color.Red;
                ok = false;
            }
            #endregion

            if (ok)
            {
                return new DonationCenter(locXTextbox.Text + "," + locYTextbox.Text, nameTextbox.Text);
            }
            else
                return null;
        }

        private void fill(string dcID)
        {
            RepositoryBase repo = new RepositoryBase();
            DonationCenter dc = repo.FindOne<DonationCenter>(dcID);
            var locs = dc.id.Split(',');
            locXTextbox.Text = locs[0];
            locYTextbox.Text = locs[1];
            nameTextbox.Text = dc.name;
        }

        private void clearTextBoxes()
        {
            #region Clear textboxes
            locXTextbox.Clear();
            locYTextbox.Clear();
            nameTextbox.Clear();
            #endregion
        }

        private void update(RepositoryBase repo)
        {
            donationCenterList.Items.Clear();

            List<DonationCenter> donList = repo.FindAll<DonationCenter>().ToList();
            donList.ForEach(x => donationCenterList.Items.Add(x));

            donationCenterList.Items.Add("Add new..");

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(
                "Are you sure you want to delete this donation center?\nNote that deleting the donation center will also delete the account\nassociated with it.",
                "Delete donation center",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {



                RepositoryBase repo = new RepositoryBase();

                DonationCenter selected = (DonationCenter)donationCenterList.SelectedItem;

                LogInfo log = repo.FindAll<LogInfo>()
                                    .Where(x => x.type == "Donation")
                                    .First(x => x.varId == selected.id);

                donationCenterList.SelectedIndex = 0;
                repo.Delete(selected);
                repo.Delete(log);
                update(repo);
            }
            else
                return;

        }

        private void locXTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void gMapDonationCenterSelect_LocationChanged(object sender, EventArgs e)
        {
            locXTextbox.Text = gMapDonationCenterSelect.Position.Lat.ToString();
            locYTextbox.Text = gMapDonationCenterSelect.Position.Lng.ToString();
            gMapDonationCenterSelect.Zoom = 15;
        }

        private void gMapDonationCenterSelect_MouseClick(object sender, MouseEventArgs e)
        {
            locXTextbox.Text = gMapDonationCenterSelect.Position.Lat.ToString();
            locYTextbox.Text = gMapDonationCenterSelect.Position.Lng.ToString();
            gMapDonationCenterSelect.Zoom = 15;
        }

        private void gMapDonationCenterSelect_MouseMove(object sender, MouseEventArgs e)
        {
            locXTextbox.Text = gMapDonationCenterSelect.Position.Lat.ToString();
            locYTextbox.Text = gMapDonationCenterSelect.Position.Lng.ToString();
            gMapDonationCenterSelect.Zoom = 15;
        }

        private void locYTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void donationCenterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DonationCenter don = (DonationCenter)donationCenterList.SelectedItem;
                fill(don.id);

                don.setLatLon();

                gMapDonationCenterSelect.Position = new PointLatLng(don.lat, don.lon);

                addButton.Text = "Update";
                deleteButton.Visible = true;
                
            }
            catch (Exception) {

                clearTextBoxes();
                addButton.Text = "Add";
                deleteButton.Visible = false;

                gMapDonationCenterSelect.SetPositionByKeywords("Cluj-Napoca");

            }


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

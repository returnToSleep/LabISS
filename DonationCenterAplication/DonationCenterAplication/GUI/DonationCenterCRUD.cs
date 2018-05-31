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
            gMapDonationCenterSelect.MapProvider = GMapProviders.OpenStreetMap;
            gMapDonationCenterSelect.Zoom = 15;
            gMapDonationCenterSelect.SetPositionByKeywords("Cluj-Napoca");

            //TODO Foarte faina card-urile dom DoctorCRUD
            //Astea de aici mai putin
            //Andi sau Emu (de preferat Emu) rezolvati va rog 
        }

        private void DonationCenterCRUD_Load(object sender, EventArgs e)
        {
            RepositoryBase repo = new RepositoryBase();
            update(repo);
        }

        private void ContextMenu1_Click(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            RepositoryBase repo = new RepositoryBase();
            if (MessageBox.Show(
                "Are you sure you want to delete this donation center?",
                "Delete donation center",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {

                repo.Delete(item.Tag);
                update(new RepositoryBase());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DonationCenter dc = this.read();
            clearTextBoxes();
            if (dc != null)
            {
                RepositoryBase repo = new RepositoryBase();
                repo.Save(dc);
                update(repo);
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
            flowLayoutPanel1.Controls.Clear();
            foreach (DonationCenter dc in repo.FindAll<DonationCenter>())
            {
                GroupBox box = new GroupBox();
                #region Card Creation
                box.Size = new Size(280, 120);
                Label name = new Label
                {
                    Font = new Font(FontFamily.GenericSansSerif, 24.0f, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(5, 15),
                    Text = dc.name
                };
                box.Controls.Add(name);
                Font smallFont = new Font(FontFamily.GenericSansSerif, 11.0f);

                MenuItem item = new MenuItem("Delete");
                item.Click += ContextMenu1_Click;
                item.Tag = dc;
                ContextMenu cm = new ContextMenu();
                cm.MenuItems.Add(item);
                box.ContextMenu = cm;
                box.Click += new EventHandler(delegate (Object o, EventArgs a) { box.Focus(); box.BackColor = Color.AliceBlue; fill(dc.id); });
                //box.GotFocus += new EventHandler(delegate (Object o, EventArgs a) { });
                box.LostFocus += new EventHandler(delegate (Object o, EventArgs a) { box.BackColor = Color.Empty; });
                #endregion
                flowLayoutPanel1.Controls.Add(box);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearTextBoxes();
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
    }
}

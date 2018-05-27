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
    public partial class DoctorCRUD : Form
    {
        public DoctorCRUD()
        {
            InitializeComponent();
            gMapDoctorSelect.Manager.Mode = AccessMode.ServerOnly;
            gMapDoctorSelect.MapProvider = GMapProviders.OpenStreetMap;
            gMapDoctorSelect.Zoom = 15;
            gMapDoctorSelect.SetPositionByKeywords("Cluj-Napoca");

        }

        private void DoctorCRUD_Load(object sender, EventArgs e)
        {
            RepositoryBase repo = new RepositoryBase();
            update(repo);

            foreach(DonationCenter center in repo.FindAll<DonationCenter>())
            {
                comboBox1.Items.Add(center.name);
            }
        }

        private void ContextMenu1_Click(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            RepositoryBase repo = new RepositoryBase();
            if (MessageBox.Show(
                "Are you sure you want to delete this doctor?",
                "Delete doctor",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                repo.Delete(item.Tag);
                update(repo);
                clearTextBoxes();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Doctor doc = this.read();
            if (doc != null)
            {
                RepositoryBase repo = new RepositoryBase();
                if (idLable.Text == "none")
                    repo.Save(doc);
                else
                {
                    doc.id = int.Parse(idLable.Text);
                    repo.Update(doc);
                }
                update(repo);
            }
            clearTextBoxes();
        }

        private Doctor read()
        {
            nameTextbox.BackColor =
            specialityTextbox.BackColor =
            comboBox1.BackColor = Color.Empty;
            bool ok = true;
            #region Validation

            if (string.IsNullOrEmpty(nameTextbox.Text))
            {
                nameTextbox.BackColor = Color.Red;
                ok = false;
            }

            if (string.IsNullOrEmpty(nameTextbox.Text))
            {
                specialityTextbox.BackColor = Color.Red;
                ok = false;
            }

            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                comboBox1.BackColor = Color.Red;
                ok = false;
            }
            #endregion

            if (ok)
            {
                return new Doctor(
                    nameTextbox.Text,
                    specialityTextbox.Text,
                    comboBox1.Text,
                    new Location("", double.Parse(locXTextbox.Text), double.Parse(locYTextbox.Text))
                    );
            }
            else
                return null;
        }

        private void fill(string docID)
        {
            RepositoryBase repo = new RepositoryBase();
            Doctor doc = repo.FindOne<Doctor>(int.Parse(docID));

            idLable.Text = doc.id.ToString();
            nameTextbox.Text = doc.name;
            specialityTextbox.Text = doc.speciality;
            comboBox1.Text = doc.hospital;
            locXTextbox.Text = doc.location.latitude.ToString();
            locYTextbox.Text = doc.location.longitude.ToString();
        }

        private void clearTextBoxes()
        {
            #region Clear textboxes
            idLable.Text = "none";
            locXTextbox.Clear();
            locYTextbox.Clear();
            nameTextbox.Clear();
            specialityTextbox.Clear();
            comboBox1.Text = "";
            #endregion
        }

        private void update(RepositoryBase repo)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (Doctor doc in repo.FindAll<Doctor>())
            {
                GroupBox box = new GroupBox();
                #region Card Creation 2
                CardControl card = new CardControl
                (
                    doc.name, doc.id.ToString(), doc.speciality, doc.hospital, doc.location.latitude.ToString(), doc.location.longitude.ToString()
                );
                card.Click += (s, e) => { fill(card.id); };
                card.ContextMenu = new ContextMenu();
                MenuItem item = new MenuItem("Delete", ContextMenu1_Click);
                item.Tag = doc;
                card.ContextMenu.MenuItems.Add(item);
                #endregion
                
                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearTextBoxes();
        }

        private void gMapDoctorSelect_MouseMove(object sender, MouseEventArgs e)
        {
            locXTextbox.Text = gMapDoctorSelect.Position.Lat.ToString();
            locYTextbox.Text = gMapDoctorSelect.Position.Lng.ToString();
            gMapDoctorSelect.Zoom = 15;
        }
    }
}

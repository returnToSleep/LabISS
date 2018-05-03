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

namespace DonationCenterServer.Forms
{
    public partial class DoctorCRUD : Form
    {
        public DoctorCRUD()
        {
            InitializeComponent();
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
                repo.Delete<Doctor>(item.Tag);
                update(new RepositoryBase());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Doctor doc = this.read();
            clearTextBoxes();
            if (doc != null)
            {
                RepositoryBase repo = new RepositoryBase();
                repo.BeginTransaction();
                repo.Save(doc);
                repo.CommitTransaction();
                update(repo);
            }
        }

        private Doctor read()
        {
            nameTextbox.BackColor =
            specialityTextbox.BackColor =
            comboBox1.BackColor = Color.Empty;
            bool ok = true;
            #region Validation
            if (!float.TryParse(locXTextbox.Text, out float dummy))
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
                    locXTextbox.Text + "," + locYTextbox.Text,
                    nameTextbox.Text,
                    specialityTextbox.Text,
                    comboBox1.Text);
            }
            else
                return null;
        }

        private void fill(string docID)
        {
            RepositoryBase repo = new RepositoryBase();
            Doctor doc = repo.FindOne<Doctor>(docID);
            var locs = doc.id.Split(',');
            locXTextbox.Text = locs[0];
            locYTextbox.Text = locs[1];
            nameTextbox.Text = doc.name;
            specialityTextbox.Text = doc.speciality;
            comboBox1.Text = doc.hospital;
        }

        private void clearTextBoxes()
        {
            #region Clear textboxes
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
                #region Card Creation
                box.Size = new Size(280, 120);
                Label name = new Label
                {
                    Font = new Font(FontFamily.GenericSansSerif, 24.0f, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(5, 15),
                    Text = doc.name
                };
                box.Controls.Add(name);
                Font smallFont = new Font(FontFamily.GenericSansSerif, 14.0f);
                Label mylabel1 = new Label
                {
                    Font = smallFont,
                    AutoSize = true,
                    Location = new Point(5, 55),
                    Text = "speciality:"
                };
                box.Controls.Add(mylabel1);
                Label speciality = new Label
                {
                    Font = smallFont,
                    AutoSize = true,
                    Location = new Point(100, 55),
                    Text = doc.speciality
                };
                box.Controls.Add(speciality);
                Label mylabel2 = new Label
                {
                    Location = new Point(5, 90),
                    AutoSize = true,
                    Font = smallFont,
                    Text = "hospital"
                };
                box.Controls.Add(mylabel2);
                Label hospital = new Label
                {
                    Font = smallFont,
                    AutoSize = true,
                    Location = new Point(100, 90),
                    Text = doc.hospital
                };
                box.Controls.Add(hospital);
                MenuItem item = new MenuItem("Delete");
                item.Click += ContextMenu1_Click;
                item.Tag = doc.id;
                ContextMenu cm = new ContextMenu();
                cm.MenuItems.Add(item);
                box.ContextMenu = cm;
                box.Click += new EventHandler(delegate (Object o, EventArgs a) { box.Focus(); box.BackColor = Color.AliceBlue; fill(doc.id); });
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
    }
}

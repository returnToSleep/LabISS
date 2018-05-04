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
    public partial class DonationCenterCRUD : Form
    {
        public DonationCenterCRUD()
        {
            InitializeComponent();
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
                repo.Delete<DonationCenter>(item.Tag);
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
                repo.BeginTransaction();
                repo.Save(dc);
                repo.CommitTransaction();
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
                Font smallFont = new Font(FontFamily.GenericSansSerif, 14.0f);

                MenuItem item = new MenuItem("Delete");
                item.Click += ContextMenu1_Click;
                item.Tag = dc.id;
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
    }
}

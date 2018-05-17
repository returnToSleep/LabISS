using Common.Model;
using Controller;
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

namespace Client.GUIs
{
    public partial class DoctorGUI : Form
    {
        DoctorController doctorController;
        public DoctorGUI(DoctorController doctorController)
        {

            InitializeComponent();
            this.doctorController = doctorController;
            RefreshLists();
        }

        private void nameLabel_Click(object sender, EventArgs e)
        {

        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshLists();
        }

        private void selectionTab_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RefreshLists()
        {

            stockRedCellList.Items.Clear();
            stockPlasmaList.Items.Clear();
            stockTrombList.Items.Clear();


            IList<Trombocyte> tlst = doctorController.doctor.trombocyteList;
            foreach (Trombocyte t in tlst)
            {
                stockTrombList.Items.Add(t);
            }

            IList<Plasma> plaslst = doctorController.doctor.plasmaList;
            foreach (Plasma p in plaslst)
            {
                stockPlasmaList.Items.Add(p);
            }

            IList<RedBloodCell> rlst = doctorController.doctor.redBloodCellList;
            foreach (RedBloodCell r in rlst)
            {
                stockRedCellList.Items.Add(r);
            }


        }

        private void DoctorGUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

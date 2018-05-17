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
        DoctorController controller;
        public DoctorGUI(DoctorController controller)
        {
            InitializeComponent();
            this.controller = controller;
            RefreshLists();
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
    }
}

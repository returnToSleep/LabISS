using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GUIs.DoctorGUIs
{
    public partial class SmartRequestDialog : Form
    {

        public SmartRequestDialog(string message, bool ammountIs0)
        {
            InitializeComponent();
            messageLabel.Text = message;

            originalButton.Enabled = ! ammountIs0;
        }

        private void gatheredButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void originalButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

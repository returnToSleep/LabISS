using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GUIs.DonationCenter
{
    public partial class Dialog : Form
    {

        public bool result { get; set; }

        /*
         * Creates a dialogue window, with yes and no options
         * this.text is a label in which the prompt of the question is stored
         * ex "Are you sure you want to exit?"
         * 
         * result is used for checking the answer
        */
        public Dialog(string text)
        {
            InitializeComponent();
            this.text.Text = text;
            this.button1.Text = "Da";
            this.button2.Text = "Nu";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.result = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.result = false;
        }

    }
}

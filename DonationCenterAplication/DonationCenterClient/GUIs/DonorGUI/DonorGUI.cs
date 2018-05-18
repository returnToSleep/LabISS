using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Model;
using DonationCenterAplication.Remoting;

namespace Client.GUIs.DonorGUI
{
    public partial class DonatorGUI : Form
    {
        public DonatorGUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TcpClientChannel channel = new TcpClientChannel();
            ChannelServices.RegisterChannel(channel, false);
            IService service = (IService)(Activator.GetObject(typeof(IService),
                "tcp://localhost:9999/IService"
                ));
            service.AddToDatabase(Read());
            this.Close();
        }

        private Donor Read()
        {
            return new Donor(
                name: textBox1.Text,
                cnp: maskedTextBox1.Text,
                birthdate: dateTimePicker1.Value,
                email: textBox2.Text,
                address: richTextBox1.Text,
                location: new Location(richTextBox1.Text, 0, 0)
                );
        }
    }
}

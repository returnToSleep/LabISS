using DonationCenterAplication.Remoting;
using DonationCenterServer.Forms;
using DonationCenterServer.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;



namespace DonationCenterAplication
{
    public partial class Form1 : Form
    {

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("kernel32")]
        static extern int AllocConsole();


        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        DoctorCRUD doctorForm;
        DonationCenterCRUD donationCenterForm;

        public Form1()
        {
            InitializeComponent();
            
            doctorForm = new DoctorCRUD();
            donationCenterForm = new DonationCenterCRUD();

            var handle = GetConsoleWindow();

            // Hide
            ShowWindow(handle, SW_HIDE);

            TcpServerChannel channel = new TcpServerChannel(9999);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(ServerService),
                "IService", WellKnownObjectMode.Singleton);
        
            //Console.ReadLine();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            if (donationCenterForm.Visible)
            {
                donationCenterForm.Hide();
            }
            
            if (doctorForm.IsDisposed)
            {
                doctorForm = new DoctorCRUD();
            }

            doctorForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (doctorForm.Visible)
            {
                doctorForm.Hide();
            }

            if (donationCenterForm.IsDisposed)
            {
                donationCenterForm = new DonationCenterCRUD();
            }
            donationCenterForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       

        private void loggerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (serverConsole.Enabled)
            {
                Console.SetOut(new ControlWriter(serverConsole));
            }
            else
            {
                Console.SetOut(null);
            }
        }

        private void consoleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (consoleCheckBox.Checked)
            { 
                Console.SetOut(new ControlWriter(serverConsole));
            }
            else
            {
                var standardOutput = new StreamWriter(Console.OpenStandardOutput());
                standardOutput.AutoFlush = true;
                Console.SetOut(standardOutput);
            }

        }
    }
    
}

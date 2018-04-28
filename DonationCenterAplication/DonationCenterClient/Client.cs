using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DonationCenterClient
{
    public partial class Client : Form
    {
        public Client()
        {
            GMapProvider.WebProxy = WebRequest.GetSystemWebProxy();
            GMapProvider.WebProxy.Credentials = CredentialCache.DefaultNetworkCredentials;

           
            //not use proxy
            GMapProvider.WebProxy = null;
            
            InitializeComponent();

            gmap.Manager.Mode = AccessMode.ServerOnly;
            gmap.MapProvider = GMapProviders.OpenStreetMap;
            gmap.Zoom = 1;
            gmap.SetPositionByKeywords("Brasov, Garii 4");
            gmap.Zoom = 18;


        }

        public void client_Load(object sender, EventArgs e)
        {
           
        }

        private void ZOOOOOM_Click(object sender, EventArgs e)
        {
            gmap.SetPositionByKeywords("Brasov, Garii 4");
            gmap.Zoom = 18;
           
        }
    }
}

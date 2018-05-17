using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
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
            gmap.Zoom = 2;
            gmap.SetPositionByKeywords("Cluj");
            gmap.Zoom = 15;

        }

        public void client_Load(object sender, EventArgs e)
        {

        }

        private void ZOOOOOM_Click(object sender, EventArgs e)
        {
            textBox1.Text = gmap.Position.Lat.ToString();
            textBox2.Text = gmap.Position.Lng.ToString();
        }

        private void gmap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            gmap.Position = item.Position;
        }
    }
}

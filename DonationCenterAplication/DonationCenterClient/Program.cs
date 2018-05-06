using Client.Controller;
using Client.GUIs;
using Client.GUIs.LogIn;
using Common.Model;
using DonationCenterAplication.Remoting;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DonationCenterClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogInForm());
            


            /*
             * Makes connection to server  
             */
            /*


          */

            
            
            


            //Donor donor = new Donor("ggg", "ok", "asdf", new DateTime(1,1,1), "aassdf", new Location(11,11), "asdf", "asdf");
            

            //DonationCenterController d = new DonationCenterController(service, service.GetOneFromDatabase<DonationCenter>("46.789348,23.607177"));


            //Donor dss = new Donor("19809", "ok", "Lecu", new DateTime(1999, 02, 10), "Ok", new Location("ok", 42, 43), "emaol@yahpp.cpm");
            //dss.isPending = false;

            //service.AddToDatabase(dss);

            //service.Refresh(d.donationCenter);

            
            //d.refreshBloodStock();

            //Console.ReadLine();

            /*
            try
            {
                //var d = new Doctor("10,10", "ok", "ok", "ok");
                //service.AddToDatabase(d);
                //service.Refresh();
                //service.DeleteFromDatabase<Doctor>("10");
                Console.Write(service.GetOneFromDatabase<Doctor>("10,10").ToString());
            }
            catch (TypeUnloadedException e)
            {
                Console.Write("Could not connect to server");
            }
            Console.Read();
           */
        }
      
    }

}

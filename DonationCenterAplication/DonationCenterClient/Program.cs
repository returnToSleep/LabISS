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

            /*
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            */


            /*
             * Makes connection to server  
             */

            ChannelServices.RegisterChannel(new TcpClientChannel(), false);
            IService service = (IService)(Activator.GetObject(typeof(IService),
                "tcp://localhost:9999/IService"
                ));

           
            
            Console.Write(service.getOneFromDatabase<Doctor>(1).ToString());

            Console.Read();
       
        }
      
    }

}

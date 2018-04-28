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
                Application.Run(new Client());
            */


            /*
             * Makes connection to server  
             */
            Console.ReadLine();

            ChannelServices.RegisterChannel(new TcpClientChannel(), false);
            IService service = (IService)(Activator.GetObject(typeof(IService),
                "tcp://localhost:9999/IService"
                ));

            try
            {

                Location l = new Location("testAddress", 10.10, 10.10);

                Doctor d = new Doctor("test", "test", "test", l);

                service.addToDatabase(d);
                
                Doctor d1 = service.getAllFromDatabase<Doctor>()[0];
                Console.Write(d1.location.ToString());

            }
            catch (TypeUnloadedException e)
            {
                Console.Write("Could not connect to server");
            }
            Console.Read();
            
        }
      
    }

}


using DonationCenterAplication;
using DonationCenterAplication.ORM;
using DonationCenterAplication.Remoting;
using Model;
using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Windows.Forms;

/**
 * 
 */
public class Source
{

    /**
     * 
     */
    static void Main()
    {

        
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
        

        
       
      
    }
}
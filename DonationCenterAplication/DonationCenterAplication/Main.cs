
using DonationCenterAplication.ORM;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/**
 * 
 */
public class Source {

    /**
     * 
     */
    static void Main()
    {
        RepositoryBase r = new RepositoryBase();

        Location l = new Location("asdf", "asdf", "asdf");
        Doctor d = new Doctor("asdf", "Asdf", "asdf", l);
        d.id = 2;

        try
        {
            r.BeginTransaction();
           
            r.Save(d);
            r.CommitTransaction();

            d = r.FindOne<Doctor>(1);
            Console.Write(d);

            r.Delete<Doctor>(2);

            List<Doctor> dL = r.FindAll<Doctor>();

            dL.ForEach(i => Console.Write(i));

        }
        catch(Exception e)
        {
            Console.Write("\n\n\n\n\n\n\nException");
            Console.Write(e.Message);
            r.RollbackTransaction();
        }
    }

}
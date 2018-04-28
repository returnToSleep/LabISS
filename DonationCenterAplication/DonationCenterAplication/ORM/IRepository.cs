using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationCenterAplication.ORM
{
    interface IRepository
    {
        /*
         * Saves element in database
         * Ex:
         *     Save(new Donor(...)); 
         */
        void Save(object obj);





        /*
         * Updates an object based on "obj.id"
         * Ex:
         *      Donor d = new Donor(...);
         *      d.id = 1;
         *     
         *      Save(d);
         *      
         *      d.name = "whatever";
         *      Update(d);
         * 
         */

        void Update(object obj);

        /*
        * Deletes elem 
        * Ex:
        *     Delete<Doctor>(1); 
        */
        void Delete<T>(object objId);

        /*
         * Returns element with id: objId
         * Ex:
         *    Donor d = repo.FindOne<Donor>(1);
         */ 
        T FindOne<T>(object objId);

        /*
         * Refreseg object
         * Ex:
         *    DonationCenter d = repo.FindOne<DonationCenter>(1);
         *    ...
         *    Refresh(d)
         */ 

        void Refresh(object obj);

        /*
         * Returns a list of type T
         * Ex:
         *    List<Doctor> = repo.FindAll<Doctor>();
         * 
        */
        List<T> FindAll<T>() where T: class;
    }
}

﻿using System;
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
         * Returns a list of type T
         * Ex:
         *    List<Doctor> = repo.FindAll<Doctor>();
         * 
        */
        List<T> FindAll<T>();
    }
}

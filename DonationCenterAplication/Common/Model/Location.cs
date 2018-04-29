
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model{
    /**
     * The Location class holds all the details of a location.
     */
     [Serializable]
    public class Location {


        public virtual string addressString { get; set; }
        public virtual int id { get; set; }
        public virtual double latitude { get; set;}
        public virtual double longitude { get; set; }

        public Location() { }

        /**
         * The Location class holds all the details of a location.
         */
        public Location(string addressString, double latitude, double longitude) {
            this.addressString = addressString;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public Location(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }


        public override bool Equals(object obj)
        {
            Location l;

            try
            {
                l = (Location)obj;
            }
            catch (InvalidCastException)
            {
                return false;
            }

            return l.latitude == latitude && l.longitude == longitude;

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public override string ToString()
        {
            return addressString;
        }
    }
}
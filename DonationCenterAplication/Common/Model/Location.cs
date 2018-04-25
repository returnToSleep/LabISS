
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


        public Location() { }

        /**
         * The Location class holds all the details of a location.
         */
        public Location(string address, string country, string city) {
            this.address = address;
            this.country = country;
            this.city = city;
        }

        /**
         * The Address as a string.
         */
        private string address;

        /**
         * The Country as a string.
         */
        private string country;

        /**
         * The City as a string.
         */
        private string city;


        /**
         * Returns the address.
         * @return
         */
        public string getAddress() {
            return this.address;
        }

        /**
         * Sets a new value for the address.
         * @param val 
         * @return
         */
        public void setAddress(string val) {
            this.address = val;
        }

        /**
         * Returns the country.
         * @return
         */
        public string getCountry() {
            return this.country;
        }

        /**
         * Sets a new value to country.
         * @param val 
         * @return
         */
        public void setCountry(string val) {
            this.country = val;
        }

        /**
         * Returns the city.
         * @return
         */
        public string getCity() {
            return city;
        }

        /**
         * Sets a new value to the city.
         * @param val 
         * @return
         */
        public void setCity(string val) {
            this.city = val;
        }

        public override string ToString()
        {
            return address + "city, " + city + ", country " + country;
        }
    }
}
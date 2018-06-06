using Common.Exceptions;
using Common.Model;
using DonationCenterAplication.Remoting;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;




namespace Client.Controller
{

    public class DonationCenterController
    {


        public IService service { get; set; }
        public DonationCenter donationCenter { get; set;}
        /**
         * Donation center constructor with args
         */
        public DonationCenterController(IService serv, DonationCenter donationCenter)
        {
            this.service = serv;
            this.donationCenter = donationCenter;
        }

        /**
   * Eliminates from the bloodcomponent lists the components that have expired. ( ExpirationDate > DateTime.Now )   
   * 
   */
        public void refreshBloodStock()
        {
            removeFromList(donationCenter.redBloodCellList);
            removeFromList(donationCenter.trombocyteList);
            removeFromList(donationCenter.plasmaList);
            service.Refresh(donationCenter);
        }

        /**
         * Function that removes the expired blood components
         */
        private void removeFromList<T>(IList<T> l) where T : BloodComponent
        {
          
            if ( l == null ){ return;  }

            l.ToList()
                .Where(x => DateTime.Compare(x.getExpirationDate(), DateTime.Now) <= 0)
                .ToList()
                .ForEach(x => service.DeleteFromDatabase(x));

        }


        /*
         * Retruns the list of pending donors
         *      (isPending - true)
         */ 
        public IList<Donor> getPendingDonors(){
            return this.donationCenter.donors.Where(x => x.isPending == true).ToList();
        }

        /*
         * Returns the list of available donors
         *      (isPending - false)
         */ 

        public IList<Donor> getDonatedDonors()
        {
            return this.donationCenter.donors.Where(x => x.isPending == false).ToList();
        }


        /*
        *   Returns the distance between two LatLong points
        */
        public double getDistanceFromDonationCenter(Donor donor)
        {
            double exp1 = donor.location.latitude - double.Parse(donationCenter.id.Split(',')[0]);
            double exp2 = donor.location.longitude - double.Parse(donationCenter.id.Split(',')[1]);

            return Math.Sqrt(Math.Pow(exp1, 2) + Math.Pow(exp2, 2));
        }

        /*
         *  Returns a sorted list (ordered by distance) of the available donors 
         */

        public IList<Donor> getNearestDonors(IList<Donor> lst)
        {

            IList<Tuple<double, Donor>> distanceList = new List<Tuple<double, Donor>>(); 

            foreach(Donor d in lst)
            {
                distanceList.Add(new Tuple<double, Donor>(getDistanceFromDonationCenter(d), d));
            }

            return distanceList.OrderBy(x => x.Item1)
                .Select(x => x.Item2)
                .ToList();
        }

        /**
         * Adds a certain blood component to the stock, the donation center id of the component is set to this center's id
         * bloodComponent is the blood component ( plasma/ red cells / trobocytes) 
         */
        public void addBloodToStock<T>(T bloodComponent) where T : BloodComponent
        {
            bloodComponent.donationCenter_id = donationCenter.id;
            try
            {
                service.AddToDatabase(bloodComponent);
            }
            catch (RemotingException rmE)
            {
                throw new ControllerException("An error has occured", rmE);
            }
            Refresh();
        }


        /*
        *   Adds a donation to the donor 
        * 
        */ 
        public void addDonationToDonor(Donor donor, Donation donation, string bloodType)
        {
          
            try
            {
                service.UpdateOneFromDatabase(donor);
                service.AddToDatabase(donation);
            }
            catch (RemotingException rmE)
            {
                throw new ControllerException("An error has occured", rmE);
            }
        }

        /*
         * Gets a new instance for this.donationCenter
         * 
         */ 

        public void Refresh()
        {
            refreshBloodStock();
            try
            {
                donationCenter = this.service.GetOneFromDatabase<DonationCenter>(this.donationCenter.id);
            }
            catch (RemotingException rmE)
            {
                throw new ControllerException("An error has occured", rmE);
            }
        }

        /**
         * Evaluates a donor, if the donor passes the test( the bool is true), updates it's status from pending to donated and sends him a mail,
         * otherwise removes the donor from the list and sends him a mail.
         */
        public void evaluateDonor(bool b, Donor d)
        {
            if (b)
            {
                d.isPending = false;
                try
                {
                    service.UpdateOneFromDatabase(d);
                }
                catch (RemotingException rmE)
                {
                    throw new ControllerException("An error has occured", rmE);
                }
                Refresh();
            }
            else
            {
                try
                {
                    service.DeleteFromDatabase(d);
                }
                catch (RemotingException rmE)
                {
                    throw new ControllerException("An error has occured", rmE);
                }
                Refresh();
            }

        }

        /*
         * Creates a priority queue from the doctor requests, based on the request's importance 
        */
        public IList<DoctorRequest> sortRequests()
        {
            IList<DoctorRequest> priorityQueueRequests = new List<DoctorRequest>();
            try
            {
                IList<DoctorRequest> doctorRequest = this.service.GetAllFromDatabase<DoctorRequest>();
                doctorRequest.OrderByDescending(x => x.priority)
                .Select(x => x)
                .ToList().ForEach(request => priorityQueueRequests.Add(request));
            }
            catch (RemotingException rmE)
            {
                throw new ControllerException("An error has occured", rmE);
            }
            return priorityQueueRequests;
        }




        #region Blood dispatching

        /*
         * Returns the matching donors based on a request (Same blood type)
         */ 

        public IList<Donor> getAvailableDonorsForRequest(DoctorRequest request)
        {
            string[] splitRequest = request.requestString.Split(',');

            string bloodType = "AB";
            bool rh = false;

            #region Plasma
            if (splitRequest[0].Equals("Plasma"))
            {
                if (splitRequest[1] == "A")
                {
                    bloodType = "B";
                }

                if (splitRequest[1] == "B")
                {
                    bloodType = "A";
                }

                if (splitRequest[1] == "AB")
                {
                    bloodType = "0";
                }

                if (splitRequest[1] == "0")
                {
                    bloodType = "A";
                }

                return getNearestDonors(getDonatedDonors()
                    .Where(x => x.bloodType == bloodType)
                    .Where(x => DateTime.Compare(x.getLastDonation().AddMonths(2), DateTime.Now) < 0)
                    .ToList());

            }
            #endregion
            #region Red
            if (splitRequest[0].Equals("Red"))
            {

                bloodType = splitRequest[1];

                rh = bool.Parse(splitRequest[2]);

                return getNearestDonors(getDonatedDonors()
                    .Where(x => x.bloodType == bloodType && x.rh == rh)
                    .Where(x => DateTime.Compare(x.getLastDonation().AddMonths(2), DateTime.Now) < 0)
                    .ToList());

            }
            #endregion
            #region Tromb
            if(splitRequest[0] == "Tromb")
            {
                return getNearestDonors(getDonatedDonors()
                    .Where(x => DateTime.Compare(x.getLastDonation().AddMonths(2), DateTime.Now) < 0)
                    .ToList());
            }
            #endregion

            return null;

        }

        /*
         * This one is a bit strange
         *      When an employee of the donation center wants to see if there is enough blood for a request
         *      The components needed should't be removed from the database (Onlny when the wmployee clicks the "trimitere" button)      
         *
         *      Returns a string with the type of the component, the id's of the selected components, the ammounts and the first expiration date
         *      
         *      Ex:
         *          Plasma;12,100,15;15,200,02-02-2018"
         *      
         */     
        public string getAvailableBloodGreedy<T>(List<T> componentList, double ammountNeeded) where T : BloodComponent
        {
            IEnumerable<T> orderedList = componentList.OrderByDescending(x => x.ammount);
            string combinedBlood = "";
            double gatheredAmount = 0f;
            DateTime maxDate = new DateTime(1, 1, 1);

            foreach (T comp in orderedList)
            {
                if (gatheredAmount + comp.ammount >= ammountNeeded)
                {
                    if (comp.donationDate.CompareTo(maxDate) > 0)
                    {
                        maxDate = comp.donationDate;
                    }
                    combinedBlood += comp.id.ToString() + "," + (ammountNeeded - gatheredAmount).ToString() + ";" + maxDate.Year.ToString() + "/" + maxDate.Month.ToString() + "/" + maxDate.Day.ToString();
                    gatheredAmount += ammountNeeded - gatheredAmount;
                    break; 
                }

                if (comp.donationDate.CompareTo(maxDate) > 0)
                {
                    maxDate = comp.donationDate;
                }
                gatheredAmount +=  comp.ammount;
                combinedBlood += comp.id.ToString() + "," + comp.ammount + ";"; 

            }

            if (gatheredAmount < ammountNeeded)
            {
                return null;
            }

            string type = typeof(T).ToString().Split('.')[1];

            if (type == "RedBloodCell")
            {
                return "Red Cells;" + combinedBlood;
            }

            if (type == "Plasma")
            {
                return type + ";" + combinedBlood;
            }

            if (type == "Trombocyte")
            {
                return "Trombocyte;" + combinedBlood;
            }

            return null; 
        }



        public string getAvailableBloodForRequest(DoctorRequest request)
        {

            if (request.isBeeingDelivered)
            {
                return "Package is beeing delivered to the doctor";
            }

            string[] splitRequest = request.requestString.Split(',');
            

            if (splitRequest[0].Equals("Plasma"))
            {
                return getAvailableBloodGreedy(donationCenter.plasmaList
                    .Where(x => x.antibody == splitRequest[1])
                    .ToList(), double.Parse(splitRequest[2]));
            
            }

            if (splitRequest[0].Equals("Red"))
            {
            
                return getAvailableBloodGreedy(donationCenter.redBloodCellList
                    .Where(x => x.antigen == splitRequest[1] && x.rh == bool.Parse(splitRequest[2]))
                    .ToList(), double.Parse(splitRequest[3]));

            }

            if (splitRequest[0].Equals("Tromb"))
            {
                return getAvailableBloodGreedy(donationCenter.trombocyteList
                   .ToList(), double.Parse(splitRequest[1]));
            }

            return null;

        }

        /*
         * Updates the component ammount based on "splitCompStr" 
         * Example of "splitCompStr":
         *       {"Plasma", "12,100", "15,15", "02-02-2018"}"
         *       
         *  if the ammount of the component is 0 after the operation, it is removed fom the database
         */


        public IList<Tuple<string, DoctorRequest>> updateAmmounts(string[] splitCompStr, string type, DoctorRequest req)
        {

            IList<Tuple<string, DoctorRequest>> emailList = new List<Tuple<string, DoctorRequest>>();

            try
            {
                if (type == "Plasma")
                {
                    foreach (string s in splitCompStr)
                    {
                        string[] sArr = s.Split(',');
                        Plasma p = donationCenter.plasmaList.First(x => x.id == int.Parse(sArr[0]));
                        p.ammount -= double.Parse(sArr[1]);

                        if (p.email != null) {
                            emailList.Add(new Tuple<string, DoctorRequest>(p.email, req));
                        }
                            

                        if (p.ammount == 0)
                        {
                            service.DeleteFromDatabase(p);
                        }
                        else
                        {
                            service.UpdateOneFromDatabase(p);
                        }
                        
                    }
                }

                if (type == "Red")
                {
                    foreach (string s in splitCompStr)
                    {
                        string[] sArr = s.Split(',');
                        RedBloodCell r = donationCenter.redBloodCellList.First(x => x.id == int.Parse(sArr[0]));
                        r.ammount -= double.Parse(sArr[1]);

                        if (r.email != null)
                        {
                            emailList.Add(new Tuple<string, DoctorRequest>(r.email, req));
                        }
                        

                        if (r.ammount == 0)
                        {
                            service.DeleteFromDatabase(r);
                        }
                        else
                        {
                            service.UpdateOneFromDatabase(r);
                        }
                    }
                }

                if (type == "Tromb")
                {
                    foreach (string s in splitCompStr)
                    {
                        string[] sArr = s.Split(',');
                        Trombocyte t = donationCenter.trombocyteList.First(x => x.id == int.Parse(sArr[0]));
                        t.ammount -= double.Parse(sArr[1]);

                        if (t.email != null)
                        {
                            emailList.Add(new Tuple<string, DoctorRequest>(t.email, req));
                        }


                        if (t.ammount == 0)
                        {
                            service.DeleteFromDatabase(t);
                        }
                        else
                        {
                            service.UpdateOneFromDatabase(t);
                        }

                    }
                }
                return emailList;
            }


            catch (RemotingException rmE)
            {
                throw new ControllerException("An error has occured", rmE);
            }
       }


        /*
         * Sends blood to doctor
         * Marks the doctor_id field with the id of the doctor making the request
         * All components with doctor_id != null are beeing delivered to a doctor
         * 
         * Creates a new BloodComponent with the amount requested, and reduces the ammount of the source

         */


        public IList<Tuple<string, DoctorRequest>> sendBlood(string compStr, DoctorRequest request)
        {
            string[] splitRequest = request.requestString.Split(',');

            string[] splitCompStr = compStr.Replace("\n", "").Split(';');
            splitCompStr = splitCompStr.Skip(1).ToArray();
            
            var emailList = updateAmmounts(splitCompStr.Take(splitCompStr.Count() - 1).ToArray(), splitRequest[0], request);

           
            if (splitRequest[0] == "Plasma")
            {
                string dateStr = splitCompStr[splitCompStr.Length - 1];
                string[] splitDateStr = dateStr.Split('/');

                Plasma comp;

                DateTime date = new DateTime(int.Parse(splitDateStr[0]), int.Parse(splitDateStr[1]), int.Parse(splitDateStr[2]));
                comp = new Plasma(splitRequest[1], null, null, float.Parse(splitRequest[2]), date, null);
                comp.doctor_id = request.doctor_id;

                request.isBeeingDelivered = true;
                service.UpdateOneFromDatabase(request);
                service.AddToDatabase(comp);
                return emailList;
            }

            if (splitRequest[0] == "Red")
            {
                string dateStr = splitCompStr[splitCompStr.Length - 1];
                string[] splitDateStr = dateStr.Split('/');

                RedBloodCell comp;

                DateTime date = new DateTime(int.Parse(splitDateStr[0]), int.Parse(splitDateStr[1]), int.Parse(splitDateStr[2]));
                comp = new RedBloodCell(splitRequest[1], bool.Parse(splitRequest[2]), null, null, float.Parse(splitRequest[3]), date, null);
                comp.doctor_id = request.doctor_id;

                request.isBeeingDelivered = true;
                service.UpdateOneFromDatabase(request);
                service.AddToDatabase(comp);
                return emailList;
            }

            if (splitRequest[0] == "Tromb")
            {
                Trombocyte comp;

                string dateStr = splitCompStr[splitCompStr.Length - 1];
                string[] splitDateStr = dateStr.Split('/');

                DateTime date = new DateTime(int.Parse(splitDateStr[0]), int.Parse(splitDateStr[1]), int.Parse(splitDateStr[2]));
                comp = new Trombocyte( null, null, float.Parse(splitRequest[1]), date, null);
                comp.doctor_id = request.doctor_id;

                request.isBeeingDelivered = true;
                service.UpdateOneFromDatabase(request);
                service.AddToDatabase(comp);
                return emailList;
            }

            return emailList;
        }
    }
    #endregion

}

using Common.Model;
using DonationCenterAplication.Remoting;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




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
            removeFromList(this.donationCenter.redBloodCellList);
            removeFromList(this.donationCenter.trombocyteList);
            removeFromList(this.donationCenter.plasmaList);
            service.Refresh(donationCenter);
        }

        /**
         * Function that removes the expired blood components
         */
        private void removeFromList<T>(IList<T> l) where T : BloodComponent
        {
          
            if ( l == null ){ return;  }
            
            foreach(T bloodCompoenent in l)
            {
                if (DateTime.Compare(bloodCompoenent.getExpirationDate(), DateTime.Now) <= 0)
                {
                    service.DeleteFromDatabase(bloodCompoenent);
                }
            }
        
        }



        public IList<Donor> getPendingDonors(){
            return this.donationCenter.donors.Where(x => x.isPending == true).ToList();
        }

        public IList<Donor> getDonatedDonors()
        {
            return this.donationCenter.donors.Where(x => x.isPending == false).ToList();
        }


        public double getDistanceFromDonationCenter(Donor donor)
        {
            double exp1 = donor.location.latitude - float.Parse(this.donationCenter.id.Split(',')[0]);
            double exp2 = donor.location.longitude - float.Parse(this.donationCenter.id.Split(',')[1]);

            return Math.Sqrt(Math.Pow(exp1, 2) - Math.Pow(exp2, 2));
        }

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
            service.AddToDatabase(bloodComponent);
            Refresh();
        }

        public void addDonationToDonor(Donor donor, Donation donation, string bloodType)
        {
            donor.bloodType = bloodType.Split(' ')[0];

            donor.rh = bloodType.Split(' ')[1] == "pozitiv";


            service.UpdateOneFromDatabase(donor);
            service.AddToDatabase(donation);
        }

        public void Refresh()
        {
            refreshBloodStock();
            donationCenter = this.service.GetOneFromDatabase<DonationCenter>(this.donationCenter.id);
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
                this.service.UpdateOneFromDatabase(d);
                Refresh();
                //TODO : send mail
            }
            else
            {
                this.service.DeleteFromDatabase(d);
                Refresh();
                //TODO : send mail
            }

        }

        /*
         * Creates a priority queue from the doctor requests, based on the request's importance 
        */
        private PriorityQueue<DoctorRequest> sortRequests()
        {
            PriorityQueue<DoctorRequest> priorityQueueRequests = new PriorityQueue<DoctorRequest>();
            IList<DoctorRequest> doctorRequest = this.service.GetAllFromDatabase<DoctorRequest>();
            doctorRequest.ToList().ForEach(request => priorityQueueRequests.Enqueue(request));
            return priorityQueueRequests;
        }




        #region Blood dispatching

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


        public List<T> getAvailableBloodForRequest<T>(DoctorRequest request) where T : BloodComponent
        {
            string[] splitRequest = request.requestString.Split(',');
            

            if (splitRequest[0].Equals("Plasma"))
            {
                return this.donationCenter.plasmaList
                    .Where(x => x.antibody == splitRequest[1] && x.ammount >= double.Parse(splitRequest[2]))
                    .Cast<T>()
                    .ToList();
            }

            if (splitRequest[0].Equals("Red"))
            {
                return this.donationCenter.redBloodCellList
                    .Where(x => x.antigen == splitRequest[1] && x.rh == bool.Parse(splitRequest[2]) && x.ammount >= double.Parse(splitRequest[3]))
                    .Cast<T>()
                    .ToList();

            }

            if (splitRequest[0].Equals("Tromb"))
            {
                return this.donationCenter.trombocyteList
                    .Where(x => x.ammount >= double.Parse(splitRequest[1]))
                    .Cast<T>()
                    .ToList();
            }

            return null;

        }
     
        /*
         * Sends blood to doctor
         * Marks the doctor_id field with the id of the doctor making the request
         * All components with doctor_id != null are beeing delivered to a doctor
         * 
         * Creates a new BloodComponent with the amount requested, and reduces the ammount of the source

         */
        public void sendBlood<T>(BloodComponent bloodComponent, DoctorRequest request) where T : BloodComponent
        {
            string[] splitRequest = request.requestString.Split(',');
            
            T comp = (T)bloodComponent;
            comp.doctor_id = request.doctor_id;

            float ammount = float.Parse(splitRequest[3]);

            bloodComponent.ammount -= ammount;

            if (bloodComponent.ammount == 0)
                service.DeleteFromDatabase(bloodComponent);
            else
                service.UpdateOneFromDatabase(bloodComponent);

            comp.ammount = ammount;
            service.UpdateOneFromDatabase(comp);
            Refresh();
        }
    }
    #endregion

}

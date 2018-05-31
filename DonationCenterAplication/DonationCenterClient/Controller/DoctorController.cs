
using Common.Exceptions;
using Common.Model;
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


namespace Controller
{
    /**
     * 
     */

    public class DoctorController
    {

        public Doctor doctor { get; set; }
        public IService service { get; set; }

        public DoctorController(IService service, Doctor doctor)
        {
            this.service = service;
            this.doctor = doctor;
        }

        public void refresh()
        {
            doctor = this.service.GetOneFromDatabase<Doctor>(this.doctor.id);
        }

        /*
         * Returns a set with all the pacients based on the doctor's requests 
         * (All the pacientNames from the requests)
         */ 

        public HashSet<string> getPacients()
        {
            return new HashSet<string>(doctor.requests.Select(x => x.pacientName).ToList());
        }

        public double getDistanceFromDoctor(DonationCenter don)
        {
            don.setLatLon();
            double exp1 = don.lat - doctor.location.latitude;
            double exp2 = don.lon - doctor.location.longitude;

            return Math.Sqrt(Math.Pow(exp1, 2) - Math.Pow(exp2, 2));
        }

  


        public List<Tuple<string, double, string>> getBestRequest(string pacientName, string component, string type = null, bool rh = false, float ammount = 0)
        {
            List<DonationCenter> donList = service.GetAllFromDatabase<DonationCenter>().ToList();
            
            List<Tuple<string, double, string>> returnList = new List<Tuple<string, double, string>>();
            
            double gatheredAmmount = 0.0f;
            double localAmmount = 0.0f;

            switch (component)
            {
                case "Plasma":
                    {

                        List<DonationCenter> sortedList = donList.ToList()
                                .OrderByDescending(x => x.plasmaList
                                        .Where(plasma => plasma.antibody == type)
                                        .Select(y => y.ammount)
                                        .Sum() - getDistanceFromDoctor(x))
                                        .ToList();


                        foreach (DonationCenter donationCenter in sortedList)
                        {

                            localAmmount = 0.0f;

                            localAmmount += donationCenter.plasmaList
                                .Where(plasma => plasma.antibody == type && plasma.donatedFor == pacientName)
                                .Select(plasma => plasma.ammount)
                                .Sum();

                            gatheredAmmount += localAmmount;

                            if (gatheredAmmount >= ammount)
                            {
                                returnList.Add(Tuple.Create(donationCenter.name, Math.Abs(ammount - (gatheredAmmount - localAmmount)), donationCenter.id));
                                return returnList;
                            }

                            returnList.Add(Tuple.Create(donationCenter.name, localAmmount, donationCenter.id));

                        }

                        foreach (DonationCenter donationCenter in sortedList)
                        {

                            localAmmount = 0.0f;

                            localAmmount += donationCenter.plasmaList
                                .Where(plasma => plasma.antibody == type && plasma.donatedFor != pacientName)
                                .Select(plasma => plasma.ammount)
                                .Sum();

                            gatheredAmmount += localAmmount;

                            if (gatheredAmmount >= ammount)
                            {
                                returnList.Add(Tuple.Create(donationCenter.name, Math.Abs(ammount - (gatheredAmmount - localAmmount)), donationCenter.id));
                                return returnList;
                            }

                            returnList.Add(Tuple.Create(donationCenter.name, localAmmount, donationCenter.id));

                        }
                        break;
                    }

                case "Red":
                    {

                        List<DonationCenter> sortedList = donList.ToList()
                           .OrderByDescending(x => x.redBloodCellList
                                .Where(red => red.antigen == type && red.rh == rh)
                                .Select(y => y.ammount)
                                .Sum() - getDistanceFromDoctor(x))
                                .ToList();

                        foreach (DonationCenter donationCenter in sortedList)
                        {

                            localAmmount = 0.0f;

                            localAmmount += donationCenter.redBloodCellList
                              .Where(red => red.antigen == type && red.rh == rh && red.donatedFor == pacientName)
                              .Select(plasma => plasma.ammount)
                              .Sum();

                            gatheredAmmount += localAmmount;

                            if (gatheredAmmount >= ammount)
                            {
                                returnList.Add(Tuple.Create(donationCenter.name, Math.Abs(ammount - (gatheredAmmount - localAmmount)), donationCenter.id));
                                return returnList;
                            }

                            returnList.Add(Tuple.Create(donationCenter.name, localAmmount, donationCenter.id));

                        }

                        foreach (DonationCenter donationCenter in sortedList)
                        {

                            localAmmount = 0.0f;

                            localAmmount += donationCenter.redBloodCellList
                                .Where(red => red.antigen == type && red.rh == rh && red.donatedFor != pacientName)
                                .Select(plasma => plasma.ammount)
                                .Sum();

                            gatheredAmmount += localAmmount;

                            if (gatheredAmmount >= ammount)
                            {
                                returnList.Add(Tuple.Create(donationCenter.name, Math.Abs(ammount - (gatheredAmmount - localAmmount)), donationCenter.id));
                                return returnList;
                            }

                            returnList.Add(Tuple.Create(donationCenter.name, localAmmount, donationCenter.id));
                        }
                        break;
                    }
                case "Tromb":
                    {

                        List<DonationCenter> sortedList = donList.ToList()
                           .OrderByDescending(x => x.redBloodCellList
                                .Select(y => y.ammount)
                                .Sum() - getDistanceFromDoctor(x))
                                .ToList();

                        foreach (DonationCenter donationCenter in sortedList) 
                        {

                            localAmmount = 0.0f;

                            localAmmount += donationCenter.trombocyteList
                                .Where(tromb => tromb.donatedFor == pacientName)
                                .Select(tromb => tromb.ammount)
                                .Sum();

                            gatheredAmmount += localAmmount;

                            if (gatheredAmmount >= ammount)
                            {
                                returnList.Add(Tuple.Create(donationCenter.name, Math.Abs(ammount - (gatheredAmmount - localAmmount)), donationCenter.id));
                                return returnList;
                            }

                            returnList.Add(Tuple.Create(donationCenter.name, localAmmount, donationCenter.id));
                        }

                        foreach (DonationCenter donationCenter in sortedList)
                        {

                            localAmmount = 0.0f;

                            localAmmount += donationCenter.trombocyteList
                                .Where(tromb => tromb.donatedFor != pacientName)
                                .Select(tromb => tromb.ammount)
                                .Sum();

                            gatheredAmmount += localAmmount;

                            if (gatheredAmmount >= ammount)
                            {
                                returnList.Add(Tuple.Create(donationCenter.name, Math.Abs(ammount - (gatheredAmmount - localAmmount)), donationCenter.id));
                                return returnList;
                            }

                            returnList.Add(Tuple.Create(donationCenter.name, localAmmount, donationCenter.id));
                        }
                        break;
                    }
            }
            return returnList;

        }

        public Tuple<double, double, double> getAvailableBloodForPacient(string pacientName, string donationCenterId)
        {
            try
            {
                DonationCenter don = service.GetOneFromDatabase<DonationCenter>(donationCenterId);

                List<DoctorRequest> req = doctor.requests.Where(x => x.pacientName == pacientName && x.donationCenter_id == don.id).ToList();

                double trombQ = 0.0;
                double plasmaQ = 0.0;
                double redQ = 0.0;


                req.ForEach(r => {

                    string[] splitRequest = r.requestString.Split(',');

                    if (splitRequest[0] == "Plasma")
                    {


                        plasmaQ += don.plasmaList
                            .Where(x => x.donatedFor == null)
                            .Where(x => x.antibody == splitRequest[1])
                            .Select(x => x.ammount)
                            .Sum();

                        /*
                        plasmaQ += doctor.plasmaList
                           .Where(x => x.antibody == splitRequest[1])
                           .Select(x => x.ammount)
                           .Sum();
                           */
                    }

                    if (splitRequest[0] == "Red")
                    {

                        redQ += don.redBloodCellList
                            .Where(x => x.donatedFor == null)
                            .Where(x => x.antigen == splitRequest[1] && x.rh == bool.Parse(splitRequest[2]))
                            .Select(x => x.ammount)
                            .Sum();

                        /*
                        redQ += doctor.redBloodCellList
                            .Where(x => x.antigen == splitRequest[1] && x.rh == bool.Parse(splitRequest[2]))
                            .Select(x => x.ammount)
                            .Sum();
                            */
                    }

                    if (splitRequest[0] == "Tromb")
                    {

                        trombQ += don.trombocyteList
                            .Where(x => x.donatedFor == null)
                            .Select(x => x.ammount)
                            .Sum();

                        /*
                        trombQ += doctor.trombocyteList
                           .Select(x => x.ammount)
                           .Sum();
                           */
                    }

                });


                return new Tuple<double, double, double>(trombQ, plasmaQ, redQ);


            }
            catch (RemotingException rmE)
            {
                throw new ControllerException("getBloodDonatedForPacient", rmE);
            }
        }

        



        /*
         * Returns a tuple with all the components donated for the pacient at the donation centersecified
         *  item1 - tromb
         *  item2 - plasma
         *  item3 - red
         *  
         *  Blood components have a field called "donated for" which is used for this method 
         */
        public Tuple<double, double, double> getBloodDonatedForPacient(string pacientName, string donationCenterId)
        {
            try
            {
                DonationCenter don = service.GetOneFromDatabase<DonationCenter>(donationCenterId);

                double trombQ = 0.0;
                double plasmaQ = 0.0;
                double redQ = 0.0;

                
                plasmaQ += don.plasmaList
                    .Where(x => x.donatedFor == pacientName)
                    .Select(x => x.ammount)
                    .Sum();

                redQ += don.redBloodCellList
                    .Where(x => x.donatedFor == pacientName)
                    .Select(x => x.ammount)
                    .Sum();

                trombQ += don.trombocyteList
                    .Where(x => x.donatedFor == pacientName)
                    .Select(x => x.ammount)
                    .Sum();

                

                plasmaQ += doctor.plasmaList
                    .Where(x => x.donatedFor == pacientName)
                    .Select(x => x.ammount)
                    .Sum();

                redQ += doctor.redBloodCellList
                        .Where(x => x.donatedFor == pacientName)
                        .Select(x => x.ammount)
                        .Sum();

                trombQ += doctor.trombocyteList
                    .Where(x => x.donatedFor == pacientName)
                    .Select(x => x.ammount)
                    .Sum();



                return new Tuple<double, double, double>(trombQ, plasmaQ, redQ);


            }
            catch (RemotingException rmE)
            {
                throw new ControllerException("getBloodDonatedForPacient", rmE);
            }
        }

        /*
         * Returns a tuple with all the components donated for the pacient
         *  item1 - tromb
         *  item2 - plasma
         *  item3 - red
         */
        public Tuple<double, double, double> getRequiredBloodForPacient(string pacientName)
        {
            try
            {

                double trombQ = 0.0;
                double plasmaQ = 0.0;
                double redQ = 0.0;


                List<DoctorRequest> filteredList = service.GetAllFromDatabase<DoctorRequest>()
                    .Where(x => x.pacientName == pacientName)
                    .ToList();

                trombQ = filteredList
                    .Select(x => x.requestString)
                    .Where(x => x.Split(',')[0] == "Tromb")
                    .Select(x => double.Parse(x.Split(',')[1]))
                    .Sum();

                redQ = filteredList
                    .Select(x => x.requestString)
                    .Where(x => x.Split(',')[0] == "Red")
                    .Select(x => double.Parse(x.Split(',')[3]))
                    .Sum();

                plasmaQ = filteredList
                    .Select(x => x.requestString)
                    .Where(x => x.Split(',')[0] == "Plasma")
                    .Select(x => double.Parse(x.Split(',')[2]))
                    .Sum();



                return new Tuple<double, double, double>(trombQ, plasmaQ, redQ);


            }
            catch (RemotingException rmE)
            {
                throw new ControllerException("getBloodDonatedForPacient", rmE);
            }
        }


        /*
         * Adds a new request to the database. If there allready exist a similar reques (Same component, same donation center, different ammounts, it will automatically merge them
         */ 
        #region Ladi

        public void deleteRequest(string pacientName)
        {
            foreach (var req in this.service.GetAllFromDatabase<DoctorRequest>()
                .Where(dr => dr.pacientName == pacientName))
            {
                this.service.DeleteFromDatabase(req);
            }
        }

        public void makeRequest(Location val, int priority, string patientName, string pacientName, string requestString, string donationCenterName)
        {
            bool foundRequest = false;
            string donationCenterLocation = val.latitude.ToString() + ',' + val.longitude.ToString();
            DoctorRequest req = new DoctorRequest
            {
                donationCenter_id = donationCenterLocation,
                priority = priority,
                doctor_name = doctor.name,
                pacientName = pacientName,
                requestString = requestString,
                doctor_id = doctor.id,
                hospital = doctor.hospital,
                donationCenterName = donationCenterName

            };
            List<string> requestSplitted = requestString.Split(',').ToList();

            IList<DoctorRequest> reqList = null;

            try
            {
                reqList = this.service.GetAllFromDatabase<DoctorRequest>();
            }
            catch (RemotingException)
            {
                service.AddToDatabase(req);
                return;
            }

            switch (requestSplitted[0])
            {
                case "Red":
                    {
                        foreach (var dbRequest in reqList)
                        {
                            if (dbRequest.donationCenter_id == donationCenterLocation && dbRequest.isBeeingDelivered == false)
                            {
                                List<string> dbRequestSplitted = dbRequest.requestString.Split(',').ToList();
                                if (dbRequestSplitted[0] == requestSplitted[0] && dbRequestSplitted[1] == requestSplitted[1] && dbRequestSplitted[2] == requestSplitted[2])
                                {
                                    string newRequestString = dbRequestSplitted[0] + ',' + dbRequestSplitted[1] + ',' + dbRequestSplitted[2] + ',';
                                    double amount = Convert.ToDouble(dbRequestSplitted[3]);
                                    amount += Convert.ToDouble(requestSplitted[3]);
                                    newRequestString += amount.ToString();
                                    dbRequest.requestString = newRequestString;
                                    foundRequest = true;
                                    try
                                    {
                                        this.service.UpdateOneFromDatabase(dbRequest);
                                    }
                                    catch (RemotingException rmE)
                                    {
                                        throw new ControllerException("An error has occured!", rmE);
                                    }
                                }
                            }
                        }
                        break;
                    }
                case "Plasma":
                    {
                        foreach (var dbRequest in reqList)
                        {
                            if (dbRequest.donationCenter_id == donationCenterLocation && dbRequest.isBeeingDelivered == false)
                            {
                                List<string> dbRequestSplitted = dbRequest.requestString.Split(',').ToList<string>();
                                if (dbRequestSplitted[0] == requestSplitted[0] && dbRequestSplitted[1] == requestSplitted[1])
                                {
                                    string newRequestString = dbRequestSplitted[0] + ',' + dbRequestSplitted[1] + ',';
                                    double amount = Convert.ToDouble(dbRequestSplitted[2]);
                                    amount += Convert.ToDouble(requestSplitted[2]);
                                    newRequestString += amount.ToString();
                                    dbRequest.requestString = newRequestString;
                                    foundRequest = true;
                                    try
                                    {
                                        this.service.UpdateOneFromDatabase(dbRequest);
                                    }
                                    catch (RemotingException rmE)
                                    {
                                        throw new ControllerException("An error has occured", rmE);
                                    }
                                }
                            }
                        }
                        break;
                    }
                case "Tromb":
                    {

                        foreach (var dbRequest in reqList)
                        {
                            if (dbRequest.donationCenter_id == donationCenterLocation && dbRequest.isBeeingDelivered == false)
                            {
                                List<string> dbRequestSplitted = dbRequest.requestString.Split(',').ToList<string>();
                                if (dbRequestSplitted[0] == requestSplitted[0])
                                {
                                    string newRequestString = dbRequestSplitted[0] + ',';
                                    double amount = Convert.ToDouble(dbRequestSplitted[1]);
                                    amount += Convert.ToDouble(requestSplitted[1]);
                                    newRequestString += amount.ToString();
                                    dbRequest.requestString = newRequestString;
                                    foundRequest = true;
                                    try
                                    {
                                        this.service.UpdateOneFromDatabase(dbRequest);
                                    }
                                    catch (RemotingException rmE)
                                    {
                                        throw new ControllerException("An error has occured!", rmE);
                                    }
                                }
                            }
                        }
                        break;
                    }
                default:
                    break;
            }
            if (foundRequest == false)
                this.service.AddToDatabase(req);

        }
        #endregion

        #region Biju
        /*
         * Returns a tuple with the blood component lists from a donationCenter
         */ 
        public Tuple<IList<Plasma>, IList<Trombocyte>, IList<RedBloodCell>> reviewBloodStocks(Location val)
        {
            try
            {
                return Tuple.Create(this.service.GetAllFromDatabase<Plasma>(),
                    this.service.GetAllFromDatabase<Trombocyte>(),
                    this.service.GetAllFromDatabase<RedBloodCell>());
            }
            catch (RemotingException rmE)
            {
                throw new ControllerException("An error has occured!", rmE);
            }
        }

        /*
         * Returns the component that matcher the request based on requestString
         * 
         * requestString
         *      Type,[Group][Rh],Quantity
         * 
         * Examples:
         *      requestString for RedBloodCells 
         *           "Red,A,true,100" 
         *           "Red,AB,false,200"
         *      
         *      requestString for Plasma 
         *           "Plasma,B,100" 
         *           "Plasma,0,200"
         *       
         *       requestString for Trombocytes
         *           "Tromb,100"
         *           "Tromb,200"
         */
        public BloodComponent matchBloodWithRequest(DoctorRequest docReq)
        {
            string[] reqInfo = docReq.requestString.Split(',');
            if(reqInfo[0] == "Red")
            {

                foreach(var bloodCell in this.doctor.redBloodCellList)
                {
                    if(bloodCell.antigen == reqInfo[1] && bloodCell.rh == bool.Parse(reqInfo[2]) 
                        && bloodCell.ammount == float.Parse(reqInfo[3]))
                    {
                        return bloodCell;
                    }
                }
            }
            if(reqInfo[0] == "Tromb")
            {
                foreach (var trombocyte in this.doctor.trombocyteList)
                {
                    if (trombocyte.ammount == float.Parse(reqInfo[1]))
                    {
                        return trombocyte;
                    }
                }
            }
            if (reqInfo[0] == "Plasma")
            {
                foreach (var plasma in this.doctor.plasmaList)
                {
                    if (plasma.antibody == reqInfo[1] && plasma.ammount == float.Parse(reqInfo[2]))
                    {
                        return plasma;
                    }
                }
            }

            return null;
        }

        /*
         * This one is a bit tricky
         * 
         * If the doctor accepts the blood
         *      then it and the request are removed from the database
         * else 
         *      The way blood delivery works:
         *          donationCenter_Id from the component is set to null 
         *          doctor_Id is set to request.doctor_Id
         *          request.isBeeingDelivered is set to true
         *          
         *      That way, the component no longer appears in the donation center gui (beeing delivered)
         *      and can be added back if the doctor refuses it
         */
        public void acceptBlood<T>(DoctorRequest request, T component, bool bloodIsOk) where T : BloodComponent
        {
            if (bloodIsOk)
            {
                try
                {
                    service.DeleteFromDatabase(component);
                    service.DeleteFromDatabase(request);
                }
                catch (RemotingException rmE)
                {
                    throw new ControllerException("An error has occured!", rmE);
                }
            }
            else
            {
                try
                {
                    component.doctor_id = null;
                    component.donationCenter_id = request.donationCenter_id;
                    service.UpdateOneFromDatabase(component);

                    request.isBeeingDelivered = false;
                    service.UpdateOneFromDatabase(request);
                }
                catch (RemotingException rmE)
                {
                    throw new ControllerException("An error has occured", rmE);
                }
            }
        }
        #endregion



        public void deleteRequest(DoctorRequest req)
        {
            if (req.isBeeingDelivered)
                throw new ControllerException("A request while that is beeing delivered cannot delete");

            try
            {
                service.DeleteFromDatabase(req);
            }
            catch (Exception)
            {
                throw new ControllerException("No selected item");
            }
        }

        public void deleteAllRequests(DoctorRequest req)
        {

            if (req.isBeeingDelivered)
                throw new ControllerException("A request while that is beeing delivered cannot delete");

            try
            {
                doctor.requests.Where(x => x.pacientName == req.pacientName && x.isBeeingDelivered == false)
                .ToList()
                .ForEach(x => service.DeleteFromDatabase(x));

            }
            catch (Exception)
            {
                throw new ControllerException("No selected item");
            }
        }

        public void sortRequests()
        {
            doctor.requests = doctor.requests.OrderBy(x => x.isBeeingDelivered).ToList();
        }


    }
}

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

        public Doctor doctor;
        public IService service;

        public DoctorController(IService service, Doctor doctor)
        {
            this.service = service;
            this.doctor = doctor;
        }


        #region Ladi
        public void makeRequest(Location val, int priority, string patientCNP, string requestString)
        {
            bool foundRequest = false;
            string donationCenterLocation = val.latitude.ToString() + ',' + val.longitude.ToString();
            DoctorRequest req = new DoctorRequest
            {
                donationCenter_id = donationCenterLocation,
                priority = priority,
                doctor_name = doctor.name,
                patientCnp = patientCNP,
                requestString = requestString,
                doctor_id = doctor.id,
                hospital = doctor.hospital

            };
            List<string> requestSplitted = requestString.Split(',').ToList<string>();

            switch (requestSplitted[0])
            {
                case "Red":
                    {
                        foreach (var dbRequest in this.service.GetAllFromDatabase<DoctorRequest>())
                        {
                            if (dbRequest.donationCenter_id == donationCenterLocation && dbRequest.isBeeingDelivered == false)
                            {
                                List<string> dbRequestSplitted = dbRequest.requestString.Split(',').ToList<string>();
                                if (dbRequestSplitted[0] == requestSplitted[0] && dbRequestSplitted[1] == requestSplitted[1] && dbRequestSplitted[2] == requestSplitted[2])
                                {
                                    string newRequestString = dbRequestSplitted[0] + ',' + dbRequestSplitted[1] + ',' + dbRequestSplitted[2] + ',';
                                    double amount = Convert.ToDouble(dbRequestSplitted[3]);
                                    amount += Convert.ToDouble(requestSplitted[3]);
                                    newRequestString += amount.ToString();
                                    dbRequest.requestString = newRequestString;
                                    foundRequest = true;
                                    this.service.UpdateOneFromDatabase(dbRequest);
                                }
                            }
                        }
                        break;
                    }
                case "Plasma":
                    {
                        foreach (var dbRequest in this.service.GetAllFromDatabase<DoctorRequest>())
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
                                    this.service.UpdateOneFromDatabase(dbRequest);
                                }
                            }
                        }
                        break;
                    }
                case "Tromb":
                    {

                        foreach (var dbRequest in this.service.GetAllFromDatabase<DoctorRequest>())
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
                                    this.service.UpdateOneFromDatabase(dbRequest);
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
        public Tuple<IList<Plasma>, IList<Trombocyte>, IList<RedBloodCell>> reviewBloodStocks(Location val)
        {
            return Tuple.Create( this.service.GetAllFromDatabase<Plasma>(),
                this.service.GetAllFromDatabase<Trombocyte>(),
                this.service.GetAllFromDatabase<RedBloodCell>());
            
        }
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


        public void acceptBlood<T>(DoctorRequest request, T component, bool bloodIsOk) where T : BloodComponent
        {//TODO functie care sa dea valoare lui bloodisok din gui
            if (bloodIsOk)
            {
                service.DeleteFromDatabase(component);
                service.DeleteFromDatabase(request);
            }
            else
            {
                component.doctor_id = null;
                request.isBeeingDelivered = false;
            }
        }
        #endregion

        #region setters
        public void setDoctorName(string name)
        {
            doctor.name = name;
        }

        /**
         * @param newVal
         */
        public void setDoctorSpeciality(string newVal)
        {
            doctor.speciality = newVal;
        }

        /**
         * @param newVal
         */
        public void setHospita(string newVal)
        {
            doctor.hospital = newVal;
        }
        #endregion

    }
}
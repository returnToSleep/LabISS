
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

        /**
         * 
         */

        private IService service;

        public DoctorController(Doctor doctor)
        {
            this.doctor = doctor;
        }

        /**
         * 
         */
        public Doctor doctor;

        public void Refresh()
        {
            refreshBloodStock();
            doctor = this.service.GetAllFromDatabase<Doctor>().Where(d => d.id == doctor.id).FirstOrDefault();
        }

        public void refreshBloodStock()
        {
            removeFromList(this.doctor.redBloodCellList);
            removeFromList(this.doctor.trombocyteList);
            removeFromList(this.doctor.plasmaList);
            service.Refresh(doctor);
        }

        /**
         * Function that removes the expired blood components
         */
        private void removeFromList<T>(IList<T> l) where T : BloodComponent
        {

            if (l == null) { return; }

            foreach (T bloodCompoenent in l)
            {
                if (DateTime.Compare(bloodCompoenent.getExpirationDate(), DateTime.Now) <= 0)
                {
                    service.DeleteFromDatabase(bloodCompoenent);
                }
            }

        }

        /**
         * @param val 
         * @return
         */
        public void makeRequest(Location val, int priority, string patientName, string patientCNP, string requestString)
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

        /**
         * @return
         */
        public void notifyDonors()
        {
            // TODO send mail 
            // TODO implement here
            return;
        }

        /**
         * @param val 
         * @return
         */
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
                    if(bloodCell.antigen == reqInfo[1] && bloodCell.rh == reqInfo[2]
                        && bloodCell.ammount == float.Parse(reqInfo[3]))
                    {
                        return bloodCell;
                    }
                }
            }
            else if(reqInfo[0] == "Tromb")
            {
                foreach (var trombocyte in this.doctor.trombocyteList)
                {
                    if (trombocyte.ammount == float.Parse(reqInfo[1]))
                    {
                        return trombocyte;
                    }
                }
            }
            else
            {
                foreach (var plasma in this.doctor.plasmaList)
                {
                    if (plasma.antibody == reqInfo[1] && plasma.ammount == float.Parse(reqInfo[2]))
                    {
                        return plasma;
                    }
                }
            }
        }
        public T acceptBlood<T>(T component)
        {//TODO functie care sa dea valoare lui bloodisok din gui
            if (bloodIsOk)
            {
                this.service.DeleteFromDatabase(component);
            }
            else
            {
                component.doctor_id = null;
                component.isBeeingDeliverd = false;
            }
        }

       
        /**
         * @param name
         */
        public void setDoctorName(String name)
        {
            doctor.name = name;
        }

        /**
         * @param newVal
         */
        public void setDoctorSpeciality(String newVal)
        {
            doctor.speciality = newVal;
        }

        /**
         * @param newVal
         */
        public void setHospita(String newVal)
        {
            doctor.hospital = newVal;
        }

    }
}

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

        public DoctorController()
        {
            ChannelServices.RegisterChannel(new TcpClientChannel(), false);
            service = (IService)(Activator.GetObject(typeof(IService),
                "tcp://localhost:9999/IService"
                ));
        }

        /**
         * 
         */
        private Doctor doctor;


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
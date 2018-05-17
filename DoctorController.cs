
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
        public void makeRequest(Location val, int priority, string patientName, string requestString)
        {
            DoctorRequest req = new DoctorRequest(doctor.id, val.latitude.ToString() + ',' + val.longitude.ToString(), priority, patientName, requestString);
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
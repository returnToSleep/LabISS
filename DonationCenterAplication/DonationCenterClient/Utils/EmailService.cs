using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Common.Model;

namespace Client.Utils
{
    class EmailService
    {

        public EmailService()
        {
        }

        public static void sendMail(string fromName, string toAddress, string subject, string body)
        {


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(new MailAddress("donation.center0100@gmail.com", fromName).Address, "Parola123*")
            };
            

            var message = new MailMessage("donation.center0100@gmail.com", toAddress, subject, body);

            smtp.Send(message);
        }

        public static void sendCreateMesage(string toAddress, LogInfo log)
        {
            string subject = "Contul dumneavoastra a fost creeat!";

            string body = "Buna ziua!" + "\n\n\n"
                    + "Multumim ca ati ales aplicatia noastra\n"
                    + "Utilizator: " + log.username + "\n"
                    + "Parola: " + log.password;


            sendMail("Blood donation", toAddress, subject, body);
        }
    
        public static void sendBloodDispatchingMail(string toAddress, DoctorRequest req)
        {
            string subject = "Sangele donat de catre dumneavoastra a fost trimis catre un spital!";

            string body = "Buna ziua!" + "\n\n\n"
                    + "Va aducem la cunostinta faptul ca sangele donat de dumneavoastra\n"
                    + "urmeaza sa fie livrat catre spitalul " + req.hospital
                    + "pentru pacientul " + req.pacientName + ".\n"
                    + "Multumim pentru inca o data pentru donatie si pentru ca ati ajutat la salvarea unui pacient.\n"
                    + "\n\n"
                    + "Cu respect,"
                    + req.donationCenterName;

            sendMail(req.donationCenterName, toAddress, subject, body);               

        }

        public static void sendNotEnoughtBloodMail(Donor don, DoctorRequest req)
        {
            string subject = "Avem nevoie de ajutorul dumneavoastra!";

            string missMister1 = don.cnp[0] == '1' ? "Stimate domn " : "Stimata doamna ";
            string missMister = don.cnp[0] == '1' ? "determiat a fi compatibil" : "determinata a fi compatibila";

            string body = missMister1 + don.name + ",\n\n\n"
                    + "Pacientrul " + req.pacientName + " are mare nevoie de ajutorul dumneavoastra.\n"
                    + "Din nefericire nu avem sangele necesar in stoc iar dumneavostra ati fost " + missMister + ".\n"
                    + "Am aprecia enorm daca ati putea sa va faceti timp pentru o donatie.\n"
                    + "Multumim si ne cerem scuze pentru deranj."
                    + "\n\n"
                    + "Cu respect, "
                    + req.donationCenterName;
                   
            sendMail(req.donationCenterName, don.email, subject, body);

        }


    }
}

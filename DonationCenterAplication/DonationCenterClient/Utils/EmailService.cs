using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using Common.Model;
using System.Net.Mime;
using System.IO;

namespace Client.Utils
{
    class EmailService
    {

        public EmailService(){}

        public static void sendMail(string fromName, string toAddress, string subject, string body, List<string> attachements = null)
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

            if (attachements != null)
            {

                attachements.ForEach(fileName =>
                {

                    Attachment attachment = new Attachment(fileName, MediaTypeNames.Application.Octet);
                    ContentDisposition disposition = attachment.ContentDisposition;
                    disposition.CreationDate = File.GetCreationTime(fileName);
                    disposition.ModificationDate = File.GetLastWriteTime(fileName);
                    disposition.ReadDate = File.GetLastAccessTime(fileName);
                    disposition.FileName = Path.GetFileName(fileName);
                    disposition.Size = new FileInfo(fileName).Length;
                    disposition.DispositionType = DispositionTypeNames.Attachment;
                    message.Attachments.Add(attachment);

                });
            }
            smtp.Send(message);
        }

        public static void sendCreateMesage(string toAddress, LogInfo log)
        {
            string subject = "Your account has been created!";

            string body = "Hello!" + "\n\n\n"
                    + "Thank you for using our application\n"
                    + "User: " + log.username + "\n"
                    + "Password: " + log.password;


            sendMail("Blood donation", toAddress, subject, body);
        }
    
        public static void sendBloodDispatchingMail(string toAddress, DoctorRequest req)
        {
            string subject = "Some of the blood you have donated has been sent to a hospital!";

            string body = "Good day!" + "\n\n\n"
                    + "We would like to inform you that part of the blood you have donated\n"
                    + "is beeing delivered to " + req.hospital + " hospital"
                    + "for the pacient " + req.pacientName + ".\n"
                    + "Thank you again for your donation and for aiding in the recovery of a pacient.\n"
                    + "\n\n"
                    + "Respectfully,"
                    + req.donationCenterName;

            sendMail(req.donationCenterName, toAddress, subject, body);               

        }

        public static void sendNotEnoughtBloodMail(Donor don, DoctorRequest req)
        {
            string subject = "Someone needs your help!";

            string missMister1 = don.cnp[0] == '1' ? "Dear mister " : "Dear miss ";
        
            string body = missMister1 + don.name + ",\n\n\n"
                    +  req.pacientName + " has hospitalized at the " + req.hospital + " hospital and is in great need of your help.\n"
                    + "Unfortunately, we do not have the necessary ammount on stock and you have been determined to be compatible.\n"
                    + "We would appreciate enormly if you could make some time for a donation.\n"
                    + "Thank you."
                    + "\n\n"
                    + "Respectfully, "
                    + req.donationCenterName;
                   
            sendMail(req.donationCenterName, don.email, subject, body);

        }


    }
}

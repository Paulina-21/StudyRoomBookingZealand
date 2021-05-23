using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace StudyroomBookingZealand.Data.Helpers
{
    public class EmailHelper
    {
        public static void SendEmail(List<string> receivers, string subject, string content)
        {
            var builder = new ConfigurationBuilder()  // I guess it loads the SMTP email variables from the appsettings
                .AddJsonFile("appsettings.json");
            var config = builder.Build();

            var smtpClient = new SmtpClient(config["Smtp:Host"])  //parses the variables to the code 
            {
                Port = int.Parse(config["Smtp:Port"]),
                Credentials = new NetworkCredential(config["Smtp:Username"], config["Smtp:Password"]),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage //Supports html, you can make cool stuff with it. The variables should be pretty explanatory to what they do
            {
                From = new MailAddress("zealandbookingsystem@gmail.com"),
                Subject = subject,
                Body = content,
                IsBodyHtml = true,
            };

            foreach (string r in receivers)
            {
                mailMessage.To.Add(r); // You can add addresses like a list mailMessage.To.Add("pedro_mrmr@hotmail.com"); mailMessage.To.Add("radu@hotmail.com"); etc etc.....
            }
            smtpClient.Send(mailMessage);//Sends it 
        }
        public static List<string> GatherEmails(List<Models.User> users)
        {
            List<string> list = new List<string>();
            foreach(Models.User u in users)
            {
                list.Add(u.Email);
            }
            return list;
        }
    }
}

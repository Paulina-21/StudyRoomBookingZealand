using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Pages.User;
using StudyroomBookingZealand.Services.EFServices;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.Bookings
{
    public class DeleteBookingModel : PageModel
    {
        private IBooking _bookingService;
        [BindProperty(SupportsGet = true)]
        public Booking booking { set; get; }

        public DeleteBookingModel(IBooking _bokSer)
        {
            _bookingService = _bokSer;
        }

        public IActionResult OnGet(int id)
        {
            booking = _bookingService.GetBookingById(id);
            if(CurrentUser.LoggedUser==null || (!(CurrentUser.LoggedUser.IsTeacher == true || CurrentUser.LoggedUser.GroupId == booking.Student_GroupID)))
            {
                return Redirect("/Unauthorized");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
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
                Subject = "Amogus",
                Body = "<h1>Amogus</h1>",
                IsBodyHtml = true,
            };
    
            mailMessage.To.Add("pedro_mrmr@hotmail.com"); // You can add addresses like a list mailMessage.To.Add("pedro_mrmr@hotmail.com"); mailMessage.To.Add("radu@hotmail.com"); etc etc.....
             
            smtpClient.Send(mailMessage);//Sends it 




            //Async programming piece of code. It creates a new task that will be executed in 72 hours. In this case it will delete a booking in 3 days.
            // Fixed by changing method to async
            await Task.Delay(new TimeSpan(0, 0, 1)).ContinueWith(o => { _bookingService.DeleteBooking(id); });
            
            return Redirect("/Bookings/ListBookings");
        }
    }
}

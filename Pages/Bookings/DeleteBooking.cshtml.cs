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
            List<string> receivers = Data.Helpers.EmailHelper.GatherEmails(_bookingService.BookingOwners(id));
            string subject = "My back aches";
            string content = "<h1>Free robux down below!!<h1>";
            Data.Helpers.EmailHelper.SendEmail(receivers, subject, content);

            //Async programming piece of code. It creates a new task that will be executed in 72 hours. In this case it will delete a booking in 3 days.
            // Fixed by changing method to async
            await Task.Delay(new TimeSpan(72, 0, 0)).ContinueWith(o => { _bookingService.DeleteBooking(id); });
            return Redirect("/Bookings/ListBookings");
        }
    }
}

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
        private IWarning _warningService;
        [BindProperty(SupportsGet = true)]
        public Booking booking { set; get; }

        public DeleteBookingModel(IBooking _bokSer, IWarning _warnSer)
        {
            _warningService = _warnSer;
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
            if(CurrentUser.IsAdmin) //It will only send an email if the user is admin
            {
                List<string> receivers = Data.Helpers.EmailHelper.GatherEmails(_bookingService.BookingOwners(id));
                string subject = "Warning - Your booked room will be deleted in 3 days";
                string content = $"<h1>Your booking on {_bookingService.GetBookingById(id).FromDateTime} will be deleted in 3 days </h1>" +
                                 $"<a> Due to an unforeseen circumstance, your booking will be removed in 3 days by an Administrator, we are sorry for the inconvenience </a>";

                List<Models.User> bookingMembers = _bookingService.BookingOwners(id);

                foreach (var user in bookingMembers)
                {
                    string Content = $"Your booking on {_bookingService.GetBookingById(id).FromDateTime} will be deleted in 3 days";
                    _bookingService.GetBookingById(id).Active = false;
                    _bookingService.UpdateBooking(_bookingService.GetBookingById(id));
                    _warningService.AddWarning(Shared.WarningsHelperModel.CreateWarning(Content, user.Id, Warning.TypeList.DeletedBooking));
                }

                Data.Helpers.EmailHelper.SendEmail(receivers, subject, content);

                //Async programming piece of code. It creates a new task that will be executed in 72 hours. In this case it will delete a booking in 3 days.
                // Fixed by changing method to async
                await Task.Delay(new TimeSpan(0, 0, 1)).ContinueWith(o =>
            {
                _bookingService.DeleteBooking(id);
            });
            return Redirect("/Admin/ListBookings");
            }
            
                _bookingService.DeleteBooking(id);
                return Redirect("/Index");
            
        }
    }
}

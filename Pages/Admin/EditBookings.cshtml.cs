using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Pages.User;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.Admin
{
    public class EditBookingsModel : PageModel
    {
        private IBooking _bookingService;
        public Booking Booking { get; set; }
        public EditBookingsModel(IBooking booking)
        {
            _bookingService = booking;
        }
        public IActionResult OnGet(int id)
        {
            if (CurrentUser.LoggedUser == null || (!(CurrentUser.LoggedUser.IsTeacher == true || CurrentUser.LoggedUser.GroupId == Booking.Student_GroupID)))
            {
                return Redirect("/Unauthorized");
            }
            Booking = _bookingService.GetBookingById(id);
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _bookingService.UpdateBooking(Booking);
            return Redirect("/Admin/ListBookings");
        }
    }
}

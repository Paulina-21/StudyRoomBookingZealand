using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
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

        public IActionResult OnPost(int id)
        {
            _bookingService.DeleteBooking(id);
            return Redirect("/Bookings/ListBookings");
        }
    }
}

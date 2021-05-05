using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.Bookings
{
    public class ListBookingsModel : PageModel
    {
        private IBooking _bookingService;
        private ILocations _locationsService;
        public List<Booking> Bookings { get; set; }

        public ListBookingsModel(IBooking service,ILocations loc)
        {
            _bookingService = service;
            _locationsService = loc;
        }
        public IActionResult OnGet(int id)
        {
            if (id==0)
            {
                Bookings = _bookingService.GetAllBookings();
            }
            else
            {
                Bookings = _locationsService.GetBookingsForLocation(id);
            }

            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.Admin
{
    public class ListBookingsModel : PageModel
    {
        private IBooking _bookingService;

        [BindProperty(SupportsGet = true)]
        
        public string SearchCriteria { get; set; }
        public List<Booking> Bookings { get; set; }
        

        public ListBookingsModel(IBooking booking)
        {
            _bookingService = booking;
        }
        public IActionResult OnGet()
        {
            if (String.IsNullOrEmpty(SearchCriteria))
            {
                Bookings = _bookingService.GetAllBookings();
            }
            else
            {
                Bookings = _bookingService.SearchByName(SearchCriteria);
            }

            return Page();
        }
        
    }
}

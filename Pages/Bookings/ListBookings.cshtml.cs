using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Pages.User;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.Bookings
{
    public class ListBookingsModel : PageModel
    {
        private IBooking _bookingService;
        private ILocations _locationsService;
        [BindProperty]
        public Location location { set; get; }
        public List<Booking> Bookings { get; set; }
        public Models.Group Group { get; set; }
        [BindProperty]
        public Models.User user { get; set; }

        public ListBookingsModel(IBooking service,ILocations loc)
        {
            _bookingService = service;
            _locationsService = loc;
        }
        public IActionResult OnGet(int id)
        {
            Bookings = _bookingService.GetAllBookings();
            //if (CurrentUser.LoggedUser != null)
            //{
            //    user = CurrentUser.LoggedUser;
            //}
                if(id>0)
            {
                location = _locationsService.GetLocation(id);
                location = _bookingService.LocationForBooking(id);
                Bookings = _locationsService.GetBookingsForLocation(location.LocationId);
            }

            return Page();
        }
    }
}

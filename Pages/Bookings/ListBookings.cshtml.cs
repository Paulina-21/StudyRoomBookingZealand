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
        public IRoom _roomService;
        [BindProperty]
        public Room Room { set; get; }
        public List<Booking> Bookings { get; set; }
        public Models.Group Group { get; set; }
        [BindProperty]
        public Models.User user { get; set; }

        public ListBookingsModel(IBooking service,ILocations loc,IRoom rom)
        {
            _bookingService = service;
            _locationsService = loc;
            _roomService = rom;
        }
        public IActionResult OnGet(int id)
        {
            if (CurrentUser.LoggedUser == null)
            {
                return Redirect("/Unauthorized");
            }
            else
            {
                Bookings = _bookingService.GetAllBookings();
                if (id > 0)
                {
                    Room = _bookingService.RoomForBooking(id);
                    Bookings = _roomService.GetBookingsForRoom(Room.RoomId);
                }

                return Page();
            }
            
        }
    }
}

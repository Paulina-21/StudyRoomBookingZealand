using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.Bookings
{
    public class SelectTimeModel : PageModel
    {
        private IBooking BookService;
        private IRoom RoomService;
        public SelectTimeModel(IBooking bservice, IRoom rservice)
        {
            BookService = bservice;
            RoomService = rservice;
        }
        public static int SelectedRoom;
        [BindProperty]
        public DateTime FromTime { get; set; }
        [BindProperty]
        public DateTime ToTime { get; set; }
        public IActionResult OnGet(int id)
        {
            SelectedRoom = id;
            return Page();
        }
    }
}

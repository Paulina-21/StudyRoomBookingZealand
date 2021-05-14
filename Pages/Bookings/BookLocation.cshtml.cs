using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Pages.User;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.Bookings
{
    public class BookLocationModel : PageModel
    {
        private IBooking _BookService;
        private ILocations _LocService;
        public List<Location> Locations { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }

        public BookLocationModel(IBooking book, ILocations loc)
        {
            _BookService = book;
            _LocService = loc;
        }

        public IActionResult OnGet()
        {
            if (CurrentUser.LoggedUser == null)
            {
                return RedirectToPage("/Unauthorized");
            }
            else
            {
                if (CurrentUser.LoggedUser.IsTeacher || CurrentUser.LoggedUser.GroupId != 0)
                {
                    Locations = _LocService.GetAllLocations();
                }
            }
                return Page();
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}

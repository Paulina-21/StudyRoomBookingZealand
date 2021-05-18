using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Pages.User;

namespace StudyroomBookingZealand.Pages.Admin
{
    public class AdminModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (CurrentUser.LoggedUser == null || CurrentUser.LoggedUser.IsTeacher == false)
            {
                return Redirect("/Unauthorized");
            }

            return Page();
        }

        public IActionResult OnPostManageUsers()
        {
            return null;
        }

        public IActionResult OnPostManageRooms()
        {
            return Redirect("/Admin/ListRooms");
        }

        public IActionResult OnPostManageLocations()
        {
            return Redirect("/Admin/ListLocations");;
        }

        public IActionResult OnPostManageBookings()
        {
            return Redirect("/Admin/ListBookings");
        }
    }
}

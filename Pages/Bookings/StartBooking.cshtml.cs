using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Pages.User;

namespace StudyroomBookingZealand.Pages.Bookings
{
    public class StartBookingModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (CurrentUser.LoggedUser == null)
            {
                return RedirectToPage("/User/Login");
            }
            else
            {
                if (CurrentUser.LoggedUser.IsTeacher == true)
                {
                    return RedirectToPage("Unauthorized");
                }
                else
                {
                    return Page();
                }
            }
        }
    }
}

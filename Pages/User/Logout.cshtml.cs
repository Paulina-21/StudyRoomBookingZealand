using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudyroomBookingZealand.Pages.User
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            CurrentUser.Logout();
            return Redirect("/Index");
        }
    }
}

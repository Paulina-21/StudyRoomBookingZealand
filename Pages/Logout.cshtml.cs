using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudyroomBookingZealand.Pages.Shared
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            //Clear the session and redirect to Index
            return Redirect("/Index");
        }
    }
}
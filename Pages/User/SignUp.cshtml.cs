using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudyroomBookingZealand.Pages.User
{
    public class CreateUserModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}

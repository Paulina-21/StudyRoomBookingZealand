using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudyroomBookingZealand.Pages.Shared
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public bool RememberMe { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Services.Interfaces;


namespace StudyroomBookingZealand.Pages.Admin
{
    public class CreateAccountModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}

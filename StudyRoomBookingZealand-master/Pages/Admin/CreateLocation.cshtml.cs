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
    public class CreateLocationModel : PageModel
    {
        [BindProperty]
        public Location Location { get; set; }
        private ILocations _locationsService;

        public CreateLocationModel(ILocations service)
        {
            _locationsService = service;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _locationsService.AddLocation(Location);
            return Page();
        }
    }
}

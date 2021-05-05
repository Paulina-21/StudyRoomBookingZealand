using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.Locations
{
    public class ListLocationsModel : PageModel
    {

        private ILocations _locationService;

        public List<Location> Locations { get; set; }

        public ListLocationsModel(ILocations service)
        {
            _locationService = service;
        }
        public IActionResult OnGet()
        {
            Locations = _locationService.GetAllLocations();
            return Page();
        }
    }
}

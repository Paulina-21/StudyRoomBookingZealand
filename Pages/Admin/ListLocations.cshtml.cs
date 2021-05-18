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
    public class ListLocationsModel : PageModel
    {
        private ILocations _locationService;
        [BindProperty(SupportsGet = true)]
        public String SearchCriteria { get; set; }
        public List<Location> Locations { get; set; }

        public ListLocationsModel(ILocations location)
        {
            _locationService = location;
        }
        public IActionResult OnGet()
        {
            if (String.IsNullOrEmpty(SearchCriteria))
            {
                Locations = _locationService.GetAllLocations();
            }
            else
            {
                Locations = _locationService.SearchByName(SearchCriteria);
            }

            return Page();
        }
    }
}

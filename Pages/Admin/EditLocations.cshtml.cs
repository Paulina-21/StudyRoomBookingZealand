using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Pages.User;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.Admin
{
    public class EditLocationsModel : PageModel
    {
        [BindProperty]
        public Location Location { get; set; }
        private ILocations _locationsService;
        
        public EditLocationsModel(ILocations location)
        {
            _locationsService = location;
        }
        public IActionResult OnGet(int id)
        {
            if (CurrentUser.LoggedUser == null || CurrentUser.LoggedUser.IsTeacher == false)
            {
                return Redirect("/Unauthorized");
            }
            Location = _locationsService.GetLocation(id);
            return Page();
            
        }

        public IActionResult OnPost()
        {
            
            _locationsService.UpdateLocation(Location);
            return Redirect("/Admin/ListLocations");
        }
    }
}

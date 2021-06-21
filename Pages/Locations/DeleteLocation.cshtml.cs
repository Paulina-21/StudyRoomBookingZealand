using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Pages.User;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.Locations
{
    public class DeleteLocationModel : PageModel
    {
        private ILocations _locationService;
        [BindProperty(SupportsGet = true)]
        public Location Location { set; get; }

        public DeleteLocationModel(ILocations _bokSer)
        {
            _locationService = _bokSer;
        }

        public IActionResult OnGet(int id)
        {
            Location = _locationService.GetLocation(id);
            if (CurrentUser.LoggedUser == null || CurrentUser.LoggedUser.IsTeacher == false)
            {
                return Redirect("/Unauthorized");
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            _locationService.DeleteLocation(id);
            return Redirect("/Admin/ListLocations");
        }
       
    }
}

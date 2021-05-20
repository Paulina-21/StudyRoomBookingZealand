using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.Admin
{
    public class ListUsersModel : PageModel
    {
        private IUsers _userService;

        public List<Models.User> Users { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchCriteria { get; set; }
        public ListUsersModel(IUsers user)
        {
            _userService = user;
        }

        public IActionResult OnGet()
        {
            if (String.IsNullOrEmpty(SearchCriteria))
            {
                Users = _userService.GetAllUsers();
            }
            else
            {
                Users = _userService.SearchByName(SearchCriteria);
            }
            
            return Page();
        }
    }
}

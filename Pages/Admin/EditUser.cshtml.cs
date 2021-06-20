using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.Admin
{
    public class EditUserModel : PageModel
    {
        private IUsers _userService;
        [BindProperty]
        public Models.User User { get; set; }

        public EditUserModel(IUsers user)
        {
            _userService = user;
        }

        public IActionResult OnGet(int id)
        {
            User = _userService.GetUserById(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _userService.UpdateUser(User);
            return Redirect("/Admin/ListUsers");
        }

    }
}

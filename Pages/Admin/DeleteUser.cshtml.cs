using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Pages.User;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.Admin
{
    public class DeleteUserModel : PageModel
    {
        private IUsers _userService;
        public Models.User User { get; set; }

        public DeleteUserModel(IUsers user)
        {
            _userService = user;
        }
        public IActionResult OnGet(int id)
        {
            User = _userService.GetUserById(id);
            if (CurrentUser.LoggedUser == null || CurrentUser.LoggedUser.IsTeacher == false)
            {
                return Redirect("/Unauthorized");
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            _userService.DeleteUser(id);
            return Redirect("/Admin/ListUsers");
        }
    }
}

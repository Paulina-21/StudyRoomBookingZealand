using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.User.Profile
{
    public class EditProfileModel : PageModel
    {
        IUsers UserService;
        public EditProfileModel(IUsers _users)
        {
            UserService = _users;
        }
        [BindProperty]
        public Models.User LoggedUser { get; set; }
        public void OnGet()
        {
            LoggedUser = UserService.GetUserById(CurrentUser.LoggedUser.Id);
        }
        public IActionResult OnPost()
        {
            CurrentUser.Update(CurrentUser.LoggedUser, LoggedUser);
            UserService.UpdateUser(CurrentUser.LoggedUser);
            return RedirectToPage("ProfilePage");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.User.Profile
{
    public class ViewProfileModel : PageModel
    {
        IUsers UserService;
        public ViewProfileModel(IUsers users)
        {
            UserService = users;
        }
        public Models.User ViewUser;
        public void OnGet(int id)
        {
            ViewUser = UserService.GetUserById(id);
        }
    }
}

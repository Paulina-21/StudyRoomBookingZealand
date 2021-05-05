using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Pages.User;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.User
{
    public class LoginModel : PageModel
    {
        IUsers UsersService;
        public LoginModel(IUsers service)
        {
            UsersService = service;
        }
        public bool InvalidUsername;
        public bool InvalidPassword;
        [BindProperty]
        public bool RememberMe { get; set; }
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public IActionResult OnGet()
        {
            
            InvalidUsername = false;
            InvalidPassword = false;
            return Page();
        }
        public IActionResult OnGetAutoLogin(Models.User user)
        {
            if (user!=null)
            {
                Username = user.Username;
                Password = user.Password;
                string[] Login = new string[2] { Username, Password };
                Models.User userAccount = UsersService.GetUserByUsername(Username);
                if (userAccount == null)
                {
                    InvalidUsername = true;
                    return Page();
                }
                else if (CurrentUser.Login(Login, RememberMe, userAccount))
                {
                    return RedirectToPage("/Index");
                }
                else
                {
                    InvalidPassword = true;
                    return Page();
                }
            }
            else
            return RedirectToPage("/Index");
        }
        public IActionResult OnPost()
        {
            string[] Login = new string[2] { Username, Password };
            Models.User userAccount = UsersService.GetUserByUsername(Username);
            if (userAccount == null)
            {
                InvalidUsername = true;
                return Page();
            }
            else if(CurrentUser.Login(Login, RememberMe, userAccount))
            {
                return RedirectToPage("/Index");
            }
            else
            {
                InvalidPassword = true;
                return Page();
            }
            
        }
    }
}

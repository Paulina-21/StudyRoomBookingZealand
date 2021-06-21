using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Pages.User;
using StudyroomBookingZealand.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace StudyroomBookingZealand.Pages.User
{
    public class LoginModel : PageModel
    {
        IUsers UsersService;
        public LoginModel(IUsers service)
        {
            UsersService = service;
        }
        public bool InvalidUsername; //used to tell the user on the view that the username is wrong
        public bool InvalidPassword; //same but for password
        [BindProperty]
        public bool RememberMe { get; set; }
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        [StringLength(20)]
        public string Password { get; set; }
        public IActionResult OnGet()
        {
            
            InvalidUsername = false; 
            InvalidPassword = false; 
            return Page();
        }
        //this method uses the login credentials from the json file to try and log in the user automatically
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
            PasswordHasher<Models.User> hasher = new PasswordHasher<Models.User>();
            Models.User userAccount = UsersService.GetUserByUsername(Username);
            string[] Login = new string[2] { Username, Password };
            if (userAccount == null) //account was not found, so the username is wrong
            {
                InvalidUsername = true;
                return Page();
            }
            else if(CurrentUser.Login(Login, RememberMe, userAccount)) // account found and password matches
            {
                return RedirectToPage("/Index");
            }
            else //password didnt match
            {
                InvalidPassword = true;
                return Page();
            }
            
        }
    }
}

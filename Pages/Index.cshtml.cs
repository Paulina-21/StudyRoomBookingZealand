using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using StudyroomBookingZealand.Pages.User;
using StudyroomBookingZealand.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyroomBookingZealand.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IUsers UsersService;

        public IndexModel(ILogger<IndexModel> logger, IUsers service)
        {
            _logger = logger;
            UsersService = service;
        }

        public IActionResult OnGet()
        {
            if (!CurrentUser.Exists) //will attempt to log in the user with the data from the json file
            {
                string[] login = new string[2];
                login = CheckUser();
                if (login == null)
                    return Page();
                else
                {
                    Models.User user = UsersService.GetUserByUsername(login[0]);
                    if (user != null)
                    {
                        CurrentUser.Login(login, true, user);
                        if (!user.IsTeacher)
                            return Page();
                        else return RedirectToPage("/Admin/Admin");
                    }
                    else return Page();
                }
            }
            else if(!CurrentUser.LoggedUser.IsTeacher) return Page();
            //admins get redirected to their own homepage
            else return RedirectToPage("/Admin/Admin"); ;
        }
        //used to check the json file if there are any user credentials inside or not
        public static string[] CheckUser() 
        {
            string[] login = new string[2];
            try
            {
                login = Data.Helpers.JsonFileHelper<string[]>.ReadJson(CurrentUser.JsonLoggedInUser);
                if (login == null) throw new ArgumentException();
                else return login;
            }
            catch(ArgumentException e)
            {
                return null;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using StudyroomBookingZealand.Pages.User;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.Dansk
{
    public class HjemmesideModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IUsers UsersService;

        public HjemmesideModel(ILogger<IndexModel> logger, IUsers service)
        {
            _logger = logger;
            UsersService = service;
        }

        public IActionResult OnGet()
        {
            if (!CurrentUser.Exists)
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
            else if (!CurrentUser.LoggedUser.IsTeacher) return Page();
            else return RedirectToPage("/Admin/Admin"); ;
        }
        public static string[] CheckUser()
        {
            string[] login = new string[2];
            try
            {
                login = Data.Helpers.JsonFileHelper<string[]>.ReadJson(CurrentUser.JsonLoggedInUser);
                if (login == null) throw new ArgumentException();
                else return login;
            }
            catch (ArgumentException e)
            {
                return null;
            }

        }
        
    }
}

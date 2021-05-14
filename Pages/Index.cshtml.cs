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
                    return Page();
                }
                else return Page();
            }
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
            catch(ArgumentException e)
            {
                return null;
            }

        }
    }
}

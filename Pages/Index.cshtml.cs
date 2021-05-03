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
            if (string.IsNullOrEmpty(login[0]))
                return Page();
            else
            {
                Models.User user = UsersService.GetUserByUsername(login[0]);
                CurrentUser.Login(login, true, user);
                return Page();
            }
        }
        public static string[] CheckUser() // will probably be moved to index page
        {
            string[] login = new string[2];
            login = Data.Helpers.JsonFileHelper<string[]>.ReadJson(CurrentUser.JsonLoggedInUser);
            if (!string.IsNullOrEmpty(login[0]))
            {
                return login;
            } 
            return null;

        }
    }
}

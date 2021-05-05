using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using StudyroomBookingZealand.Pages.User;
using StudyroomBookingZealand.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TryIdentity.Pages
{
    public class PrivacyModel : PageModel
    {
<<<<<<< HEAD:TryIdentity/Pages/Privacy.cshtml.cs
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
=======
        private readonly ILogger<IndexModel> _logger;
        private IUsers UsersService;

        public IndexModel(ILogger<IndexModel> logger, IUsers service)
>>>>>>> ea6375f0c9a73321fccac0a586cde9b8b5c906bb:Pages/Index.cshtml.cs
        {
            _logger = logger;
            UsersService = service;
        }

        public IActionResult OnGet()
        {
<<<<<<< HEAD:TryIdentity/Pages/Privacy.cshtml.cs
=======
            string[] login = new string[2];
            login = CheckUser();
            if (login == null)
                return Page();
            else
            {
                Models.User user = UsersService.GetUserByUsername(login[0]);
                CurrentUser.Login(login, true, user);
                return Page();
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

>>>>>>> ea6375f0c9a73321fccac0a586cde9b8b5c906bb:Pages/Index.cshtml.cs
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Pages.User;
using StudyroomBookingZealand.Services.Interfaces;


namespace StudyroomBookingZealand.Pages.Admin
{
    public class CreateAccountModel : PageModel
    {
        [BindProperty]
        public Models.User User { get; set; }
        private IUsers _usersService;

        public CreateAccountModel(IUsers service)
        {
            _usersService = service;
        }
        
        public IActionResult OnGet()
        {
            if (CurrentUser.LoggedUser == null || CurrentUser.LoggedUser.IsTeacher == false)
            {
                return Redirect("/Unauthorized");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            _usersService.AddUser(User);
            return Redirect("/Index");
        }
    }
}

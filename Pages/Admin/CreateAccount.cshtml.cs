using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
            return Page();
        }

        public IActionResult OnPost()
        {
            _usersService.AddUser(User);
            return Redirect("/Index");
        }
    }
}

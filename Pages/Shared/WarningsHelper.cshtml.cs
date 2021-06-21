using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.Shared
{
    public class WarningsHelperModel : PageModel
    {
        private IWarning WarningService;
        public WarningsHelperModel(IWarning wServ)
        {
            WarningService = wServ;
            Warnings = WarningService.GetWarningsForUser(Pages.User.CurrentUser.LoggedUser.Id);
        }
        public static List<Models.Warning> Warnings;
        public IActionResult OnGet(int id)
        {
            Models.Warning warning = WarningService.GetWarning(id);
            WarningService.DeleteWarning(id);
            switch (warning.Type) //based on the warning's type you get redirected to different pages
            {
                case Models.Warning.TypeList.DeletedBooking:
                    return RedirectToPage("/User/Profile/ProfilePage");
                    
                case Models.Warning.TypeList.GroupAction:
                    return RedirectToPage("/User/Profile/ManageGroup");
                    
                case Models.Warning.TypeList.GroupKick:
                    return RedirectToPage("/User/Profile/ProfilePage");
                    
                case Models.Warning.TypeList.Invitation:
                    return RedirectToPage("/User/Profile/Invitations");
                    
                default:
                    return RedirectToPage("/User/Profile/ProfilePage");
            }
        }
        public IActionResult OnGetDelete()
        {
            WarningService.ClearWarningsForUser(Pages.User.CurrentUser.LoggedUser.Id);
            return RedirectToPage("/Index");
        }
        public static Models.Warning CreateWarning(string content, int user, Models.Warning.TypeList type) 
        {
            Models.Warning warning = new Models.Warning();
            warning.Content = content;
            warning.UserID = user;
            warning.Type = type;
            return warning;
        }
    }
}

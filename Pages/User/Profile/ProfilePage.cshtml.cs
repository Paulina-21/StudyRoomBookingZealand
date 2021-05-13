using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.User.Profile
{
    public class ProfilePageModel : PageModel
    {
        IGroups GroupService;
        IUsers UserService;
        IInvitations InvitationService;
        public ProfilePageModel(IGroups groupservice, IUsers userservice, IInvitations invitationservice)
        {
            GroupService = groupservice;
            UserService = userservice;
            InvitationService = invitationservice;
        }
        public bool HasInvitations
        {
            get { return InvitationService.GetInvitationsForUser(CurrentUser.LoggedUser.Id).Count > 0; }
        }
        public IActionResult OnGet()
        {
            if (CurrentUser.LoggedUser == null)
            {
                return RedirectToPage("/User/Login");
            }
            else return Page();
        }
        public IActionResult OnPost()
        {
            Models.Group newgroup = new Models.Group();
            GroupService.AddGroup(newgroup);
            GroupService.AddStudentToGroup(newgroup.GroupId, CurrentUser.LoggedUser.Id);
            CurrentUser.LoggedUser.GroupId = newgroup.GroupId;
            GroupService.UpdateGroup(newgroup.GroupId);
            return Page();
        }
        public List<Models.User> GetStudentsFromGroup(int id)
        {
            return GroupService.GetStudentsFromGroup(UserService.GetUserById(id).GroupId);
        }
    }
}

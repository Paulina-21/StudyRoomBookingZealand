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
            get
            {
                if (InvitationService.GetInvitationsForUser(CurrentUser.LoggedUser.Id).Count > 0)
                {
                    int j = 0;
                    foreach(Models.Invitation i in InvitationService.GetInvitationsForUser(CurrentUser.LoggedUser.Id))
                    {
                        if (UserService.GetUserById(i.Sender).GroupId != CurrentUser.LoggedUser.GroupId) j++;
                    }
                    if (j > 0) return true;
                    else return false;
                }
                else return false;
            }
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
            newgroup.Owner = CurrentUser.LoggedUser.Id;
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

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
            get { return InvitationService.GetInvitationsForUser(CurrentUser.LoggedUser.Id) != null; }
        }
        [BindProperty]
        public string NewGroupMember
        {
            get;set;
        }
        public int InvalidName;
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
            Models.User newgroupmember = UserService.GetUserByName(NewGroupMember);
            if (newgroupmember != null)
            {
                if (CurrentUser.LoggedUser.GroupId == 0)
                {
                    Models.Group newgroup = new Models.Group();
                    GroupService.AddGroup(newgroup);
                    GroupService.AddStudentToGroup(newgroup.GroupId, CurrentUser.LoggedUser.Id);
                }
                Models.Invitation newinvitation = new Models.Invitation(CurrentUser.LoggedUser.Id,newgroupmember.Id);
                InvitationService.AddInvitation(newinvitation);
                InvalidName = 2;
            }
            else InvalidName = 1;
            return Page();
        }
    }
}

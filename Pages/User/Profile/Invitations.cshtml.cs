using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.User.Profile
{
    public class InvitationsModel : PageModel
    {
        IInvitations InvitationService;
        IUsers UserService;
        IGroups GroupService;
        IWarning WarningService;
        public InvitationsModel(IInvitations invitationservice, IUsers userservice, IGroups groupservice, IWarning warnserv)
        {
            InvitationService = invitationservice;
            UserService = userservice;
            GroupService = groupservice;
            WarningService = warnserv;
        }
        public List<Models.Invitation> InvitationsList
        {
            get { return InvitationService.GetInvitationsForUser(CurrentUser.LoggedUser.Id); }
        }
        public IActionResult OnGet()
        {
            if (CurrentUser.LoggedUser == null )
            {
                 return Redirect("/User/Login");
            }
            else
            {
                if (CurrentUser.LoggedUser.IsTeacher == true)
                {
                    return Redirect("/Unauthorized");
                }
            }

            return Page();
        }
        public IActionResult OnPostAccept(int id)
        {
            AcceptInvitation(id);
            return RedirectToPage("ProfilePage");
        }
        public IActionResult OnPostDecline(int id)
        {
            DeclineInvitation(id);
            return Page();
        }
        public Models.User GetUser(int id)
        {
            return UserService.GetUserById(id);
        }
        public List<Models.User> GetStudentsFromGroup(int id)
        {
            return GroupService.GetStudentsFromGroup(UserService.GetUserById(id).GroupId);
        }
        public void AcceptInvitation(int id)
        {
            Models.Invitation i = InvitationService.GetInvitation(id);
            string content = $"{UserService.GetUserById(CurrentUser.LoggedUser.Id).FullName} has joined your group";
            foreach(Models.User user in GroupService.GetStudentsFromGroup(UserService.GetUserById(i.Sender).GroupId))
            {
                WarningService.AddWarning(Shared.WarningsHelperModel.CreateWarning(content, user.Id, Models.Warning.TypeList.GroupAction));
            }
            GroupService.AddStudentToGroup(UserService.GetUserById(i.Sender).GroupId, i.Receiver);
            CurrentUser.LoggedUser.GroupId = UserService.GetUserById(i.Sender).GroupId;
            GroupService.UpdateGroup(UserService.GetUserById(i.Sender).GroupId);
            InvitationService.DeleteInvitation(id);
        }
        public void DeclineInvitation(int id)
        {
            InvitationService.DeleteInvitation(id);
        }
    }
}

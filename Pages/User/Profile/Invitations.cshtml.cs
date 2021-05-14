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
        public InvitationsModel(IInvitations invitationservice, IUsers userservice, IGroups groupservice)
        {
            InvitationService = invitationservice;
            UserService = userservice;
            GroupService = groupservice;
        }
        public List<Models.Invitation> InvitationsList
        {
            get { return InvitationService.GetInvitationsForUser(CurrentUser.LoggedUser.Id); }
        }
        public void OnGet()
        {
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

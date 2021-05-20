using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.User.Profile
{
    public class ManageGroupModel : PageModel
    {
        IUsers UserService;
        IGroups GroupService;
        IInvitations InvitationService;
        public ManageGroupModel(IUsers userservice, IGroups groupservice, IInvitations invitationservice)
        {
            UserService = userservice;
            GroupService = groupservice;
            InvitationService = invitationservice;
        }
        public List<Models.User> StudentsList
        {
            get { return GroupService.GetStudentsFromGroup(CurrentUser.LoggedUser.GroupId); }
        }
        [BindProperty]
        public string NewGroupMember
        {
            get; set;
        }
        public int InvalidName;
       // 1 = name not found, 2= success, 3=you invited yourself, 4= this guy is already in group, 5= already invited this person
        public IActionResult OnGet()
        {
            if (CurrentUser.LoggedUser == null)
            {
                return Redirect("/User/Login");
            }
            if (CurrentUser.LoggedUser.GroupId == 0)
            {
                return RedirectToPage("/Index");
            }
            else return Page();
        }
        public IActionResult OnPostInvite()
        {
            Models.User newgroupmember = UserService.GetUserByName(NewGroupMember);
            if (newgroupmember != null)
            {
                if (newgroupmember.Id == CurrentUser.LoggedUser.Id)
                {
                    InvalidName = 3;
                }
                else if (GroupService.ContainsStudent(CurrentUser.LoggedUser.GroupId, newgroupmember.Id))
                {
                    InvalidName = 4;
                }
                else if (InvitationService.FindInvitation(CurrentUser.LoggedUser.Id, newgroupmember.Id))
                {
                    InvalidName = 5;
                }
                else if (newgroupmember.IsTeacher)
                {
                    InvalidName = 1;
                }
                else
                {
                    Models.Invitation newinvitation = new Models.Invitation(CurrentUser.LoggedUser.Id, newgroupmember.Id);
                    InvitationService.AddInvitation(newinvitation);
                    InvalidName = 2;
                }
            }
            else InvalidName = 1;
            return Page();
        }
        public IActionResult OnPostKick(int id)
        {
            Models.Group group = GroupService.GetGroupById(UserService.GetUserById(id).GroupId);
            if (GroupService.GetStudentsFromGroup(group.GroupId).Count == 1)
            {
                GroupService.RemoveStudentFromGroup(id);
                GroupService.DeleteGroup(group.GroupId);
            }
            else
            {
                GroupService.RemoveStudentFromGroup(id);
                GroupService.UpdateGroup(group.GroupId);
            }
            if (CurrentUser.LoggedUser.Id == id)
            {
                CurrentUser.LoggedUser.GroupId = 0;
                return RedirectToPage("ProfilePage"); 
            }
            else return Page();
        }
    }
}

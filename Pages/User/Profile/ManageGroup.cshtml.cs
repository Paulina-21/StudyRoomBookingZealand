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
        IWarning WarningService;
        public ManageGroupModel(IUsers userservice, IGroups groupservice, IInvitations invitationservice, IWarning warningservice)
        {
            UserService = userservice;
            GroupService = groupservice;
            InvitationService = invitationservice;
            WarningService = warningservice;
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
                    string content = $"{UserService.GetUserById(CurrentUser.LoggedUser.Id).FullName} has invited you to a group";
                    WarningService.AddWarning(Shared.WarningsHelperModel.CreateWarning(content, newgroupmember.Id, Models.Warning.TypeList.Invitation));
                }
            }
            else InvalidName = 1;
            return Page();
        }
        public IActionResult OnPostKick(int id) //method used when the owner kicks a member
        {
            Models.Group group = GroupService.GetGroupById(UserService.GetUserById(id).GroupId);
            if (GroupService.GetStudentsFromGroup(group.GroupId).Count == 1)
            {
                //this is probably never used
                GroupService.RemoveStudentFromGroup(id);
                GroupService.DeleteGroup(group.GroupId);
            }
            else
            {
                GroupService.RemoveStudentFromGroup(id);
                GroupService.UpdateGroup(group.GroupId);
            }
            //warning for all group members
            string content = $"{UserService.GetUserById(id).FullName} has been kicked from your group";
            foreach (Models.User user in GroupService.GetStudentsFromGroup(group.GroupId))
            {
                WarningService.AddWarning(Shared.WarningsHelperModel.CreateWarning(content, user.Id, Models.Warning.TypeList.GroupAction));
            }
            //warning for the kicked member
            string contentforkicked = $"You have been kicked from your group";
            WarningService.AddWarning(Shared.WarningsHelperModel.CreateWarning(contentforkicked, id, Models.Warning.TypeList.GroupKick));
            if (CurrentUser.LoggedUser.Id == id)
            {
                CurrentUser.LoggedUser.GroupId = 0;
                return RedirectToPage("ProfilePage"); 
            }
            else return Page();
        }
        public IActionResult OnPostLeave()//method used when a user leaves the group
        {
            #region Notifications for the other group members
            string content = $"{CurrentUser.LoggedUser.FullName} has left your group";
            foreach (Models.User user in GroupService.GetStudentsFromGroup(CurrentUser.LoggedUser.GroupId))
            {
                if(user.Id!=CurrentUser.LoggedUser.Id)
                WarningService.AddWarning(Shared.WarningsHelperModel.CreateWarning(content, user.Id, Models.Warning.TypeList.GroupAction));
            }
            #endregion
            //if the owner leaves, the group gets deleted
            if (GroupService.GetGroupById(CurrentUser.LoggedUser.GroupId).Owner == CurrentUser.LoggedUser.Id)
            {
                GroupService.DeleteGroup(CurrentUser.LoggedUser.GroupId);
                CurrentUser.LoggedUser.GroupId = 0;
            }
            else
            {
                GroupService.RemoveStudentFromGroup(CurrentUser.LoggedUser.Id);
                CurrentUser.LoggedUser.GroupId = 0;
            }
            return RedirectToPage("ProfilePage");
        }
    }
}

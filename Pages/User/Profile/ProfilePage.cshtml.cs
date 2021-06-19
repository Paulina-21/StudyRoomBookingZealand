using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.User.Profile
{
    public class ProfilePageModel : PageModel
    {
        IGroups GroupService;
        IUsers UserService;
        IInvitations InvitationService;
        IBooking BookingService;
        ILocations LocationService;
        IWarning WarningService;
        public List<Booking> UserBookings { get; set; }
        public ProfilePageModel(IGroups groupservice, IUsers userservice, IInvitations invitationservice, IBooking bookingService, ILocations locationService, IWarning warnserv)
        {
            GroupService = groupservice;
            UserService = userservice;
            InvitationService = invitationservice;
            BookingService = bookingService;
            LocationService = locationService;
            WarningService = warnserv;
        }
        public static int BookingsPage;
        public static int LastBookingsPage;
        public const int BookingsPerPage = 4;
        public Dictionary<int, List<Models.Booking>> Catalog = new Dictionary<int, List<Booking>>();
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
            BookingsPage = 1;
            return Page();
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
        public IActionResult OnPostCancel(int bid)
        {
            Booking b = BookingService.GetBookingById(bid);
            b.Active = false;
            BookingService.UpdateBooking(b);
            string content = $"{CurrentUser.LoggedUser.FullName} has cancelled a booking";
            foreach (Models.User user in GroupService.GetStudentsFromGroup(CurrentUser.LoggedUser.GroupId)) 
            {
                if(user.Id!=CurrentUser.LoggedUser.Id)
                WarningService.AddWarning(Shared.WarningsHelperModel.CreateWarning(content, user.Id, Warning.TypeList.DeletedBooking));
            }
            return Page();
        }
        public IActionResult OnPostNext()
        {
            BookingsPage++;
            return Page();
        }
        public IActionResult OnPostPrevious()
        {
            BookingsPage--;
            return Page();
        }
        public List<Models.User> GetStudentsFromGroup(int id)
        {
            return GroupService.GetStudentsFromGroup(UserService.GetUserById(id).GroupId);
        }
        public void BookingsForUser()
        {
            List<Models.Booking> bookings = BookingService.GetBookingsByUserId(CurrentUser.LoggedUser.Id);
            int i = 0;
            LastBookingsPage = bookings.Count / 4 + 1;
            for (int j = 1; j <= LastBookingsPage; j++)
            {
                List<Models.Booking> list = new List<Booking>();
                for(int l=1; l<= BookingsPerPage && i<bookings.Count; l++)
                {
                    list.Add(bookings[i]);
                    i++;
                }
                Catalog.Add(j, list);
            }
        }
        public List<Models.Booking> RenderBookings(int page)
        {
            return Catalog[page];
        }
    }
}

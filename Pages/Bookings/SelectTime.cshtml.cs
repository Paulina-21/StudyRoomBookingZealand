using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Pages.User;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.Bookings
{
    public class SelectTimeModel : PageModel
    {
        private IBooking BookService;
        private IRoom RoomService;
        private IWarning WarningService;
        private IGroups GroupService;
        public SelectTimeModel(IBooking bservice, IRoom rservice, IWarning warnserv, IGroups groupservice)
        {
            BookService = bservice;
            RoomService = rservice;
            WarningService = warnserv;
            GroupService = groupservice;
        }
        public static int Stage; //used for switching between day picker and the booking buttons 0= default, 1=day selected
        public static int SelectedRoom; //id of the room picked in the previous page
        public static bool LimitReached; //whether you have reached your group's limit of bookings
        public static List<DateTime> DateList;
        public const int OpeningHour = 8;
        public const int HoursPerInterval = 2;
        public const int ClosingHour = 16;
        [BindProperty]
        public static DateTime FromDate { get; set; }
        public DateTime Date { get; set; }
        [BindProperty]
        public DateTime Duration { get; set; }
        public IActionResult OnGet(int id)
        {
            Stage = 0;
            if (CurrentUser.LoggedUser == null)
            {
                return RedirectToPage("/User/Login");
            }
            else
            {
                if (CurrentUser.LoggedUser.IsTeacher == true)
                {
                    return RedirectToPage("Unauthorized");
                }
                else
                {
                    SelectedRoom = id;
                    LimitReached = BookService.CheckBookingLimit(CurrentUser.LoggedUser.Id);
                    return Page();
                }
            }
            
        }
        //this method switches from the day picker to the booking buttons
        public IActionResult OnPostDay(DateTime date)
        {
            FromDate = date;
            DateList = RenderIntervals();
            Stage = 1;
            return Page();
        }
        public IActionResult OnPostBack()
        {
            Stage = 0;
            return Page();
        }
        public IActionResult OnPostPrevious()
        {
            FromDate = FromDate.AddDays(-1);
            DateList = RenderIntervals();
            return Page();
        }
        public IActionResult OnPostNext()
        {
            FromDate = FromDate.AddDays(1);
            DateList = RenderIntervals();
            return Page();
        }
        public IActionResult OnPostBook(int id, int datetime)
        {
            #region Booking creation
            Models.Booking booking = new Models.Booking();
            booking.RoomId = id;
            booking.UserId = CurrentUser.LoggedUser.Id;
            booking.FromDateTime = DateList[datetime];
            booking.ToDateTime = DateList[datetime].AddHours(2);
            booking.Student_GroupID = CurrentUser.LoggedUser.GroupId;
            BookService.AddBooking(booking);
            #endregion
            #region Notification for each group member
            if (CurrentUser.LoggedUser.GroupId != 0)
            {
                string content = $"{CurrentUser.LoggedUser.FullName} has made a new booking";
                foreach (Models.User user in GroupService.GetStudentsFromGroup(CurrentUser.LoggedUser.GroupId))
                {
                    if(user.Id!=CurrentUser.LoggedUser.Id)
                    WarningService.AddWarning(Shared.WarningsHelperModel.CreateWarning(content, user.Id, Models.Warning.TypeList.DeletedBooking));
                }
            }
            #endregion
            return RedirectToPage("/Index");
        }
        public bool ValidTime(DateTime dateTime) //checks that the datetime picked is not earlier than the current datetime
        {
            if (dateTime.CompareTo(DateTime.Now) > 0) return true;
            else return false;
        }
        public List<DateTime> RenderIntervals() //used to assign a datetime value for each button
        {
            int time = OpeningHour;
            List<DateTime> list = new List<DateTime>();
            while (time < ClosingHour)
            {
                DateTime dateTime = new DateTime(FromDate.Year, FromDate.Month, FromDate.Day, time, 0, 0);
                list.Add(dateTime);
                time = time + HoursPerInterval;
            }
            return list;
        }
    }
}

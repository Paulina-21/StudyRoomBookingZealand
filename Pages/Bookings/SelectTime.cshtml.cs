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
        public SelectTimeModel(IBooking bservice, IRoom rservice)
        {
            BookService = bservice;
            RoomService = rservice;
        }
        public int Stage; //0= default, 1=day selected
        public static int SelectedRoom;
        [BindProperty]
        public DateTime FromDate { get; set; }
        [BindProperty]
        public DateTime Duration { get; set; }
        public IActionResult OnGet(int id)
        {
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
                    return Page();
                }
            }
            
        }
        public IActionResult OnPostDay()
        {
            Stage = 1;
            return Page();
        }
        public IActionResult OnPostBack()
        {
            Stage = 0;
            return Page();
        }
        public IActionResult OnPostBook(int id, DateTime datetime)
        {
            Models.Booking booking = new Models.Booking();
            booking.RoomId = id;
            booking.UserId = CurrentUser.LoggedUser.Id;
            booking.FromDateTime = datetime;
            booking.ToDateTime = datetime.AddHours(2);
            booking.Student_GroupID = CurrentUser.LoggedUser.GroupId;
            BookService.AddBooking(booking);
            return RedirectToPage("/Index");
        }
        public bool ValidTime(DateTime dateTime)
        {
            if (dateTime.CompareTo(DateTime.Now) > 0) return true;
            else return false;
        }
    }
}

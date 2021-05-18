using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Pages.User;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.Bookings
{
    public class BookRoomModel : PageModel
    {
        private IBooking BookService;
        private IRoom RoomService;
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public int SelectedRoom { get; set; }

        public BookRoomModel(IBooking book, IRoom room)
        {
            BookService = book;
            RoomService = room;
        }
        public List<Room> Rooms;

        public IActionResult OnGet()
        {
            if (CurrentUser.LoggedUser == null)
            {
                return RedirectToPage("/Unauthorized");
            }
            Rooms = RoomService.GetAllRooms();
            return Page();
        }

        public void OnPostSelect(int id)
        {
            SelectedRoom = id;
            OnGet();
        }
        public void OnPostUnSelect()
        {
            SelectedRoom = 0;
            OnGet();
        }
    }
}

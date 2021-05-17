using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Pages.User;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.Locations.Rooms
{
    public class DeleteRoomModel : PageModel
    {
        private IRoom _roomService;
        [BindProperty(SupportsGet = true)]
        public Room Room { set; get; }

        public DeleteRoomModel(IRoom _bokSer)
        {
            _roomService = _bokSer;
        }

        public IActionResult OnGet(int id)
        {
            Room = _roomService.GetRoomById(id);
            if (CurrentUser.LoggedUser == null || CurrentUser.LoggedUser.IsTeacher == false)
            {
                return Redirect("/Unauthorized");
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            _roomService.DeleteRoom(id);
            return Redirect("/Rooms/ListRooms");
        }
    }
}

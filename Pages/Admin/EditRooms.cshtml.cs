using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Pages.User;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.Admin
{
    public class EditRoomsModel : PageModel
    {
        private IRoom _roomService;
        private ILocations _locationsService;
        [BindProperty]
        public Room Room { get; set; }
        [BindProperty]
        public int LocationId { get; set; }
        public static SelectList Options { get; set; }
        public EditRoomsModel(IRoom room, ILocations locations)
        {
            _roomService = room;
            _locationsService = locations;
        }
        public IActionResult OnGet(int id)
        {
            if (CurrentUser.LoggedUser == null || CurrentUser.LoggedUser.IsTeacher == false)
            {
                return Redirect("/Unauthorized");
            }
            Room = _roomService.GetRoomById(id);
            Options = new SelectList(_locationsService.GetAllLocations(), nameof(Location.LocationId), nameof(Location.Name));
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Room.LocationId = LocationId;
            _roomService.UpdateRoom(Room);
            return Redirect("/Admin/ListRooms");
        }
    }
}

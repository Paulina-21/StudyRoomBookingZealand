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
    public class CreateRoomModel : PageModel
    {
        [BindProperty]
        public Room Room { set; get; }
        [BindProperty]
        public int LocationId { get; set; }
        public SelectList Options { get; set; }
       
        private IRoom _roomService;
        private ILocations _locationsService;

        public CreateRoomModel(IRoom room, ILocations locations)
        {
            _roomService = room;
            _locationsService = locations;
        }

        public IActionResult OnGet()
        {
            if (CurrentUser.LoggedUser == null || CurrentUser.LoggedUser.IsTeacher == false)
            {
                return Redirect("/Unauthorized");
            }
            Options = new SelectList(_locationsService.GetAllLocations(), nameof(Location.LocationId), nameof(Location.Name));
            return Page();
        }

        public IActionResult OnPost()
        {
            Room.LocationId = LocationId;
            _roomService.AddRoom(Room);
            return Redirect("/Locations/Rooms/ListRooms");
        }
    }
}

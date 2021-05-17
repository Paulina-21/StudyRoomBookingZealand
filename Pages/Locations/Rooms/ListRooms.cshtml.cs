using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.Locations.Rooms
{
    public class ListRoomsModel : PageModel
    {
        public Location Location { get; set; }
        private IRoom _roomService;
        private ILocations _locService;
        public List<Room> Rooms { get; set; }

        public ListRoomsModel(IRoom rooms,ILocations loc)
        {
            _roomService = rooms;
            _locService = loc;
        }
        public IActionResult OnGet(int id)
        {
            Rooms = _roomService.GetAllRooms();
            if (id > 0)
            {
                Location = _locService.GetLocation(id);
                Rooms = _locService.GetRoomsForLocation(Location.LocationId);
            }

            return Page();
        }

    }
}

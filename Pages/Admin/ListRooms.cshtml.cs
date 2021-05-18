using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.Admin
{
    public class ListRoomsModel : PageModel
    {
        private IRoom _roomService;
        [BindProperty(SupportsGet = true)]
        public string SearchCriteria { get; set; }
        public Location Location { get; set; }
        public List<Room> Rooms { get; set; }

        public ListRoomsModel(IRoom rooms)
        {
            _roomService = rooms;
        }

        public IActionResult OnGet()
        {
            
            if (String.IsNullOrEmpty(SearchCriteria))
            {
                Rooms = _roomService.GetAllRooms();
            }
            else
            {
                Rooms = _roomService.SearchbyName(SearchCriteria);
            }

            return Page();
        }
    }
}

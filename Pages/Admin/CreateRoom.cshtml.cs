using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Pages.Admin
{
    public class CreateRoomModel : PageModel
    {
        [BindProperty]
        public Room Room { set; get; }
        private IRoom _roomService;

        public CreateRoomModel(IRoom room)
        {
            _roomService = room;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _roomService.AddRoom(Room);
            return Page();
        }
    }
}

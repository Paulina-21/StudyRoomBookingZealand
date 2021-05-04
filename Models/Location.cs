using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyroomBookingZealand.Models
{
    public class Location
    {
        public int LocationId { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }

        public enum Type
        {
            Group1,Group2,Group3,Group4
        }
        public ICollection<Booking> Bookings { set; get; }
        public bool SmartBoard { set; get; }
        public bool? SmartBoardBooked { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyroomBookingZealand.Models
{
    public class Booking
    {
        public int BookingID { set; get; }
        public int Student_GroupID { set; get; }
        public DateTime DateTime { set; get; }
        public int LocationId { set; get; }
        public bool SmartBoardBooked
        {
            get {return false;}
            set{}
        }
    }
}
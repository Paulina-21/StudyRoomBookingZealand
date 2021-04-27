﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyroomBookingZealand.Models
{
    public class Location
    {
        public int LocationId { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public object Type { set; get; }
        public ICollection<Booking> Bookings { set; get; }
        public bool SmartBoard { set; get; }
        public bool SmartBoardBooked { set; get; }
    }
}

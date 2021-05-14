﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StudyroomBookingZealand.Models
{
    public class Booking
    {
        public int BookingID { set; get; }
        public int Student_GroupID { set; get; }
        public DateTime FromDateTime { set; get; }
        public DateTime ToDateTime { get; set; }
        public int RoomId { set; get; }
        public bool SmartBoardBooked
        {
            get {return false;}
            set{}
        }
        public User Booker { get; set; }
    }
}
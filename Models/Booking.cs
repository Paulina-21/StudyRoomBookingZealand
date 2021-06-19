using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StudyroomBookingZealand.Models
{
    public class Booking
    {
        public Booking()
        {
            Active = true;
        }
        public int BookingID { set; get; }
        public int Student_GroupID { set; get; }
        public DateTime FromDateTime { set; get; }
        public DateTime ToDateTime { get; set; }
        public TimeSpan Duration
        { 
            get { return ToDateTime.Subtract(FromDateTime); } 
        }
        public int RoomId { set; get; }
        public int UserId { get; set; }
        public const int BookingLimit = 4;
        public bool Active { get; set; }
    }
}
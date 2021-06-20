using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "The group id is required")]
        public int Student_GroupID { set; get; }
        [Required(ErrorMessage = "The start date is required")]
        public DateTime FromDateTime { set; get; }
        [Required(ErrorMessage = "The end date is required")]
        public DateTime ToDateTime { get; set; }
        public TimeSpan Duration
        { 
            get { return ToDateTime.Subtract(FromDateTime); } 
        }
        [Required(ErrorMessage = "The room id is required")]
        public int RoomId { set; get; }
        public int UserId { get; set; }
        public const int BookingLimit = 4;
        public bool Active { get; set; }
    }
}
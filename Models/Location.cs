using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StudyroomBookingZealand.Models;

namespace StudyroomBookingZealand.Models
{
    public enum Type { OneGroup, TwoGroups, ThreeGroups, FourGroups }
    public class Location
    {
        public int LocationId { set; get; }
        [Required] [StringLength(30)] public string Name { set; get; }
        [Required] [StringLength(50)] public string Address { set; get; }

        public enum Type
        {
        Groups1, Groups2, Groups3, Groups4 };
        public Type Types { set; get; }
        public ICollection<Booking> Bookings { set; get; }
        public bool SmartBoard { set; get; }
        public bool? SmartBoardBooked { set; get; }
    }
}

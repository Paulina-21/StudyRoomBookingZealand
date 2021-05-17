using System.Collections.Generic;

namespace StudyroomBookingZealand.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public int LocationId { set; get; }
        public string Adress { get; set; }
        public string Name { set; get; }

        public TypeList Type { get; set; }
        public enum TypeList
        {
            Classroom, Room, Lounge, Office
        }
        public ICollection<Booking> Bookings { set; get; }
        public bool SmartBoard { set; get; }
        public bool? SmartBoardBooked { set; get; }
    }
}
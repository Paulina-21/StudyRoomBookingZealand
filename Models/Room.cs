using System.Collections.Generic;

namespace StudyroomBookingZealand.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public int LocationId { set; get; }
        public string Adress { get; set; }
        public string Name { set; get; }
        public string ImagePath { get; set; }
        public TypeList Type { get; set; }
        public enum TypeList
        {
            Classroom, Room, Lounge, Office //classroom can be booked by 2 groups at the same time
        }
        public bool Big { set; get; }
    }
}
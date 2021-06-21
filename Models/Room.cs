using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudyroomBookingZealand.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        [Required(ErrorMessage = "The location is required")]
        public int LocationId { set; get; }
        [Required(ErrorMessage = "The room number is required")]
        [StringLength(30)]
        public string RoomNR { get; set; }
        [Required(ErrorMessage = "The name is required")]
        [StringLength(30)]
        public string Name { set; get; }
        public string ImagePath { get; set; }
        [Required(ErrorMessage = "The type is required")]
        public TypeList Type { get; set; }
        public enum TypeList
        {
            Classroom, Room, Lounge, Office, SmartBoard //classroom can be booked by 2 groups at the same time
        }
        public bool Big { set; get; }
    }
}
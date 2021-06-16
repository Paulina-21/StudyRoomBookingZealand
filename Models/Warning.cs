using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyroomBookingZealand.Models
{
    public class Warning
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserID { get; set; }
        public enum TypeList
        {
            GroupAction, DeletedBooking, GroupKick, Invitation
        }
        public TypeList Type { get; set; }
    }
}

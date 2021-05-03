using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudyroomBookingZealand.Models
{
    [NotMapped]
    public class Admin : User
    {
        public enum Role
        {
            Admin, Teacher, Assistant
        }
        public Role Type { set; get; }  
    }
}

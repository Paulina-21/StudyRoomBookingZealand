using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudyroomBookingZealand.Models
{
    public class User
    {
        [Required]
        [StringLength(50)]
        public string Name { set; get; }
        public int Id { set; get; }
        [Required]
        [StringLength(50)]
        public string Address { set; get; }
        [Required]
        [StringLength(20)]
        public string Password { set; get; }
        [Required]
        [StringLength(10)]
        public string Username { set; get; }
        public string? PhoneNr { set; get; }
        public string Email { set; get; }
        public bool IsTeacher { set; get; }
    }
}

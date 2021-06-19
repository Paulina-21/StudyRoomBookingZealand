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
        public string FirstName { set; get; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        public int Id { set; get; }
        [Required]
        [StringLength(50)]
        public string Address { set; get; }
        [Required]
        public string Password { set; get; }
        [Required]
        [StringLength(10)]
        public string Username { set; get; }
        public string? PhoneNr { set; get; }
        public string Email { get; set; }
        public bool IsTeacher { get; set; }
        public int GroupId { get; set; }
        public string ImagePath { get; set; }
        public string FullName
        {
            get { return FirstName +" "+ LastName; }
        }
    }
}

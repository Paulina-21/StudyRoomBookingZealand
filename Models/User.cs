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
        [Required(ErrorMessage = "The first name is required")]
        [StringLength(20)]
        public string FirstName { set; get; }
        [Required(ErrorMessage = "The last name is required")]
        [StringLength(20)]
        public string LastName { get; set; }
        public int Id { set; get; }
        [Required(ErrorMessage = "The address is required")]
        [StringLength(50)]
        public string Address { set; get; }
        [Required(ErrorMessage = "The password is required")]
        public string Password { set; get; }
        [Required(ErrorMessage = "The username is required")]
        [StringLength(10)]
        public string Username { set; get; }
        public string PhoneNr { set; get; }
        [Required(ErrorMessage = "The email is required")]
        [EmailAddress(ErrorMessage = "This is not a valid email adress")]
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

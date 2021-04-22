using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyroomBookingZealand.Models
{
    public class Student
    {
        public string Name { set; get; }
        public int StudentId { set; get; }
        public string Address { set; get; }
        public string Password { set; get; }
        public string Username { set; get; }
        public string PhoneNr { set; get; }
        public string Email { set; get; }
    }
}

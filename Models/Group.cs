using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyroomBookingZealand.Models
{
    public class Group
    {
        public  ICollection<Student> StudentList { set; get; }
        public int GroupId { set; get; }
        public string GroupName { set; get; }
    }
}

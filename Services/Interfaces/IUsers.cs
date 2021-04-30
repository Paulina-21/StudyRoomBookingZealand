using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyroomBookingZealand.Models;

namespace StudyroomBookingZealand.Services.Interfaces
{
    public interface IUsers
    {

        public void AddUser(User u);

        public void DeleteUser(int id);

        public List<User> GetAllUsers();
    }
}

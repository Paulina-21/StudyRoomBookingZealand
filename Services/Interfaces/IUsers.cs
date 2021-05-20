using StudyroomBookingZealand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyroomBookingZealand.Services.Interfaces
{
    public interface IUsers
    {
        public User GetUserById(int id);
        public User GetUserByUsername(string username);
        public User GetUserByName(string name);

        public void AddUser(User u);

        public void DeleteUser(int id);

        public List<User> GetAllUsers();

        List<User> SearchByName(string searchCriteria);

        public void UpdateUser(User u);
    }
}

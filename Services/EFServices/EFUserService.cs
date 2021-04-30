using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyroomBookingZealand.Models;

namespace StudyroomBookingZealand.Services.EFServices
{
    public class EFUserService : IUsers
    {
        private BookingDbContext _service;
        public EFUserService(BookingDbContext db)
        {
            _service = db;
        }

        public User GetUserById(int id)
        {
            return _service.Users.Find(id);
        }
        public User GetUserByUsername(string username)
        {
            foreach(User u in _service.Users.ToList())
            {
                if (u.Username == username)
                {
                    return u;
                }
            }
            return null;
        }
        

        public void AddUser(User u)
        {
            _service.Users.Add(u);
            _service.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            //Searches on the DB, for a user with the specific ID and stores it
            User u = _service.Users.Find(id);
            _service.Users.Remove(u);
            _service.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _service.Users.ToList();
        }
        
    }
}

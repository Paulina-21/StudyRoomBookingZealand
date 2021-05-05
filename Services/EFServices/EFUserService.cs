using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            _service.Users.Remove(GetUserById(id));
            _service.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _service.Users.ToList();
        }

        public void UpdateUser(int id)
        {
            _service.Users.Update(GetUserById(id));
            _service.SaveChanges();
        }
        
    }
}

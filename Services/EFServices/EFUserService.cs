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

            return _service.Users.Where(u => u.Username == username).FirstOrDefault();
            
        }
        public User GetUserByName(string name)
        {

            return _service.Users.Where(u => u.FirstName+" "+u.LastName == name).FirstOrDefault();

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

    public void UpdateUser(User u)
    {
        _service.Users.Update(u);
        _service.SaveChanges();
    }

    public List<User> SearchByName(string searchCriteria)
    {
        return _service.Users.Where(u => u.FirstName.StartsWith(searchCriteria)).ToList();
    }

    }
}

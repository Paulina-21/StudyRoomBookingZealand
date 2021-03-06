using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Services.EFServices
{
    public class EFGroupService : IGroups
    {
        private BookingDbContext _service;
        private IBooking BookingService;
        public EFGroupService(BookingDbContext db, IBooking bookserv)
        {
            _service = db;
            BookingService = bookserv;
        }
        public void AddGroup(Group g)
        {
            _service.Groups.Add(g);
            _service.SaveChanges();
        }

        public void DeleteGroup(int id)
        {
            foreach(Models.User user in _service.Users.Where(u => u.GroupId == id).ToList())
            {
                user.GroupId = 0;
            }
            foreach (Models.Booking  b in _service.Bookings.Where(b=>b.Student_GroupID == id).ToList())
            {
                BookingService.DeleteBooking(b.BookingID);
            }
            _service.Groups.Remove(GetGroupById(id));
            _service.SaveChanges();
        }

        public List<Group> GetAllGroups()
        {
            return _service.Groups.ToList();
        }

        public Group GetGroupById(int id)
        {
            return _service.Groups.Find(id);
        }

        public void UpdateGroup(int id)
        {
            _service.Groups.Update(GetGroupById(id));
            _service.SaveChanges();
        }
        public void AddStudentToGroup(int groupid, int studentid)
        {
            _service.Users.Where(s => s.Id == studentid).FirstOrDefault().GroupId = groupid;
            _service.SaveChanges();
        }
        public void RemoveStudentFromGroup(int studentid)
        {
            _service.Users.Where(s => s.Id == studentid).FirstOrDefault().GroupId = 0;
            _service.SaveChanges();
        }
        public List<User> GetStudentsFromGroup(int id)
        {
            return _service.Users.Where(s => s.GroupId == id).ToList();
        }
        public bool ContainsStudent(int groupid, int studentid)
        {
            if (_service.Users.Where(s => s.Id == studentid).FirstOrDefault().GroupId == groupid) return true;
            else return false;
        }
        public void SetGroupOwner(int groupid, int studentid)
        {
            _service.Groups.Find(groupid).Owner = studentid;
            _service.SaveChanges();
        }

    }
}

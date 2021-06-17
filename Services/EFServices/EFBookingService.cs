using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace StudyroomBookingZealand.Services.EFServices
{
    public class EFBookingService : IBooking
    {
        private BookingDbContext _service;

        public EFBookingService(BookingDbContext db)
        {
            _service = db;
        }

        public void AddBooking(Booking b)
        {
            _service.Bookings.Add(b);
            _service.SaveChanges();
        }

        public void DeleteBooking(int id)
        {
            _service.Bookings.Remove(GetBookingById(id));
            _service.SaveChanges();
        }

        public List<Booking> GetAllBookings()
        {
            MarkExpiredBookings();
            return _service.Bookings.ToList();
        }

        public Booking GetBookingById(int id)
        {
            MarkExpiredBookings();
            return _service.Bookings.Find(id);
        }

        public Group GetGroupForBooking(int id)
        {
            return _service.Groups.Where(g => g.GroupId == id).FirstOrDefault();
        }

        public Location LocationForBooking(int id)
        {
            return _service.Locations.Where(l => l.LocationId == id).FirstOrDefault();
        }

        public void UpdateBooking(Booking b)
        {
            _service.Bookings.Update(b);
            _service.SaveChanges();
        }

        public List<Booking> BookingsForLocation(int id)
        {
            return _service.Bookings.Where(b => b.RoomId == id).ToList();
        }

        public Room RoomForBooking(int id)
        {
            return _service.Rooms.Where(r => r.RoomId == id).FirstOrDefault();
        }

        public List<Booking> BookingByRoomId(int id)
        {
            return _service.Bookings.Where(b => b.RoomId == id).ToList();
        }
        public List<User> BookingOwners(int id)
        {
            List<User> users = new List<User>();
            if(GetBookingById(id).Student_GroupID == 0)
            {
                users.Add(_service.Users.Find(GetBookingById(id).UserId));
            }
            else
            {
                users =_service.Users.Where(s => s.GroupId == GetBookingById(id).Student_GroupID).ToList();
            }
            return users;
        }
        public bool CheckBookingLimit(int userid)
        {
            if (_service.Users.Find(userid).GroupId == 0)
            {
               return _service.Bookings.Where(b => b.UserId == userid && b.Active==true).ToList().Count >= Booking.BookingLimit;
            }
            else return _service.Bookings.Where(b => b.Student_GroupID == _service.Users.Find(userid).GroupId && b.Active == true).ToList().Count >= Booking.BookingLimit;
        }

        public List<Booking> GetBookingsByUserId(int id)
        {
            MarkExpiredBookings();
            return _service.Bookings.Where(b => b.Student_GroupID == _service.Users.Find(id).GroupId).ToList();
        }
        public void MarkExpiredBookings()
        {
            foreach(Models.Booking b in _service.Bookings.Where(b => b.ToDateTime < System.DateTime.Now))
            {
                b.Active = false;
            }
            _service.SaveChanges();
        }
        //public List<Booking> SearchByName(string searchCriteria)
        //{
        //    //Doesnt work need to redo
        // //   return _service.Bookings.Where(b => b.Booker.Name.StartsWith(searchCriteria)).ToList();
        //}
    }
}
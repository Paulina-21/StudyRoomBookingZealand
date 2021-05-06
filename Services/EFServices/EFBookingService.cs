using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Services.EFServices
{
    public class EFBookingService : IBookings
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
            return _service.Bookings.ToList();
        }

        public Booking GetBookingById(int id)
        {
            return _service.Bookings.Find(id);
        }

        public void UpdateGroup(int id)
        {
            _service.Bookings.Update(GetBookingById(id));
            _service.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyroomBookingZealand.Models;

namespace StudyroomBookingZealand.Services.Interfaces
{
    public interface IBookings
    {
        public Booking GetBookingById(int id);

        public void AddBooking(Booking b);

        public void DeleteBooking(int id);

        public List<Booking> GetAllBookings();

        public void UpdateGroup(int id);
    }
}

using System.Collections.Generic;
using StudyroomBookingZealand.Models;

namespace StudyroomBookingZealand.Services.Interfaces
{
    public interface IBooking
    {
        public List<Booking> GetAllBookings();
        public Booking GetBookingById(int id);
        public Group GetGroupForBooking(int id);
        public Location GetLocationForBooking(int id);
        public void AddBooking(Booking b);
        public void DeleteBooking(int id);
        public void UpdateBooking(int id);
    }
}
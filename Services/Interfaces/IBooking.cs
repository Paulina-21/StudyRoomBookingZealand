using System.Collections.Generic;
using StudyroomBookingZealand.Models;

namespace StudyroomBookingZealand.Services.Interfaces
{
    public interface IBooking
    {
        public List<Booking> GetAllBookings();
        public Booking GetBookingById(int id);
        public Group GetGroupForBooking(int id);
        public Location LocationForBooking(int id);
        public Room RoomForBooking(int id);
        public void AddBooking(Booking b);
        public void DeleteBooking(int id);
        public void UpdateBooking(Booking b);
        public List<Booking> BookingByRoomId(int id);
       // public List<Booking> SearchByName(string searchCriteria);
    }
}
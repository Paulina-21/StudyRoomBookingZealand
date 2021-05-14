using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace StudyroomBookingZealand.Services.EFServices
{
    public class EFRoomService : IRoom
    {
        private BookingDbContext _service;

        public EFRoomService(BookingDbContext db)
        {
            _service = db;
        }

        public void AddRoom(Room r)
        {
            _service.Rooms.Add(r);
            _service.SaveChanges();
        }

        public void DeleteRoom(int id)
        {
            _service.Rooms.Remove(GetRoomById(id));
            _service.SaveChanges();

        }

        public List<Room> GetAllRooms()
        {
            return _service.Rooms.ToList();
        }

        public List<Booking> GetBookingsForRoom(int id)
        {
            return _service.Bookings.Where(b => b.RoomId == id).ToList();
        }

        public Room GetRoomById(int id)
        {
            return _service.Rooms.Find(id);
        }

        public List<Room> SmartBoardRooms()
        {
            return _service.Rooms.Where(r=>r.SmartBoard==true).ToList();
        }

        public void UpdateRoom(int id)
        {
            _service.Rooms.Update(GetRoomById(id));
            _service.SaveChanges();
        }
    }
}
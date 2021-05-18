using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyroomBookingZealand.Models;

namespace StudyroomBookingZealand.Services.Interfaces
{
    public interface IRoom
    {
        public Room GetRoomById(int id);
        public List<Room> GetAllRooms();
        public List<Room> GetAllRoomsForLocation(int locationid);
        public List<Booking> GetBookingsForRoom(int id);
        public void AddRoom(Room r);
        public void DeleteRoom(int id);
        public void UpdateRoom(int id);
        public List<Room> SmartBoardRooms();

    }
}

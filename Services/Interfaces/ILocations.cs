using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyroomBookingZealand.Models;

namespace StudyroomBookingZealand.Services.Interfaces
{
    public interface ILocations
    {
        public List<Location> GetAllLocations();
        public Location GetLocation(int id);
        public List<Booking> GetBookingsForLocation(int id);
        public List<Room> GetRoomsForLocation(int id);
        public void AddLocation(Location l);
        public void DeleteLocation(int id);
        public void UpdateLocation(Location l);
        public void AddRoomToLocation(Room r);
       // public void SmartBoardRooms(int id);
        public List<Location> SearchByName(string searchCriteria);
    }
}

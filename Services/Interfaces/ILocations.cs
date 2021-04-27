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
        public Location GetLocation();
        public List<Booking> GetBookingsForLocation();
        public void AddLocation(Location l);
        public void DeleteLocation(int id);
        public void UpdateLocation(Location l);
        public List<Location> SmartBoardLocations();
    }
}

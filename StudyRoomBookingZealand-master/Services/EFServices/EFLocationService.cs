using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Services.Interfaces;

namespace StudyroomBookingZealand.Services.EFServices
{
    public class EFLocationService : ILocations
    {
        private BookingDbContext _service;

        public EFLocationService(BookingDbContext db)
        {
            _service = db;
        }

        public void AddLocation(Location l)
        {
            _service.Locations.Add(l);
            _service.SaveChanges();
        }

        public void DeleteLocation(int id)
        {
            _service.Locations.Remove(GetLocation(id));
            _service.SaveChanges();
        }

        public List<Location> GetAllLocations()
        {
            return _service.Locations.ToList();
        }

        public List<Booking> GetBookingsForLocation(int id)
        {
            return _service.Bookings.Where(b => b.LocationId == id).ToList();
        }

        public Location GetLocation(int id)
        {
            return _service.Locations.Find(id);
        }

        public List<Location> SmartBoardLocations()
        {
            return _service.Locations.Where(l => l.SmartBoard == true).ToList();
        }

        public void UpdateLocation(int id)
        {
            _service.Locations.Update(GetLocation(id));
            _service.SaveChanges();
        }
    }
}

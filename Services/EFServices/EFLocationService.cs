﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Pages.Admin;
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

        public void AddRoomToLocation(Room r)
        {
            _service.Rooms.Add(r);
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
            return _service.Bookings.Where(b => b.RoomId == id).ToList();
        }

        public Location GetLocation(int id)
        {
            return _service.Locations.Find(id);
        }

        public List<Room> GetRoomsForLocation(int id)
        {
            return _service.Rooms.Where(r => r.LocationId == id).ToList();
        }

        public void SmartBoardRooms(int id)
        {
            List<Room> empty=new List<Room>();
            empty= _service.Rooms.Where(r => r.SmartBoard == true && r.LocationId==id).ToList();
            if (empty != null)
            {
                _service.Locations.Where(l => l.LocationId == id).FirstOrDefault().SmartBoardsNr =empty.Count;
            }
        }

        public void UpdateLocation(Location l)
        {
            _service.Locations.Update(l);
            _service.SaveChanges();
        }

        public List<Location> SearchByName(string searchCriteria)
        {
            return _service.Locations.Where(l => l.Name.StartsWith(searchCriteria)).ToList();
        }
    }
}

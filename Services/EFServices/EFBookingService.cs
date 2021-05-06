﻿using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace StudyroomBookingZealand.Services.EFServices
{
    public class EFBookingService : IBooking
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

        public Group GetGroupForBooking(int id)
        {
            return _service.Groups.Where(g => g.GroupId == id).FirstOrDefault();
        }

        public Location LocationForBooking(int id)
        {
            return _service.Locations.Where(l => l.LocationId == id).FirstOrDefault();
        }

        public void UpdateBooking(int id)
        {
            _service.Bookings.Update(GetBookingById(id));
            _service.SaveChanges();
        }

        public List<Booking> BookingsForLocation(int id)
        {
            return _service.Bookings.Where(b => b.LocationId == id).ToList();
        }
    }
}
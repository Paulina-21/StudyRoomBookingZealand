using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudyroomBookingZealand.Pages.Shared;

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
        public List<Room> GetAllRoomsForLocation(int locationid)
        {
            return _service.Rooms.Where(r => r.LocationId == locationid).ToList();
        }
        public List<Booking> GetBookingsForRoom(int id)
        {
            return _service.Bookings.Where(b => b.RoomId == id).ToList();
        }

        public Room GetRoomById(int id)
        {
            return _service.Rooms.Find(id);
        }

        public List<Room> BigRooms()
        {
            return _service.Rooms.Where(r=>r.Big==true).ToList();
        }

        public void UpdateRoom(Room r)
        {
            _service.Rooms.Update(r);
            _service.SaveChanges();
        }

        public List<Room> SearchbyName(string searchCriteria)
        {

                return _service.Rooms.Where(r => r.Name.StartsWith(searchCriteria)).ToList();
        }

        public List<Room> SearchByNameAndLocId(string searchCriteria, int id)
        {
            return _service.Rooms.Where(r => r.LocationId == id && r.Name.StartsWith(searchCriteria)).ToList();
        }
        public int CheckAvailability(int roomid, DateTime date) //returns 2 if all seats are available, 1 if only one seat is left, 0 if none
        {
            if (_service.Rooms.Find(roomid).Big == true)
            {
                switch (_service.Bookings.Where(b => b.RoomId == roomid && b.Active==true).Where(b => b.FromDateTime == date).ToList().Count)
                {
                    case 0:
                        return 2;
                    case 1:
                        return 1;
                    case 2:
                        return 0;
                    default:
                        return 0;
                }
            }
            else if (_service.Bookings.Where(b => b.RoomId == roomid && b.Active==true).Where(b => b.FromDateTime == date).ToList().Count == 0)
            {
                return 2;
            }
            else return 0;
        }
    }
}
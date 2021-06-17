using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyroomBookingZealand.Services.EFServices
{
    public class EFWarningService : IWarning
    {
        private BookingDbContext _service;
        public EFWarningService(BookingDbContext db)
        {
            _service = db;
        }
        public void AddWarning(Warning w)
        {
            _service.Add(w);
            _service.SaveChanges();
        }
        public void DeleteWarning(int id)
        {
            _service.Remove(GetWarning(id));
            _service.SaveChanges();
        }
        public Warning GetWarning(int id)
        {
            return _service.Warnings.Find(id);
        }
        public List<Warning> GetWarningsForUser(int id)
        {
            return _service.Warnings.Where(w => w.UserID == id).ToList();
        }
    }
}

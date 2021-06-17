using StudyroomBookingZealand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyroomBookingZealand.Services.Interfaces
{
    public interface IWarning
    {
        public void AddWarning(Warning w);
        public void DeleteWarning(int id);
        public Warning GetWarning(int id);
        public List<Warning> GetWarningsForUser(int id);
        public void ClearWarningsForUser(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyroomBookingZealand.Models;

namespace StudyroomBookingZealand.Services.Interfaces
{
    public interface IGroups
    {
        public Group GetGroupById(int id);

        public void AddGroup(Group g);

        public void DeleteGroup(int id);

        public List<Group> GetAllGroups();

        public void UpdateGroup(int id);
    }
}

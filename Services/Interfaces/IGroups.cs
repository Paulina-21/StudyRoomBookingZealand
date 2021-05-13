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
        public void AddStudentToGroup(int groupid, int studentid);
        public void RemoveStudentFromGroup(int studentid);
        public List<User> GetStudentsFromGroup(int id);
        public bool ContainsStudent(int groupid, int studentid);
    }
}

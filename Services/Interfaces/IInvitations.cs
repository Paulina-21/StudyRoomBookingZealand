using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyroomBookingZealand.Models;

namespace StudyroomBookingZealand.Services.Interfaces
{
    public interface IInvitations
    {
        public void AddInvitation(Invitation invitation);
        public void DeleteInvitation(int id);
        public List<Invitation> GetAllInvitations();
        public Invitation GetInvitation(int id);
        public List<Invitation> GetInvitationsForUser(int userid);
        public List<Invitation> GetInvitationsFromUser(int userid);
    }
}

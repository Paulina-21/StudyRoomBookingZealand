using StudyroomBookingZealand.Models;
using StudyroomBookingZealand.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyroomBookingZealand.Services.EFServices
{
    public class EFInvitationService:IInvitations
    {
        private BookingDbContext _service;
        public EFInvitationService(BookingDbContext db)
        {
            _service = db;
        }
        public void AddInvitation(Invitation invitation)
        {
            _service.Invitations.Add(invitation);
            _service.SaveChanges();
        }
        public void DeleteInvitation(int id)
        {
            _service.Remove(GetInvitation(id));
            _service.SaveChanges();
        }
        public List<Invitation> GetAllInvitations()
        {
            return _service.Invitations.ToList();
        }
        public Invitation GetInvitation(int id)
        {
            return _service.Invitations.Find(id);
        }
        public List<Invitation> GetInvitationsForUser(int userid)
        {
            return _service.Invitations.Where(i => i.Receiver == userid).ToList();
        }
        public List<Invitation> GetInvitationsFromUser(int userid)
        {
            return _service.Invitations.Where(i => i.Sender == userid).ToList();
        }
        public bool FindInvitation(int sender, int receiver)
        {
            return _service.Invitations.Where(i => i.Sender == sender).Where(i => i.Receiver == receiver).ToList().Count > 0;
        }
    }
}

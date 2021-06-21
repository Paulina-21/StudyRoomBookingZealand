using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyroomBookingZealand.Models
{
    public class Invitation
    {
        public Invitation(int sender, int receiver)
        {
            Sender = sender;
            Receiver = receiver;
            State = state.TBD;
        }
        public int Id { set; get; }
        public int Sender { get; set; } //uses id for finding the user
        public int Receiver { get; set; }
        public enum state //unused
        {
            TBD, Accepted, Rejected
        }
        public state State
        {
            get;set;
        }
    }
}

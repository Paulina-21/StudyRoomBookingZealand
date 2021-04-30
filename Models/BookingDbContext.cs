using System;
using StudyroomBookingZealand;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudyroomBookingZealand.Models
{
    public class BookingDbContext: DbContext
    {
        public BookingDbContext() { }
        public BookingDbContext(DbContextOptions options) : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocaldb;Initial Catalog=SchoolBooking;Integrated Security=True");
            }
        }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Student> Students { set; get; }
        public virtual DbSet<Location> Locations { set; get; }
        public virtual DbSet<Admin> Teachers { set; get; }
        public virtual DbSet<User> Users { set; get; }
    }
}

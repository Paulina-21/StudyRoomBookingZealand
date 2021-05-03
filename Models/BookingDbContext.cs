using System;
using StudyroomBookingZealand;
using System.Collections.Generic;
using System.Configuration;
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
        public virtual DbSet<User> Users { set; get; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Student> Students { set; get; }
        public virtual DbSet<Location> Locations { set; get; }
        public virtual DbSet<Admin> Teachers { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocaldb;Initial Catalog=BookingDB;Integrated Security=True");
            }
        }
    }
}

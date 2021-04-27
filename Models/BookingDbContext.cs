using System;
using StudyroomBookingZealand;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudyroomBookingZealand.Models
{
    public class BookingDbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public BookingDbContext() { }
        public BookingDbContext(DbContextOptions options) : base(options)
        { }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Student> Students { set; get; }
        public virtual DbSet<Location> Locations { set; get; }
        public virtual DbSet<Teacher> Teachers { set; get; }
    }
}

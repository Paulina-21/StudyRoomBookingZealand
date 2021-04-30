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
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
                @"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookingDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public BookingDbContext() { }
        public BookingDbContext(DbContextOptions options) : base(options)
        { }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Student> Students { set; get; }
        public virtual DbSet<Location> Locations { set; get; }
        public virtual DbSet<Admin> Teachers { set; get; }

    }
}

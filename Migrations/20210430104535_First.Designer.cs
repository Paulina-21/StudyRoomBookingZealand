﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudyroomBookingZealand.Models;

namespace StudyroomBookingZealand.Migrations
{
    [DbContext(typeof(BookingDbContext))]
    [Migration("20210430104535_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudyroomBookingZealand.Models.Booking", b =>
                {
                    b.Property<int>("BookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("Student_GroupID")
                        .HasColumnType("int");

                    b.HasKey("BookingID");

                    b.HasIndex("LocationId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("StudyroomBookingZealand.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("GroupId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("StudyroomBookingZealand.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SmartBoard")
                        .HasColumnType("bit");

                    b.Property<bool>("SmartBoardBooked")
                        .HasColumnType("bit");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("StudyroomBookingZealand.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsTeacher")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("StudyroomBookingZealand.Models.Admin", b =>
                {
                    b.HasBaseType("StudyroomBookingZealand.Models.User");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("StudyroomBookingZealand.Models.Student", b =>
                {
                    b.HasBaseType("StudyroomBookingZealand.Models.User");

                    b.Property<int?>("GroupId1")
                        .HasColumnType("int");

                    b.HasIndex("GroupId1");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("StudyroomBookingZealand.Models.Booking", b =>
                {
                    b.HasOne("StudyroomBookingZealand.Models.Location", "Location")
                        .WithMany("Bookings")
                        .HasForeignKey("LocationId");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("StudyroomBookingZealand.Models.Student", b =>
                {
                    b.HasOne("StudyroomBookingZealand.Models.Group", null)
                        .WithMany("StudentList")
                        .HasForeignKey("GroupId1");
                });

            modelBuilder.Entity("StudyroomBookingZealand.Models.Group", b =>
                {
                    b.Navigation("StudentList");
                });

            modelBuilder.Entity("StudyroomBookingZealand.Models.Location", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
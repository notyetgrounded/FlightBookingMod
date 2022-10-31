﻿// <auto-generated />
using System;
using EuroTrip2.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EuroTrip2.Migrations
{
    [DbContext(typeof(FlightDBContext))]
    [Migration("20221031100526_addedTicketsAndSeatStatus")]
    partial class addedTicketsAndSeatStatus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EuroTrip2.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NextBooking_Id")
                        .HasColumnType("int");

                    b.Property<int>("PhoneNo")
                        .HasColumnType("int");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.Property<int>("Trip_Id")
                        .HasColumnType("int");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NextBooking_Id")
                        .IsUnique()
                        .HasFilter("[NextBooking_Id] IS NOT NULL");

                    b.HasIndex("Trip_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("EuroTrip2.Models.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeatCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("EuroTrip2.Models.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("IOTA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("EuroTrip2.Models.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Flight_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Flight_Id");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("EuroTrip2.Models.SeatStatus", b =>
                {
                    b.Property<int>("Seat_Id")
                        .HasColumnType("int");

                    b.Property<int>("Trip_Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsFree")
                        .HasColumnType("bit");

                    b.HasKey("Seat_Id", "Trip_Id");

                    b.HasIndex("Trip_Id");

                    b.ToTable("SeatStatus");
                });

            modelBuilder.Entity("EuroTrip2.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Booking_Id")
                        .HasColumnType("int");

                    b.Property<string>("PassagerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassengerAge")
                        .HasColumnType("int");

                    b.Property<int>("PassengerGender")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Seat_Id")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Booking_Id");

                    b.HasIndex("Seat_Id");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("EuroTrip2.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DestinationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Flight_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassengerCount")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime>("SourceTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TripRoute_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Flight_Id");

                    b.HasIndex("TripRoute_Id");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("EuroTrip2.Models.TripRoute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Destination_Id")
                        .HasColumnType("int");

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Source_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Destination_Id");

                    b.HasIndex("Source_Id");

                    b.ToTable("TripRoutes");
                });

            modelBuilder.Entity("EuroTrip2.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EuroTrip2.Models.Booking", b =>
                {
                    b.HasOne("EuroTrip2.Models.Booking", "FromBooking")
                        .WithOne("NextBooking")
                        .HasForeignKey("EuroTrip2.Models.Booking", "NextBooking_Id");

                    b.HasOne("EuroTrip2.Models.Trip", "Trip")
                        .WithMany("Bookings")
                        .HasForeignKey("Trip_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EuroTrip2.Models.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FromBooking");

                    b.Navigation("Trip");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EuroTrip2.Models.Seat", b =>
                {
                    b.HasOne("EuroTrip2.Models.Flight", "Flight")
                        .WithMany("Seats")
                        .HasForeignKey("Flight_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("EuroTrip2.Models.SeatStatus", b =>
                {
                    b.HasOne("EuroTrip2.Models.Seat", "Seat")
                        .WithMany("SeatStatuses")
                        .HasForeignKey("Seat_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EuroTrip2.Models.Trip", "Trip")
                        .WithMany("SeatStatuses")
                        .HasForeignKey("Trip_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Seat");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("EuroTrip2.Models.Ticket", b =>
                {
                    b.HasOne("EuroTrip2.Models.Booking", "Booking")
                        .WithMany("Tickets")
                        .HasForeignKey("Booking_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EuroTrip2.Models.Seat", "Seat")
                        .WithMany("Tickets")
                        .HasForeignKey("Seat_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Seat");
                });

            modelBuilder.Entity("EuroTrip2.Models.Trip", b =>
                {
                    b.HasOne("EuroTrip2.Models.Flight", "Flight")
                        .WithMany("Trips")
                        .HasForeignKey("Flight_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EuroTrip2.Models.TripRoute", "TripRoute")
                        .WithMany("Trips")
                        .HasForeignKey("TripRoute_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");

                    b.Navigation("TripRoute");
                });

            modelBuilder.Entity("EuroTrip2.Models.TripRoute", b =>
                {
                    b.HasOne("EuroTrip2.Models.Place", "Destination")
                        .WithMany("Destinations")
                        .HasForeignKey("Destination_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EuroTrip2.Models.Place", "Source")
                        .WithMany("Sources")
                        .HasForeignKey("Source_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Destination");

                    b.Navigation("Source");
                });

            modelBuilder.Entity("EuroTrip2.Models.Booking", b =>
                {
                    b.Navigation("NextBooking");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("EuroTrip2.Models.Flight", b =>
                {
                    b.Navigation("Seats");

                    b.Navigation("Trips");
                });

            modelBuilder.Entity("EuroTrip2.Models.Place", b =>
                {
                    b.Navigation("Destinations");

                    b.Navigation("Sources");
                });

            modelBuilder.Entity("EuroTrip2.Models.Seat", b =>
                {
                    b.Navigation("SeatStatuses");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("EuroTrip2.Models.Trip", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("SeatStatuses");
                });

            modelBuilder.Entity("EuroTrip2.Models.TripRoute", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("EuroTrip2.Models.User", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
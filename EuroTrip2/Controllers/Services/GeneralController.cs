﻿using EuroTrip2.Contexts;
using EuroTrip2.Models;
using EuroTrip2.ModelView;
using EuroTrip2.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Configuration;
using NuGet.Protocol;
using System.Collections.Immutable;
using System.Data;

namespace EuroTrip2.Controllers.Services
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        protected readonly FlightDBContext _context;
        public GeneralController(FlightDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Place>>> GetPlaces()
        {
            return await _context.Places.ToListAsync();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripRoute>>> GetTripRoutes()
        {
            return await _context.TripRoutes.ToListAsync();
        }

        [HttpGet]
        public ActionResult<IEnumerable<CompleteTrip>> GetOneStopTrips(int sourceId, int destinationId, DateTime sourceTime, int passengerCount)
        {
            List<CompleteTrip> completeTrips = new List<CompleteTrip>();

            var oneStopRoutes = from route1 in _context.TripRoutes.Where(x => x.Source_Id == sourceId)
                                join route2 in _context.TripRoutes.Where(x => x.Destination_Id == destinationId)
                                on route1.Destination_Id equals route2.Source_Id
                                select new List<int>() { route1.Id, route2.Id };
            foreach (var route in oneStopRoutes)
            {

                var combinations = from trip1 in _context.Trips.Where(x => x.TripRoute_Id == route[0] && x.SourceTime >= sourceTime && x.SourceTime < sourceTime.AddDays(1))
                                   from trip2 in _context.Trips.Where(x => x.TripRoute_Id == route[1] && x.SourceTime >= trip1.DestinationTime && x.SourceTime <= trip1.DestinationTime.AddDays(1))
                                   select new List<int>() { trip1.Id, trip2.Id };
                foreach (var trips in combinations)
                {
                    var completeTrip = new CompleteTrip();
                    var tripViews = new List<TripView>();
                    foreach (var tripid in trips)
                    {
                        tripViews.Add(FillTripView(tripid));
                    }
                    completeTrip.TripViews = tripViews;
                    completeTrips.Add(completeTrip);
                }
            }

            return completeTrips;

        }
        [HttpGet]
        public ActionResult<IEnumerable<TripView>> GetTrips(int sourceId, int destinationId, DateTime sourceTime, int passengerCount)
        {
            var tripRoute = _context.TripRoutes.Where(x => x.Source_Id == sourceId && x.Destination_Id == destinationId);
            //if (tripRoute == null)
            //{ return NoContent(); }

            List<TripView> Trips = new List<TripView>();

            foreach (var route in tripRoute)
            {
                var directTripIds = _context.Trips.AsNoTracking().Where(x => x.TripRoute.Id == route.Id && x.PassengerCount >= passengerCount && x.SourceTime.Date == sourceTime.Date).Select(x => x.Id).ToList();

                foreach (var tripId in directTripIds)
                {

                    var Trip = new TripView();
                    Trip = FillTripView(tripId);
                    Trips.Add(Trip);
                }
            }
            return Trips;
        }
        [NonAction]
        public TripView FillTripView(int id)
        {
            var trip = _context.Trips.AsNoTracking().Include(x => x.TripRoute).ThenInclude(x => x.Source).Include(x => x.TripRoute).ThenInclude(x => x.Destination).Include(x => x.Flight).Where(x => x.Id == id).SingleOrDefault();

            TripView tripView = new TripView();
            if (trip == null)
            {
                return tripView;
            }

            tripView.Id = trip.Id;
            tripView.FlightName = tripView.FlightName;
            tripView.SourceName = trip.TripRoute.Source.Name;
            tripView.SourceIOTA = trip.TripRoute.Source.IOTA;
            tripView.DestinationName = trip.TripRoute.Destination.Name;
            tripView.DestinationIOTA = trip.TripRoute.Destination.IOTA;
            tripView.DestinationTime = trip.DestinationTime;
            tripView.SourceTime = trip.SourceTime;
            tripView.Price = trip.Price;
            tripView.Name = trip.Name;
            tripView.PassengerCount = trip.PassengerCount;
            return tripView;

        }



        //[HttpGet]
        //public ActionResult<IEnumerable<BookingsView>> GetMyBookings(string email)
        //{

        //    var userQueary=_context.Users.Where(x=>x.Email==email);
        //    if (userQueary==null  )
        //    {
        //        return NotFound();
        //    }
        //    var user = userQueary.Include(x => x.Bookings).ThenInclude(x => x.Trip).ThenInclude(x => x.TripRoute).First();



        //    if (user.Bookings==null)
        //    {
        //        return NoContent();
        //    }
        //    var records = user.Bookings;
        //    List<BookingsView> bookings = new List<BookingsView>(); 

        //    foreach(var record in records)
        //    {
        //        BookingsView bookingsView = new BookingsView()
        //        {
        //            BookingId = record.Id,
        //            PassengerName = record.PassengerName,
        //            PassengerAge = record.PassengerAge,
        //            PassengerGender = record.PassengerGender,
        //            DateTime = record.DateTime,
        //            TripId = (int)record.Trip_Id,
        //            TripName = record.Trip.Name,
        //            Source = GetLocation(record.Trip.TripRoute.Source_Id),
        //            Destination = GetLocation(record.Trip.TripRoute.Destination_Id),
        //            Status = Enum.GetName(typeof(Options.BookingStatus),record.Status)

        //        };

        //        bookings.Add(bookingsView);
        //    }
        //    return bookings;
        //}
        [NonAction]
        public string GetLocation(int id)
        {
            return _context.Places.FirstOrDefault(x => x.Id == id).Name;
        }


        //[HttpGet]
        //public ActionResult<SeatsView> GetSeatStatusByTripId(int id )
        //{
        //    var temp = _context.Trips.Where(x => x.Id == id);
        //    if (!temp.Any())
        //    {
        //        return NotFound();
        //    }
        //    var trip = temp.AsNoTracking().Include(x => x.TripRoute).ThenInclude(x => x.Destination).Include(x => x.TripRoute).ThenInclude(x => x.Destination).Include(x=>x.TripRoute).ThenInclude(x=>x.Source).First();
        //    var seats= _context.Seats.Where(x=>x.Flight_Id==trip.Flight_Id).ToList();
        //    if (!seats.Any())
        //    {
        //        return NoContent();
        //    }
        //    var seatsView = new SeatsView();
        //    seatsView.Price=trip.Price;
        //    seatsView.TripName = trip.Name;
        //    seatsView.TripId = trip.Id;
        //    seatsView.Destination = trip.TripRoute.Destination.Name;
        //    seatsView.DestinationIOTA = trip.TripRoute.Destination.IOTA;
        //    seatsView.DestinationTime = trip.DestinationTime;
        //    seatsView.Source = trip.TripRoute.Source.Name;
        //    seatsView.SourceIOTA = trip.TripRoute.Source.IOTA;
        //    seatsView.SourceTime = trip.SourceTime;

        //    var seatStatusList = new List<SeatStatusView>();

        //    var bookedSeatsIds= _context.Bookings.Where(x=>x.Trip_Id==trip.Id && (x.Status==(int)BookingStatus.Booked || x.Status== (int)BookingStatus.Pending)).Select(x=>x.Id).ToList();
        //    foreach(var seat in seats)
        //    {
        //        var seatStatus = new SeatStatus();
        //        seatStatus.SeatName=seat.Name; 
        //        seatStatus.SeatId= seat.Id;
        //        seatStatus.Status = true;
        //        if (bookedSeatsIds.Contains(seat.Id))
        //        {
        //            seatStatus.Status = false;
        //        }
        //        seatStatusList.Add(seatStatus);
        //    }
        //    seatsView.Seats=seatStatusList;
        //    return seatsView;
        //}

    }
}

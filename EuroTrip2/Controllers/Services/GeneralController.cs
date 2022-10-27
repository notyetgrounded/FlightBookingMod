using EuroTrip2.Contexts;
using EuroTrip2.Models;
using EuroTrip2.ModelView;
using EuroTrip2.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
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
        public ActionResult<IEnumerable<TripView>> GetTrips(int source_Id, int destination_Id,DateTime sourceTime,int passengerCount)
        {
            var tripRoute=_context.TripRoutes.FirstOrDefault(x=>x.Source_Id==source_Id && x.Destination_Id==destination_Id);
            if (tripRoute == null)
            { return NoContent(); }
            var directTrips = _context.Trips.Where(x => x.TripRoute == tripRoute && x.SourceTime >= sourceTime && x.PassengerCount >= passengerCount);
            if (!directTrips.Any())
            {
                return NoContent();
            }
            directTrips=directTrips.Include(x=>x.TripRoute).ThenInclude(x=>x.Source).Include(x=>x.TripRoute).ThenInclude(x=>x.Destination).Include(x=>x.Flight);
            List<TripView> tripViews = new List<TripView>();

            foreach (var trip in directTrips)
            {
                TripView tripView = new TripView();
                tripView.TripIds.Add(trip.Id);
                tripView.FlightName = tripView.FlightName;
                tripView.Source = trip.TripRoute.Source.Name;
                tripView.SourceIOTA = trip.TripRoute.Source.IOTA;
                tripView.Destination = trip.TripRoute.Destination.Name;
                tripView.DestinationIOTA = trip.TripRoute.Destination.IOTA;
                tripView.DestinationTime = trip.DestinationTime;
                tripView.SourceTime = trip.SourceTime;
                tripView.Price = trip.Price;
                tripView.Name = trip.Name;
                tripView.stops = 0;
                tripView.SeatCount = trip.PassengerCount;
                tripViews.Add(tripView);
            }

            return tripViews;

        }

        

        [HttpGet]
        public ActionResult<MyBookingsView> GetMyBookings(string EmailId)
        {
            
            var userQueary=_context.Users.Where(x=>x.Email==EmailId);
            if (userQueary==null  )
            {
                return NotFound();
            }
            var user = userQueary.Include(x => x.Bookings).ThenInclude(x => x.Trip).ThenInclude(x => x.TripRoute).First();
            MyBookingsView myBookingsView = new MyBookingsView();
            if (user.Bookings==null)
            {
                return NoContent();
            }
            var records = user.Bookings;
            myBookingsView.Bookings = new List<BookingsView>();
            foreach(var record in records)
            {
                BookingsView bookingsView = new BookingsView()
                {
                    BookingId = record.Id,
                    PassengerName = record.PassengerName,
                    DateTime = record.DateTime,
                    TripId = (int)record.Trip_Id,
                    TripName = record.Trip.Name,
                    Source = GetLocation(record.Trip.TripRoute.Source_Id),
                    Destination = GetLocation(record.Trip.TripRoute.Destination_Id)
                };
                myBookingsView.Bookings.Append(bookingsView);
            }
            return myBookingsView;
        }
        [NonAction]
        public string GetLocation(int id)
        {
            return _context.Places.FirstOrDefault(x => x.Id == id).Name;
        }


        [HttpGet]
        public ActionResult<SeatsView> GetSeatStatusByTripId(int id )
        {
            var temp = _context.Trips.Where(x => x.Id == id);
            if (!temp.Any())
            {
                return NotFound();
            }
            var trip = temp.Include(x => x.TripRoute).ThenInclude(x => x.Destination).Include(x => x.TripRoute).ThenInclude(x => x.Destination).First();
            var seats= _context.Seats.Where(x=>x.Flight_Id==trip.Flight_Id).ToList();
            if (!seats.Any())
            {
                return NoContent();
            }
            var seatsView = new SeatsView();
            seatsView.Price=trip.Price;
            seatsView.TripName = trip.Name;
            seatsView.TripId = trip.Id;
            seatsView.Destination = trip.TripRoute.Destination.Name;
            seatsView.DestinationIOTA = trip.TripRoute.Destination.IOTA;
            seatsView.DestinationTime = trip.DestinationTime;
            seatsView.Source = trip.TripRoute.Source.Name;
            seatsView.SourceIOTA = trip.TripRoute.Source.IOTA;
            seatsView.SourceTime = trip.SourceTime;
            var bookedSeatsIds= _context.Bookings.Where(x=>x.Trip_Id==trip.Id && (x.Status==(int)BookingStatus.Booked || x.Status== (int)BookingStatus.Pending)).Select(x=>x.Id).ToList();
            foreach(var seat in seats)
            {
                var seatStatus = new SeatStatus();
                seatStatus.SeatName=seat.Name; 
                seatStatus.SeatId= seat.Id;
                seatStatus.Status = true;
                if (bookedSeatsIds.Contains(seat.Id))
                {
                    seatStatus.Status = false;
                }
                seatsView.Seats.Append(seatStatus);
            }
            return seatsView;
        }

    }
}

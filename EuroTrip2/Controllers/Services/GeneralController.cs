using EuroTrip2.Contexts;
using EuroTrip2.Models;
using EuroTrip2.ModelView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public ActionResult<TripsListVist> GetTrips(int source_Id, int destination_Id,DateTime sourceTime,int passengerCount)
        {

            var tripRoute= _context.TripRoutes.FirstOrDefault(x => x.Source_Id == source_Id && x.Destination_Id == destination_Id);
            if (tripRoute == null)
            {
                return NotFound();
            }    
            //tripRoute.Trips
            var trips = _context.Trips.Where(x=>x.TripRoute_Id == tripRoute.Id && x.SourceTime>=sourceTime && x.PassengerCount>=passengerCount).Include(x=>x.Flight).Include(x=>x.TripRoute.Source).Include(x=>x.);
            //var res = _context.Trips.Where(x=>x.TripRoute_Id==route);
            if (trips== null)
            {
                return NotFound();
            }
            TripsListVist tripsListVist = new TripsListVist();
            tripsListVist.TripsViews =  new List<TripsView>();
            var routes = _context.TripRoutes.Include(x => x.Source).Include(x => x.Destination);
            
            foreach (var trp in trips)
            {
                // loop for connecting flights
                var thisRoute = routes.First(x => x.Id == trp.Id);
                TripsView completeTrip = new TripsView();
                completeTrip.AirLines = trp.Flight.Name;
                completeTrip.Source = thisRoute.Source.Name;
                completeTrip.SourceTime = trp.SourceTime;
                //inner loop
                completeTrip.Stops += 1;
                completeTrip.Destination = thisRoute.Destination.Name;
                completeTrip.DestinationTime = trp.DestinationTime;
                completeTrip.Price += trp.Price;
                var tripView= new TripView();
                tripView.Price = trp.Price;
                tripView.Name = trp.Name;
                tripView.FlightName = trp.Flight.Name;
                tripView.Id=trp.Id;
                tripView.SeatCount = trp.PassengerCount;
                //endloop
                completeTrip.Trips.Append(tripView);
                //endloop
                tripsListVist.TripsViews.Append(completeTrip);
            }


            return tripsListVist;
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
    }
}

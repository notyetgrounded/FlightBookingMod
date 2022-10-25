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
        public ActionResult<IEnumerable<Trip>> GetTrips(int source_Id, int destination_Id,DateTime sourceTime,int passengerCount)
        {
            var tripRoute=GetTripRoute(source_Id, destination_Id);
            //tripRoute.Trips
            var res = tripRoute.Trips.Where(x=>x.SourceTime>=sourceTime && x.PassengerCount>=passengerCount);
            //var res = _context.Trips.Where(x=>x.TripRoute_Id==route);
            if (res== null)
            {
                return NotFound();
            }
            return res.ToList();
        }

        [NonAction]

        public TripRoute GetTripRoute(int source_Id, int destination_id)
        {
            return _context.TripRoutes.Include(x=>x.Trips).FirstOrDefault(x => x.Source_Id == source_Id && x.Destination_Id == destination_id);
        }

        [HttpGet]
        public async Task<ActionResult<MyBookingsView>> GetMyBookings(string EmailId)
        {
            
            var user=_context.Users.FirstOrDefault(x=>x.Email==EmailId);
            if (user==null )
            {
                return NotFound();
            }
            MyBookingsView myBookingsView = new MyBookingsView();
            if (user.Bookings==null)
            {
                return myBookingsView;
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
                    TripId = record.Trip_Id,
                    TripName = record.Trip.Name,
                    Source = record.Trip.TripRoute.Source.Name,
                    Destination = record.Trip.TripRoute.Destination.Name
                };
                myBookingsView.Bookings.Append(bookingsView);
            }
            return myBookingsView;
        }
    }
}

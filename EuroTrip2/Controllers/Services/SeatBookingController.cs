using EuroTrip2.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EuroTrip2.Controllers.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatBookingController : ControllerBase
    {
        protected readonly FlightDBContext _context;

        public SeatBookingController(FlightDBContext context)
        {
            _context=context;
        }
        public IActionResult<IEnumerable<bookin BookSeat()
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EuroTrip2.Contexts;
using EuroTrip2.Models;

namespace EuroTrip2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripRoutesController : ControllerBase
    {
        private readonly FlightDBContext _context;

        public TripRoutesController(FlightDBContext context)
        {
            _context = context;
        }

        // GET: api/TripRoutes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripRoute>>> GetTripRoutes()
        {
            return await _context.TripRoutes.ToListAsync();
        }

        // GET: api/TripRoutes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TripRoute>> GetTripRoute(int id)
        {
            var tripRoute = await _context.TripRoutes.FindAsync(id);

            if (tripRoute == null)
            {
                return NotFound();
            }

            return tripRoute;
        }

        // PUT: api/TripRoutes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTripRoute(int id, TripRoute tripRoute)
        {
            if (id != tripRoute.Id)
            {
                return BadRequest();
            }

            _context.Entry(tripRoute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripRouteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
 
        // POST: api/TripRoutes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TripRoute>> PostTripRoute(TripRoute tripRoute)
        {
            _context.TripRoutes.Add(tripRoute);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTripRoute", new { id = tripRoute.Id }, tripRoute);
        }

        // DELETE: api/TripRoutes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTripRoute(int id)
        {
            var tripRoute = await _context.TripRoutes.FindAsync(id);
            if (tripRoute == null)
            {
                return NotFound();
            }

            _context.TripRoutes.Remove(tripRoute);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TripRouteExists(int id)
        {
            return _context.TripRoutes.Any(e => e.Id == id);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using DataAshishPandey.Models;

namespace DataAshishPandey.Controllers
{
    [Produces("application/json")]
    [Route("api/Locations")]
    public class LocationsController : Controller
    {
        private AppDbContext _context;

        public LocationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Locations
        [HttpGet]
        public IEnumerable<Location> GetLocations()
        {
            return _context.Locations;
        }

        // GET: api/Locations/5
        [HttpGet("{id}", Name = "GetLocation")]
        public IActionResult GetLocation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Location location = _context.Locations.Single(m => m.LocationID == id);

            if (location == null)
            {
                return HttpNotFound();
            }

            return Ok(location);
        }

        // PUT: api/Locations/5
        [HttpPut("{id}")]
        public IActionResult PutLocation(int id, [FromBody] Location location)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != location.LocationID)
            {
                return HttpBadRequest();
            }

            _context.Entry(location).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
                {
                    return HttpNotFound();
                }
                else
                {
                    throw;
                }
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/Locations
        [HttpPost]
        public IActionResult PostLocation([FromBody] Location location)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.Locations.Add(location);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LocationExists(location.LocationID))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetLocation", new { id = location.LocationID }, location);
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public IActionResult DeleteLocation(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Location location = _context.Locations.Single(m => m.LocationID == id);
            if (location == null)
            {
                return HttpNotFound();
            }

            _context.Locations.Remove(location);
            _context.SaveChanges();

            return Ok(location);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LocationExists(int id)
        {
            return _context.Locations.Count(e => e.LocationID == id) > 0;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using DataAshishPandey.Models;

namespace DataAshishPandey.Controllers
{
    [Produces("application/json")]
    [Route("api/Movies")]
    public class MoviesController : Controller
    {
        private AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        [HttpGet]
        public IEnumerable<Movie> Getmovies()
        {
            return _context.movies;
        }

        // GET: api/Movies/5
        [HttpGet("{id}", Name = "GetMovie")]
        public IActionResult GetMovie([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Movie movie = _context.movies.Single(m => m.MovieID == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return Ok(movie);
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public IActionResult PutMovie(int id, [FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != movie.MovieID)
            {
                return HttpBadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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

        // POST: api/Movies
        [HttpPost]
        public IActionResult PostMovie([FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.movies.Add(movie);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MovieExists(movie.MovieID))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetMovie", new { id = movie.MovieID }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Movie movie = _context.movies.Single(m => m.MovieID == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            _context.movies.Remove(movie);
            _context.SaveChanges();

            return Ok(movie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovieExists(int id)
        {
            return _context.movies.Count(e => e.MovieID == id) > 0;
        }
    }
}
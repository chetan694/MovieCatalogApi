using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCatalogApi.Data;

namespace MovieCatalogApi.Controllers
{
    [Route("api/directors")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DirectorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET MOVIES BY DIRECTOR
        [HttpGet("{directorId}/movies")]
        public async Task<IActionResult> GetMoviesByDirector(int directorId)
        {
            var director = await _context.Directors
                .Include(d => d.Movies)
                .FirstOrDefaultAsync(d => d.Id == directorId);

            if (director == null)
            {
                return NotFound("Director not found");
            }

            return Ok(director.Movies);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDirector(Models.Director director)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Directors.Add(director);

            await _context.SaveChangesAsync();

            return Ok(director);
        }
    }
}
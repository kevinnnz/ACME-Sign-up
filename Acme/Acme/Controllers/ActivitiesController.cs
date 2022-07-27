using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Acme.DAL;
using Acme.Model;

namespace Acme.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly AcmeDbContext _context;

        public ActivitiesController(AcmeDbContext context)
        {
            _context = context;
        }

        // GET: api/Activities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivities()
        {
          if (_context.Activities == null)
          {
              return NotFound();
          }
            return await _context.Activities.ToListAsync();
        }
    }
}

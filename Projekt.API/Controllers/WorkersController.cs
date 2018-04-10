using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.API.Data;

namespace Projekt.API.Controllers
{
    [Route("api/[controller]")]
    public class WorkersController : Controller
    {
        private readonly DataContext _context;
        public WorkersController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> GetWorkers()
        {
            var workers = await _context.workers.ToListAsync();

            return Ok(workers);
        }
        
    }
}
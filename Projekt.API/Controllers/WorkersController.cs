using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.API.Data;
using Projekt.API.Dtos;
using Projekt.API.Models;

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

        [HttpPost("addNewWorkers")]

        public async Task<IActionResult> addWorkers([FromBody]WorkersForAddToLocalDatabaseDto workersForAddToLocalDatabaseDto)
        {

                var workerToCreate = new Worker
                    {
                        surname = workersForAddToLocalDatabaseDto.surname,
                        name = workersForAddToLocalDatabaseDto.name,
                        city = workersForAddToLocalDatabaseDto.city,
                        email = workersForAddToLocalDatabaseDto.email,
                        pass = workersForAddToLocalDatabaseDto.pass,
                        pesel = workersForAddToLocalDatabaseDto.pesel,
                        street = workersForAddToLocalDatabaseDto.street
                    };

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

        


                await _context.workers.AddAsync(workerToCreate);
                await _context.SaveChangesAsync();
                return StatusCode(201);

        }
        
    }
}
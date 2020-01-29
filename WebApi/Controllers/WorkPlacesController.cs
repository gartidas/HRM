using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkPlacesController : ControllerBase
    {
        private readonly Context _context;

        public WorkPlacesController(Context context)
        {
            _context = context;
        }

        // GET: api/WorkPlaces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkPlace>>> GetWorkplaces()
        {
            return await _context.Workplaces.ToListAsync();
        }

        // GET: api/WorkPlaces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkPlace>> GetWorkPlace(int id)
        {
            var workPlace = await _context.Workplaces.FindAsync(id);

            if (workPlace == null)
            {
                return NotFound();
            }

            return workPlace;
        }

        // PUT: api/WorkPlaces/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkPlace(int id, WorkPlace workPlace)
        {
            if (id != workPlace.ID)
            {
                return BadRequest();
            }

            _context.Entry(workPlace).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkPlaceExists(id))
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

        // POST: api/WorkPlaces
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<WorkPlace>> PostWorkPlace(WorkPlace workPlace)
        {
            _context.Workplaces.Add(workPlace);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkPlace", new { id = workPlace.ID }, workPlace);
        }

        // DELETE: api/WorkPlaces/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkPlace>> DeleteWorkPlace(int id)
        {
            var workPlace = await _context.Workplaces.FindAsync(id);
            if (workPlace == null)
            {
                return NotFound();
            }

            _context.Workplaces.Remove(workPlace);
            await _context.SaveChangesAsync();

            return workPlace;
        }

        private bool WorkPlaceExists(int id)
        {
            return _context.Workplaces.Any(e => e.ID == id);
        }
    }
}

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
    public class FormerEmployeesController : ControllerBase
    {
        private readonly Context _context;

        public FormerEmployeesController(Context context)
        {
            _context = context;
        }

        // GET: api/FormerEmployees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormerEmployee>>> GetFormerEmployees()
        {
            return await _context.FormerEmployees.ToListAsync();
        }

        // GET: api/FormerEmployees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FormerEmployee>> GetFormerEmployee(int id)
        {
            var formerEmployee = await _context.FormerEmployees.FindAsync(id);

            if (formerEmployee == null)
            {
                return NotFound();
            }

            return formerEmployee;
        }

        // PUT: api/FormerEmployees/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormerEmployee(int id, FormerEmployee formerEmployee)
        {
            if (id != formerEmployee.ID)
            {
                return BadRequest();
            }

            _context.Entry(formerEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormerEmployeeExists(id))
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

        // POST: api/FormerEmployees
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<FormerEmployee>> PostFormerEmployee(FormerEmployee formerEmployee)
        {
            _context.FormerEmployees.Add(formerEmployee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFormerEmployee", new { id = formerEmployee.ID }, formerEmployee);
        }

        // DELETE: api/FormerEmployees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FormerEmployee>> DeleteFormerEmployee(int id)
        {
            var formerEmployee = await _context.FormerEmployees.FindAsync(id);
            if (formerEmployee == null)
            {
                return NotFound();
            }

            _context.FormerEmployees.Remove(formerEmployee);
            await _context.SaveChangesAsync();

            return formerEmployee;
        }

        private bool FormerEmployeeExists(int id)
        {
            return _context.FormerEmployees.Any(e => e.ID == id);
        }
    }
}

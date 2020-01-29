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
    public class BonusesController : ControllerBase
    {
        private readonly Context _context;

        public BonusesController(Context context)
        {
            _context = context;
        }

        // GET: api/Bonuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bonus>>> GetBonuses()
        {
            return await _context.Bonuses.ToListAsync();
        }

        // GET: api/Bonuses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bonus>> GetBonus(int id)
        {
            var bonus = await _context.Bonuses.FindAsync(id);

            if (bonus == null)
            {
                return NotFound();
            }

            return bonus;
        }

        // PUT: api/Bonuses/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBonus(int id, Bonus bonus)
        {
            if (id != bonus.ID)
            {
                return BadRequest();
            }

            _context.Entry(bonus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BonusExists(id))
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

        // POST: api/Bonuses
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Bonus>> PostBonus(Bonus bonus)
        {
            _context.Bonuses.Add(bonus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBonus", new { id = bonus.ID }, bonus);
        }

        // DELETE: api/Bonuses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bonus>> DeleteBonus(int id)
        {
            var bonus = await _context.Bonuses.FindAsync(id);
            if (bonus == null)
            {
                return NotFound();
            }

            _context.Bonuses.Remove(bonus);
            await _context.SaveChangesAsync();

            return bonus;
        }

        private bool BonusExists(int id)
        {
            return _context.Bonuses.Any(e => e.ID == id);
        }
    }
}

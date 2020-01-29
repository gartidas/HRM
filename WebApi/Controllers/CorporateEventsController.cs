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
    public class CorporateEventsController : ControllerBase
    {
        private readonly Context _context;

        public CorporateEventsController(Context context)
        {
            _context = context;
        }

        // GET: api/CorporateEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CorporateEvent>>> GetCorporateEvents()
        {
            return await _context.CorporateEvents.ToListAsync();
        }

        // GET: api/CorporateEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CorporateEvent>> GetCorporateEvent(int id)
        {
            var corporateEvent = await _context.CorporateEvents.FindAsync(id);

            if (corporateEvent == null)
            {
                return NotFound();
            }

            return corporateEvent;
        }

        // PUT: api/CorporateEvents/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCorporateEvent(int id, CorporateEvent corporateEvent)
        {
            if (id != corporateEvent.ID)
            {
                return BadRequest();
            }

            _context.Entry(corporateEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorporateEventExists(id))
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

        // POST: api/CorporateEvents
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CorporateEvent>> PostCorporateEvent(CorporateEvent corporateEvent)
        {
            _context.CorporateEvents.Add(corporateEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCorporateEvent", new { id = corporateEvent.ID }, corporateEvent);
        }

        // DELETE: api/CorporateEvents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CorporateEvent>> DeleteCorporateEvent(int id)
        {
            var corporateEvent = await _context.CorporateEvents.FindAsync(id);
            if (corporateEvent == null)
            {
                return NotFound();
            }

            _context.CorporateEvents.Remove(corporateEvent);
            await _context.SaveChangesAsync();

            return corporateEvent;
        }

        private bool CorporateEventExists(int id)
        {
            return _context.CorporateEvents.Any(e => e.ID == id);
        }
    }
}

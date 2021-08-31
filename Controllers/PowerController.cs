using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using relation.Models;

namespace relation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerController : ControllerBase
    {
        private readonly RelationContext _context;

        public PowerController(RelationContext context)
        {
            _context = context;
        }

        // GET: api/Power
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Power>>> GetPower()
        {
            return await _context.Power.ToListAsync();
        }

        // GET: api/Power/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Power>> GetPower(int id)
        {
            var power = await _context.Power.FindAsync(id);

            if (power == null)
            {
                return NotFound();
            }

            return power;
        }

        // PUT: api/Power/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPower(int id, Power power)
        {
            if (id != power.Id)
            {
                return BadRequest();
            }

            _context.Entry(power).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PowerExists(id))
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

        // POST: api/Power
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Power>> PostPower(Power power)
        {
            _context.Power.Add(power);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPower", new { id = power.Id }, power);
        }

        // DELETE: api/Power/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePower(int id)
        {
            var power = await _context.Power.FindAsync(id);
            if (power == null)
            {
                return NotFound();
            }

            _context.Power.Remove(power);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PowerExists(int id)
        {
            return _context.Power.Any(e => e.Id == id);
        }
    }
}

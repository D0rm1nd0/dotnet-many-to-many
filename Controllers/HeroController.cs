using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using relation.Models;
using relation.ViewModels;

namespace relation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly RelationContext _context;

        public HeroController(RelationContext context)
        {
            _context = context;
        }

        // GET: api/Hero
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hero>>> GetHero()
        {
            return await _context.Hero.ToListAsync();
        }

        // GET: api/Hero/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> GetHero(int id)
        {
            var hero = await _context.Hero.FindAsync(id);

            if (hero == null)
            {
                return NotFound();
            }

            return hero;
        }

        // PUT: api/Hero/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHero(int id, Hero hero)
        {
            if (id != hero.Id)
            {
                return BadRequest();
            }

            _context.Entry(hero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroExists(id))
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

        // POST: api/Hero
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hero>> PostHero(HeroPowerViewModel heroViewModel)
        {
            ICollection<Power> powers = heroViewModel.Powers;
            Hero hero = heroViewModel.Hero;

            _context.Hero.Add(hero);
            await _context.SaveChangesAsync();
            await SaveHeroPowersAsync(hero, powers);

            return CreatedAtAction("GetHero", new { id = hero.Id }, hero);
        }

        private async Task SaveHeroPowersAsync(Hero hero, ICollection<Power> powers)
        {
            var heroPowers = new List<HeroPower>();
            foreach (var power in powers)
            {
                var powerId = power.Id;
                if (power.Id == 0)
                {
                    var newPower = await SaveNewPowerAsync(power);
                    powerId = newPower.Id;

                }

                heroPowers.Add(new HeroPower()
                {
                    HeroId = hero.Id,
                    PowerId = powerId
                });
            }

            _context.AddRange(heroPowers);
            await _context.SaveChangesAsync();
        }

        private async Task<Power> SaveNewPowerAsync(Power power)
        {
            _context.Power.Add(power);
            await _context.SaveChangesAsync();
            return power;
        }



        // DELETE: api/Hero/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var hero = await _context.Hero.FindAsync(id);
            if (hero == null)
            {
                return NotFound();
            }

            _context.Hero.Remove(hero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HeroExists(int id)
        {
            return _context.Hero.Any(e => e.Id == id);
        }
    }
}

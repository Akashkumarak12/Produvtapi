using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Produvtapi.Models;

namespace Produvtapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CussesController : ControllerBase
    {
        private readonly ProductContext _context;

        public CussesController(ProductContext context)
        {
            _context = context;
        }

        // GET: api/Cusses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuss>>> GetCusses()
        {
          if (_context.Cusses == null)
          {
              return NotFound();
          }
            return await _context.Cusses.ToListAsync();
        }

        // GET: api/Cusses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cuss>> GetCuss(int id)
        {
          if (_context.Cusses == null)
          {
              return NotFound();
          }
            var cuss = await _context.Cusses.FindAsync(id);

            if (cuss == null)
            {
                return NotFound();
            }

            return cuss;
        }

        // PUT: api/Cusses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuss(int id, Cuss cuss)
        {
            if (id != cuss.CusId)
            {
                return BadRequest();
            }

            _context.Entry(cuss).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CussExists(id))
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

        // POST: api/Cusses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cuss>> PostCuss(Cuss cuss)
        {
          if (_context.Cusses == null)
          {
              return Problem("Entity set 'ProductContext.Cusses'  is null.");
          }
            _context.Cusses.Add(cuss);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCuss", new { id = cuss.CusId }, cuss);
        }

        // DELETE: api/Cusses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuss(int id)
        {
            if (_context.Cusses == null)
            {
                return NotFound();
            }
            var cuss = await _context.Cusses.FindAsync(id);
            if (cuss == null)
            {
                return NotFound();
            }

            _context.Cusses.Remove(cuss);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CussExists(int id)
        {
            return (_context.Cusses?.Any(e => e.CusId == id)).GetValueOrDefault();
        }
    }
}

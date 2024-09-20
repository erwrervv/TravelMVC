using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel.WebApi.Models;

namespace Travel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTravelsController : ControllerBase
    {
        private readonly FinalContext _context;

        public ProductTravelsController(FinalContext context)
        {
            _context = context;
        }

        // GET: api/ProductTravels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductTravel>>> GetProductTravels()
        {
            return await _context.ProductTravels.Take(6).ToListAsync();
        }

        // GET: api/ProductTravels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTravel>> GetProductTravel(int id)
        {
            var productTravel = await _context.ProductTravels.FindAsync(id);

            if (productTravel == null)
            {
                return NotFound();
            }

            return Ok(productTravel);
        }

        // PUT: api/ProductTravels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductTravel(int id, ProductTravel productTravel)
        {
            if (id != productTravel.TravelId)
            {
                return BadRequest();
            }

            _context.Entry(productTravel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTravelExists(id))
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

        // POST: api/ProductTravels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductTravel>> PostProductTravel(ProductTravel productTravel)
        {
            _context.ProductTravels.Add(productTravel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductTravel", new { id = productTravel.TravelId }, productTravel);
        }

        // DELETE: api/ProductTravels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductTravel(int id)
        {
            var productTravel = await _context.ProductTravels.FindAsync(id);
            if (productTravel == null)
            {
                return NotFound();
            }

            _context.ProductTravels.Remove(productTravel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductTravelExists(int id)
        {
            return _context.ProductTravels.Any(e => e.TravelId == id);
        }
    }
}

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
    public class TravelDetailsController : ControllerBase
    {
        private readonly FinalContext _context;

        public TravelDetailsController(FinalContext context)
        {
            _context = context;
        }

        // GET: api/TravelDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelDetail>>> GetTravelDetails()
        {
            return await _context.TravelDetails.ToListAsync();
        }

        // GET: api/TravelDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TravelDetail>> GetTravelDetail(int id)
        {
            var travelDetail = await _context.TravelDetails.FindAsync(id);

            if (travelDetail == null)
            {
                return NotFound();
            }

            return travelDetail;
        }

        // PUT: api/TravelDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTravelDetail(int id, TravelDetail travelDetail)
        {
            if (id != travelDetail.TravelDetailsId)
            {
                return BadRequest();
            }

            _context.Entry(travelDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelDetailExists(id))
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

        // POST: api/TravelDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TravelDetail>> PostTravelDetail(TravelDetail travelDetail)
        {
            _context.TravelDetails.Add(travelDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTravelDetail", new { id = travelDetail.TravelDetailsId }, travelDetail);
        }

        // DELETE: api/TravelDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravelDetail(int id)
        {
            var travelDetail = await _context.TravelDetails.FindAsync(id);
            if (travelDetail == null)
            {
                return NotFound();
            }

            _context.TravelDetails.Remove(travelDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TravelDetailExists(int id)
        {
            return _context.TravelDetails.Any(e => e.TravelDetailsId == id);
        }
    }
}

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
    public class ShoprecordDetailsController : ControllerBase
    {
        private readonly FinalContext _context;

        public ShoprecordDetailsController(FinalContext context)
        {
            _context = context;
        }

        // GET: api/ShoprecordDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoprecordDetail>>> GetShoprecordDetails()
        {
            return await _context.ShoprecordDetails.ToListAsync();
        }

        // GET: api/ShoprecordDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoprecordDetail>> GetShoprecordDetail(int id)
        {
            var shoprecordDetail = await _context.ShoprecordDetails.FindAsync(id);

            if (shoprecordDetail == null)
            {
                return NotFound();
            }

            return shoprecordDetail;
        }

        // PUT: api/ShoprecordDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoprecordDetail(int id, ShoprecordDetail shoprecordDetail)
        {
            if (id != shoprecordDetail.ShoprecordDetailid)
            {
                return BadRequest();
            }

            _context.Entry(shoprecordDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoprecordDetailExists(id))
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

        // POST: api/ShoprecordDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShoprecordDetail>> PostShoprecordDetail(ShoprecordDetail shoprecordDetail)
        {
            _context.ShoprecordDetails.Add(shoprecordDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShoprecordDetail", new { id = shoprecordDetail.ShoprecordDetailid }, shoprecordDetail);
        }

        // DELETE: api/ShoprecordDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoprecordDetail(int id)
        {
            var shoprecordDetail = await _context.ShoprecordDetails.FindAsync(id);
            if (shoprecordDetail == null)
            {
                return NotFound();
            }

            _context.ShoprecordDetails.Remove(shoprecordDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShoprecordDetailExists(int id)
        {
            return _context.ShoprecordDetails.Any(e => e.ShoprecordDetailid == id);
        }
    }
}
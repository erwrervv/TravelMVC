using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel.WebApi.DTO;
using Travel.WebApi.Models;

namespace Travel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTravels1Controller : ControllerBase
    {
        private readonly FinalContext _context;

        public ProductTravels1Controller(FinalContext context)
        {
            _context = context;
        }

        // GET: api/ProductTravels1
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ProductTravel>>> GetProductTravels()
        //{
        //    return await _context.ProductTravels.ToListAsync();
        //}
        //台北
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductTravelDTOModel>>> GetProductTravels2()
        {
            var result = await _context.ProductTravels
                .Where(w => w.TravelareaId == 2)
                .Select(travel => new ProductTravelDTOModel
                {
                    TravelId = travel.TravelId,
                    TravelName = travel.TravelName,
                    AllDays = travel.AllDays,
                    TravelareaId = travel.TravelareaId,
                    TravelDatetime = travel.TravelDatetime,
                    TravelIntroduction = travel.TravelIntroduction,
                    TravelMeetingpoint = travel.TravelMeetingpoint,
                    Price = travel.Price
                })
                //.Skip(12) // 跳過前 11 筆
                .Take(6)
                .ToListAsync(); // 將 IQueryable 轉換為 List 並非同步地執行

            return Ok(result); // 使用 Ok() 來返回 200 OK 結果
        }

        // GET: api/ProductTravels1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTravel>> GetProductTravel(int id)
        {
            var productTravel = await _context.ProductTravels.FindAsync(id);

            if (productTravel == null)
            {
                return NotFound();
            }

            return productTravel;
        }

        // PUT: api/ProductTravels1/5
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

        // POST: api/ProductTravels1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductTravel>> PostProductTravel(ProductTravel productTravel)
        {
            _context.ProductTravels.Add(productTravel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductTravel", new { id = productTravel.TravelId }, productTravel);
        }

        // DELETE: api/ProductTravels1/5
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

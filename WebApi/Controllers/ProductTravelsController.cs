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
    public class ProductTravelsController : ControllerBase
    {
        private readonly finalContext _context;

        public ProductTravelsController(finalContext context)
        {
            _context = context;
        }

        // GET: api/ProductTravels
        [HttpGet]
        //基隆
        public async Task<ActionResult<IEnumerable<ProductTravelDTOModel>>> GetProductTravels()
        {
            var result = await _context.product_travel
                .Where(w => w.travelarea_id == 1)
                .Select(travel => new ProductTravelDTOModel
                {
                    TravelId = travel.travel_id,
                    TravelName = travel.travel_name,
                    AllDays = travel.All_days,
                    TravelareaId = travel.travelarea_id,
                    TravelDatetime = travel.travel_datetime,
                    TravelIntroduction =travel.travel_introduction,
                    TravelMeetingpoint = travel.travel_meetingpoint,
                    Price =travel.price,
                    Pictures =travel.pictures
                })
                .Take(6)
                .ToListAsync(); // 將 IQueryable 轉換為 List 並非同步地執行

            return Ok(result); // 使用 Ok() 來返回 200 OK 結果
        }
        //台北
        //public async Task<ActionResult<IEnumerable<ProductTravelDTOModel>>> GetProductTravels2()
        //{
        //    var result = await _context.ProductTravels
        //        .Where(w => w.TravelId == 2)
        //        .Select(travel => new ProductTravelDTOModel
        //        {
        //            TravelId = travel.TravelId,
        //            TravelName = travel.TravelName,
        //            AllDays = travel.AllDays,
        //            TravelareaId = travel.TravelareaId,
        //            TravelDatetime = travel.TravelDatetime,
        //            TravelIntroduction = travel.TravelIntroduction,
        //            TravelMeetingpoint = travel.TravelMeetingpoint,
        //            Price = travel.Price
        //        })
        //        .Skip(12) // 跳過前 11 筆
        //        .Take(6)
        //        .ToListAsync(); // 將 IQueryable 轉換為 List 並非同步地執行

        //    return Ok(result); // 使用 Ok() 來返回 200 OK 結果
        //}
        //台中
        //public async Task<ActionResult<IEnumerable<ProductTravelDTOModel>>> GetProductTravels7()
        //{
        //    var result = await _context.ProductTravels
        //        .Where(w => w.TravelId == 7)
        //        .Select(travel => new ProductTravelDTOModel
        //        {
        //            TravelId = travel.TravelId,
        //            TravelName = travel.TravelName,
        //            AllDays = travel.AllDays,
        //            TravelareaId = travel.TravelareaId,
        //            TravelDatetime = travel.TravelDatetime,
        //            TravelIntroduction = travel.TravelIntroduction,
        //            TravelMeetingpoint = travel.TravelMeetingpoint,
        //            Price = travel.Price
        //        })
        //        .Skip(24) // 跳過前 24 筆
        //        .Take(6)
        //        .ToListAsync(); // 將 IQueryable 轉換為 List 並非同步地執行

        //    return Ok(result); // 使用 Ok() 來返回 200 OK 結果
        //}
        ////台南
        //public async Task<ActionResult<IEnumerable<ProductTravelDTOModel>>> GetProductTravels11()
        //{
        //    var result = await _context.ProductTravels
        //        .Where(w => w.TravelId == 11)
        //        .Select(travel => new ProductTravelDTOModel
        //        {
        //            TravelId = travel.TravelId,
        //            TravelName = travel.TravelName,
        //            AllDays = travel.AllDays,
        //            TravelareaId = travel.TravelareaId,
        //            TravelDatetime = travel.TravelDatetime,
        //            TravelIntroduction = travel.TravelIntroduction,
        //            TravelMeetingpoint = travel.TravelMeetingpoint,
        //            Price = travel.Price
        //        })
        //        .Skip(36) // 跳過前 36 筆
        //        .Take(6)
        //        .ToListAsync(); // 將 IQueryable 轉換為 List 並非同步地執行

        //    return Ok(result); // 使用 Ok() 來返回 200 OK 結果
        //}
        ////高雄
        //public async Task<ActionResult<IEnumerable<ProductTravelDTOModel>>> GetProductTravels12()
        //{
        //    var result = await _context.ProductTravels
        //        .Where(w => w.TravelId == 12)
        //        .Select(travel => new ProductTravelDTOModel
        //        {
        //            TravelId = travel.TravelId,
        //            TravelName = travel.TravelName,
        //            AllDays = travel.AllDays,
        //            TravelareaId = travel.TravelareaId,
        //            TravelDatetime = travel.TravelDatetime,
        //            TravelIntroduction = travel.TravelIntroduction,
        //            TravelMeetingpoint = travel.TravelMeetingpoint,
        //            Price = travel.Price
        //        })
        //        .Skip(42) // 跳過前 42 筆
        //        .Take(6)
        //        .ToListAsync(); // 將 IQueryable 轉換為 List 並非同步地執行

        //    return Ok(result); // 使用 Ok() 來返回 200 OK 結果
        //}
        ////花蓮
        //public async Task<ActionResult<IEnumerable<ProductTravelDTOModel>>> GetProductTravels15()
        //{
        //    var result = await _context.ProductTravels
        //        .Where(w => w.TravelId == 15)
        //        .Select(travel => new ProductTravelDTOModel
        //        {
        //            TravelId = travel.TravelId,
        //            TravelName = travel.TravelName,
        //            AllDays = travel.AllDays,
        //            TravelareaId = travel.TravelareaId,
        //            TravelDatetime = travel.TravelDatetime,
        //            TravelIntroduction = travel.TravelIntroduction,
        //            TravelMeetingpoint = travel.TravelMeetingpoint,
        //            Price = travel.Price
        //        })
        //        .Skip(48) // 跳過前 48 筆
        //        .Take(6)
        //        .ToListAsync(); // 將 IQueryable 轉換為 List 並非同步地執行

        //    return Ok(result); // 使用 Ok() 來返回 200 OK 結果
        //}
        // GET: api/ProductTravels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTravel>> GetProductTravel(int id)
        {
            var productTravel = await _context.ProductTravel.FindAsync(id);

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

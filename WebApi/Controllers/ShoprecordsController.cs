using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel.WebApi.Models;
using Travel.WebApi.DTO;


namespace Travel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoprecordsController : ControllerBase
    {
        private readonly FinalContext _context;

        public ShoprecordsController(FinalContext context)
        {
            _context = context;
        }

        // GET: api/Shoprecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shoprecord>>> GetShoprecords()
        {
            return await _context.Shoprecords.ToListAsync();
        }

        // GET: api/Shoprecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoprecordDTO>> GetShoprecord(int id)
        {
            var shoprecordDTO = await _context.Shoprecords.FindAsync(id);

            if (shoprecordDTO == null)
            {
                return NotFound();
            }

            return Ok(shoprecordDTO);
        }

        // PUT: api/Shoprecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoprecord(int id, Shoprecord shoprecord)
        {
            if (id != shoprecord.ShopRecordid)
            {
                return BadRequest();
            }

            _context.Entry(shoprecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoprecordExists(id))
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

        // POST: api/Shoprecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShoprecordDTO>> PostShoprecord(ShoprecordDTO dto)
        {
            var shoprecord = new Shoprecord
            {
                MemberName = dto.MemberName,
                TotalPrice = dto.TotalPrice,
                MemberPhone = dto.MemberPhone,
                Address = dto.Address,
              Shoporderid = dto.Shoporderid,
                PurchaseTime = DateTime.Now,
                ExchangeStatus = true,
            };

            // 将新的实体添加到数据库
            _context.Shoprecords.Add(shoprecord);
            await _context.SaveChangesAsync();

            // 返回创建的资源，包含新生成的 ID
            return CreatedAtAction("GetShoprecord", new { id = shoprecord.ShopRecordid }, shoprecord);
        }

        //post 以id
        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateShoprecord(int id, ShoprecordDTO dto)
        {
            // 通过 id 查找现有的记录
            var shoprecord = await _context.Shoprecords.FindAsync(id);
            if (shoprecord == null)
            {
                return NotFound();
            }

            // 使用 DTO 更新实体，只更新 DTO 提供的字段
            shoprecord.MemberName = dto.MemberName;
            shoprecord.TotalPrice = dto.TotalPrice;
            shoprecord.MemberPhone = dto.MemberPhone;
            shoprecord.Address = dto.Address;
            shoprecord.Shoporderid = dto.Shoporderid;

            // 保存更改
            _context.Entry(shoprecord).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoprecordExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // 返回状态码 204（无内容）表示更新成功
            return NoContent();
        }



        // DELETE: api/Shoprecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoprecord(int id)
        {
            var shoprecord = await _context.Shoprecords.FindAsync(id);
            if (shoprecord == null)
            {
                return NotFound();
            }

            _context.Shoprecords.Remove(shoprecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShoprecordExists(int id)
        {
            return _context.Shoprecords.Any(e => e.ShopRecordid == id);
        }
    }
}

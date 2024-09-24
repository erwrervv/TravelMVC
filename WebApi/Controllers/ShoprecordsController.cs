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
        
        public async Task<ActionResult<ShoprecordDTO>> GetShopRecordDetails(int id)
        {
            var shopRecord = await _context.Shoprecords
                .Include(sr => sr.ShoprecordDetails)
                .FirstOrDefaultAsync(sr => sr.ShopRecordid == id);

            if (shopRecord == null)
            {
                return NotFound();
            }

            var shoprecordDTO = new ShoprecordDTO
            {
                ShopRecordid = shopRecord.ShopRecordid,
                MemberName = shopRecord.MemberName,
                MemberPhone = shopRecord.MemberPhone,
                Address = shopRecord.Address,
                TotalPrice = shopRecord.TotalPrice,
                PurchaseTime = shopRecord.PurchaseTime,
                ExchangeStatus = shopRecord.ExchangeStatus,
                AllProducts = shopRecord.ShoprecordDetails.Select(d => new ShoprecordDetailDTO
                {
                    MallProductTableId = d.MallProductTableId,
                    MallProductName = d.MallProductName,
                    MallProductQuantity = d.MallProductQuantity
                }).ToList()
            };

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
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
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

                    //這邊是9/24新加的部分
                    int shopRecordId = shoprecord.ShopRecordid;

                    foreach (var product in dto.AllProducts)
                    {
                        var shoprecordDetail = new ShoprecordDetail
                        {
                            ShopRecordid = shopRecordId, // 關聯主表
                            MallProductTableId = product.MallProductTableId,
                            MallProductName = product.MallProductName,
                            MallProductQuantity = product.MallProductQuantity,
                           
                        };

                        _context.ShoprecordDetails.Add(shoprecordDetail);
                    }
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Ok((new { shopRecordid = shoprecord.ShopRecordid }));
                }
                catch (Exception ex)
                {
                    // 回滾事務
                    await transaction.RollbackAsync();

                }
                return StatusCode(500, "訂單處理發生錯誤" );
            }

        

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

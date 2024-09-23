using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel.WebApi.Models;
using Travel.WebApi.ViewModels;
namespace Travel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicMemberInformationsController : ControllerBase
    {
        private readonly finalContext _context;

        public BasicMemberInformationsController(finalContext context)
        {
            _context = context;
        }
        //------------tes------------------
        // GET: api/BasicMemberInformations/GetPicture/5
        [HttpGet("GetPicture/{id}")]
        public async Task<IActionResult> GetPicture(int id)
        {
            var BasicMemberInformations = await _context.BasicMemberInformations
                .FirstOrDefaultAsync(a => a.MemberuniqueId == id);

            if (BasicMemberInformations == null || BasicMemberInformations.MemberPicture == null)
            {
                return NotFound();
            }

            string mimeType = "image/png"; // 根據圖片後綴調整
            return File(BasicMemberInformations.MemberPicture, mimeType);
        }
        // GET: api/BasicMemberInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasicMemberInformation>>> GetBasicMemberInformations()
        {
            return await _context.BasicMemberInformations.ToListAsync();
        }

        // GET: api/BasicMemberInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BasicMemberInformation>> GetBasicMemberInformation(int id)
        {
            var basicMemberInformation = await _context.BasicMemberInformations.FindAsync(id);

            if (basicMemberInformation == null)
            {
                return NotFound();
            }

            return basicMemberInformation;
        }

        // PUT: api/BasicMemberInformations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBasicMemberInformation(int id, BasicMemberInformation basicMemberInformation)
        {
            if (id != basicMemberInformation.MemberuniqueId)
            {
                return BadRequest();
            }

            _context.Entry(basicMemberInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BasicMemberInformationExists(id))
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

        // POST: api/BasicMemberInformations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BasicMemberInformation>> PostBasicMemberInformation(BasicMemberInformation basicMemberInformation)
        {
            _context.BasicMemberInformations.Add(basicMemberInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBasicMemberInformation", new { id = basicMemberInformation.MemberuniqueId }, basicMemberInformation);
        }

        // DELETE: api/BasicMemberInformations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasicMemberInformation(int id)
        {
            var basicMemberInformation = await _context.BasicMemberInformations.FindAsync(id);
            if (basicMemberInformation == null)
            {
                return NotFound();
            }

            _context.BasicMemberInformations.Remove(basicMemberInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BasicMemberInformationExists(int id)
        {
            return _context.BasicMemberInformations.Any(e => e.MemberuniqueId == id);
        }
    }
}

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
    public class MallProductTablesController : ControllerBase
    {
        private readonly FinalContext _context;

        public MallProductTablesController(FinalContext context)
        {
            _context = context;
        }

        // GET: api/MallProductTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MallProductTable>>> GetMallProductTables()
        {
            return await _context.MallProductTables.ToListAsync();
        }

        // GET: api/MallProductTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MallProductTable>> GetMallProductTable(int id)
        {
            var mallProductTable = await _context.MallProductTables.FindAsync(id);

            if (mallProductTable == null)
            {
                return NotFound();
            }

            return mallProductTable;
        }

        // PUT: api/MallProductTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMallProductTable(int id, MallProductTable mallProductTable)
        {
            if (id != mallProductTable.MallProductTableId)
            {
                return BadRequest();
            }

            _context.Entry(mallProductTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MallProductTableExists(id))
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

        // POST: api/MallProductTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MallProductTable>> PostMallProductTable(MallProductTable mallProductTable)
        {
            _context.MallProductTables.Add(mallProductTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMallProductTable", new { id = mallProductTable.MallProductTableId }, mallProductTable);
        }

        // DELETE: api/MallProductTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMallProductTable(int id)
        {
            var mallProductTable = await _context.MallProductTables.FindAsync(id);
            if (mallProductTable == null)
            {
                return NotFound();
            }

            _context.MallProductTables.Remove(mallProductTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MallProductTableExists(int id)
        {
            return _context.MallProductTables.Any(e => e.MallProductTableId == id);
        }
    }
}

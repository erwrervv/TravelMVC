using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Travel.Admin.Models;

namespace Travel.Admin.Controllers
{
    public class MallProductTablesController : Controller
    {
        private readonly FinalContext _context;

        public MallProductTablesController(FinalContext context)
        {
            _context = context;
        }

        // GET: MallProductTables
        public async Task<IActionResult> Index()
        {
            return View(await _context.MallProductTables.ToListAsync());
        }

        // GET: MallProductTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mallProductTable = await _context.MallProductTables
                .FirstOrDefaultAsync(m => m.MallProductTableId == id);
            if (mallProductTable == null)
            {
                return NotFound();
            }

            return View(mallProductTable);
        }

        // GET: MallProductTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MallProductTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MallProductTableId,MallProductId,MallProductName,GoldAmount,Pimage")] MallProductTable mallProductTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mallProductTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mallProductTable);
        }

        // GET: MallProductTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mallProductTable = await _context.MallProductTables.FindAsync(id);
            if (mallProductTable == null)
            {
                return NotFound();
            }
            return View(mallProductTable);
        }

        // POST: MallProductTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MallProductTableId,MallProductId,MallProductName,GoldAmount,Pimage")] MallProductTable mallProductTable)
        {
            if (id != mallProductTable.MallProductTableId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mallProductTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MallProductTableExists(mallProductTable.MallProductTableId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mallProductTable);
        }

        // GET: MallProductTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mallProductTable = await _context.MallProductTables
                .FirstOrDefaultAsync(m => m.MallProductTableId == id);
            if (mallProductTable == null)
            {
                return NotFound();
            }

            return View(mallProductTable);
        }

        // POST: MallProductTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mallProductTable = await _context.MallProductTables.FindAsync(id);
            if (mallProductTable != null)
            {
                _context.MallProductTables.Remove(mallProductTable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MallProductTableExists(int id)
        {
            return _context.MallProductTables.Any(e => e.MallProductTableId == id);
        }
    }
}

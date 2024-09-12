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
    public class MallProductPurchaseRecordController : Controller
    {
        private readonly FinalContext _context;

        public MallProductPurchaseRecordController(FinalContext context)
        {
            _context = context;
        }

        // GET: MallProductPurchaseRecord
        public async Task<IActionResult> Index()
        {
            var finalContext = _context.MallProductPurchaseRecords.Include(m => m.MallProductTable);
            return View(await finalContext.ToListAsync());
        }

        // GET: MallProductPurchaseRecord/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mallProductPurchaseRecord = await _context.MallProductPurchaseRecords
                .Include(m => m.MallProductTable)
                .FirstOrDefaultAsync(m => m.MprecordId == id);
            if (mallProductPurchaseRecord == null)
            {
                return NotFound();
            }

            return View(mallProductPurchaseRecord);
        }

        // GET: MallProductPurchaseRecord/Create
        public IActionResult Create()
        {
            ViewData["MallProductTableId"] = new SelectList(_context.MallProductTables, "MallProductTableId", "MallProductTableId");
            return View();
        }

        // POST: MallProductPurchaseRecord/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MprecordId,MemberName,MallProductTableId,ExchangeStatus,ExchangeTime")] MallProductPurchaseRecord mallProductPurchaseRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mallProductPurchaseRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MallProductTableId"] = new SelectList(_context.MallProductTables, "MallProductTableId", "MallProductTableId", mallProductPurchaseRecord.MallProductTableId);
            return View(mallProductPurchaseRecord);
        }

        // GET: MallProductPurchaseRecord/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mallProductPurchaseRecord = await _context.MallProductPurchaseRecords.FindAsync(id);
            if (mallProductPurchaseRecord == null)
            {
                return NotFound();
            }
            ViewData["MallProductTableId"] = new SelectList(_context.MallProductTables, "MallProductTableId", "MallProductTableId", mallProductPurchaseRecord.MallProductTableId);
            return View(mallProductPurchaseRecord);
        }

        // POST: MallProductPurchaseRecord/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MprecordId,MemberName,MallProductTableId,ExchangeStatus,ExchangeTime")] MallProductPurchaseRecord mallProductPurchaseRecord)
        {
            if (id != mallProductPurchaseRecord.MprecordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mallProductPurchaseRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MallProductPurchaseRecordExists(mallProductPurchaseRecord.MprecordId))
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
            ViewData["MallProductTableId"] = new SelectList(_context.MallProductTables, "MallProductTableId", "MallProductTableId", mallProductPurchaseRecord.MallProductTableId);
            return View(mallProductPurchaseRecord);
        }

        // GET: MallProductPurchaseRecord/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mallProductPurchaseRecord = await _context.MallProductPurchaseRecords
                .Include(m => m.MallProductTable)
                .FirstOrDefaultAsync(m => m.MprecordId == id);
            if (mallProductPurchaseRecord == null)
            {
                return NotFound();
            }

            return View(mallProductPurchaseRecord);
        }

        // POST: MallProductPurchaseRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mallProductPurchaseRecord = await _context.MallProductPurchaseRecords.FindAsync(id);
            if (mallProductPurchaseRecord != null)
            {
                _context.MallProductPurchaseRecords.Remove(mallProductPurchaseRecord);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MallProductPurchaseRecordExists(int id)
        {
            return _context.MallProductPurchaseRecords.Any(e => e.MprecordId == id);
        }
    }
}

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
    public class StoredrecordsController : Controller
    {
        private readonly FinalContext _context;

        public StoredrecordsController(FinalContext context)
        {
            _context = context;
        }

        // GET: Storedrecords
        public async Task<IActionResult> Index()
        {
            var finalContext = _context.Storedrecords.Include(s => s.GoldDenomination).Include(s => s.Memberunique);
            return View(await finalContext.ToListAsync());
        }

        // GET: Storedrecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storedrecord = await _context.Storedrecords
                .Include(s => s.GoldDenomination)
                .Include(s => s.Memberunique)
                .FirstOrDefaultAsync(m => m.StoreRecordId == id);
            if (storedrecord == null)
            {
                return NotFound();
            }

            return View(storedrecord);
        }

        // GET: Storedrecords/Create
        public IActionResult Create()
        {
            ViewData["GoldDenominationId"] = new SelectList(_context.GoldExchangeTables, "GoldDenominationId", "GoldDenominationId");
            ViewData["MemberuniqueId"] = new SelectList(_context.BasicMemberInformations, "MemberuniqueId", "MemberuniqueId");
            return View();
        }

        // POST: Storedrecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoreRecordId,MemberuniqueId,GoldDenominationId,PurchaseDate,PaymentStatus,RefundStatus")] Storedrecord storedrecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storedrecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GoldDenominationId"] = new SelectList(_context.GoldExchangeTables, "GoldDenominationId", "GoldDenominationId", storedrecord.GoldDenominationId);
            ViewData["MemberuniqueId"] = new SelectList(_context.BasicMemberInformations, "MemberuniqueId", "MemberuniqueId", storedrecord.MemberuniqueId);
            return View(storedrecord);
        }

        // GET: Storedrecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storedrecord = await _context.Storedrecords.FindAsync(id);
            if (storedrecord == null)
            {
                return NotFound();
            }
            ViewData["GoldDenominationId"] = new SelectList(_context.GoldExchangeTables, "GoldDenominationId", "GoldDenominationId", storedrecord.GoldDenominationId);
            ViewData["MemberuniqueId"] = new SelectList(_context.BasicMemberInformations, "MemberuniqueId", "MemberuniqueId", storedrecord.MemberuniqueId);
            return View(storedrecord);
        }

        // POST: Storedrecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StoreRecordId,MemberuniqueId,GoldDenominationId,PurchaseDate,PaymentStatus,RefundStatus")] Storedrecord storedrecord)
        {
            if (id != storedrecord.StoreRecordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storedrecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoredrecordExists(storedrecord.StoreRecordId))
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
            ViewData["GoldDenominationId"] = new SelectList(_context.GoldExchangeTables, "GoldDenominationId", "GoldDenominationId", storedrecord.GoldDenominationId);
            ViewData["MemberuniqueId"] = new SelectList(_context.BasicMemberInformations, "MemberuniqueId", "MemberuniqueId", storedrecord.MemberuniqueId);
            return View(storedrecord);
        }

        // GET: Storedrecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storedrecord = await _context.Storedrecords
                .Include(s => s.GoldDenomination)
                .Include(s => s.Memberunique)
                .FirstOrDefaultAsync(m => m.StoreRecordId == id);
            if (storedrecord == null)
            {
                return NotFound();
            }

            return View(storedrecord);
        }

        // POST: Storedrecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var storedrecord = await _context.Storedrecords.FindAsync(id);
            if (storedrecord != null)
            {
                _context.Storedrecords.Remove(storedrecord);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoredrecordExists(int id)
        {
            return _context.Storedrecords.Any(e => e.StoreRecordId == id);
        }
    }
}

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
    public class TravelDetailsController : Controller
    {
        private readonly FinalContext _context;

        public TravelDetailsController(FinalContext context)
        {
            _context = context;
        }

        // GET: TravelDetails
        public async Task<IActionResult> Index()
        {
            var finalContext = _context.TravelDetails.Include(t => t.Travel);
            return View(await finalContext.ToListAsync());
        }

        // GET: TravelDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelDetail = await _context.TravelDetails
                .Include(t => t.Travel)
                .FirstOrDefaultAsync(m => m.TravelDetailsId == id);
            if (travelDetail == null)
            {
                return NotFound();
            }

            return View(travelDetail);
        }

        // GET: TravelDetails/Create
        public IActionResult Create()
        {
            ViewData["TravelId"] = new SelectList(_context.ProductTravels, "TravelId", "TravelId");
            return View();
        }

        // POST: TravelDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TravelDetailsId,TravelId,TravelDetailedIntroduction,TourBus,Bus,Train,MorningName,LunchName,DinnerName,AccommodationName,WhichDay")] TravelDetail travelDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(travelDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TravelId"] = new SelectList(_context.ProductTravels, "TravelId", "TravelId", travelDetail.TravelId);
            return View(travelDetail);
        }

        // GET: TravelDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelDetail = await _context.TravelDetails.FindAsync(id);
            if (travelDetail == null)
            {
                return NotFound();
            }
            ViewData["TravelId"] = new SelectList(_context.ProductTravels, "TravelId", "TravelId", travelDetail.TravelId);
            return View(travelDetail);
        }

        // POST: TravelDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TravelDetailsId,TravelId,TravelDetailedIntroduction,TourBus,Bus,Train,MorningName,LunchName,DinnerName,AccommodationName,WhichDay")] TravelDetail travelDetail)
        {
            if (id != travelDetail.TravelDetailsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(travelDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelDetailExists(travelDetail.TravelDetailsId))
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
            ViewData["TravelId"] = new SelectList(_context.ProductTravels, "TravelId", "TravelId", travelDetail.TravelId);
            return View(travelDetail);
        }

        // GET: TravelDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelDetail = await _context.TravelDetails
                .Include(t => t.Travel)
                .FirstOrDefaultAsync(m => m.TravelDetailsId == id);
            if (travelDetail == null)
            {
                return NotFound();
            }

            return View(travelDetail);
        }

        // POST: TravelDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var travelDetail = await _context.TravelDetails.FindAsync(id);
            if (travelDetail != null)
            {
                _context.TravelDetails.Remove(travelDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelDetailExists(int id)
        {
            return _context.TravelDetails.Any(e => e.TravelDetailsId == id);
        }
    }
}

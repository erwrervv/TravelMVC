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
    public class ProductTravelsController : Controller
    {
        private readonly FinalContext _context;

        public ProductTravelsController(FinalContext context)
        {
            _context = context;
        }

        // GET: ProductTravels
        public async Task<IActionResult> Index()
        {
            var finalContext = _context.ProductTravels.Include(p => p.Travelarea);
            return View(await finalContext.ToListAsync());
        }

        // GET: ProductTravels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTravel = await _context.ProductTravels
                .Include(p => p.Travelarea)
                .FirstOrDefaultAsync(m => m.TravelId == id);
            if (productTravel == null)
            {
                return NotFound();
            }

            return View(productTravel);
        }

        // GET: ProductTravels/Create
        public IActionResult Create()
        {
            ViewData["TravelareaId"] = new SelectList(_context.TravelareaTables, "TravelareaId", "TravelareaId");
            return View();
        }

        // POST: ProductTravels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TravelId,AllDays,TravelName,TravelareaId,TravelDatetime,TravelIntroduction,TravelMeetingpoint,ProductShow,Price")] ProductTravel productTravel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productTravel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TravelareaId"] = new SelectList(_context.TravelareaTables, "TravelareaId", "TravelareaId", productTravel.TravelareaId);
            return View(productTravel);
        }

        // GET: ProductTravels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTravel = await _context.ProductTravels.FindAsync(id);
            if (productTravel == null)
            {
                return NotFound();
            }
            ViewData["TravelareaId"] = new SelectList(_context.TravelareaTables, "TravelareaId", "TravelareaId", productTravel.TravelareaId);
            return View(productTravel);
        }

        // POST: ProductTravels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TravelId,AllDays,TravelName,TravelareaId,TravelDatetime,TravelIntroduction,TravelMeetingpoint,ProductShow,Price")] ProductTravel productTravel)
        {
            if (id != productTravel.TravelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productTravel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductTravelExists(productTravel.TravelId))
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
            ViewData["TravelareaId"] = new SelectList(_context.TravelareaTables, "TravelareaId", "TravelareaId", productTravel.TravelareaId);
            return View(productTravel);
        }

        // GET: ProductTravels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTravel = await _context.ProductTravels
                .Include(p => p.Travelarea)
                .FirstOrDefaultAsync(m => m.TravelId == id);
            if (productTravel == null)
            {
                return NotFound();
            }

            return View(productTravel);
        }

        // POST: ProductTravels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productTravel = await _context.ProductTravels.FindAsync(id);
            if (productTravel != null)
            {
                _context.ProductTravels.Remove(productTravel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductTravelExists(int id)
        {
            return _context.ProductTravels.Any(e => e.TravelId == id);
        }
    }
}

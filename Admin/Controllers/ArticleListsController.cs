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
    public class ArticleListsController : Controller
    {
        private readonly FinalContext _context;

        public ArticleListsController(FinalContext context)
        {
            _context = context;
        }

        // GET: ArticleLists
        public async Task<IActionResult> Index()
        {
            var finalContext = _context.ArticleLists.Include(a => a.Memberunique);
            return View(await finalContext.ToListAsync());
        }

        // GET: ArticleLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleList = await _context.ArticleLists
                .Include(a => a.Memberunique)
                .FirstOrDefaultAsync(m => m.ArticleListId == id);
            if (articleList == null)
            {
                return NotFound();
            }

            return View(articleList);
        }

        // GET: ArticleLists/Create
        public IActionResult Create()
        {
            ViewData["MemberuniqueId"] = new SelectList(_context.BasicMemberInformations, "MemberuniqueId", "MemberName");
            return View();
        }

        // POST: ArticleLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArticleListId,ArticleListName,MemberuniqueId")] ArticleList articleList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articleList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MemberuniqueId"] = new SelectList(_context.BasicMemberInformations, "MemberuniqueId", "MemberName", articleList.MemberuniqueId);
            return View(articleList);
        }

        // GET: ArticleLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleList = await _context.ArticleLists.FindAsync(id);
            if (articleList == null)
            {
                return NotFound();
            }
            ViewData["MemberuniqueId"] = new SelectList(_context.BasicMemberInformations, "MemberuniqueId", "MemberuniqueId", articleList.MemberuniqueId);
            return View(articleList);
        }

        // POST: ArticleLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArticleListId,ArticleListName,MemberuniqueId")] ArticleList articleList)
        {
            if (id != articleList.ArticleListId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articleList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleListExists(articleList.ArticleListId))
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
            ViewData["MemberuniqueId"] = new SelectList(_context.BasicMemberInformations, "MemberuniqueId", "MemberuniqueId", articleList.MemberuniqueId);
            return View(articleList);
        }

        // GET: ArticleLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleList = await _context.ArticleLists
                .Include(a => a.Memberunique)
                .FirstOrDefaultAsync(m => m.ArticleListId == id);
            if (articleList == null)
            {
                return NotFound();
            }

            return View(articleList);
        }

        // POST: ArticleLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articleList = await _context.ArticleLists.FindAsync(id);
            if (articleList != null)
            {
                _context.ArticleLists.Remove(articleList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleListExists(int id)
        {
            return _context.ArticleLists.Any(e => e.ArticleListId == id);
        }
    }
}

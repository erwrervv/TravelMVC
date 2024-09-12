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
    public class ArticleRepositoriesController : Controller
    {
        private readonly FinalContext _context;

        public ArticleRepositoriesController(FinalContext context)
        {
            _context = context;
        }

        // GET: ArticleRepositories
        public async Task<IActionResult> Index()
        {
            var finalContext = _context.ArticleRepositories.Include(a => a.Article).Include(a => a.ArticleList);
            return View(await finalContext.ToListAsync());
        }

        // GET: ArticleRepositories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleRepository = await _context.ArticleRepositories
                .Include(a => a.Article)
                .Include(a => a.ArticleList)
                .FirstOrDefaultAsync(m => m.ArticleRepositoryId == id);
            if (articleRepository == null)
            {
                return NotFound();
            }

            return View(articleRepository);
        }

        // GET: ArticleRepositories/Create
        public IActionResult Create()
        {
            ViewData["ArticleId"] = new SelectList(_context.ArticleOverviews, "ArticleId", "ArticleName");
            ViewData["ArticleListId"] = new SelectList(_context.ArticleLists, "ArticleListId", "ArticleListName");
            return View();
        }

        // POST: ArticleRepositories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArticleRepositoryId,ArticleListId,ArticleId")] ArticleRepository articleRepository)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articleRepository);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArticleId"] = new SelectList(_context.ArticleOverviews, "ArticleId", "ArticleId", articleRepository.ArticleId);
            ViewData["ArticleListId"] = new SelectList(_context.ArticleLists, "ArticleListId", "ArticleListId", articleRepository.ArticleListId);
            return View(articleRepository);
        }

        // GET: ArticleRepositories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleRepository = await _context.ArticleRepositories.FindAsync(id);
            if (articleRepository == null)
            {
                return NotFound();
            }

            ViewData["ArticleId"] = new SelectList(_context.ArticleOverviews, "ArticleId", "ArticleName", articleRepository.ArticleId);
            ViewData["ArticleListId"] = new SelectList(_context.ArticleLists, "ArticleListId", "ArticleListName", articleRepository.ArticleListId);
            return View(articleRepository);
        }

        // POST: ArticleRepositories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArticleRepositoryId,ArticleListId,ArticleId")] ArticleRepository articleRepository)
        {
            if (id != articleRepository.ArticleRepositoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articleRepository);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleRepositoryExists(articleRepository.ArticleRepositoryId))
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
            ViewData["ArticleId"] = new SelectList(_context.ArticleOverviews, "ArticleId", "ArticleId", articleRepository.ArticleId);
            ViewData["ArticleListId"] = new SelectList(_context.ArticleLists, "ArticleListId", "ArticleListId", articleRepository.ArticleListId);
            return View(articleRepository);
        }

        // GET: ArticleRepositories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleRepository = await _context.ArticleRepositories
                .Include(a => a.Article)
                .Include(a => a.ArticleList)
                .FirstOrDefaultAsync(m => m.ArticleRepositoryId == id);
            if (articleRepository == null)
            {
                return NotFound();
            }

            return View(articleRepository);
        }

        // POST: ArticleRepositories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articleRepository = await _context.ArticleRepositories.FindAsync(id);
            if (articleRepository != null)
            {
                _context.ArticleRepositories.Remove(articleRepository);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleRepositoryExists(int id)
        {
            return _context.ArticleRepositories.Any(e => e.ArticleRepositoryId == id);
        }
    }
}

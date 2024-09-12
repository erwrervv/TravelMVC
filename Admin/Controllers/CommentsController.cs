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
    public class CommentsController : Controller
    {
        private readonly FinalContext _context;

        public CommentsController(FinalContext context)
        {
            _context = context;
        }

        // GET: Comments
        public async Task<IActionResult> Index()
        {
            var finalContext = _context.Comments.Include(c => c.Article).Include(c => c.Memberunique);
            return View(await finalContext.ToListAsync());
        }

        // GET: Comments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .Include(c => c.Article)
                .Include(c => c.Memberunique)
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // GET: Comments/Create
        public IActionResult Create()
        {
            ViewData["ArticleId"] = new SelectList(_context.ArticleOverviews, "ArticleId", "ArticleName");
            ViewData["MemberuniqueId"] = new SelectList(_context.BasicMemberInformations, "MemberuniqueId", "MemberName");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,ArticleId,MemberuniqueId,CommentContent,CommentDateTime")] Comment comment)
        {
            comment.CommentDateTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArticleId"] = new SelectList(_context.ArticleOverviews, "ArticleId", "ArticleName", comment.ArticleId);
            ViewData["MemberuniqueId"] = new SelectList(_context.BasicMemberInformations, "MemberuniqueId", "MemberName", comment.MemberuniqueId);
            return View(comment);
        }

        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .Include(c => c.Article)
                .Include(c => c.Memberunique)
                .FirstOrDefaultAsync(m => m.CommentId == id);

            if (comment == null)
            {
                return NotFound();
            }

            // 设置 ViewData 用于下拉列表
            ViewData["ArticleId"] = new SelectList(_context.ArticleOverviews, "ArticleId", "ArticleName", comment.ArticleId);
            ViewData["MemberuniqueId"] = new SelectList(_context.BasicMemberInformations, "MemberuniqueId", "MemberName", comment.MemberuniqueId);

            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommentId,ArticleId,MemberuniqueId,CommentContent,CommentDateTime")] Comment comment)
        {
            if (id != comment.CommentId)
            {
                return NotFound();
            }

            // 保留原始的 CommentDateTime 值
            var originalComment = await _context.Comments.AsNoTracking().FirstOrDefaultAsync(c => c.CommentId == id);
            if (originalComment == null)
            {
                return NotFound();
            }

            comment.CommentDateTime = originalComment.CommentDateTime; // 保持原始创建时间不变

            // 处理可能的 null 或空值
            if (string.IsNullOrWhiteSpace(comment.CommentContent))
            {
                ModelState.AddModelError("CommentContent", "Comment content cannot be empty.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.CommentId))
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

            // 如果验证失败，重新设置 ViewData 并返回视图
            ViewData["ArticleId"] = new SelectList(_context.ArticleOverviews, "ArticleId", "ArticleName", comment.ArticleId);
            ViewData["MemberuniqueId"] = new SelectList(_context.BasicMemberInformations, "MemberuniqueId", "MemberName", comment.MemberuniqueId);
            return View(comment);
        }


        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .Include(c => c.Article)
                .Include(c => c.Memberunique)
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.CommentId == id);
        }
    }
}

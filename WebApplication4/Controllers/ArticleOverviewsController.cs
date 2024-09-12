using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Travel.Admin.Models;
using Travel.Admin.ViewModels;
namespace Travel.Admin.Controllers
{
    public class ArticleOverviewsController : Controller
    {
        private readonly FinalContext _context;

        public ArticleOverviewsController(FinalContext context)
        {
            _context = context;
        }
        //// GET: 
        //public async Task<IActionResult> IndexOld()
        //{
        //    var FinalContext = _context.ArticleOverviews.Include(p => p.ArticleId);
        //    return View(await FinalContext.ToListAsync());
        //}
        [HttpGet]
        public JsonResult IndexJson()
        {
            return Json(_context.ArticleOverviews);
        }
        // GET: ArticleOverviews

        public async Task<IActionResult> Index()
        {
            var finalContext = _context.ArticleOverviews.Include(a => a.Memberunique);
            return View(await finalContext.ToListAsync());
        }
        // GET: /ArticleOverviews/GetPicture/1 /*https://localhost:7241/ArticleOverviews/GetPicture/1*/
        [HttpGet]
        //上傳圖片
        //public async Task<FileResult> GetPicture(int? id)
        //{
        //    ArticleOverview c = await _context.ArticleOverviews.FindAsync(id);
        //    byte[] ImageContent = c?.ArticleCoverImage;
        //    return File(ImageContent, "image/jpeg");
        //    if (c?.ArticleCoverImage != null)
        //    {
        //        var base64 = Convert.ToBase64String(c.ArticleCoverImage);
        //        var imgSrc = $"data:image/png;base64,{base64}";
        //        return File(c.ArticleCoverImage, "image/jpeg");
        //    }
        //    else
        //    {
        //        return File("~/images/noimage.png", "image/jpeg");
        //    }
        //}
        // GET: /Articles/GetPicture/5
        public async Task<IActionResult> GetPicture(int id)
        {
            var article = await _context.ArticleOverviews
                .FirstOrDefaultAsync(a => a.ArticleId == id);

            if (article == null || article.ArticleCoverImage == null)
            {
                return NotFound();
            }

            return File(article.ArticleCoverImage, "images/png"); // 根据实际图片类型返回正确的 MIME 类型
        }
        //public async Task<FileResult> GetPicture(int? id)
        //{
        //    var article = await _context.ArticleOverviews.FindAsync(id);

        //    if (article == null || article.ArticleCoverImage == null)
        //    {
        //        return File("~/images/noimage.png", "image/png");
        //    }

        //    return File(article.ArticleCoverImage, "image/jpeg");
        //}


        // GET: ArticleOverviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleOverview = await _context.ArticleOverviews
                .Include(a => a.Memberunique)
                .FirstOrDefaultAsync(m => m.ArticleId == id);
            if (articleOverview == null)
            {
                return NotFound();
            }

            return View(articleOverview);
        }

        // GET: ArticleOverviews/Create
        public IActionResult Create()
        {
            ViewData["MemberuniqueId"] = new SelectList(_context.BasicMemberInformations, "MemberuniqueId", "MemberName");
            return View();
        }

        // POST: ArticleOverviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArticleOverview model, IFormFile ArticleCoverImage)
        {
            model.CreateTime = DateTime.Now;
            model.UpdateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                if (ArticleCoverImage != null && ArticleCoverImage.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await ArticleCoverImage.CopyToAsync(memoryStream);
                        model.ArticleCoverImage = memoryStream.ToArray();
                    }
                }
                else
                {
                    // 用户没有上传图片时，使用默认图片
                    var defaultImagePath = Path.Combine(Directory.GetCurrentDirectory(), "~/images/noimage.png");
                    model.ArticleCoverImage = await System.IO.File.ReadAllBytesAsync(defaultImagePath);
                }

                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["MemberuniqueId"] = new SelectList(_context.BasicMemberInformations, "MemberuniqueId", "MemberName", model.MemberuniqueId);
            return View(model);
        }


        // GET: ArticleOverviews/Edit/5
        [HttpGet]

        public async Task<IActionResult> Edit(int? id)
        {
            var articleOverviews = await _context.ArticleOverviews.FindAsync(id);
            if (articleOverviews == null)
            {
                return NotFound();
            }
            if (articleOverviews.ArticleCoverImage != null)
            {
                // 将图片转换为 Base64 字符串
                var base64Image = Convert.ToBase64String(articleOverviews.ArticleCoverImage);
                var imageSrc = $"data:image/png;base64,{base64Image}";
                ViewData["ImageSrc"] = imageSrc;
            }
            return View(articleOverviews);
        }



        // POST: ArticleOverviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ArticleOverview model, IFormFile ArticleCoverImage)
        {
            if (id != model.ArticleId)
            {
                return NotFound();
            }

            var article = await _context.ArticleOverviews.FirstOrDefaultAsync(a => a.ArticleId == id);
            if (article == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                article.UpdateTime = DateTime.Now;

                // 更新其他字段
                article.ArticleName = model.ArticleName;
                article.ArticleContent = model.ArticleContent;

                if (ArticleCoverImage != null && ArticleCoverImage.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await ArticleCoverImage.CopyToAsync(memoryStream);
                        article.ArticleCoverImage = memoryStream.ToArray();
                    }
                }
                // 如果用户没有上传新图片，保持现有图片，不做任何更改

                _context.Update(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["MemberuniqueId"] = new SelectList(_context.BasicMemberInformations);
            return View(model);
        }




        // GET: ArticleOverviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleOverview = await _context.ArticleOverviews
                .Include(a => a.Memberunique)
                .FirstOrDefaultAsync(m => m.ArticleId == id);
            if (articleOverview == null)
            {
                return NotFound();
            }

            return View(articleOverview);
        }

        // POST: ArticleOverviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articleOverview = await _context.ArticleOverviews.FindAsync(id);
            if (articleOverview != null)
            {
                _context.ArticleOverviews.Remove(articleOverview);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleOverviewExists(int id)
        {
            return _context.ArticleOverviews.Any(e => e.ArticleId == id);
        }
    }
}

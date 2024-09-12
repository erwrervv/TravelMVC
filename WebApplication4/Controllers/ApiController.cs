using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using Microsoft.AspNetCore.Mvc.Rendering;
using Travel.Admin.Models;
using Travel.Admin.ViewModels;
using System;
namespace Travel.Admin.Controllers
{
    public class ApiController : Controller
    {
        private readonly FinalContext _context;
        [HttpGet]
        public JsonResult IndexJson()
        {
            return Json(_context.ArticleOverviews);
        }

        public ApiController(FinalContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var finalContext = _context.ArticleOverviews.Include(a => a.Memberunique);
            return View(await finalContext.ToListAsync());
        }
        [HttpGet("ArticleCover")]
        public IActionResult ArticleCover()
        {
            var articles = _context.ArticleOverviews
                                   .Select(a => a.ArticleCoverImage)
                                   .Distinct()
                                   .ToList();

            return Json(articles);
        }

        [HttpGet("GetArticles")]
        public IActionResult GetArticles()
        {
            var articles = _context.ArticleOverviews
                                   .Select(a => new
                                   {
                                       a.ArticleId,
                                       a.ArticleName,
                                       a.ArticleContent,
                                       a.CreateTime,
                                       a.UpdateTime,
                                       a.ArticleCoverImageString
                                   })
                                   .ToList();

            return new JsonResult(articles);
        }
        //api/Avatar/ArticleId=1
        [HttpGet("Avatar/{ArticleId}")]
        public IActionResult Avatar(int ArticleId = 1)
        {
            var article = _context.ArticleOverviews.Find(ArticleId);
            if (article != null && article.ArticleCoverImage != null)
            {
                byte[] img = article.ArticleCoverImage;
                // 根据实际图片格式设置 MIME 类型，如果知道图片格式为 PNG，则使用 "image/png"
                return File(img, "image/png");
            }
            return NotFound();
        }
    }
}
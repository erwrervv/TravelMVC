using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Travel.Admin.Models;

namespace Travel.Admin.Controllers
{
    public class HomePageController : Controller
    {
        private readonly ILogger<HomePageController> _logger;
        private readonly FinalContext _context;
        public HomePageController(FinalContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var finalContext = _context.ArticleOverviews.Include(a => a.Memberunique);
            return View(await finalContext.ToListAsync());
        }
        public JsonResult IndexJson()
        {
            return Json(_context.ArticleOverviews);
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
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
        ////api/Avatar/ArticleId=1
        //[HttpGet("Avatar/{ArticleId}")]
        //public IActionResult Avatar(int ArticleId = 1)
        //{
        //    var article = _context.ArticleOverviews.Find(ArticleId);
        //    if (article != null && article.ArticleCoverImage != null)
        //    {
        //        byte[] img = article.ArticleCoverImage;
        //        // 根据实际图片格式设置 MIME 类型，如果知道图片格式为 PNG，则使用 "image/png"
        //        return File(img, "image/png");
        //    }
        //    return NotFound();
        //}
    }
    
}

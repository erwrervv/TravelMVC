using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel.WebApi.Models;
using Travel.WebApi.ViewModels;
using Travel.WebApi.DTO;
namespace Travel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleOverviewsController : ControllerBase
    {
        private readonly FinalContext _context;

        public ArticleOverviewsController(FinalContext context)
        {
            _context = context;
        }

        //------------tes------------------
        //https://localhost:7003/api/ArticleOverviews/GetPicture/13
        // GET: api/ArticleOverviews/GetPicture/5
        [HttpGet("GetPicture/{id}")]
        public async Task<IActionResult> GetPicture(int id)
        {
            var article = await _context.ArticleOverviews
                .FirstOrDefaultAsync(a => a.ArticleId == id);

            if (article == null || article.ArticleCoverImage == null)
            {
                return NotFound();
            }

            string mimeType = "image/png"; // 根據圖片後綴調整
            return File(article.ArticleCoverImage, mimeType);
        }
        //------------------------
        // GET: api/ArticleOverviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleOverview>>> GetArticleOverviews()
        {
            try
            {
                var articles = await _context.ArticleOverviews.Include(x=>x.Memberunique).Select(x=> new ArticleOverviewsModel
                {
                    ArticleId = x.ArticleId,
                    ArticleName = x.ArticleName,
                    ArticleContent = x.ArticleContent,
                    MemberName = x.Memberunique.MemberName,
                    ArticleCoverImage = x.ArticleCoverImage,
                    CreateTime = x.CreateTime,
                    UpdateTime = x.UpdateTime,
                    
                }).ToListAsync();
                return Ok(articles); 
            }
            catch (Exception ex)
            {
                // 記錄錯誤
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleOverview>> GetArticleOverview(int id)
        {
            try
            {
                var articleOverview = await _context.ArticleOverviews.FindAsync(id);

                if (articleOverview == null)
                {
                    return NotFound();
                }

                return Ok(articleOverview); 
            }
            catch (Exception ex)
            {
                // 記錄錯誤
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        // PUT: api/ArticleOverviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticleOverview(int id, ArticleOverview articleOverview)
        {
            if (id != articleOverview.ArticleId)
            {
                return BadRequest();
            }

            _context.Entry(articleOverview).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleOverviewExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ArticleOverviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        //-----strat 本來的HttpPost-------
        //[HttpPost]
        //public async Task<ActionResult<ArticleOverview>> PostArticleOverview(ArticleOverview articleOverview)
        //{
        //    _context.ArticleOverviews.Add(articleOverview);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetArticleOverview", new { id = articleOverview.ArticleId }, articleOverview);
        //}
        //-----end 本來的HttpPost-------

        //-----嘗試post-------
        [HttpPost]
        public async Task<ActionResult<ArticleOverview>> PostArticleOverview(ArticleOverview model)
        {
            if (model == null)
            {
                return BadRequest("Invalid article data.");
            }

            // 根据前端传来的数据创建一个新的 ArticleOverview 实体
            var article = new ArticleOverview
            {
                MemberuniqueId = model.MemberuniqueId,
                ArticleName = model.ArticleName,
                ArticleContent = model.ArticleContent,
                CreateTime = model.CreateTime ?? DateTime.UtcNow,
                UpdateTime = model.UpdateTime ?? DateTime.UtcNow,
                ArticleCoverImage = model.ArticleCoverImage
            };

            _context.ArticleOverviews.Add(article);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetArticleOverview), new { id = article.ArticleId }, article);
        }
        //-----end 嘗試post-------

        // DELETE: api/ArticleOverviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticleOverview(int id)
        {
            var articleOverview = await _context.ArticleOverviews.FindAsync(id);
            if (articleOverview == null)
            {
                return NotFound();
            }

            _context.ArticleOverviews.Remove(articleOverview);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [NonAction]
        private bool ArticleOverviewExists(int id)
        {
            return _context.ArticleOverviews.Any(e => e.ArticleId == id);
        }
    }
}

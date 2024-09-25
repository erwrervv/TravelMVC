using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel.WebApi.Models;

namespace Travel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleListsController : ControllerBase
    {
        private readonly FinalContext _context;

        public ArticleListsController(FinalContext context)
        {
            _context = context;
        }

        // GET: api/ArticleLists
        [HttpGet]
        public ActionResult GetArticleLists()
        {
            var articleLists = _context.ArticleLists
            .Include(m => m.Memberunique)
            .ToList();

            var articleOverviews = _context.ArticleOverviews.ToList();

            var result = articleLists
                .Select(item => new
                {
                    ArticleListId = item.ArticleListId,
                    MemberuniqueId = item.MemberuniqueId,
                    ArticleListName = item.ArticleListName,
                    ArticleRepositories = item.ArticleRepositories,
                    MemberName = item.Memberunique.MemberName,
                    UpdateTime = articleOverviews
                        .Where(x => x.Tag == item.ArticleListName)
                        .Select(x => x.UpdateTime)
                        .ToList(),
                    PartialArticleOverviews = articleOverviews
                        .Where(x => x.Tag == item.ArticleListName)
                        .Select(x =>new 
                        {
                            Image=x.ArticleCoverImage,
                            ArticleId=x.ArticleId,
                            UpdateTime =x.UpdateTime
                        } )
                        .ToList()
                }).ToList();

            return Ok(result);

        }

        // GET: api/ArticleLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleList>> GetArticleList(int id)
        {
            var articleList = await _context.ArticleLists.FindAsync(id);

            if (articleList == null)
            {
                return NotFound();
            }

            return articleList;
        }

        // PUT: api/ArticleLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticleList(int id, ArticleList articleList)
        {
            if (id != articleList.ArticleListId)
            {
                return BadRequest();
            }

            _context.Entry(articleList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleListExists(id))
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

        // POST: api/ArticleLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArticleList>> PostArticleList(ArticleList articleList)
        {
            var data = new ArticleList()
            {
                MemberuniqueId = articleList.MemberuniqueId,
                ArticleListName = articleList.ArticleListName,
                ArticleListId = articleList.ArticleListId,
            };
            _context.ArticleLists.Add(data);
            await _context.SaveChangesAsync();

            return Ok(data);
        }

        // DELETE: api/ArticleLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticleList(int id)
        {
            var articleList = await _context.ArticleLists.FindAsync(id);
            if (articleList == null)
            {
                return NotFound();
            }

            _context.ArticleLists.Remove(articleList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArticleListExists(int id)
        {
            return _context.ArticleLists.Any(e => e.ArticleListId == id);
        }
    }
}

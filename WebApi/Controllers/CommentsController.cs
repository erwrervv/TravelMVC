using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel.WebApi.Models;
using Travel.WebApi.ViewModels;

namespace Travel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly FinalContext _context;

        public CommentsController(FinalContext context)
        {
            _context = context;
        }
        //------------tes------------------
        //https://localhost:7003/api/Comments/GetPicture/13
        // GET: api/Comments/GetPicture/5
        [HttpGet("GetPicture/{id}")]
        public async Task<IActionResult> GetPicture(int id)
        {
            var Comments = await _context.Comments
                .FirstOrDefaultAsync(a => a.CommentId == id);

            if (Comments == null || Comments.Memberunique.MemberPicture == null)
            {
                return NotFound();
            }

            string mimeType = "image/png"; // 根據圖片後綴調整
            return File(Comments.Memberunique.MemberPicture, mimeType);
        }
        //// GET: api/Comments
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        //{
        //    try
        //    {
        //        var Comment = await _context.Comments.Include(x => x.Memberunique).Select(x => new CommentModel
        //        {
        //            CommentId = x.CommentId,
        //            ArticleName = x.Article.ArticleName,
        //            CommentContent = x.CommentContent,
        //            CommentDateTime = x.CommentDateTime,
        //            MemberName = x.Memberunique.MemberName,
        //            MemberPicture = x.Memberunique.MemberPicture,

        //        }).ToListAsync();
        //        return Ok(Comment);
        //    }
        //    catch (Exception ex)
        //    {
        //        // 記錄錯誤
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}
        //---- test GET: api/Comments
        // GET: api/Comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentModel>>> GetComments([FromQuery] int articleId)
        {
            try
            {
                var comments = await _context.Comments
                    .Include(c => c.Memberunique) // 加載會員數據
                    .Include(c => c.Article) // 加載文章數據
                    .Where(c => c.Article.ArticleId == articleId) // 獲得特定 ArticleId的評論
                    .Select(c => new CommentModel
                    {
                        //CommentId = c.CommentId,
                        //ArticleName = c.Article.ArticleName,
                        CommentContent = c.CommentContent,
                        CommentDateTime = c.CommentDateTime,
                        MemberName = c.Memberunique.MemberName,
                        MemberPicture = c.Memberunique.MemberPicture,
                    })
                    .ToListAsync();

                return Ok(comments);
            }
            catch (Exception ex)
            {
                // 可以使用 _logger 記錄異常
                return StatusCode(StatusCodes.Status500InternalServerError, $"發生錯誤: {ex.Message}");
            }
        }
        //---- test GET: api/Comments
        // GET: api/Comments

        //------

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }
        //---------test[HttpGet("{id}")]*------

        //---------test[HttpGet("{id}")]*------
        // PUT: api/Comments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, Comment comment)
        {
            if (id != comment.CommentId)
            {
                return BadRequest();
            }

            _context.Entry(comment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
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

        // POST: api/Comments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComment", new { id = comment.CommentId }, comment);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.CommentId == id);
        }
    }
}

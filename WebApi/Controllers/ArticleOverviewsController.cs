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
                var articles = await _context.ArticleOverviews.Include(x => x.Memberunique).Select(x => new ArticleOverviewsModel
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
        public async Task<IActionResult> PutArticleOverview(int id, [FromBody] ArticleOverview articleOverview)
        {
            var oldarticleOverviewData = _context.ArticleOverviews.Find(id);
            if (oldarticleOverviewData == null)
            {
                return NotFound("此ID無對應文章");
            }
            
            var oldTag = oldarticleOverviewData.Tag.Split(",").Select(s => s.Trim()); //拆分原資料tag
            var newtag = articleOverview.Tag.Split(",").Select(s => s.Trim());//拆分新資料tag
            var mergeTag = oldTag.Concat(newtag).Distinct(); //先找出重複TAG並去除
            if (articleOverview.ArticleCoverImage != null)
            {
                var rootPath = Path.Combine(Directory.GetCurrentDirectory(), "images"); //找當前專案的根目錄中的images
                var directoryPath = Path.Combine(rootPath, "articleId", id.ToString()); // 組檔案相對路徑 (如果是全新文章則會創建資料夾)
                var filePath = Path.Combine(directoryPath, "1.jpg"); //ex: /images/articleId/ID/1.jpg
                await System.IO.File.WriteAllBytesAsync(filePath, articleOverview.ArticleCoverImage);//寫入資料
            }
            //以下為修改後賦值
            oldarticleOverviewData.Tag=string.Join(",", mergeTag); //用逗號組成新值
            oldarticleOverviewData.ArticlePictures = articleOverview.ArticlePictures ?? oldarticleOverviewData.ArticlePictures;
            oldarticleOverviewData.ArticleContent = articleOverview.ArticleContent ?? oldarticleOverviewData.ArticleContent;
            oldarticleOverviewData.ArticleName = articleOverview.ArticleName ?? oldarticleOverviewData.ArticleName;
            oldarticleOverviewData.UpdateTime = DateTime.Now; // 更新修改時間
            oldarticleOverviewData.MemberuniqueId = articleOverview.MemberuniqueId ?? oldarticleOverviewData.MemberuniqueId;
            if (id != articleOverview.ArticleId)
            {
                return BadRequest();
            }
            _context.Entry(oldarticleOverviewData).State = EntityState.Modified;

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
                //ArticleCoverImage = model.ArticleCoverImage,
                Tag = model.Tag,
                //ArticleCoverImageString  //規定存入格式
            };
            _context.ArticleOverviews.Add(article);
            await _context.SaveChangesAsync();
            //流程：先產生出當前資料真實ID 
            //1.交由後續組成路徑使用
            //2.ArticleCoverImageString欄位路徑組成為真實ID
            article.ArticleCoverImageString = @$"/images\articleId\{article.ArticleId}\1.jpg";
            var rootPath = Path.Combine(Directory.GetCurrentDirectory(), "images"); //找當前專案的根目錄中的images
            var directoryPath = Path.Combine(rootPath, "articleId", article.ArticleId.ToString()); // 組檔案相對路徑 (如果是全新文章則會創建資料夾)
            var filePath = Path.Combine(directoryPath, "1.jpg"); //ex: /images/articleId/ID/1.jpg
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);//判斷式: 不存在則創建              
            }
            _context.ArticleOverviews.Update(article);
            await _context.SaveChangesAsync();
            await System.IO.File.WriteAllBytesAsync(filePath, model.ArticleCoverImage);
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
        [HttpGet("GetPaged")]
        public IActionResult GetPaged([FromQuery] PageInfo page)
        {
            //初始化分頁
            if (page.PageSize <= 0) page.PageSize = 5;
            if (page.PageNumber <= 0) page.PageNumber = 1;
            var query = _context.ArticleOverviews.Include(m => m.Memberunique).AsQueryable();

            //如果有搜尋文章標題 則改變語法
            if (!string.IsNullOrEmpty(page.SearchKeyword))
            {
                query = query.Where(x => x.ArticleName.Contains(page.SearchKeyword));
            }
            else if (!string.IsNullOrEmpty(page.SearchTagName))
            {
                query = query.Where(x => x.Tag == page.SearchTagName);
            }
            //無搜尋文字則全部取回
            var result = query.OrderByDescending(x => x.UpdateTime)
              .Skip((page.PageNumber - 1) * page.PageSize) //Skip  假設目前第1頁 1-1=0 *預設筆數(5) 所以跳過0筆
              .Take(page.PageSize)//取得幾筆 (5)
              .Select(x => new
              {
                  ArticleId = x.ArticleId,
                  ArticleName = x.ArticleName,
                  ArticleContent = x.ArticleContent,
                  CreateTime = x.CreateTime,
                  ArticleCoverImage = x.ArticleCoverImage,
                  UpdateTime = x.UpdateTime,
                  MemberName = x.Memberunique.MemberName,
                  Tag = x.Tag,
                  //ImageUrl = Path.Combine("/images", "articleId", x.ArticleId.ToString(), "1.jpg")// 圖片相對的 URL 
                  ArticleCoverImageString = x.ArticleCoverImageString
              })
              .ToList();
            //計算總共筆數
            var totalActicle = query.Count();
            var pagedResult = new
            {
                TotalCount = totalActicle, //總共筆數
                PageSize = page.PageSize, //每次數量
                PageNumber = page.PageNumber, //第幾頁
                TotalPages = (int)Math.Ceiling(totalActicle / (double)page.PageSize), //總共幾個分頁
                List = result//資料源
            };
            return Ok(pagedResult);
        }
    }
}

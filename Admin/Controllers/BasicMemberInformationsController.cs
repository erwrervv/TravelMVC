using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Travel.Admin.Models;

namespace Travel.Admin.Controllers
{
    public class BasicMemberInformationsController : Controller
    {
        private readonly FinalContext _context;

        public BasicMemberInformationsController(FinalContext context)
        {
            _context = context;
        }

        // GET: /BasicMemberInformations/GetPicture/5
        public async Task<IActionResult> GetPicture(int id)
        {
            var member = await _context.BasicMemberInformations
                .FirstOrDefaultAsync(a => a.MemberuniqueId == id);

            if (member == null || member.MemberPicture == null)
            {
                return NotFound();
            }

            return File(member.MemberPicture, "image/png"); // 根据实际图片类型返回正确的 MIME 类型
        }

        // GET: BasicMemberInformations
        public async Task<IActionResult> Index()
        {
            var finalContext = _context.BasicMemberInformations.Include(b => b.Level);
            return View(await finalContext.ToListAsync());
        }

        // GET: BasicMemberInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basicMemberInformation = await _context.BasicMemberInformations
                .Include(b => b.Level)
                .FirstOrDefaultAsync(m => m.MemberuniqueId == id);
            if (basicMemberInformation == null)
            {
                return NotFound();
            }

            return View(basicMemberInformation);
        }

        // GET: BasicMemberInformations/Create
        public IActionResult Create()
        {
            ViewData["LevelId"] = new SelectList(_context.LevelTables, "LevelId", "LevelId");
            return View();
        }

        // POST: BasicMemberInformations/Create
        [HttpPost]
        public async Task<IActionResult> Create(BasicMemberInformation model, IFormFile MemberPicture)
        {
            if (ModelState.IsValid)
            {
                model.Activate = true;
                // 处理上传的图片
                if (MemberPicture != null && MemberPicture.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await MemberPicture.CopyToAsync(memoryStream);
                        model.MemberPicture = memoryStream.ToArray();  // 将图片数据保存到模型中
                    }
                }
                else
                {
                    // 用户没有上传图片时，使用默认图片
                    var defaultImagePath = Path.Combine(Directory.GetCurrentDirectory(), "~/images/unknown.png");
                    model.MemberPicture = await System.IO.File.ReadAllBytesAsync(defaultImagePath);
                }
                // 保存数据
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // 如果有错误，再次返回视图并显示错误信息
            ViewData["LevelId"] = new SelectList(_context.LevelTables, "LevelId", "LevelId", model.LevelId); // 保持下拉列表的状态
            return View(model);
        }


        // GET: BasicMemberInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basicMemberInformation = await _context.BasicMemberInformations.FindAsync(id);
            if (basicMemberInformation == null)
            {
                return NotFound();
            }
            ViewData["LevelId"] = new SelectList(_context.LevelTables, "LevelId", "LevelId", basicMemberInformation.LevelId);
            return View(basicMemberInformation);
        }

        // POST: BasicMemberInformations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BasicMemberInformation model, IFormFile MemberPicture)
        {
            if (id != model.MemberuniqueId)
            {
                return NotFound();
            }

            // 获取数据库中现有的记录
            var existingMember = await _context.BasicMemberInformations.FindAsync(id);
            if (existingMember == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // 如果用户上传了新图片，则更新图片
                if (MemberPicture != null && MemberPicture.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await MemberPicture.CopyToAsync(memoryStream);
                        existingMember.MemberPicture = memoryStream.ToArray(); // 更新图片数据
                    }
                }

                // 更新其他字段
                existingMember.MemberName = model.MemberName;
                existingMember.Activate = model.Activate;
                existingMember.Phone = model.Phone;
                existingMember.Birthday = model.Birthday;
                existingMember.Email = model.Email;
                existingMember.Password = model.Password;
                //existingMember.BeCommodity = model.BeCommodity;
                existingMember.LevelId = model.LevelId; // 更新 LevelId

                try
                {
                    _context.Update(existingMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BasicMemberInformationExists(existingMember.MemberuniqueId))
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

            ViewData["LevelId"] = new SelectList(_context.LevelTables, "LevelId", "LevelId", model.LevelId);
            return View(model);
        }

        // GET: BasicMemberInformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basicMemberInformation = await _context.BasicMemberInformations
                .Include(b => b.Level)
                .FirstOrDefaultAsync(m => m.MemberuniqueId == id);
            if (basicMemberInformation == null)
            {
                return NotFound();
            }

            return View(basicMemberInformation);
        }

        // POST: BasicMemberInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var basicMemberInformation = await _context.BasicMemberInformations.FindAsync(id);
            if (basicMemberInformation != null)
            {
                _context.BasicMemberInformations.Remove(basicMemberInformation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BasicMemberInformationExists(int id)
        {
            return _context.BasicMemberInformations.Any(e => e.MemberuniqueId == id);
        }
    }
}

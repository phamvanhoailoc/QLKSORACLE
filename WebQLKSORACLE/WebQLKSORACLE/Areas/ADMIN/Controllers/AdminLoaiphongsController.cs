using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using DiChoSaiGon.Helpper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebQLKSORACLE.Models;

namespace WebQLKSORACLE.Areas.ADMIN.Controllers
{
    [Area("ADMIN")]
    public class AdminLoaiphongsController : Controller
    {
        private readonly ModelContext _context;
        public INotyfService _notyfService { get; }

        public AdminLoaiphongsController(ModelContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: ADMIN/AdminLoaiphongs
        public async Task<IActionResult> Index()
        {
            ViewData["MaDvt"] = new SelectList(_context.Donvitiens, "MaDvt", "TenDvt");
            var modelContext = _context.Loaiphongs.Include(l => l.MaDvtNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: ADMIN/AdminLoaiphongs/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiphong = await _context.Loaiphongs
                .Include(l => l.MaDvtNavigation)
                .FirstOrDefaultAsync(m => m.MaLp == id);
            if (loaiphong == null)
            {
                return NotFound();
            }

            return View(loaiphong);
        }

        // GET: ADMIN/AdminLoaiphongs/Create
        public IActionResult Create()
        {
            ViewData["MaDvt"] = new SelectList(_context.Donvitiens, "MaDvt", "TenDvt");
            return View();
        }

        // POST: ADMIN/AdminLoaiphongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLp,TenLp,ChitietLp,TrangthaiLp,MaDvt,Dongia,SlNguoi,LGiuong, DienTich")] Loaiphong loaiphong, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            if (ModelState.IsValid)
            {
                loaiphong.TenLp = Utilities.ToTitleCase(loaiphong.TenLp);
                if (fThumb != null)
                {
                    string extension = Path.GetExtension(fThumb.FileName);
                    string imageLP = Utilities.SEOUrl(loaiphong.TenLp) + extension;
                    loaiphong.HinhLp = await Utilities.UploadFile(fThumb, @"loaiphongs", imageLP.ToLower());
                }
                if (string.IsNullOrEmpty(loaiphong.HinhLp)) loaiphong.HinhLp = "default.jpg";
                _context.Add(loaiphong);
                await _context.SaveChangesAsync();
                _notyfService.Success("Tạo thành công");
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDvt"] = new SelectList(_context.Donvitiens, "MaDvt", "MaDvt", loaiphong.MaDvt);
            return View(loaiphong);
        }

        // GET: ADMIN/AdminLoaiphongs/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiphong = await _context.Loaiphongs.FindAsync(id);
            if (loaiphong == null)
            {
                return NotFound();
            }
            ViewData["MaDvt"] = new SelectList(_context.Donvitiens, "MaDvt", "TenDvt", loaiphong.MaDvt);
            return View(loaiphong);
        }

        // POST: ADMIN/AdminLoaiphongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("MaLp,TenLp,ChitietLp,TrangthaiLp,MaDvt,Dongia,SlNguoi,LGiuong, DienTich, HinhLp")] Loaiphong loaiphong, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            if (id != loaiphong.MaLp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    loaiphong.TenLp = Utilities.ToTitleCase(loaiphong.TenLp);
                    if (fThumb != null)
                    {
                        string extension = Path.GetExtension(fThumb.FileName);
                        string imageLP = Utilities.SEOUrl(loaiphong.TenLp) + extension;
                        loaiphong.HinhLp = await Utilities.UploadFile(fThumb, @"loaiphongs", imageLP.ToLower());
                    }
                    if (string.IsNullOrEmpty(loaiphong.HinhLp)) loaiphong.HinhLp = "default.jpg";
                    _context.Update(loaiphong);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Chỉnh sửa thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiphongExists(loaiphong.MaLp))
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
            ViewData["MaDvt"] = new SelectList(_context.Donvitiens, "MaDvt", "MaDvt", loaiphong.MaDvt);
            return View(loaiphong);
        }

        // GET: ADMIN/AdminLoaiphongs/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiphong = await _context.Loaiphongs
                .Include(l => l.MaDvtNavigation)
                .FirstOrDefaultAsync(m => m.MaLp == id);
            if (loaiphong == null)
            {
                return NotFound();
            }

            return View(loaiphong);
        }

        // POST: ADMIN/AdminLoaiphongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var loaiphong = await _context.Loaiphongs.FindAsync(id);
            _context.Loaiphongs.Remove(loaiphong);
            await _context.SaveChangesAsync();
            _notyfService.Success("Xóa thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiphongExists(decimal id)
        {
            return _context.Loaiphongs.Any(e => e.MaLp == id);
        }
    }
}

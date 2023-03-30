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
using PagedList.Core;
using WebQLKSORACLE.Models;

namespace WebQLKSORACLE.Areas.ADMIN.Controllers
{
    [Area("ADMIN")]
    public class AdminPhongsController : Controller
    {
        private readonly ModelContext _context;
        public INotyfService _notyfService { get; }

        public AdminPhongsController(ModelContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: ADMIN/AdminPhongs
        public async Task<IActionResult> Index(int? page, String name)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 10;
            var Isphongs = _context.Phongs
                    .AsNoTracking()
                    .Include(t => t.MaLpNavigation)
                    .Include(c => c.MattPNavigation);
            if (!string.IsNullOrEmpty(name))
            {
                Isphongs = Isphongs
                                .Where(x => x.TenP.ToUpper().Contains(name.ToUpper()))
                                .OrderByDescending(x => x.TenP)
                                .Include(t => t.MaLpNavigation)
                                .Include(c => c.MattPNavigation);
            }

            PagedList<Phong> models = new PagedList<Phong>(Isphongs, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            ViewData["MattP"] = new SelectList(_context.TrangthaiPs, "MattP", "TenttP");
            ViewData["Malp"] = new SelectList(_context.Loaiphongs, "MaLp", "TenLp");
            return View(models);
        }

        // GET: ADMIN/AdminPhongs/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phong = await _context.Phongs
                .Include(p => p.MaLpNavigation)
                .Include(p => p.MattPNavigation)
                .FirstOrDefaultAsync(m => m.MaP == id);
            if (phong == null)
            {
                return NotFound();
            }

            return View(phong);
        }

        // GET: ADMIN/AdminPhongs/Create
        public IActionResult Create()
        {
            ViewData["MaLp"] = new SelectList(_context.Loaiphongs, "MaLp", "TenLp");
            ViewData["MattP"] = new SelectList(_context.TrangthaiPs, "MattP", "TenttP");
            return View();
        }

        // POST: ADMIN/AdminPhongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaP,TenP,MaLp,ChitietP,Hinh,MattP,Trangthai")] Phong phong, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            if (ModelState.IsValid)
            {
                phong.TenP = Utilities.ToTitleCase(phong.TenP);
                if (fThumb != null)
                {
                    string extension = Path.GetExtension(fThumb.FileName);
                    string image = Utilities.SEOUrl(phong.TenP) + extension;
                    phong.Hinh = await Utilities.UploadFile(fThumb, @"TenP", image.ToLower());
                }
                if (string.IsNullOrEmpty(phong.Hinh)) phong.Hinh = "default.jpg";
                
                _context.Add(phong);
                _notyfService.Success("Create thành công");
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            ViewData["MaLp"] = new SelectList(_context.Loaiphongs, "MaLp", "MaLp", phong.MaLp);
            ViewData["MattP"] = new SelectList(_context.TrangthaiPs, "MattP", "MattP", phong.MattP);
            return View(phong);
        }

        // GET: ADMIN/AdminPhongs/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phong = await _context.Phongs.FindAsync(id);

            if (phong == null)
            {
                return NotFound();
            }
            ViewData["MaLp"] = new SelectList(_context.Loaiphongs, "MaLp", "TenLp", phong.MaLp);
            ViewData["MattP"] = new SelectList(_context.TrangthaiPs, "MattP", "TenttP", phong.MattP);
            return View(phong);
        }

        // POST: ADMIN/AdminPhongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("MaP,TenP,MaLp,ChitietP,Hinh,MattP,Trangthai")] Phong phong, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            if (id != phong.MaP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    phong.TenP = Utilities.ToTitleCase(phong.TenP);
                    if (fThumb != null)
                    {
                        string extension = Path.GetExtension(fThumb.FileName);
                        string image = Utilities.SEOUrl(phong.TenP) + extension;
                        phong.Hinh = await Utilities.UploadFile(fThumb, @"TenP", image.ToLower());
                    }
                    if (string.IsNullOrEmpty(phong.Hinh)) phong.Hinh = "default.jpg";
                    _context.Update(phong);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("chỉnh sửa thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhongExists(phong.MaP))
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
            ViewData["MaLp"] = new SelectList(_context.Loaiphongs, "MaLp", "MaLp", phong.MaLp);
            ViewData["MattP"] = new SelectList(_context.TrangthaiPs, "MattP", "MattP", phong.MattP);
            return View(phong);
        }

        // GET: ADMIN/AdminPhongs/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phong = await _context.Phongs
                .Include(p => p.MaLpNavigation)
                .Include(p => p.MattPNavigation)
                .FirstOrDefaultAsync(m => m.MaP == id);
            if (phong == null)
            {
                return NotFound();
            }

            return View(phong);
        }

        // POST: ADMIN/AdminPhongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var phong = await _context.Phongs.FindAsync(id);
            _context.Phongs.Remove(phong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhongExists(decimal id)
        {
            return _context.Phongs.Any(e => e.MaP == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using WebQLKSORACLE.Models;

namespace WebQLKSORACLE.Areas.ADMIN.Controllers
{
    [Area("ADMIN")]
    public class AdminPhieuDatPhongsController : Controller
    {
        private readonly ModelContext _context;

        public AdminPhieuDatPhongsController(ModelContext context)
        {
            _context = context;
        }

        // GET: ADMIN/AdminPhieuDatPhongs
        public async Task<IActionResult> Index(int? page, String name)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 10;
            var Ispdphongs = _context.PhieuDatPhongs
                    .AsNoTracking()
                    .Where(x => x.MaTtdp != 101)
                    .Include(t => t.MaTtdpNavigation)
                    .Include(c => c.MaKhNavigation);

            if (!string.IsNullOrEmpty(name))
            {
                Ispdphongs = Ispdphongs
                                .Where(x => x.MaKhNavigation.TenKh.ToUpper().Contains(name.ToUpper()))
                                .OrderByDescending(x => x.MaKhNavigation.TenKh)
                                .Include(t => t.MaTtdpNavigation)
                                .Include(c => c.MaKhNavigation);
            }

            PagedList<PhieuDatPhong> models = new PagedList<PhieuDatPhong>(Ispdphongs, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            ViewData["MaKh"] = new SelectList(_context.Khachhangs, "MaKh", "TenKh");
            ViewData["MaTtdp"] = new SelectList(_context.TrangthaiDps, "MaTtdp", "TenTt");
            return View(models);
            //

        }

        // GET: ADMIN/AdminPhieuDatPhongs/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuDatPhong = await _context.PhieuDatPhongs
                .Include(p => p.MaKhNavigation)
                .Include(p => p.MaTtdpNavigation)
                .FirstOrDefaultAsync(m => m.MaDp == id);
            var ctpdp = _context.CtPdps
                                .AsNoTracking()
                                .Where(x => x.MaDp == phieuDatPhong.MaDp)
                                .Include(p => p.MaPNavigation)
                                .Include(p => p.MaDpNavigation.MaKhNavigation)
                                .Include(p => p.MaDpNavigation);

                                
            if (phieuDatPhong == null)
            {
                return NotFound();
            }

            return View(ctpdp);
        }

        // GET: ADMIN/AdminPhieuDatPhongs/Create
        public IActionResult Create()
        {
            ViewData["MaKh"] = new SelectList(_context.Khachhangs, "MaKh", "MaKh");
            ViewData["MaTtdp"] = new SelectList(_context.TrangthaiDps, "MaTtdp", "MaTtdp");
            return View();
        }

        // POST: ADMIN/AdminPhieuDatPhongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDp,MaKh,MaTtdp,NgaydenDp,NgaydiDp,NgayLapP,Tongtien,SlNgay")] PhieuDatPhong phieuDatPhong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phieuDatPhong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKh"] = new SelectList(_context.Khachhangs, "MaKh", "MaKh", phieuDatPhong.MaKh);
            ViewData["MaTtdp"] = new SelectList(_context.TrangthaiDps, "MaTtdp", "MaTtdp", phieuDatPhong.MaTtdp);
            return View(phieuDatPhong);
        }

        // GET: ADMIN/AdminPhieuDatPhongs/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuDatPhong = await _context.PhieuDatPhongs.FindAsync(id);
            if (phieuDatPhong == null)
            {
                return NotFound();
            }
            ViewData["MaKh"] = new SelectList(_context.Khachhangs, "MaKh", "MaKh", phieuDatPhong.MaKh);
            ViewData["MaTtdp"] = new SelectList(_context.TrangthaiDps, "MaTtdp", "MaTtdp", phieuDatPhong.MaTtdp);
            return View(phieuDatPhong);
        }

        // POST: ADMIN/AdminPhieuDatPhongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("MaDp,MaKh,MaTtdp,NgaydenDp,NgaydiDp,NgayLapP,Tongtien,SlNgay")] PhieuDatPhong phieuDatPhong)
        {
            if (id != phieuDatPhong.MaDp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phieuDatPhong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieuDatPhongExists(phieuDatPhong.MaDp))
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
            ViewData["MaKh"] = new SelectList(_context.Khachhangs, "MaKh", "MaKh", phieuDatPhong.MaKh);
            ViewData["MaTtdp"] = new SelectList(_context.TrangthaiDps, "MaTtdp", "MaTtdp", phieuDatPhong.MaTtdp);
            return View(phieuDatPhong);
        }

        // GET: ADMIN/AdminPhieuDatPhongs/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuDatPhong = await _context.PhieuDatPhongs
                .Include(p => p.MaKhNavigation)
                .Include(p => p.MaTtdpNavigation)
                .FirstOrDefaultAsync(m => m.MaDp == id);
            if (phieuDatPhong == null)
            {
                return NotFound();
            }

            return View(phieuDatPhong);
        }

        // POST: ADMIN/AdminPhieuDatPhongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var phieuDatPhong = await _context.PhieuDatPhongs.FindAsync(id);
            _context.PhieuDatPhongs.Remove(phieuDatPhong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhieuDatPhongExists(decimal id)
        {
            return _context.PhieuDatPhongs.Any(e => e.MaDp == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using WebQLKSORACLE.Models;

namespace WebQLKSORACLE.Areas.ADMIN.Controllers
{
    [Area("ADMIN")]
    public class AdminKhachhangsController : Controller
    {
        private readonly ModelContext _context;
        public INotyfService _notyfService { get; }
        public AdminKhachhangsController(ModelContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: ADMIN/AdminKhachhangs
        public async Task<IActionResult> Index(int? page, String name, String sdt, String email)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 10;
            var IsCustomers = _context.Khachhangs
                    .AsNoTracking();
            if (!string.IsNullOrEmpty(name))
            {
                IsCustomers = IsCustomers
                                .Where(x => x.TenKh.ToUpper().Contains(name.ToUpper()))
                                .OrderByDescending(x => x.TenKh);
            }
            else if (!string.IsNullOrEmpty(sdt))
            {
                IsCustomers = IsCustomers.Where(x => x.SdtKh.ToString().Contains(sdt));
                               
            } else if (!string.IsNullOrEmpty(email)) {
                IsCustomers = IsCustomers
                               .Where(x => x.EmailKh.ToUpper().Contains(email.ToUpper()))
                               .OrderByDescending(x => x.EmailKh);
            }
                              
            
            PagedList<Khachhang> models = new PagedList<Khachhang>(IsCustomers, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

        // GET: ADMIN/AdminKhachhangs/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhangs
                .FirstOrDefaultAsync(m => m.MaKh == id);
            if (khachhang == null)
            {
                return NotFound();
            }

            return View(khachhang);
        }

        // GET: ADMIN/AdminKhachhangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ADMIN/AdminKhachhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaKh,TenKh,EmailKh,SdtKh,MatkhauKh,TrangthaiKh,DiachiKh,Gioitinh")] Khachhang khachhang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khachhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khachhang);
        }

        // GET: ADMIN/AdminKhachhangs/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhangs.FindAsync(id);
            if (khachhang == null)
            {
                return NotFound();
            }
            return View(khachhang);
        }

        // POST: ADMIN/AdminKhachhangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("MaKh,TenKh,EmailKh,SdtKh,MatkhauKh,TrangthaiKh,DiachiKh,Gioitinh")] Khachhang khachhang)
        {
            if (id != khachhang.MaKh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khachhang);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Sửa thông tin thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhachhangExists(khachhang.MaKh))
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
            return View(khachhang);
        }

        // GET: ADMIN/AdminKhachhangs/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhangs
                .FirstOrDefaultAsync(m => m.MaKh == id);
            if (khachhang == null)
            {
                return NotFound();
            }

            return View(khachhang);
        }

        // POST: ADMIN/AdminKhachhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var khachhang = await _context.Khachhangs.FindAsync(id);
            _context.Khachhangs.Remove(khachhang);
            await _context.SaveChangesAsync();
            _notyfService.Success("Xóa thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool KhachhangExists(decimal id)
        {
            return _context.Khachhangs.Any(e => e.MaKh == id);
        }
    }
}

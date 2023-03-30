using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebQLKSORACLE.Models;

namespace WebQLKSORACLE.Areas.ADMIN.Controllers
{
    [Area("ADMIN")]
    public class AdminTrangthaiDpsController : Controller
    {
        private readonly ModelContext _context;
        public INotyfService _notyfService { get; }

        public AdminTrangthaiDpsController(ModelContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: ADMIN/AdminTrangthaiDps
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrangthaiDps.ToListAsync());
        }

        // GET: ADMIN/AdminTrangthaiDps/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trangthaiDp = await _context.TrangthaiDps
                .FirstOrDefaultAsync(m => m.MaTtdp == id);
            if (trangthaiDp == null)
            {
                return NotFound();
            }

            return View(trangthaiDp);
        }

        // GET: ADMIN/AdminTrangthaiDps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ADMIN/AdminTrangthaiDps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTtdp,TenTt,Trangthai,Chitiet")] TrangthaiDp trangthaiDp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trangthaiDp);
                await _context.SaveChangesAsync();
                _notyfService.Success("Tạo mới thành công");
                return RedirectToAction(nameof(Index));
            }
            return View(trangthaiDp);
        }

        // GET: ADMIN/AdminTrangthaiDps/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trangthaiDp = await _context.TrangthaiDps.FindAsync(id);
            if (trangthaiDp == null)
            {
                return NotFound();
            }
            return View(trangthaiDp);
        }

        // POST: ADMIN/AdminTrangthaiDps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("MaTtdp,TenTt,Trangthai,Chitiet")] TrangthaiDp trangthaiDp)
        {
            if (id != trangthaiDp.MaTtdp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trangthaiDp);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Cập nhật thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrangthaiDpExists(trangthaiDp.MaTtdp))
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
            return View(trangthaiDp);
        }

        // GET: ADMIN/AdminTrangthaiDps/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trangthaiDp = await _context.TrangthaiDps
                .FirstOrDefaultAsync(m => m.MaTtdp == id);
            if (trangthaiDp == null)
            {
                return NotFound();
            }

            return View(trangthaiDp);
        }

        // POST: ADMIN/AdminTrangthaiDps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var trangthaiDp = await _context.TrangthaiDps.FindAsync(id);
            _context.TrangthaiDps.Remove(trangthaiDp);
            await _context.SaveChangesAsync();
            _notyfService.Success("Xóa thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool TrangthaiDpExists(decimal id)
        {
            return _context.TrangthaiDps.Any(e => e.MaTtdp == id);
        }
    }
}

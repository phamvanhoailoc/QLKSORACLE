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
    public class AdminRoLesController : Controller
    {
        private readonly ModelContext _context;
        public INotyfService _notyfService { get; }

        public AdminRoLesController(ModelContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: ADMIN/AdminRoLes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoLes.ToListAsync());
        }

        // GET: ADMIN/AdminRoLes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roLe = await _context.RoLes
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (roLe == null)
            {
                return NotFound();
            }

            return View(roLe);
        }

        // GET: ADMIN/AdminRoLes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ADMIN/AdminRoLes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleId,TenR,TrangthaiR")] RoLe roLe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roLe);
                await _context.SaveChangesAsync();
                _notyfService.Success("Tạo mới thành công");
                return RedirectToAction(nameof(Index));
            }
            return View(roLe);
        }

        // GET: ADMIN/AdminRoLes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roLe = await _context.RoLes.FindAsync(id);
            if (roLe == null)
            {
                return NotFound();
            }
            return View(roLe);
        }

        // POST: ADMIN/AdminRoLes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("RoleId,TenR,TrangthaiR")] RoLe roLe)
        {
            if (id != roLe.RoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roLe);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Cập nhật thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoLeExists(roLe.RoleId))
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
            return View(roLe);
        }

        // GET: ADMIN/AdminRoLes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roLe = await _context.RoLes
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (roLe == null)
            {
                return NotFound();
            }

            return View(roLe);
        }

        // POST: ADMIN/AdminRoLes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var roLe = await _context.RoLes.FindAsync(id);
            _context.RoLes.Remove(roLe);
            await _context.SaveChangesAsync();
            _notyfService.Success("Xóa thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool RoLeExists(decimal id)
        {
            return _context.RoLes.Any(e => e.RoleId == id);
        }
    }
}

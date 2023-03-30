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
    public class AdminDonvitiensController : Controller
    {
        private readonly ModelContext _context;
        public INotyfService _notyfService { get; }

        public AdminDonvitiensController(ModelContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: ADMIN/AdminDonvitiens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Donvitiens.ToListAsync());
        }

        // GET: ADMIN/AdminDonvitiens/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donvitien = await _context.Donvitiens
                .FirstOrDefaultAsync(m => m.MaDvt == id);
            if (donvitien == null)
            {
                return NotFound();
            }

            return View(donvitien);
        }

        // GET: ADMIN/AdminDonvitiens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ADMIN/AdminDonvitiens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDvt,TenDvt")] Donvitien donvitien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donvitien);
                await _context.SaveChangesAsync();
                _notyfService.Success("Tạo mới thành công");
                return RedirectToAction(nameof(Index));
            }
            return View(donvitien);
        }

        // GET: ADMIN/AdminDonvitiens/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donvitien = await _context.Donvitiens.FindAsync(id);
            if (donvitien == null)
            {
                return NotFound();
            }
            return View(donvitien);
        }

        // POST: ADMIN/AdminDonvitiens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("MaDvt,TenDvt")] Donvitien donvitien)
        {
            if (id != donvitien.MaDvt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donvitien);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Sửa thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonvitienExists(donvitien.MaDvt))
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
            return View(donvitien);
        }

        // GET: ADMIN/AdminDonvitiens/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donvitien = await _context.Donvitiens
                .FirstOrDefaultAsync(m => m.MaDvt == id);
            if (donvitien == null)
            {
                return NotFound();
            }

            return View(donvitien);
        }

        // POST: ADMIN/AdminDonvitiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var donvitien = await _context.Donvitiens.FindAsync(id);
            _context.Donvitiens.Remove(donvitien);
            await _context.SaveChangesAsync();
            _notyfService.Success("Xóa thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool DonvitienExists(decimal id)
        {
            return _context.Donvitiens.Any(e => e.MaDvt == id);
        }
    }
}

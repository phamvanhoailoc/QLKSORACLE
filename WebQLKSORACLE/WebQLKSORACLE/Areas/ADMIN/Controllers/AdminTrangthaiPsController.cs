using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebQLKSORACLE.Models;

namespace WebQLKSORACLE.Areas.ADMIN.Controllers
{
    [Area("ADMIN")]
    public class AdminTrangthaiPsController : Controller
    {
        private readonly ModelContext _context;

        public AdminTrangthaiPsController(ModelContext context)
        {
            _context = context;
        }

        // GET: ADMIN/AdminTrangthaiPs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrangthaiPs.ToListAsync());
        }

        // GET: ADMIN/AdminTrangthaiPs/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trangthaiP = await _context.TrangthaiPs
                .FirstOrDefaultAsync(m => m.MattP == id);
            if (trangthaiP == null)
            {
                return NotFound();
            }

            return View(trangthaiP);
        }

        // GET: ADMIN/AdminTrangthaiPs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ADMIN/AdminTrangthaiPs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MattP,TenttP")] TrangthaiP trangthaiP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trangthaiP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trangthaiP);
        }

        // GET: ADMIN/AdminTrangthaiPs/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trangthaiP = await _context.TrangthaiPs.FindAsync(id);
            if (trangthaiP == null)
            {
                return NotFound();
            }
            return View(trangthaiP);
        }

        // POST: ADMIN/AdminTrangthaiPs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("MattP,TenttP")] TrangthaiP trangthaiP)
        {
            if (id != trangthaiP.MattP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trangthaiP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrangthaiPExists(trangthaiP.MattP))
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
            return View(trangthaiP);
        }

        // GET: ADMIN/AdminTrangthaiPs/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trangthaiP = await _context.TrangthaiPs
                .FirstOrDefaultAsync(m => m.MattP == id);
            if (trangthaiP == null)
            {
                return NotFound();
            }

            return View(trangthaiP);
        }

        // POST: ADMIN/AdminTrangthaiPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var trangthaiP = await _context.TrangthaiPs.FindAsync(id);
            _context.TrangthaiPs.Remove(trangthaiP);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrangthaiPExists(decimal id)
        {
            return _context.TrangthaiPs.Any(e => e.MattP == id);
        }
    }
}

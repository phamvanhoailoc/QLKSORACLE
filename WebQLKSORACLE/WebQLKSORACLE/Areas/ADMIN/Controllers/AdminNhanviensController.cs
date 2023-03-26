using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using DiChoSaiGon.Extension;
using DiChoSaiGon.Helpper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using WebQLKSORACLE.Areas.ADMIN.ModelViews;
using WebQLKSORACLE.Models;

namespace WebQLKSORACLE.Areas.ADMIN.Controllers
{
    [Area("ADMIN")]
    public class AdminNhanviensController : Controller
    {
        private readonly ModelContext _context;
        public INotyfService _notyfService { get; }

        public AdminNhanviensController(ModelContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: ADMIN/AdminNhanviens
        public async Task<IActionResult> Index(int? page, String name, String sdt, String email)
        {

            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 10;
            var IsNhanviens = _context.Nhanviens
                    .AsNoTracking() 
                    .Include(t => t.Role);
            if (!string.IsNullOrEmpty(name))
            {
                IsNhanviens = IsNhanviens
                                .Where(x => x.TenNv.ToUpper().Contains(name.ToUpper()))
                                .OrderByDescending(x => x.TenNv)
                                .Include(t => t.Role);
            }
            else if (!string.IsNullOrEmpty(sdt))
            {
                IsNhanviens = IsNhanviens
                                .Where(x => x.SdtNv.ToString().Contains(sdt))
                                .Include(t => t.Role);

            }
            else if (!string.IsNullOrEmpty(email))
            {
                IsNhanviens = IsNhanviens
                               .Where(x => x.EmailNv.ToUpper().Contains(email.ToUpper()))
                               .OrderByDescending(x => x.EmailNv)
                               .Include(t => t.Role);
            }
            PagedList<Nhanvien> models = new PagedList<Nhanvien>(IsNhanviens, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            ViewData["DanhMuc"] = new SelectList(_context.RoLes, "RoleId", "TenR");
           
            return View(models);
        }

        // GET: ADMIN/AdminNhanviens/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens
                .Include(n => n.Role)
                .FirstOrDefaultAsync(m => m.MaNv == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // GET: ADMIN/AdminNhanviens/Create
        public IActionResult Create()
        {
            ViewData["DanhMuc"] = new SelectList(_context.RoLes, "RoleId", "TenR");
            return View();
        }

        // POST: ADMIN/AdminNhanviens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterAdminVM taikhoan)
        {
            ViewData["DanhMuc"] = new SelectList(_context.RoLes, "RoleId", "TenR");
            try
            {
                if (ModelState.IsValid)
                {

                    string salt = Utilities.GetRandomKey();
                    Nhanvien tk = new Nhanvien
                    {
                        TenNv = taikhoan.TenNv,
                        SdtNv = taikhoan.SdtNv,
                        EmailNv = taikhoan.EmailNv.Trim().ToLower(),
                        MatkhauNv = (taikhoan.MatkhauNv + salt.Trim()).ToMD5(),
                        DiachiNv = taikhoan.DiachiNv,
                        GioitinhNv = taikhoan.GioitinhNv,
                        RoleId = taikhoan.RoleId,
                        KeyNv = salt,
                        TrangthaiNv = taikhoan.TrangthaiNv
                    };
                    try
                    {
                        var checkEmail = _context.Nhanviens
                            .AsNoTracking()
                            .SingleOrDefault(x => x.EmailNv.ToLower() == taikhoan.EmailNv.ToLower());
                        if (checkEmail != null) {
                             _notyfService.Error(taikhoan.EmailNv+ "Email đã được sử dụng");
                            return View(taikhoan);
                        }
                        _context.Add(tk);
                        await _context.SaveChangesAsync();
                       
                        _notyfService.Success("Đăng ký thành công");
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    return View(taikhoan);
                }
            }
            catch
            {
                return View(taikhoan);
            }
            ViewData["DanhMuc"] = new SelectList(_context.RoLes, "RoleId", "TenR",taikhoan.RoleId );
        }

        // GET: ADMIN/AdminNhanviens/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens.FindAsync(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            ViewData["DanhMuc"] = new SelectList(_context.RoLes, "RoleId", "TenR");
            return View(nhanvien);
        }

        // POST: ADMIN/AdminNhanviens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("MaNv,TenNv,EmailNv,SdtNv,MatkhauNv,DiachiNv,GioitinhNv,RoleId,TrangthaiNv")] Nhanvien nhanvien)
        {
            if (id != nhanvien.MaNv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanvien);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Cập nhật thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanvienExists(nhanvien.MaNv))
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
            ViewData["RoleId"] = new SelectList(_context.RoLes, "RoleId", "RoleId", nhanvien.RoleId);
            return View(nhanvien);
        }

        // GET: ADMIN/AdminNhanviens/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens
                .Include(n => n.Role)
                .FirstOrDefaultAsync(m => m.MaNv == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // POST: ADMIN/AdminNhanviens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var nhanvien = await _context.Nhanviens.FindAsync(id);
            _context.Nhanviens.Remove(nhanvien);
            await _context.SaveChangesAsync();
            _notyfService.Success("Xóa thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool NhanvienExists(decimal id)
        {
            return _context.Nhanviens.Any(e => e.MaNv == id);
        }

        public async Task<IActionResult> EditPassword(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens.FindAsync(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            //ViewData["DanhMuc"] = new SelectList(_context.RoLes, "RoleId", "TenR");
            return View();
        }

        // POST: ADMIN/AdminNhanviens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPassword(decimal id, EditPassword taikhoan)
        {
            //if (id != nv.MaNv)
            //{
            //    return notfound();
            //}
            try
            {
                //if (ModelState.IsValid)
                //{
                    string salt = Utilities.GetRandomKey(); 
                    try
                    {  
                        var checkPassword = await _context.Nhanviens
                                            .FindAsync(id);
                        string pass = (taikhoan.MatkhauCu + checkPassword.KeyNv.Trim()).ToMD5();
                    if (checkPassword.MatkhauNv != pass)
                        {
                            _notyfService.Error("Password hiện tại sai!!");
                            return View(taikhoan);
                        }
                        checkPassword.MatkhauNv = (taikhoan.MatkhauNv + salt.Trim()).ToMD5();
                        checkPassword.KeyNv = salt;                                      
                        _context.Update(checkPassword);
                        await _context.SaveChangesAsync();
                        _notyfService.Success("Cập nhật thành công");
                        return RedirectToAction(nameof(Index));
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!NhanvienExists(taikhoan.MaNv))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));

                //}
            }
            catch {
                return View(taikhoan);
            }

            return View(taikhoan);
        }

    }
}

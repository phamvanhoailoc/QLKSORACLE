using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQLKSORACLE.Models;

namespace WebLaptop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SearchController : Controller
    {
        private readonly ModelContext _context;

        public SearchController(ModelContext context)
        {
            _context = context;
        }
        //GET: Search/FindProduct
        [HttpPost]
        public IActionResult Findkhachang(string keyword)
        {
           List<Khachhang> ls = new List<Khachhang>();
            if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
            {
                return PartialView("ListKhachhangSearchPartialView", null);
            }
             ls = _context.Khachhangs
                                        .AsNoTracking()
                                        .Where(x => x.TenKh.Contains(keyword))
                                        .OrderByDescending(x => x.TenKh)
                                        .Take(10)
                                        .ToList();
            if (ls == null)
            {
                return PartialView("ListKhachhangPartialView", null);
            }
            else
            {
                return PartialView("ListKhachhangPartialView", ls);
            }
        }
    }
}

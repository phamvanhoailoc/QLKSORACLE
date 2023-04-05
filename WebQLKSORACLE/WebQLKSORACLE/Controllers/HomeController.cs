using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebQLKSORACLE.Models;
using WebQLKSORACLE.ModelViews;

namespace WebQLKSORACLE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ModelContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ModelContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            HomeView model = new HomeView();

            var IsLoaiPhong = _context.Loaiphongs
                                .AsNoTracking()
                                .Where(x => x.TrangthaiLp && x.TrangthaiLp == true)
                                .Include(l => l.MaDvtNavigation)
                                .Take(4)
                                .ToList();
            model.Loaiphongs = IsLoaiPhong;
            ViewBag.AllLoaiPhong = IsLoaiPhong;
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

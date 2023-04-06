using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQLKSORACLE.Areas.ADMIN.ModelViews;
using WebQLKSORACLE.Models;

namespace WebQLKSORACLE.Areas.ADMIN.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ModelContext _context;

        public HomeController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult Index(ThongKe thongKe)
        {
            var Tongkh = _context.Khachhangs
                                .Count();

            var Tongthu = _context.CtPdps.Sum(t => t.Gia);



            thongKe = new ThongKe
            {
                TongKH = Tongkh,
                TongThu = Tongthu
            };


            return View(thongKe);
        }
    }
}

using DiChoSaiGon.Extension;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using PagedList.Core;
using System;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using WebQLKSORACLE.Models;
using WebQLKSORACLE.ModelViews;

namespace WebQLKSORACLE.Controllers
{
    public class PhongsController : Controller
    {
        private readonly ModelContext _context;

        public PhongsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Phongs
        public IActionResult Index(int? page, String name)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 6;
            var Isphongs = _context.Phongs
                    .AsNoTracking()
                    .Include(t => t.MaLpNavigation)
                    .Include(t => t.MaLpNavigation.MaDvtNavigation)
                    .Include(c => c.MattPNavigation);
            if (!string.IsNullOrEmpty(name))
            {
                Isphongs = Isphongs
                                .Where(x => x.TenP.ToUpper().Contains(name.ToUpper()))
                                .OrderByDescending(x => x.TenP)
                                .Include(t => t.MaLpNavigation)
                                .Include(t => t.MaLpNavigation.MaDvtNavigation)
                                .Include(c => c.MattPNavigation);
            }

            PagedList<Phong> models = new PagedList<Phong>(Isphongs, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;

            ViewData["MattP"] = new SelectList(_context.TrangthaiPs, "MattP", "TenttP");
            ViewData["Malp"] = new SelectList(_context.Loaiphongs, "MaLp", "TenLp");

            return View(models);
        }
        //[Route("/List/{Malp}", Name ="DanhSachPhong")]
        public IActionResult List(decimal? id, int page=1)
        {


            var pageSize = 6;
            var LoaiPhong = _context.Loaiphongs.AsNoTracking().SingleOrDefault(x => x.MaLp == id);
            var Isphongs = _context.Phongs
                    .AsNoTracking()
                    .Where(x => x.MaLp == LoaiPhong.MaLp)
                    .Include(t => t.MaLpNavigation)
                    .Include(t => t.MaLpNavigation.MaDvtNavigation)
                    .Include(c => c.MattPNavigation);

            PagedList<Phong> models = new PagedList<Phong>(Isphongs, page, pageSize);
            ViewBag.CurrentPage = page;
            ViewBag.CurrentLP = LoaiPhong;
            ViewData["MattP"] = new SelectList(_context.TrangthaiPs, "MattP", "TenttP");
            ViewData["Malp"] = new SelectList(_context.Loaiphongs, "MaLp", "TenLp");

            return View(models);
        }


        // GET: Phongs/Details/5
        public async Task<IActionResult> Details(decimal? id, DatPhongView datphong)
        {
            if (id == null)
            {
                return NotFound();
            }
         
            var phong = await _context.Phongs
                .Include(p => p.MaLpNavigation)
                .Include(t => t.MaLpNavigation.MaDvtNavigation)
                .Include(p => p.MattPNavigation)
                .FirstOrDefaultAsync(m => m.MaP == id);
                
            datphong.phongs = phong;

            if (Request.Method == "POST" && ModelState.IsValid )
            {

                Khachhang kh = new Khachhang
                {
                    EmailKh = datphong.EmailKh,
                    TenKh = datphong.TenKh,
                    TrangthaiKh = true
                };
                _context.Add(kh);
                _context.SaveChanges();
                PhieuDatPhong pdp = new PhieuDatPhong
                {
                    NgaydenDp = datphong.NgaydenDp,
                    NgaydiDp = datphong.NgaydiDp,
                    NgayLapP = DateTime.Now,
                    MaKh = kh.MaKh,
                    Token = HashMD5.GenerateRandomString(10),
                    MaTtdp = 101
                };
               
                _context.Add(pdp);
                _context.SaveChanges();
                CtPdp ctdp = new CtPdp
                {
                    MaP = id,
                    MaDp = pdp.MaDp,
                    SlNgay = datphong.SlNgay,
                    Gia = datphong.SlNgay.Value * phong.MaLpNavigation.Dongia.Value
                };
                _context.Add(ctdp);
                _context.SaveChanges();
                var confirmationLink = Url.Action("ConfirmEmail", "Phongs", new {id = pdp.MaDp, token = pdp.Token }, Request.Scheme);
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Khách sạn", "phamvanhoailoc0507@gmail.com"));
                message.To.Add(new MailboxAddress(kh.TenKh, kh.EmailKh));
                message.Subject = "How you doin'?";

                message.Body = new TextPart("html")
                {
                   
                Text = $@"<h3>Xin chào {kh.TenKh}</h3>
                        <p>Bạn nhận được thông tin này vì bạn đã đặt phòng trên khách sạn...</p>
                        <p>Thông tin đặt phòng:</p>
                        <div><p>Ngày nhận phòng: ${pdp.NgaydenDp}</p></div>
                        <div><p>Ngày trả phòng: ${pdp.NgaydiDp}</p></div>

                        <p>Nếu thông trên là đúng sự thật, vui lòng click vào đường link để hoàn tất quá trình đặt phòng</p>
                        <div><a href='{confirmationLink}' target='blank'>Click here</a></div>

                        <div> Xin chân thành cảm ơn </div> "


                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate("phamvanhoailoc0507@gmail.com", "erjzbqeufrsheknq");

                    client.Send(message);
                    client.Disconnect(true);
                }

                    return RedirectToAction("Create");
            }




            if (phong == null)
            {
                return NotFound();
            }


            ViewBag.AllPhong = phong;
            return View(datphong);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(decimal id, string token)
        {
            if (id == null || token == null )
            {
                return RedirectToAction("Index", "Home");
            }
            var result = await _context.PhieuDatPhongs.FirstOrDefaultAsync(p => p.MaDp == id && p.Token == token);
            if (result != null) {
                result.MaTtdp = 277;
                _context.Update(result);
                await _context.SaveChangesAsync();
            }
            
            return View();
        }


        // GET: Phongs/Create
        public IActionResult Create()
        {
            ViewData["MaLp"] = new SelectList(_context.Loaiphongs, "MaLp", "MaLp");
            ViewData["MattP"] = new SelectList(_context.TrangthaiPs, "MattP", "MattP");
            return View();
        }

        // POST: Phongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaP,TenP,MaLp,ChitietP,Hinh,MattP,Trangthai")] Phong phong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLp"] = new SelectList(_context.Loaiphongs, "MaLp", "MaLp", phong.MaLp);
            ViewData["MattP"] = new SelectList(_context.TrangthaiPs, "MattP", "MattP", phong.MattP);
            return View(phong);
        }

        // GET: Phongs/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phong = await _context.Phongs.FindAsync(id);
            if (phong == null)
            {
                return NotFound();
            }
            ViewData["MaLp"] = new SelectList(_context.Loaiphongs, "MaLp", "MaLp", phong.MaLp);
            ViewData["MattP"] = new SelectList(_context.TrangthaiPs, "MattP", "MattP", phong.MattP);
            return View(phong);
        }

        // POST: Phongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("MaP,TenP,MaLp,ChitietP,Hinh,MattP,Trangthai")] Phong phong)
        {
            if (id != phong.MaP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhongExists(phong.MaP))
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
            ViewData["MaLp"] = new SelectList(_context.Loaiphongs, "MaLp", "MaLp", phong.MaLp);
            ViewData["MattP"] = new SelectList(_context.TrangthaiPs, "MattP", "MattP", phong.MattP);
            return View(phong);
        }

        // GET: Phongs/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phong = await _context.Phongs
                .Include(p => p.MaLpNavigation)
                .Include(p => p.MattPNavigation)
                .FirstOrDefaultAsync(m => m.MaP == id);
            if (phong == null)
            {
                return NotFound();
            }

            return View(phong);
        }

        // POST: Phongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var phong = await _context.Phongs.FindAsync(id);
            _context.Phongs.Remove(phong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhongExists(decimal id)
        {
            return _context.Phongs.Any(e => e.MaP == id);
        }
    }
}

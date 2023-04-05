using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebQLKSORACLE.Models;

namespace WebQLKSORACLE.ModelViews
{
    public class DatPhongView
    {
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        public string TenKh { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập email")]
        public string EmailKh { get; set; }
        public bool TrangthaiKh { get; set; }
        public decimal? MaKh { get; set; }
        public decimal? MaTtdp { get; set; }
        [Display(Name = "Ngày đến")]
        public DateTime? NgaydenDp { get; set; }
        [Display(Name = "Ngày đi")]
        [NgayDiSauNgayDen]
        public DateTime? NgaydiDp { get; set; }
        public DateTime? NgayLapP { get; set; }
        public decimal? Tongtien { get; set; }
        public decimal? SlNgay { get; set; }
        public decimal? MaP { get; set; }
        public Phong phongs { get; set; }
    }
}

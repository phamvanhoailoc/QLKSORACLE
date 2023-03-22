using System;
using System.Collections.Generic;

#nullable disable

namespace WebQLKSORACLE.Models
{
    public partial class PhieuDatPhong
    {
        public decimal MaDp { get; set; }
        public decimal MaKh { get; set; }
        public decimal MaP { get; set; }
        public decimal MaTtdp { get; set; }
        public DateTime? NgaydenDp { get; set; }
        public DateTime? NgaydiDp { get; set; }

        public virtual Khachhang MaKhNavigation { get; set; }
        public virtual Phong MaPNavigation { get; set; }
        public virtual TrangthaiDp MaTtdpNavigation { get; set; }
    }
}

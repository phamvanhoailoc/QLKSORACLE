using System;
using System.Collections.Generic;

#nullable disable

namespace WebQLKSORACLE.Models
{
    public partial class PhieuDatPhong
    {
        public PhieuDatPhong()
        {
            CtPdps = new HashSet<CtPdp>();
        }

        public decimal MaDp { get; set; }
        public decimal? MaKh { get; set; }
        public decimal? MaTtdp { get; set; }
        public DateTime? NgaydenDp { get; set; }
        public DateTime? NgaydiDp { get; set; }
        public DateTime? NgayLapP { get; set; }
        public decimal? Tongtien { get; set; }
        public decimal? SlNgay { get; set; }
        public string Token { get; set; }

        public virtual Khachhang MaKhNavigation { get; set; }
        public virtual TrangthaiDp MaTtdpNavigation { get; set; }
        public virtual ICollection<CtPdp> CtPdps { get; set; }
    }
}

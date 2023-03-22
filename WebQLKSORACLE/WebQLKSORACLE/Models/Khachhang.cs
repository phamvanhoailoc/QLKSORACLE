using System;
using System.Collections.Generic;

#nullable disable

namespace WebQLKSORACLE.Models
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            PhieuDatPhongs = new HashSet<PhieuDatPhong>();
        }

        public decimal MaKh { get; set; }
        public string TenKh { get; set; }
        public string EmailKh { get; set; }
        public decimal? SdtKh { get; set; }
        public string MatkhauKh { get; set; }
        public bool TrangthaiKh { get; set; }
        public string DiachiKh { get; set; }
        public bool Gioitinh { get; set; }

        public virtual ICollection<PhieuDatPhong> PhieuDatPhongs { get; set; }
    }
}

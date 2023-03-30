using System;
using System.Collections.Generic;

#nullable disable

namespace WebQLKSORACLE.Models
{
    public partial class TrangthaiDp
    {
        public TrangthaiDp()
        {
            PhieuDatPhongs = new HashSet<PhieuDatPhong>();
        }

        public decimal MaTtdp { get; set; }
        public string TenTt { get; set; }
        public bool Trangthai { get; set; }
        public string Chitiet { get; set; }

        public virtual ICollection<PhieuDatPhong> PhieuDatPhongs { get; set; }
    }
}

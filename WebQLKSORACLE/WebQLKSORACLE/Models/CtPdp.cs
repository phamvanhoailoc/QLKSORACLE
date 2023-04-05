using System;
using System.Collections.Generic;

#nullable disable

namespace WebQLKSORACLE.Models
{
    public partial class CtPdp
    {
        public decimal MaCtpdp { get; set; }
        public decimal? MaDp { get; set; }
        public decimal? MaP { get; set; }
        public decimal? Gia { get; set; }
        public decimal? SlNgay { get; set; }

        public virtual PhieuDatPhong MaDpNavigation { get; set; }
        public virtual Phong MaPNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace WebQLKSORACLE.Models
{
    public partial class Phong
    {
        public Phong()
        {
            Giaphongs = new HashSet<Giaphong>();
            PhieuDatPhongs = new HashSet<PhieuDatPhong>();
        }

        public decimal MaP { get; set; }
        public string TenP { get; set; }
        public bool TrangthaiP { get; set; }
        public decimal MaLp { get; set; }
        public string ChitietP { get; set; }

        public virtual ICollection<Giaphong> Giaphongs { get; set; }
        public virtual ICollection<PhieuDatPhong> PhieuDatPhongs { get; set; }
    }
}

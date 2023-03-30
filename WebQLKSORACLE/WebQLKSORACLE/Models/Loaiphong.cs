using System;
using System.Collections.Generic;

#nullable disable

namespace WebQLKSORACLE.Models
{
    public partial class Loaiphong
    {
        public Loaiphong()
        {
            Phongs = new HashSet<Phong>();
        }

        public decimal MaLp { get; set; }
        public string TenLp { get; set; }
        public string ChitietLp { get; set; }
        public bool TrangthaiLp { get; set; }
        public decimal? MaDvt { get; set; }
        public decimal? Dongia { get; set; }
        public decimal? SlNguoi { get; set; }

        public virtual Donvitien MaDvtNavigation { get; set; }
        public virtual ICollection<Phong> Phongs { get; set; }
    }
}

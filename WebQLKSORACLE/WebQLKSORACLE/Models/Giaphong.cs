using System;
using System.Collections.Generic;

#nullable disable

namespace WebQLKSORACLE.Models
{
    public partial class Giaphong
    {
        public string MaGp { get; set; }
        public decimal? GiaP { get; set; }
        public decimal MaDvt { get; set; }
        public decimal MaP { get; set; }
        public DateTime? NgaydenGp { get; set; }
        public DateTime? NgaydiGp { get; set; }

        public virtual Donvitien MaDvtNavigation { get; set; }
        public virtual Phong MaPNavigation { get; set; }
    }
}

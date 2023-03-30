using System;
using System.Collections.Generic;

#nullable disable

namespace WebQLKSORACLE.Models
{
    public partial class Phong
    {
        public decimal MaP { get; set; }
        public string TenP { get; set; }
        public decimal? MaLp { get; set; }
        public string ChitietP { get; set; }
        public string Hinh { get; set; }
        public decimal? MattP { get; set; }
        public bool Trangthai { get; set; }

        public virtual Loaiphong MaLpNavigation { get; set; }
        public virtual TrangthaiP MattPNavigation { get; set; }
    }
}

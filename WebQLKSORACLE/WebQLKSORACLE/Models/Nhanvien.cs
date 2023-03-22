using System;
using System.Collections.Generic;

#nullable disable

namespace WebQLKSORACLE.Models
{
    public partial class Nhanvien
    {
        public decimal MaNv { get; set; }
        public string TenNv { get; set; }
        public string EmailNv { get; set; }
        public decimal? SdtNv { get; set; }
        public string MatkhauNv { get; set; }
        public string DiachiNv { get; set; }
        public bool GioitinhNv { get; set; }
        public decimal RoleId { get; set; }
        public bool TrangthaiNv { get; set; }

        public virtual RoLe Role { get; set; }
    }
}

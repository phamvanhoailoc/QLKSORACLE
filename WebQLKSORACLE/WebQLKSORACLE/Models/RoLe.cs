using System;
using System.Collections.Generic;

#nullable disable

namespace WebQLKSORACLE.Models
{
    public partial class RoLe
    {
        public RoLe()
        {
            Nhanviens = new HashSet<Nhanvien>();
        }

        public decimal RoleId { get; set; }
        public string TenR { get; set; }
        public bool TrangthaiR { get; set; }

        public virtual ICollection<Nhanvien> Nhanviens { get; set; }
    }
}

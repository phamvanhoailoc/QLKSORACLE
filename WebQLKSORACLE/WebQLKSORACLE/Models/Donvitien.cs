using System;
using System.Collections.Generic;

#nullable disable

namespace WebQLKSORACLE.Models
{
    public partial class Donvitien
    {
        public Donvitien()
        {
            Loaiphongs = new HashSet<Loaiphong>();
        }

        public decimal MaDvt { get; set; }
        public string TenDvt { get; set; }

        public virtual ICollection<Loaiphong> Loaiphongs { get; set; }
    }
}

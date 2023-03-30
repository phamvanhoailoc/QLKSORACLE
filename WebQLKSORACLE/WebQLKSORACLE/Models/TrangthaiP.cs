using System;
using System.Collections.Generic;

#nullable disable

namespace WebQLKSORACLE.Models
{
    public partial class TrangthaiP
    {
        public TrangthaiP()
        {
            Phongs = new HashSet<Phong>();
        }

        public decimal MattP { get; set; }
        public string TenttP { get; set; }

        public virtual ICollection<Phong> Phongs { get; set; }
    }
}

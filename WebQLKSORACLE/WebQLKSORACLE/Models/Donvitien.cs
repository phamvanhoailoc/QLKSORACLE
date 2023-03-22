using System;
using System.Collections.Generic;

#nullable disable

namespace WebQLKSORACLE.Models
{
    public partial class Donvitien
    {
        public Donvitien()
        {
            Giaphongs = new HashSet<Giaphong>();
        }

        public decimal MaDvt { get; set; }
        public string TenDvt { get; set; }

        public virtual ICollection<Giaphong> Giaphongs { get; set; }
    }
}

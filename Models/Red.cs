using System;
using System.Collections.Generic;

namespace Produvtapi.Models
{
    public partial class Red
    {
        public int Pid { get; set; }
        public string? Pname { get; set; }
        public int? Price { get; set; }
        public int? Qty { get; set; }
        public int? Sid { get; set; }

        public virtual Green? SidNavigation { get; set; }
    }
}

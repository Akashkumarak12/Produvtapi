using System;
using System.Collections.Generic;

namespace Produvtapi.Models
{
    public partial class Product
    {
        public int Pid { get; set; }
        public string? Pname { get; set; }
        public float Price { get; set; }
        public int SupplierId { get; set; }

        public virtual Supplier? Supplier { get; set; }
    }
}

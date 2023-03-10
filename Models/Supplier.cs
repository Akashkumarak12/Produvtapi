using System;
using System.Collections.Generic;

namespace Produvtapi.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; } = null!;
        public string Location { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}

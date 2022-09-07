using System;
using System.Collections.Generic;

namespace Produvtapi.Models
{
    public partial class Green
    {
        public Green()
        {
            Reds = new HashSet<Red>();
        }

        public int Sid { get; set; }
        public string Brand { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<Red> Reds { get; set; }
    }
}

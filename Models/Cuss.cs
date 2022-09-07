using System;
using System.Collections.Generic;

namespace Produvtapi.Models
{
    public partial class Cuss
    {
        public int CusId { get; set; }
        public string CustomerName { get; set; } = null!;
        public float Salary { get; set; }
        public DateTime Doj { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}

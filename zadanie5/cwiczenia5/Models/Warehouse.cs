using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia5.Models
{
    public class Warehouse
    {
        public int IdProduct { get; set; }

        public int IdWarehouse { get; set; }

        public int Amount { get; set; }

        public string CreatedAt { get; set; }
    }
}

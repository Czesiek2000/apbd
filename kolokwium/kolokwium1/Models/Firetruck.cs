using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium1.Models
{
    public class Firetruck
    {
        public Firetruck()
        {
            FiretruckActions = new HashSet<FiretruckAction>();
        }

        public int IdFireTruck { get; set; }

        public int OperationalNumber { get; set; }

        public byte SpecialEquipment { get; set; }

        public virtual ICollection<FiretruckAction> FiretruckActions { get; set; }
    }
}

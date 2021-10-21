using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium1.Models
{
    public class FirefighterAction
    {
        public int IdFirefighter { get; set; }

        public int IdAction { get; set; }

        public virtual Firefighter Firefighter { get; set; }

        public virtual Action Action { get; set; }
    }
}

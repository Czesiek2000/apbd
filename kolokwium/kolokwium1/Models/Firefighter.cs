using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium1.Models
{
    public class Firefighter
    {
        public Firefighter ()
        {
            FirefighterActions = new HashSet<FirefighterAction>();
        }
        public int IdFirefighter { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<FirefighterAction> FirefighterActions { get; set; }
    }
}

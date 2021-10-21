using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium1.Models
{
    public class Action
    {
        public Action ()
        {
            FirefighterActions = new HashSet<FirefighterAction>();
            FiretruckActions = new HashSet<FiretruckAction>();
        }
        public int IdAction { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public byte NeedSpecialEquipment { get; set; }

        public ICollection<FirefighterAction> FirefighterActions { get; set; }

        public ICollection<FiretruckAction> FiretruckActions { get; set; }
    }
}

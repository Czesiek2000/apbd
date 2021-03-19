using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwiczenia2.Helpers
{
    class Active
    {
        public string Name;

        public int ActiveStudents;

        public Active(string name)
        {
            Name = name;
        }

        public Active(string name, int activeStudents) : this(name)
        {
            ActiveStudents = activeStudents;
        }

        public int active {
            get 
            {
                return this.ActiveStudents;
            }
            
            set 
            {
                this.ActiveStudents = value;
            }
        }
    }
}

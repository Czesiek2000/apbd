using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwiczenia2.Models
{
    class Studies
    {
        public string Type;
        public string Mode;

        public Studies(string Type, string Mode)
        {
            this.Type = Type;
            this.Mode = Mode;
        }

        public string type 
        { 
            get 
            { 
                return this.Type; 
            }
                
        }

        public string mode
        {
            get
            {
                return this.Mode;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia8.Models
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime TokenTime { get; set; }
        public DateTime ExpireTime { get; set; }
        public Guid Token { get; set; }
    }
}

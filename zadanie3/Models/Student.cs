using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cwiczenia3.Models
{
    public class Student
    {

        public int IdStudent { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Date { get; set; }

        public Study Study { get; set; }

        public string Email { get; set; }

        public string Mother { get; set; }

        public string Father { get; set; }

        public string SaveText()
        {
            return $"{this.Name},{this.Surname},s{this.IdStudent},{this.Date},{this.Study.type},{this.Study.mode},{this.Email},{this.Father},{this.Mother}";
           
        }

    }
}

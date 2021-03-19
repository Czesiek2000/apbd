using cwiczenia2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace cwiczenia2.Models
{
    class University
    {
        public string createTime = DateTime.Now.ToString();
        public string creator = "Michał Czech";
        public HashSet<Student> students;

        public University(HashSet<Student> students)
        {
            this.students = students;
        }

        public string CreateJson()
        {
            var studentCollection = new List<object>();
            
            var numberOfActive = new Dictionary<string, Active>();
            
            List<object> activeList = new List<object>();
            
            foreach (var student in students)
            {
                if (numberOfActive.ContainsKey(student.Studies.type))
                {
                    var activeStudy = numberOfActive[student.Studies.Type];

                    activeStudy.active++;
                }
                else
                {
                    var activeStudy = new Active(student.Studies.type);
                    activeStudy.active++;
                    numberOfActive.Add(student.Studies.type, activeStudy);
                }
            }


            foreach (var active in numberOfActive)
            {
                activeList.Add(new
                {
                    name = active.Key,
                    numberOfStudents = active.Value.active
                });
            }

            foreach (var student in students)
            {
                studentCollection.Add( new { 
                    indexNumber = $"s{student.Index}",
                    fName = student.Name,
                    lName = student.Surname,
                    birthdate = student.BirthdayParser(),
                    email = student.Email,
                    mothersName = student.Mother,
                    fathersName = student.Father,
                    studies = new {
                        name = student.Studies.type,
                        mode = student.Studies.mode,
                    }
                });
            }

            var x = new
            {
                uczelnia = new
                {
                    created = this.ParseDate(),
                    author = this.creator,
                    students = studentCollection,
                    active =  activeList
                } 
            };
            
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };
            
            var json = JsonSerializer.Serialize(x, options);
            return json;
        }

        public string ParseDate()
        {
            var smonth = "";
            var month = DateTime.Parse(this.createTime).Month;
            if (month < 10)
            {
                smonth = $"0{month}";
            }
            return $"{DateTime.Parse(this.createTime).Day}.{smonth}.{DateTime.Parse(this.createTime).Year}";
        }

    }
}

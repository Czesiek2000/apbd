using cwiczenia2.Helpers;
using cwiczenia3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia3.Services
{
    public class DbService : IDbService
    {
        public void AddStudent(Student student)
        {
            var utils = new Utils();
            var u = utils.readFromFile();
            var students = new HashSet<Student>(new CompareHandler());

            foreach (var s in u)
            {
                students.Add(s);
            }

            if (!students.Contains(student))
            {

                if (students.Add(student))
                {
                    students.Add(student);
                    
                }
            }


            utils.SaveCollection(students);
        }
    }
}

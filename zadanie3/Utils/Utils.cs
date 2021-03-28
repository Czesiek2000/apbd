using cwiczenia3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia3
{
    public class Utils
    {
        public string Path = "data/data.csv";

        public string path { 
            get 
            {
                return this.Path;
            }

            set
            {
                this.Path = value;
            }
            
        }

        public void appendToFile(string text)
        {
            using (StreamWriter w = File.AppendText(this.Path))
            {
                w.WriteLine(text);
                w.Close();
            }
        }


        public List<Student> readFromFile()
        {

            var fileContent = new List<Student>();
            try
            {
                var fileInfo = new FileInfo(this.path);

                foreach (var line in File.ReadLines(this.path))
                {
                    string[] tmp = line.Split(",");
                    tmp[2] = tmp[2].Replace("s", String.Empty);

                    fileContent.Add(new Student
                    {
                        IdStudent = int.Parse(tmp[2]),
                        Name = tmp[0],
                        Surname = tmp[1],
                        Date = tmp[3],
                        Study = new Study(tmp[4], tmp[5]),
                        Email = tmp[6],
                        Father = tmp[7],
                        Mother = tmp[8]
                    });
                    
                }

            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException(e.Message);
                
            }

            return fileContent;
        }

        public void SaveCollection(List<Student> students)
        {

            File.Delete(this.path);
            foreach (var student in students)
            {
                this.appendToFile(student.SaveText());
            }
        }

        public void SaveCollection(HashSet<Student> students)
        {
            File.Delete(this.path);
            foreach (var student in students)
            {
                this.appendToFile(student.SaveText());
            }
        }
    }
      
}

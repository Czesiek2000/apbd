using cwiczenia2.Models;
using cwiczenia2.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace cwiczenia2
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new Logger("output/log.txt", args[1]);
            
            if (args.Length != 3)
            {

                logger.Log($"Not enought arguments, check out {logger.path}");
                throw new ArgumentException($"Not enought arguments, check out {logger.path}");

            }

            if (!File.Exists(args[0]))
            {
                logger.Log($"File {args[0]} doesn't exists");
                
                throw new FileNotFoundException("File doesn't exists");
            }


            try
            {
                var fileInfo = new FileInfo(args[0]);

                var students = new HashSet<Student>(new CompareHandler());
                
                foreach (var line in File.ReadLines(args[0]))
                {
                    string[] tmp = line.Split(",");

                    if (tmp.Length == 9)
                    {

                        if ((!string.IsNullOrEmpty(tmp[0]) && !string.IsNullOrEmpty(tmp[0])) || (!string.IsNullOrEmpty(tmp[1]) && !string.IsNullOrEmpty(tmp[1])) || (!string.IsNullOrEmpty(tmp[2]) && !string.IsNullOrEmpty(tmp[2])) || (!string.IsNullOrEmpty(tmp[3]) && !string.IsNullOrEmpty(tmp[3])) || (!string.IsNullOrEmpty(tmp[4]) && !string.IsNullOrEmpty(tmp[4])) || (!string.IsNullOrEmpty(tmp[5]) && !string.IsNullOrEmpty(tmp[5])) || (!string.IsNullOrEmpty(tmp[6]) && !string.IsNullOrEmpty(tmp[6])) || (!string.IsNullOrEmpty(tmp[7]) && !string.IsNullOrEmpty(tmp[7])) || (!string.IsNullOrEmpty(tmp[8]) && !string.IsNullOrEmpty(tmp[8])))
                        {
                            string surname = Regex.Replace(tmp[1], @"[\d]", string.Empty);
                            var tmpEmail = Regex.Replace(tmp[6], @"[\d]", string.Empty);
                            var email = $"{surname.ToLower()}{tmpEmail}";
                            

                            Student s = new Student(tmp[0], surname, new Studies(tmp[2], tmp[3]), int.Parse(tmp[4]), tmp[5], email, tmp[7], tmp[8]);

                            if (!students.Contains(s))
                            {

                                if (students.Add(s))
                                {

                                    students.Add(s);
                                    Console.WriteLine("Student " + tmp[0] + " " + surname + " dodany");

                                }

                                else
                                {
                                    
                                    logger.Log("Student " + tmp[0] + " " + surname + " s" + tmp[4] + " juz jest");
                                    
                                }

                            }
                            else
                            {
                             
                                logger.Log("Student " + tmp[0] + " " + surname + " juz istnieje");
                                
                            }
                        }

                    }

                    else
                    {
                        
                        logger.Log(line + " is wrong");
                        
                    }
                    
                }

                University university = new University(students);

                logger.WriteJson(university.CreateJson());
            }

            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found " + e.Message);
                logger.Log($"File not found " + e.Message);
            }

        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Apbd14.DTO.Response;
using Apbd14.Models;
using Apbd14.Repositories.Interfaces;

namespace Apbd14.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        public static ICollection<Student> Students;
        public static ICollection<Group> Groups;

        static StudentRepository()
        {
            var students = new List<Student>();
            var groups = new List<Group>();

            #region Load Students

                var s1 = new Student
                {
                    IdStudent = 1,
                    FirstName = "Jan",
                    LastName = "Janowski",
                    Index = "s2137",
                    IdGroup = 1
                };
                var s2 = new Student
                {
                    IdStudent = 2,
                    FirstName = "Anna",
                    LastName = "Nowak",
                    Index = "s15182",
                    IdGroup = 1
                };
                var s3 = new Student
                {
                    IdStudent = 3,
                    FirstName = "Paweł",
                    LastName = "Pawłowski",
                    Index = "s4412",
                    IdGroup = 2
                };
                var s4 = new Student
                {
                    IdStudent = 4,
                    FirstName = "Artur",
                    LastName = "Kowalski",
                    Index = "s12342",
                    IdGroup = 3
                };
                var s5 = new Student
                {
                    IdStudent = 5,
                    FirstName = "Paulina",
                    LastName = "Paulińska",
                    Index = "s21832",
                    IdGroup = 3
                };

                students.Add(s1);
                students.Add(s2);
                students.Add(s3);
                students.Add(s4);
                students.Add(s5);

                Students = students;


            #endregion

            #region Load Groups

            var g1 = new Group
            {
                IdGroup = 1,
                Code = "23c"
            };
            
            var g2 = new Group
            {
                IdGroup = 2,
                Code = "19c"
            };

            var g3 = new Group
            {
                IdGroup = 3,
                Code = "21c"
            };
            
            var g4 = new Group
            {
                IdGroup = 4,
                Code = "11c"
            };

            var g5 = new Group
            {
                IdGroup = 5,
                Code = "17c"
            };

            groups.Add(g1);
            groups.Add(g2);
            groups.Add(g3);
            groups.Add(g4);
            groups.Add(g5);

            Groups = groups;

            #endregion


        }

        public IEnumerable<StudentResponse> GetStudents()
        {
            return Students.Join(Groups, stud => stud.IdGroup, group => group.IdGroup, (stud,group) => new StudentResponse
            {
                IdStudent = stud.IdStudent,
                FirstName = stud.FirstName,
                LastName = stud.LastName,
                Index = stud.Index,
                Group = new GroupResponse
                {
                    IdGroup = group.IdGroup,
                    GroupName = group.Code
                }
            }).ToList();
        }

        public Student GetStudentById(int idStudent)
        {
            return Students.SingleOrDefault(x => x.IdStudent == idStudent);
        }

        public bool DeleteStudent(int idStudent)
        {
            var stud = Students.FirstOrDefault(x => x.IdStudent == idStudent);

            if (stud == null)
                return false;

            Students.Remove(stud);

            return true;
        }
    }
}

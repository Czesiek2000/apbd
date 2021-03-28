using cwiczenia3.Models;
using cwiczenia3.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace cwiczenia3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            this._dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = new Utils().readFromFile();
            
            if (students.Count == 0)
            {
                return Ok("Empty list");
            }

            return Ok(students);
        }

        [HttpGet("{idStudent}")]
        public async Task<IActionResult> GetStudentById(int idStudent)
        {
            var output = new Utils().readFromFile();
                
            Student result = null;
            int id = 0;

            foreach(var o in output) 
            {
                if (o != null && output.Contains(o))
                {

                    if (o.IdStudent == idStudent)
                    {
                        result = o;
                    }

                    id = idStudent;
                }
            }

            if (result != null)
            {
                return Ok(result);

            }

            return NotFound($"Student with id: {id} not found");
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            _dbService.AddStudent(student);

            return Ok($"Student with id: {student.IdStudent} added, full data: {student.SaveText()}");
        }

        [HttpPut("{idStudent}")]
        public async Task<IActionResult> UpdateStudent(Student student, int idStudent)
        {

            var utils = new Utils();
            var students = utils.readFromFile();
            var newStudent = new Student 
            {
                IdStudent = idStudent,
                Name = student.Name,
                Surname = student.Surname,
                Date = student.Date,
                Study = student.Study,
                Email = student.Email,
                Father = student.Father,
                Mother = student.Mother,
            };

            foreach (var s in students)
            {
                if (s.IdStudent == idStudent)
                {
                    students.Remove(s);
                    students.Add(newStudent);
                    utils.SaveCollection(students);
                    return Ok($"Student {idStudent} was updated, {newStudent.SaveText()}");
                }
            }

            return NotFound($"Cannot update student {student.IdStudent}, because he doesn't exists");
        }

        [HttpDelete("{idStudent}")]
        public async Task<IActionResult> DeleteStudent(int idStudent)
        {
            var util = new Utils();
            var students = util.readFromFile();

            foreach (var student in students)
            {
                if (student.IdStudent == idStudent)
                {
                    students.Remove(student);
                    util.SaveCollection(students);
                    return Ok($"Student with id {idStudent} deleted");
                }
               

            }
            
            return NotFound($"Student with id {idStudent} not found");
        }
    }
}

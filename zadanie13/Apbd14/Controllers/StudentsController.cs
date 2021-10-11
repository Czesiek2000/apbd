using System.Collections.Generic;
using Apbd14.Models;
using Microsoft.AspNetCore.Mvc;
using Apbd14.Repositories.Interfaces;

namespace Apbd14.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var res = _studentRepository.GetStudents();
            return Ok(res);
        }

        [HttpGet("{idStudent:int}")]
        public IActionResult GetStudentById(int idStudent)
        {
            var stud = _studentRepository.GetStudentById(idStudent);

            if (stud == null)
            {
                return NotFound();
            }
                

            return Ok(stud);
        }

        [HttpDelete("{idStudent:int}")]
        public IActionResult DeleteStudentById(int idStudent)
        {
            var delSucc = _studentRepository.DeleteStudent(idStudent);

            if (!delSucc)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

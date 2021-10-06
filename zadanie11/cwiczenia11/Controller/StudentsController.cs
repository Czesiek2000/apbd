using cwiczenia11.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia11.Controller
{
    [ApiController]
    [Route("/api/students")]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        [Route("${id}")]
        public IActionResult GetStudent (int id)
        {
            var students = new List<Student>();
            students.Add( new Student
            {
                Id = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                Birthdate = "5/24/2021",
                Studies = "Informatyka"
            } );

            students.Add( new Student
            {
                Id = 2,
                FirstName = "Anna",
                LastName = "Kowalska",
                Birthdate = "5/25/2021",
                Studies = "Informatyka"
            } );

            var result = students.Where( s => s.Id == id );
            return Ok( result );
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cwiczenia8.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace cwiczenia8.Controllers
{
    [ApiController]
    [Route("/api/doctors")]
    [Authorize("admin, doctor")]
    public class DoctorController : ControllerBase
    {

        private readonly _2019SBDContext _context;

        public DoctorController(_2019SBDContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var result = await _context.Doctors.ToListAsync();

            if (result.Count != 0)
            {
                return Ok(result);
            }

            return NotFound("No doctor in database");
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var result = await _context.Doctors.Where(d => d.IdDoctor.Equals(id)).Select(d => d).FirstOrDefaultAsync();

            _context.Doctors.Remove(result);

            return Ok( $"Removed doctor {result.FirstName}, {result.LastName} whose id is {id}" );

        }
    }
}

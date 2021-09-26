using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cwiczenia7.Repositories.Interfaces;
using cwiczenia7.DTO.Requests;

namespace cwiczenia7.Controllers
{
    [ApiController]
    [Route( "api/trips" )]
    public class TripsController : ControllerBase
    {
        private readonly ITripsHandler _tripsHandler;

        public TripsController ( ITripsHandler tripsHandler )
        {
            _tripsHandler = tripsHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetTripsFromDbAsync ()
        {
            var res = await _tripsHandler.GetTripsAsync();

            return Ok( res );
        }

        [HttpPost( "{idTrip}/clients" )]
        public async Task<IActionResult> UpdateClients (ClientDTO clients)
        {
            var result = await _tripsHandler.UpdateClients( clients);
            if ( result)
            {
                return Ok( "Client added" );
            }
            
            return BadRequest( "Client exists in database" );
        }
    }
}

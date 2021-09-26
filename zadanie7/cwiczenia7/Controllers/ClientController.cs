using cwiczenia7.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia7.Controllers
{
    [ApiController]
    [Route( "api/clients/" )]
    public class ClientController : ControllerBase
    {
        
        private readonly IClientHandler _clientHandler;

        public ClientController ( IClientHandler clientHandler )
        {
            _clientHandler = clientHandler;
        }

        [HttpDelete( "{idClient}")]
        public async Task<IActionResult> DeleteClient (int idClient)
        {
            var res = await _clientHandler.DeleteClient(idClient);
            if ( res )
            {
                return Ok("Client deleted");
            }

            return BadRequest( "Client has trips or doesn't exists");
        }
    }
}

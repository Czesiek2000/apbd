using cwiczenia7.Models;
using cwiczenia7.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia7.Repositories.Implementation
{
    public class ClientHandler : IClientHandler
    {
        private readonly _2019SBDContext _context;

        public ClientHandler ( _2019SBDContext context )
        {
            _context = context;
        }

        public async Task<bool> DeleteClient (int idClient)
        {
            var client = await _context.Clients.SingleOrDefaultAsync(x => x.IdClient == idClient);            
            var result = await ( from ct in _context.ClientTrips where ct.IdClient == idClient select ct).ToListAsync();
            if ( client == null )
            {
                return false;
            }

            if ( result.Count == 0 )
            {
                _context.Remove( client );

            }


            return await _context.SaveChangesAsync() > 0;
        }
    }
}

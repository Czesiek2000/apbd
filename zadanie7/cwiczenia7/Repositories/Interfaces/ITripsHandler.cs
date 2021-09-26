using cwiczenia7.DTO.Requests;
using cwiczenia7.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia7.Repositories.Interfaces
{
    public interface ITripsHandler
    {
        public Task<ICollection<TripsDTO>> GetTripsAsync ();

        public Task<bool> UpdateClients (ClientDTO clients);
    }
}

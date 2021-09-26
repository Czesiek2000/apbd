using cwiczenia7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia7.Repositories.Interfaces
{
    public interface IClientHandler
    {
        public Task<bool> DeleteClient (int idClient);
    }
}

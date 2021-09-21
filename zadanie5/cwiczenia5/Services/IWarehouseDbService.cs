using cwiczenia5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia5.Services
{
    public interface IWarehouseDbService
    {
        public Task<int> PostWarehouse ( Warehouse warehouse);
    }
}

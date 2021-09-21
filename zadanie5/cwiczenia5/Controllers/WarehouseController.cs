using cwiczenia5.Models;
using cwiczenia5.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia5.Controllers
{
    [ApiController]
    [Route("api/warehouses")]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseDbService _wearehouseDbService;

        public WarehouseController(IWarehouseDbService warehouseDbService )
        {
            _wearehouseDbService = warehouseDbService;
        }

        [HttpPost]
        public async Task<IActionResult> GetWarehouses (Warehouse warehouse)
        {
            var result = _wearehouseDbService.PostWarehouse(warehouse);
            
            return Ok( result );
        }
    }
}

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
    [Route("api/warehouses2")]
    public class Warehouse2Controller : ControllerBase
    {
        private readonly IWarehouseDbService2 _wearehouseDbService;

        public Warehouse2Controller ( IWarehouseDbService2 warehouseDbService )
        {
            _wearehouseDbService = warehouseDbService;
        }

        [HttpPost]
        public async Task<IActionResult> GetWarehouses ( Warehouse warehouse )
        {
            _wearehouseDbService.PostWarehouse( warehouse );
            return Ok( "Warehouse state changed" );
        }
    }
}

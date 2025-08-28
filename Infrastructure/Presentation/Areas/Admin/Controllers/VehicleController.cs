using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Vehicles;
using ZK.Services.Abstractions;

namespace ZK.Presentation.Areas.Admin.Controllers
{
    [ApiController]
    [Route("admin/[controller]")]
    public class VehicleController: ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public VehicleController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var vehicle = await _serviceManager.VehicleService.GetAllIncludingSoldOutAsync(cancellationToken);
            return Ok(vehicle);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] AddVehicleDTO value, CancellationToken cancellationToken)
        {
            await this._serviceManager.VehicleService.AddAsync(value, cancellationToken);
            return Ok();
        }
    }
}

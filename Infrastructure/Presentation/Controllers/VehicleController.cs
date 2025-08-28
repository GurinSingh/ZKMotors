using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ZK.Services.Abstractions;

namespace ZK.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController: ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public VehicleController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
        }
        [HttpGet("Get/{slug}")]
        public async Task<IActionResult> GetBySlugAsync(string slug, CancellationToken cancellationToken)
        {
            var vehicle = await _serviceManager.VehicleService.GetBySlugAsync(slug, cancellationToken);
            return Ok(vehicle);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var vehicles = await _serviceManager.VehicleService.GetAllAsync(cancellationToken);
            return Ok(vehicles);
        }
        
    }
}

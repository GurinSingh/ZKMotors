using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Services.Abstractions;

namespace ZK.Presentation.Areas.Admin.Controllers
{
    [Authorize]
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class DashboardController: ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public DashboardController(IServiceManager serviceManager) =>
            this._serviceManager = serviceManager;

        [HttpGet("GetStats")]
        public async Task<IActionResult> GetStatsAsync(CancellationToken cancellationToken)
        {
            var stats = await this._serviceManager.VehicleService.GetDashboardStats(cancellationToken);
            return Ok(stats);
        }
    }
}

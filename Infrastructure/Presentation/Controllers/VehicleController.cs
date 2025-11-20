using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Vehicles;
using ZK.Domain.Entities.Vehicles;
using ZK.Services.Abstractions;

namespace ZK.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
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

        [HttpGet("GetRelated/{vehicleId}")]
        public async Task<IActionResult> GetRelatedByBodyTypeAsync(int vehicleId, CancellationToken cancellationToken)
        {
            var vehicles = await this._serviceManager.VehicleService.GetRelatedVehicleById(vehicleId, cancellationToken);
            return Ok(vehicles);
        }

        [HttpGet("GetVehicleMakes")]
        public async Task<IActionResult> GetAllVehicleMakesAsync(CancellationToken cancellationToken)
        {
            var vehicleMake = await this._serviceManager.VehicleMakeService.GetAllAsync(cancellationToken);
            return Ok(vehicleMake);
        }

        [HttpGet("GetVehicleModels")]
        public async Task<IActionResult> GetVehicleAllModelsAsync(CancellationToken cancellationToken)
        {
            var vehicleModel = await this._serviceManager.VehicleModelService.GetAllAsync(cancellationToken);
            return Ok(vehicleModel);
        }

        [HttpGet("GetVehicleModels/{vehicleMakeId}")]
        public async Task<IActionResult> GetVehicleModelsByMakeIdAsync(int vehicleMakeId, CancellationToken cancellationToken)
        {
            var vehicleModel = await this._serviceManager.VehicleModelService.GetByMakeIdAsync(vehicleMakeId, cancellationToken);
            return Ok(vehicleModel);
        }

        [HttpGet("GetBodyTypes")]
        public async Task<IActionResult> GetAllBodyTypesAsync(CancellationToken cancellationToken)
        {
            var bodyTypes = await this._serviceManager.BodyTypeService.GetAllAsync(cancellationToken);
            return Ok(bodyTypes);
        }

        [HttpGet("GetVehicleStatuses")]
        public async Task<IActionResult> GetAllVehicleStatusesAsync(CancellationToken cancellationToken)
        {
            var vehicleStatuses = await this._serviceManager.VehicleStatusService.GetAllAsync(cancellationToken);
            return Ok(vehicleStatuses);
        }
        [HttpGet("GetFuelTypes")]
        public async Task<IActionResult> GetAllFuelTypesAsync(CancellationToken cancellationToken)
        {
            var fuelTypes = await this._serviceManager.FuelTypeService.GetAllAsync(cancellationToken);
            return Ok(fuelTypes);
        }
        [HttpGet("GetTransmissions")]
        public async Task<IActionResult> GetAllTransmissionsAsync(CancellationToken cancellationToken)
        {
            var transmissions = await this._serviceManager.TransmissionService.GetAllAsync(cancellationToken);
            return Ok(transmissions);
        }
        [HttpGet("GetDrivetrains")]
        public async Task<IActionResult> GetAllDrivetrainsAsync(CancellationToken cancellationToken)
        {
            var drivetrains = await this._serviceManager.DrivetrainService.GetAllAsync(cancellationToken);
            return Ok(drivetrains);
        }
    }
}

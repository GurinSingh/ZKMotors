﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ZK.Contracts.DTOs.Vehicles;
using ZK.Services.Abstractions;

namespace ZK.Presentation.Areas.Admin.Controllers
{
    [ApiController]
    [Route("admin/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public VehicleController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var vehicle = await _serviceManager.VehicleService.GetAllAsync(cancellationToken);
            return Ok(vehicle);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromForm] AddVehicleDTO value, IList<IFormFile> imageData, CancellationToken cancellationToken)
        {
            //code to be removed
            for (int i = 0, l = imageData.Count; i < l; i++)
                value.Images.Add(new AddVehicleImageDTO
                {
                    FileName = imageData[i].FileName,
                    ContentType = imageData[i].ContentType,
                    ImageData = imageData[i]
                });

            await this._serviceManager.VehicleService.AddAsync(value, cancellationToken);
            return Ok();
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateVehicleDTO updateVehicleDTO, IList<IFormFile> imageData, CancellationToken cancellationToken)
        {
            //code to be removed
            for (int i = 0, l = imageData.Count; i < l; i++)
                updateVehicleDTO.Images.Add(new UpdateVehicleImageDTO
                {
                    FileName = imageData[i].FileName,
                    ContentType = imageData[i].ContentType,
                    ImageData = imageData[i]
                });
            await this._serviceManager.VehicleService.UpdateAsync(updateVehicleDTO, cancellationToken);
            return Ok();
        }

        [HttpPost("MarkAsSold")]
        public async Task<IActionResult> MarkAsSoldAsync([FromQuery] int vehicleId, CancellationToken cancellationToken)
        {
            var vehicle = await this._serviceManager.VehicleService.GetByIdAsync(vehicleId, cancellationToken);
            if (vehicle == null)
                return NotFound();

            await this._serviceManager.VehicleService.MarkAsSold(vehicleId, cancellationToken);
            return Ok();
        }
        [HttpPost("AddVehicleMake")]
        public async Task<IActionResult> AddVehicleMakeAsync([FromQuery] AddVehicleMakeDTO addVehicleMakeDTO, IFormFile imageData, CancellationToken cancellationToken)
        {
            //code to be removed
            addVehicleMakeDTO.ImageData = imageData;

            await this._serviceManager.VehicleMakeService.AddAsync(addVehicleMakeDTO, cancellationToken);
            return Ok();
        }
        [HttpPut("UpdateVehicleMake")]
        public async Task<IActionResult> UpdateVehicleMakeAsync(UpdateVehicleMakeDTO updateVehicleMakeDto, IFormFile imageData, CancellationToken cancellation)
        {
            //code to be removed
            updateVehicleMakeDto.ImageData = imageData;

            await this._serviceManager.VehicleMakeService.UpdateAsync(updateVehicleMakeDto, cancellation);
            return Ok();
        }
    }
}

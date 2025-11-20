using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Vehicles;
using ZK.Domain.Respositories;
using ZK.Services.Abstractions.Vehicles;
using ZK.Services.MappingExtensions.Vehicles;

namespace ZK.Services.Vehicles
{
    public class DrivetrainService : IDrivetrainService
    {
        private readonly IRepositoryManager _repositoryManager;
        public DrivetrainService(IRepositoryManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<ViewDrivetrainDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var drivetrains = await this._repositoryManager.DrivetrainRepository.GetAllAsync(cancellationToken);
            return drivetrains.Select(d => d.ToDTO());
        }

        public async Task<ViewDrivetrainDTO> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var drivetrain = await this._repositoryManager.DrivetrainRepository.GetByIdAsync(id, cancellationToken);
            return drivetrain.ToDTO();
        }
    }
}

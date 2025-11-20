using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ZK.Domain.Entities.Vehicles;
using ZK.Domain.Enums;
using ZK.Domain.Respositories.Vehicles;

namespace ZK.Persistence.Repositories.Vehicles
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ZKDbContext _context;
        public VehicleRepository(ZKDbContext context)
        {
            this._context = context;
        }
        public async Task AddAsync(Vehicle vehicle, CancellationToken cancellationToken)
        {
            await this._context.Vehicles.AddAsync(vehicle, cancellationToken);
        }

        public async Task UpdateAsync(Vehicle vehicle, CancellationToken cancellationToken)
        {
            this._context.Vehicles.Update(vehicle);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await this._context.Vehicles.Where(v=> v.StatusId == (int)eVehicleStatus.OnSale).WithAllJoins().ToListAsync(cancellationToken);
        }

        public async Task<Vehicle> GetByIdAsync(int vehicleId, CancellationToken cancellationToken)
        {
            return await this._context.Vehicles.WithAllJoins().FirstOrDefaultAsync(v=> v.VehicleId == vehicleId, cancellationToken);
        }

        public async Task<Vehicle> GetBySlugAsync(string slug, CancellationToken cancellationToken)
        {
            return await this._context.Vehicles.WithAllJoins().FirstOrDefaultAsync(v => v.Slug == slug, cancellationToken);
        }

        public async Task<Vehicle> GetAsync(Expression<Func<Vehicle, bool>> predicate, CancellationToken cancellationToken)
        {
            return await this._context.Vehicles.WithAllJoins().FirstOrDefaultAsync(predicate, cancellationToken);
        }
        public async Task<IEnumerable<Vehicle>> GetManyAsync(Expression<Func<Vehicle, bool>> predicate, CancellationToken cancellationToken)
        {
            return await this._context.Vehicles.Where(predicate).WithAllJoins().ToListAsync(cancellationToken);
        }
    }
    public static class VehicleQueryExtensions
    {
        public static IQueryable<Vehicle> WithAllJoins(this IQueryable<Vehicle> query)
        {
            return query.Include(v => v.VehicleBasicIdentification)
                        .Include(v => v.VehicleTechnicalSpecification)
                        .Include(v => v.SaleHistory)
                        .Include(v => v.VehicleImages);
        }
    }
}

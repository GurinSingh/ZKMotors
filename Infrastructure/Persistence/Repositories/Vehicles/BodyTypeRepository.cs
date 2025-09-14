using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Entities.Vehicles;
using ZK.Domain.Respositories.Vehicles;

namespace ZK.Persistence.Repositories.Vehicles
{
    public class BodyTypeRepository : IBodyTypeRepository
    {
        private readonly ZKDbContext _context;
        public BodyTypeRepository(ZKDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<BodyType>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await this._context.BodyTypes.ToListAsync(cancellationToken);
        }
        public async Task<BodyType> GetByIdAsync(int bodyTypeId, CancellationToken cancellationToken)
        {
            return await this._context.BodyTypes.FirstOrDefaultAsync(bt => bt.BodyTypeId == bodyTypeId, cancellationToken);
        }
    }
}

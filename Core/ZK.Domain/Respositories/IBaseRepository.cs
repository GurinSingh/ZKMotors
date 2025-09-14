using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ZK.Domain.Respositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    }
}

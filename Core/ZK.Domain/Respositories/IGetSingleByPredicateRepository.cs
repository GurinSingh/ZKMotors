using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ZK.Domain.Respositories
{
    public interface IGetSingleByPredicateRepository<T> where T : class
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    }
}

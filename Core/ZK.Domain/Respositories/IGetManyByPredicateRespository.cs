using System.Linq.Expressions;

namespace ZK.Domain.Respositories
{
    public interface IGetManyByPredicateRespository<T> where T : class
    {
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    }
}

//TODO: using Ardalis.Specification; for ISpecification<T>
using LibraryDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryDataAccess.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<T>> ListAllAsync(CancellationToken cancellationToken = default);
        Task<List<T>> ListAllAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<int> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    }
}

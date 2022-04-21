using System.Collections.Generic;
using System.Threading.Tasks;
using core.Specificatoins;
using Core.Entities;

namespace core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetByIdAsync(int id);

        Task<T> GetEntityWithSpec(ISpecification<T> spec);

        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    }
}
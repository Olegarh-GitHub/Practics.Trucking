using System.Threading.Tasks;
using Practics.Trucking.Domain.Models.Base;

namespace Practics.Trucking.Domain.Interfaces
{
    public interface IAsyncRepository<TEntity> : IRepository<TEntity> 
        where TEntity : Entity
    {
        public Task<TEntity> CreateAsync(TEntity entity);
        public Task<TEntity> UpdateAsync(TEntity entity);
        public Task<bool> DeleteAsync(TEntity entity);
    }
}
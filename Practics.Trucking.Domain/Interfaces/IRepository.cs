using System.Linq;
using Practics.Trucking.Domain.Models.Base;

namespace Practics.Trucking.Domain.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        public TEntity Create(TEntity entity);
        public TEntity Update(TEntity entity);
        public IQueryable<TEntity> Read();
        public bool Delete(TEntity entity);
    }
}
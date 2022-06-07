using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Practics.Trucking.Domain.Interfaces;
using Practics.Trucking.Domain.Models.Base;
using Practics.Trucking.Infrastructure.Contexts;

namespace Practics.Trucking.Infrastructure.Repositories
{
    public class EntityFrameworkAsyncRepository<TEntity> : EntityFrameworkRepository<TEntity>, IAsyncRepository<TEntity>
        where TEntity : Entity
    {
        public EntityFrameworkAsyncRepository(ApplicationContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            TEntity existedEntity = await Read().FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (existedEntity is not null)
                return existedEntity;

            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            TEntity existedEntity = await Read().FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (existedEntity is null)
                return await CreateAsync(entity);

            _mapper.Map(entity, existedEntity);
            
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return existedEntity;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            TEntity existedEntity = await Read().FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (existedEntity is null)
                return false;

            _dbSet.Remove(existedEntity);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
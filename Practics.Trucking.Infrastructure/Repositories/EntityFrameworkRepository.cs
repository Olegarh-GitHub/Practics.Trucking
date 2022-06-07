using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Practics.Trucking.Domain.Interfaces;
using Practics.Trucking.Domain.Models.Base;
using Practics.Trucking.Infrastructure.Contexts;

namespace Practics.Trucking.Infrastructure.Repositories
{
    public class EntityFrameworkRepository<TEntity> : IRepository<TEntity> 
        where TEntity : Entity
    {
        protected readonly ApplicationContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly IMapper _mapper;

        public EntityFrameworkRepository
        (
            ApplicationContext context,
            IMapper mapper
        )
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
            
            _mapper = mapper;
        }

        public TEntity Create(TEntity entity)
        {
            TEntity existedEntity = Read().FirstOrDefault(x => x.Id == entity.Id);

            if (existedEntity is not null)
                return existedEntity;

            _dbSet.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            TEntity existedEntity = Read().FirstOrDefault(x => x.Id == entity.Id);

            if (existedEntity is null)
                return Create(entity);

            _mapper.Map(entity, existedEntity);

            _dbSet.Update(existedEntity);
            _context.SaveChanges();

            return existedEntity;
        }

        public IQueryable<TEntity> Read()
        {
            return _dbSet.AsQueryable();
        }

        public bool Delete(TEntity entity)
        {
            TEntity existedEntity = Read().FirstOrDefault(x => x.Id == entity.Id);

            if (existedEntity is null)
                return false;

            _dbSet.Remove(existedEntity);
            _context.SaveChanges();

            return true;
        }
    }
}
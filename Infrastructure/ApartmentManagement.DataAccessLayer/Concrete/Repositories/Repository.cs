using ApartmentManagement.DataAccessLayer.Abstract.Repositoreis;
using ApartmentManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagement.DataAccessLayer.Concrete.Repositories;

public class Repository<TEntity, TContext> : IRepository<TEntity> where TEntity : BaseEntity where TContext : DbContext
    {
        protected readonly TContext Context;
        protected readonly DbSet<TEntity> DbSet;
        public Repository(TContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }
        public virtual TEntity Add(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            return entity;
        }

        public virtual IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            Context.AddRange(entities);
            return entities;
        }

        public virtual TEntity Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public virtual IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>().Where(x => x.IsDeleted != null && x.IsActive && (bool)!x.IsDeleted);
        }
        public virtual TEntity Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            entity.IsSoftDelete = true;
            return entity;
        }

        public virtual List<TEntity> Delete(List<TEntity> entities)
        {

            foreach (var entity in entities)
            {
                Context.Entry(entity).State = EntityState.Deleted;
                entity.IsSoftDelete = true;
            }
            DbSet.RemoveRange(entities);
            return entities;
        }

        public virtual TEntity ForceDelete(TEntity entity)
        {
            entity.IsSoftDelete = false;
            Context.Entry(entity).State = EntityState.Deleted;
            return entity;
        }

        public virtual List<TEntity> ForceDelete(List<TEntity> entities)
        {

            foreach (var entity in entities)
            {
                entity.IsSoftDelete = false;
                Context.Entry(entity).State = EntityState.Deleted;
            }
            DbSet.RemoveRange(entities);
            return entities;
        }
    }
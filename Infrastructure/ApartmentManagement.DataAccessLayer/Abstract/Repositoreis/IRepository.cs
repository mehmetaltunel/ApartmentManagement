using ApartmentManagement.Entities;

namespace ApartmentManagement.DataAccessLayer.Abstract.Repositoreis;

public interface IRepository<TEntity> : IBaseRepository where TEntity : BaseEntity
{
    TEntity Add(TEntity entity);
    IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);
    TEntity Update(TEntity entity);
    TEntity Delete(TEntity entity);
    List<TEntity> Delete(List<TEntity> entities);
    TEntity ForceDelete(TEntity entity);
    List<TEntity> ForceDelete(List<TEntity> entities);
    IQueryable<TEntity> Query();
}
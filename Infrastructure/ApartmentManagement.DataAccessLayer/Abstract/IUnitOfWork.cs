using System.Data;
using ApartmentManagement.DataAccessLayer.Abstract.Repositoreis;

namespace ApartmentManagement.DataAccessLayer.Abstract;

public interface IUnitOfWork : IDisposable
{
    void OpenTransaction();
    void OpenTransaction(IsolationLevel isolationLevel);
    void Commit();
    void Rollback();
    int SaveChanges();
    Task<int> SaveChangesAsync();
    TRepo Repository<TRepo>() where TRepo : IBaseRepository;
}
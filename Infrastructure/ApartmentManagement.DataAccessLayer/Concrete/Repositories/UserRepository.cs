using ApartmentManagement.DataAccessLayer.Abstract.Repositoreis;
using ApartmentManagement.DataAccessLayer.Concrete.Contexts;
using ApartmentManagement.Entities.Models;

namespace ApartmentManagement.DataAccessLayer.Concrete.Repositories;

public class UserRepository : Repository<User, ApartmentManagementDbContext>, IUserRepository
{
    public UserRepository(ApartmentManagementDbContext context) : base(context)
    {
    }
}
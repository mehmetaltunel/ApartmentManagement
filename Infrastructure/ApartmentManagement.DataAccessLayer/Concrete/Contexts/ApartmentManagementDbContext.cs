using ApartmentManagement.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagement.DataAccessLayer.Concrete.Contexts;

public class ApartmentManagementDbContext : DbContext
{
    public ApartmentManagementDbContext(DbContextOptions options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    
    public DbSet<User> Users { get; set; }
}
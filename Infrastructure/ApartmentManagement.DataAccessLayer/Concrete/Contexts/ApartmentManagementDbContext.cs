using System.Security.Claims;
using ApartmentManagement.Entities;
using ApartmentManagement.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApartmentManagement.DataAccessLayer.Concrete.Contexts;

public class ApartmentManagementDbContext : DbContext
{
    public ApartmentManagementDbContext(DbContextOptions options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    
    public DbSet<User> Users { get; set; }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity && (
                e.State == EntityState.Added || e.State == EntityState.Modified));

        ServiceProvider serviceProvider = new ServiceCollection()
            .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
            .BuildServiceProvider();

        var httpAccessorService = serviceProvider.GetRequiredService<IHttpContextAccessor>();
        string currentUserId = httpAccessorService.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        foreach (var entityEntry in entries)
        {
            if (entityEntry.State == EntityState.Modified)
            {
                var entity = (BaseEntity)entityEntry.Entity;

                if (entity.UpdatedDate == null)
                    ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entity.UpdatedById == null)
                    ((BaseEntity)entityEntry.Entity).UpdatedById = Convert.ToInt32(currentUserId) == default ? null : Convert.ToInt32(currentUserId);
            }
            else if (entityEntry.State == EntityState.Added)
            {
                var entity = (BaseEntity)entityEntry.Entity;

                if (entity.CreatedDate == default)
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;

                if (entity.CreatedById == null)
                    ((BaseEntity)entityEntry.Entity).CreatedById = Convert.ToInt32(currentUserId) == default ? null : Convert.ToInt32(currentUserId);
                
                ((BaseEntity)entityEntry.Entity).IsActive = true;
                ((BaseEntity)entityEntry.Entity).IsDeleted = false;
            }
            
            else if (entityEntry.State == EntityState.Deleted)
            {
                var entity = (BaseEntity)entityEntry.Entity;
                ((BaseEntity)entityEntry.Entity).IsActive = true;
                ((BaseEntity)entityEntry.Entity).IsDeleted = false;
                if (entity.UpdatedDate == null)
                    ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entity.UpdatedById == null)
                    ((BaseEntity)entityEntry.Entity).UpdatedById = Convert.ToInt32(currentUserId) == default ? null : Convert.ToInt32(currentUserId);

                entityEntry.State = EntityState.Modified;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
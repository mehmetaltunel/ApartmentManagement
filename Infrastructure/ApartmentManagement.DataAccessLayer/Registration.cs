using ApartmentManagement.DataAccessLayer.Abstract;
using ApartmentManagement.DataAccessLayer.Concrete;
using ApartmentManagement.DataAccessLayer.Concrete.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ApartmentManagement.DataAccessLayer
{
    public static class Registration
    {
        public static void DataAccessLogicRegister(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("ConnectionString").Value;
            services.AddDbContext<ApartmentManagementDbContext>(x =>
            {
                x.UseNpgsql(connectionString, opt =>
                {
                    opt.CommandTimeout(120);
                });
                x.UseLazyLoadingProxies(false);
                x.EnableSensitiveDataLogging();
            });
            services.TryAddScoped(typeof(IUnitOfWork), typeof(UnitOfWork<ApartmentManagementDbContext>));
            services.TryAddScoped<DbContext, ApartmentManagementDbContext>();
        }
    }
}

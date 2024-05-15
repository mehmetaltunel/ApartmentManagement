using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ApartmentManagement.BusinessLogic;

public static class Registration
{
    public static void BusinessLogicRegister(this IServiceCollection services)
    {
        var assm = Assembly.GetExecutingAssembly();

        services.AddMediatR(assm);
       // services.AddAutoMapper(assm);
       // services.AddValidatorsFromAssembly(assm);
    }
}
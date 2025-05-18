using CarMk.Applicattion.UseCase.Services.GetAll;
using CarMk.Applicattion.UseCase.Services.GetById;
using CarMk.Applicattion.UseCase.Services.Register;
using CarMk.Core.Modules.Registration.Repositories;
using CarMk.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace CarMk.Applicattion.Services;

public static class ServiceService
{
    public static IServiceCollection AddServiceUseCase(this IServiceCollection services)
    {
        services.AddSingleton<IServiceRepository, ServiceRepository>();
        services.AddSingleton<RegisterServiceUseCase>();
        services.AddSingleton<GetAllServicesUseCase>();
        services.AddSingleton<GetServiceByIdUseCase>();

        return services;
    }
    
}
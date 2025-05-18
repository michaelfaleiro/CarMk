using CarMk.Applicattion.UseCase.Vehicles.GetAll;
using CarMk.Applicattion.UseCase.Vehicles.GetById;
using CarMk.Applicattion.UseCase.Vehicles.Register;
using CarMk.Core.Modules.Registration.Repositories;
using CarMk.Infra.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarMk.Applicattion.Services;

public static class VehicleService
{
    public static IServiceCollection AddVehicleService(this IServiceCollection services)
    {
        services.AddSingleton<IVehicleRepository, VehicleRepository>();
        services.AddSingleton<RegisterVehicleUseCase>();
        services.AddSingleton<GetAllVehiclesUseCase>();
        services.AddSingleton<GetVehicleByIdUseCase>();

        return services;
    }
    
}
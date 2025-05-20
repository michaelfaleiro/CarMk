using CarMk.Communication.Request.Vehicles;
using CarMk.Communication.Response;
using CarMk.Communication.Response.Services;
using CarMk.Communication.Response.Vehicles;
using CarMk.Core.Modules.Registration.Entities;
using CarMk.Core.Modules.Registration.Repositories;

namespace CarMk.Applicattion.UseCase.Vehicles.AddServiceVehicle;

public class AddServiceVehicleUseCase(IVehicleRepository vehicleRepository, IServiceRepository serviceRepository)
{
    public async Task<Response<VehicleWithServicesResponseJson>> Execute(AddVehicleServiceRequest request)
    {
        var service = await serviceRepository.GetById(request.ServiceId)
            ?? throw new Exception($"Service with not found");

        var vehicle = await vehicleRepository.GetById(request.VehicleId)
            ?? throw new Exception($"Vehicle with not found");

        var vehicleService = new VehicleService(
            service.Id,
            service.Description,
            service.ServiceGroup,
            request.TimeExecution,
            request.SuggestedPrice
        );
        
        vehicle.AddVehicleService(
            vehicleService
        );

        await vehicleRepository.Update(vehicle);

        return new Response<VehicleWithServicesResponseJson>
        {

            Data = new VehicleWithServicesResponseJson(
                vehicle.Id,
                vehicle.Make,
                vehicle.Model,
                vehicle.Years,
                vehicle.VehicleServices.Select(s => new VehicleServicesResponseJson(
                    s.ServiceId,
                    s.ServiceDescription,
                    s.ServiceGroup,
                    s.TimeExecution,
                    s.SuggestedPrice,
                    s.Active,
                    s.CreatedAt,
                    s.UpdatedAt
                )).ToList(),
                vehicle.CreatedAt,
                vehicle.UpdatedAt
            ),
        };
    }
}

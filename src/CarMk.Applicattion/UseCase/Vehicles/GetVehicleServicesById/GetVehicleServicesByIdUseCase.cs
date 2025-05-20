using CarMk.Communication.Response;
using CarMk.Communication.Response.Vehicles;
using CarMk.Core.Modules.Registration.Repositories;

namespace CarMk.Applicattion.UseCase.Vehicles.GetVehicleServicesById;

public class GetVehicleServicesByIdUseCase(IVehicleRepository repository)
{
    public async Task<Response<VehicleWithServicesResponseJson>> Execute(string vehicleId)
    {
        var vehicle = await repository.GetById(vehicleId)
            ?? throw new Exception("Vehicle not found");

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
using CarMk.Communication.Request.Vehicles;
using CarMk.Communication.Response;
using CarMk.Communication.Response.Vehicles;
using CarMk.Core.Modules.Registration.Entities;
using CarMk.Core.Modules.Registration.Repositories;

namespace CarMk.Applicattion.UseCase.Vehicles.Register;

public class RegisterVehicleUseCase(IVehicleRepository repository)
{
    public async Task<Response<VehicleResponseJson>> Execute(RegisterVehicleRequest request)
    {
        var vehicle = new Vehicle(
            request.Model,
            request.Make
        );
        
        foreach (var year in request.Years)
        {
            vehicle.AddYear(year);
        }
        
        var result = await repository.Create(vehicle);

        return new Response<VehicleResponseJson>
        {
            Data = new VehicleResponseJson(
                result.Id,
                result.Model,
                result.Make,
                result.Years.ToList(),
                result.CreatedAt,
                result.UpdatedAt
            ),
        };
    }
}
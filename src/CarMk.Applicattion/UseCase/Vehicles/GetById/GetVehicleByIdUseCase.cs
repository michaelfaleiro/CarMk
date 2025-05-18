using CarMk.Communication.Response;
using CarMk.Communication.Response.Vehicles;
using CarMk.Core.Modules.Registration.Repositories;

namespace CarMk.Applicattion.UseCase.Vehicles.GetById;

public class GetVehicleByIdUseCase(IVehicleRepository repository)
{
    public async Task<Response<VehicleResponseJson>> Execute(string id)
    {
        var vehicle = await repository.GetById(id) 
            ?? throw new Exception("Vehicle not found");

        return new Response<VehicleResponseJson>
        {
            Data = new VehicleResponseJson(
                vehicle.Id,
                vehicle.Model,
                vehicle.Make,
                vehicle.Years.ToList(),
                vehicle.CreatedAt,
                vehicle.UpdatedAt
            )
        };
    }
}
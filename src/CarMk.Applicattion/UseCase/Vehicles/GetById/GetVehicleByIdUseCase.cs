using CarMk.Communication.Response;
using CarMk.Communication.Response.Vehicles;
using CarMk.Core.Modules.Registration.Repositories;

namespace CarMk.Applicattion.UseCase.Vehicles.GetById;

public class GetVehicleByIdUseCase(IVehicleRepository repository)
{
    public async Task<Response<VehicleResponseJson>> Execute(string id)
    {
        var result = await repository.GetById(id) 
            ?? throw new Exception("Vehicle not found");

        return new Response<VehicleResponseJson>
        {
            Data = new VehicleResponseJson(
                result.Id,
                result.Model,
                result.Make,
                result.Years.ToList(),
                result.CreatedAt,
                result.UpdatedAt
            )
        };
    }
}
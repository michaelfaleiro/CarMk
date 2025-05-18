using CarMk.Communication.Response;
using CarMk.Communication.Response.Vehicles;
using CarMk.Core.Modules.Registration.Repositories;

namespace CarMk.Applicattion.UseCase.Vehicles.GetAll;

public class GetAllVehiclesUseCase(IVehicleRepository repository)
{
    public async Task<PagedResponse<VehicleResponseJson>> Execute(int pageNumber, int pageSize)
    {
        var vehicles = await repository.GetAll(pageNumber, pageSize)
            ?? throw new Exception("No vehicles found");

        var result = new PagedResponse<VehicleResponseJson>
        {
            Data = vehicles.Data.Select(
                vehicle => new VehicleResponseJson(
                    vehicle.Id,
                    vehicle.Model,
                    vehicle.Make,
                    vehicle.Years.ToList(),
                    vehicle.CreatedAt,
                    vehicle.UpdatedAt
                )
            ).ToList(),
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = vehicles.TotalCount
        };
        return result;
    }
}
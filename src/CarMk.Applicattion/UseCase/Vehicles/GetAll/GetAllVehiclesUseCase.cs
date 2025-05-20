using CarMk.Communication.Response;
using CarMk.Communication.Response.Vehicles;
using CarMk.Core.Modules.Registration.Repositories;

namespace CarMk.Applicattion.UseCase.Vehicles.GetAll;

public class GetAllVehiclesUseCase(IVehicleRepository repository)
{
    public async Task<PagedResponse<VehicleResponseJson>> Execute(int pageNumber, int pageSize)
    {
        var result = await repository.GetAll(pageNumber, pageSize);

        return new PagedResponse<VehicleResponseJson>
        {
            Data = result.Data.Select(vehicle => new VehicleResponseJson(
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
            TotalCount = result.TotalCount
        };
    }
}
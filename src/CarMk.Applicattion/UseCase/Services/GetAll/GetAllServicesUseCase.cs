using CarMk.Communication.Response;
using CarMk.Communication.Response.Services;
using CarMk.Core.Modules.Registration.Repositories;

namespace CarMk.Applicattion.UseCase.Services.GetAll;

public class GetAllServicesUseCase(IServiceRepository serviceRepository)
{
    public async Task<PagedResponse<ServiceResponseJson>> Execute(int pageNumber, int pageSize)
    {
        var result = await serviceRepository.GetAll(pageNumber, pageSize);

        return new PagedResponse<ServiceResponseJson>
        {
            Data = result.Data.Select(
                service => new ServiceResponseJson(
                    service.Id,
                    service.Description,
                    service.ServiceGroup,
                    service.Active,
                    service.CreatedAt,
                    service.UpdatedAt
                )
            ).ToList(),
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = result.TotalCount
            
        };
    }
   
}
using CarMk.Communication.Response;
using CarMk.Communication.Response.Services;
using CarMk.Core.Modules.Registration.Repositories;

namespace CarMk.Applicattion.UseCase.Services.GetById;

public class GetServiceByIdUseCase(IServiceRepository serviceRepository)
{
    public async Task<Response<ServiceResponseJson>> Execute(string id)
    {
        var result = await serviceRepository.GetById(id)
                      ?? throw new Exception("Service not found");
        
        return new Response<ServiceResponseJson>
        {
            Data = new ServiceResponseJson(
                result.Id,
                result.Description,
                result.ServiceGroup,
                result.Active,
                result.CreatedAt,
                result.UpdatedAt
            )
        };
    }
}
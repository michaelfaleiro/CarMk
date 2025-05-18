using CarMk.Communication.Response;
using CarMk.Communication.Response.Services;
using CarMk.Core.Modules.Registration.Repositories;

namespace CarMk.Applicattion.UseCase.Services.GetById;

public class GetServiceByIdUseCase(IServiceRepository serviceRepository)
{
    public async Task<Response<ServiceResponseJson>> Execute(string id)
    {
        var service = await serviceRepository.GetById(id)
                      ?? throw new Exception("Service not found");

        var response = new Response<ServiceResponseJson>
        {
            Data = new ServiceResponseJson(
                service.Id,
                service.Description,
                service.ServiceGroup,
                service.Active,
                service.CreatedAt,
                service.UpdatedAt
            )
        };

        return response;
    }
}
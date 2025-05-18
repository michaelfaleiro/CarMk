using CarMk.Communication.Request.Services;
using CarMk.Communication.Response;
using CarMk.Communication.Response.Services;
using CarMk.Core.Modules.Registration.Entities;
using CarMk.Core.Modules.Registration.Repositories;

namespace CarMk.Applicattion.UseCase.Services.Register;

public class RegisterServiceUseCase(IServiceRepository serviceRepository)
{
    public async Task<Response<ServiceResponseJson>> Execute(RegisterServiceRequest request)
    {
        var service = new Service(request.Description, request.ServiceGroup);
        await serviceRepository.Create(service);
        
        return new Response<ServiceResponseJson>
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
    }
}
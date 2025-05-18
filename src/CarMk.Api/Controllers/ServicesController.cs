using CarMk.Applicattion.UseCase.Services.GetAll;
using CarMk.Applicattion.UseCase.Services.GetById;
using CarMk.Applicattion.UseCase.Services.Register;
using CarMk.Communication.Request.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarMk.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServicesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post([FromServices] RegisterServiceUseCase useCase,
        [FromBody] RegisterServiceRequest request)
        => Created(string.Empty,await useCase.Execute(request));
   
    
    [HttpGet]
    public async Task<IActionResult> Get(
        [FromServices] GetAllServicesUseCase useCase,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber, int pageSize = Configuration.DefaultPageSize)
        =>  Ok(await useCase.Execute(pageNumber, pageSize));
    
    
    [HttpGet("{id:length(24)}")]
    public async Task<IActionResult> GetById([FromServices] GetServiceByIdUseCase useCase, string id) 
        => Ok(await useCase.Execute(id));
    
    
}
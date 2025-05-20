using CarMk.Applicattion.UseCase.Vehicles.AddServiceVehicle;
using CarMk.Applicattion.UseCase.Vehicles.GetAll;
using CarMk.Applicattion.UseCase.Vehicles.GetById;
using CarMk.Applicattion.UseCase.Vehicles.GetVehicleServicesById;
using CarMk.Applicattion.UseCase.Vehicles.Register;
using CarMk.Communication.Request.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace CarMk.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> RegisterVehicle([FromServices] RegisterVehicleUseCase useCase,
        [FromBody] RegisterVehicleRequest request)
        => Created(string.Empty, await useCase.Execute(request));

    [HttpGet]
    public async Task<IActionResult> GetAllVehicles([FromServices] GetAllVehiclesUseCase useCase,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber, int pageSize = Configuration.DefaultPageSize)
        => Ok(await useCase.Execute(pageNumber, pageSize));

    [HttpGet("{id:length(24)}")]
    public async Task<IActionResult> GetVehicleById([FromServices] GetVehicleByIdUseCase useCase,
        [FromRoute] string id)
        => Ok(await useCase.Execute(id));

    [HttpPost("Services")]
    public async Task<IActionResult> AddServiceToVehicle([FromServices] AddServiceVehicleUseCase useCase,
        [FromBody] AddVehicleServiceRequest request)
        => Created(string.Empty, await useCase.Execute(request));
    
    [HttpGet("{id:length(24)}/Services")]
    public async Task<IActionResult> GetVehicleServicesById([FromServices] GetVehicleServicesByIdUseCase useCase,
        [FromRoute] string id)
        => Ok(await useCase.Execute(id));
}
using CarMk.Communication.Response.Services;

namespace CarMk.Communication.Response.Vehicles;

public record VehicleWithServicesResponseJson(
    string Id,
    string Make,
    string Model,
    IEnumerable<string> Years,
    IEnumerable<VehicleServicesResponseJson> Services,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);


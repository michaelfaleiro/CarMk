namespace CarMk.Communication.Response.Vehicles;

public record VehicleResponseJson(
    string Id,
    string Model,
    string Make,
    IEnumerable<string> Years,
    DateTime CreatedAt,
    DateTime? UpdatedAt
    );
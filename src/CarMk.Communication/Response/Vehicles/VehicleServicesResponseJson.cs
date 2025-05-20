namespace CarMk.Communication.Response.Vehicles;

public record VehicleServicesResponseJson(
    string Id,
    string ServiceDescription,
    string ServiceGroup,
    int ExecutionTime,
    decimal SuggestedPrice,
    bool Active,
    DateTime CreatedAt,
    DateTime? UpdatedAt
    );

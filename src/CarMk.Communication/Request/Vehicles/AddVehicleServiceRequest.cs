namespace CarMk.Communication.Request.Vehicles;

public record AddVehicleServiceRequest(
    string VehicleId,
    string ServiceId,
    int TimeExecution,
    decimal SuggestedPrice
);
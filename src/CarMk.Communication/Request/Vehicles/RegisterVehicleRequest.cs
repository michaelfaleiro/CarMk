namespace CarMk.Communication.Request.Vehicles;

public record RegisterVehicleRequest(
    string Model,
    string Make,
    List<string> Years);

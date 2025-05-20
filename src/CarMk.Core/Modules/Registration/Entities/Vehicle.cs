using CarMk.Core.Shared.Entities;
using MongoDB.Bson.Serialization.Attributes;

namespace CarMk.Core.Modules.Registration.Entities;

[BsonIgnoreExtraElements]
public class Vehicle : BaseEntitiy
{
    public Vehicle(string model, string make)
    {
        Model = model;
        Make = make;
        Years = [];
        VehicleServices = [];
    }

    public string Model { get; private set; }
    public string Make { get; private set; }
    public IList<string> Years { get; private set; }
    public IList<VehicleService> VehicleServices { get; private set; }

    public void Update(string model, string make)
    {
        Model = model;
        Make = make;
        SetUpdatedAt();
    }

    public void AddYear(string year)
    {
        if (Years.Contains(year)) return;
        Years.Add(year);
        SetUpdatedAt();
    }

    public void RemoveYear(string year)
    {
        if (!Years.Contains(year)) return;
        Years.Remove(year);
        SetUpdatedAt();
    }

    public void AddVehicleService(VehicleService vehicleService)
    {
        if (VehicleServices.Any(vs => vs.ServiceId == vehicleService.Id)) return;
        VehicleServices.Add(vehicleService);
        SetUpdatedAt();
    }
    public void RemoveVehicleService(string serviceId)
    {
        var vehicleService = VehicleServices.FirstOrDefault(vs => vs.ServiceId == serviceId);
        if (vehicleService == null) return;
        VehicleServices.Remove(vehicleService);
        SetUpdatedAt();
    }
}
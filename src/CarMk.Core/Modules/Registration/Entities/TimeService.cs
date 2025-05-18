using CarMk.Core.Shared.Entities;

namespace CarMk.Core.Modules.Registration.Entities;

public class TimeService : BaseEntitiy
{
    public TimeService(string serviceId, string vehicleId, int timeExecution)
    {
        ServiceId = serviceId;
        VehicleId = vehicleId;
        TimeExecution = timeExecution;
        Active = true;
    }


    public string ServiceId { get; private set; }
    public string VehicleId { get; private set; }
    public int TimeExecution { get; private set; }
    public bool Active { get; private set; }

    public void Update(string serviceId, string vehicleId, int timeExecution)
    {
        ServiceId = serviceId;
        VehicleId = vehicleId;
        TimeExecution = timeExecution;
        SetUpdatedAt();
    }

    public void Activate()
    {
        Active = true;
        SetUpdatedAt();
    }

    public void Deactivate()
    {
        Active = false;
        SetUpdatedAt();
    }

}
using CarMk.Core.Shared.Entities;
using MongoDB.Bson.Serialization.Attributes;

namespace CarMk.Core.Modules.Registration.Entities;

[BsonIgnoreExtraElements]
public class VehicleService : BaseEntitiy
{
    public VehicleService(string serviceId, string serviceDescription, string serviceGroup,
        int timeExecution, decimal suggestedPrice)
    {
        ServiceId = serviceId;
        ServiceDescription = serviceDescription;
        ServiceGroup = serviceGroup;
        TimeExecution = timeExecution;
        SuggestedPrice = suggestedPrice;
        Active = true;
    }
    
    public string ServiceId { get; private set; }
    public string ServiceDescription { get; private set; }
    public string ServiceGroup { get; private set; }
    public int TimeExecution { get; private set; }
    public decimal SuggestedPrice { get; private set; }
    public bool Active { get; private set; }

    
    public void Update(string serviceId, string serviceDescription, string serviceGroup,
        int timeExecution, decimal suggestedPrice)
    {
        ServiceId = serviceId;
        ServiceDescription = serviceDescription;
        ServiceGroup = serviceGroup;
        TimeExecution = timeExecution;
        SuggestedPrice = suggestedPrice;
        SetUpdatedAt();
    }
    
    public void Activate()
    {
        Active = true;
        SetUpdatedAt();
    }
    
    public void Deactive()
    {
        Active = false;
        SetUpdatedAt();
    }
}

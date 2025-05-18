using CarMk.Core.Shared.Entities;

namespace CarMk.Core.Modules.Registration.Entities;

public class Service : BaseEntitiy
{
    public Service(string description, string serviceGroup)
    {
        Description = description;
        ServiceGroup = serviceGroup;
        Active = true;
    }


    public string Description { get; private set; }
    public string ServiceGroup { get; private set; }
    public bool Active { get; private set; }

    public void UpdateService(string description, string serviceGroup)
    {
        Description = description;
        ServiceGroup = serviceGroup;
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
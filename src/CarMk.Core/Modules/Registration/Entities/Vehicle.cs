using CarMk.Core.Shared.Entities;

namespace CarMk.Core.Modules.Registration.Entities;

public class Vehicle : BaseEntitiy
{
    public Vehicle(string model, string make)
    {
        Model = model;
        Make = make;
        Years = [];
    }

    public string Model { get; private set; }
    public string Make { get; private set; }
    public IList<string> Years { get; private set; }

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
}
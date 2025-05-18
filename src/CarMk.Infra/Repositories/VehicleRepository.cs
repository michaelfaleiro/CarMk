using CarMk.Core.Modules.Registration.Entities;
using CarMk.Core.Modules.Registration.Repositories;
using CarMk.Infra.Data;

namespace CarMk.Infra.Repositories;

public class VehicleRepository : MongoRepositoryBase<Vehicle>, IVehicleRepository
{
    public VehicleRepository(MongoDbContext database)
        : base(database.GetDatabase(), "Vehicles")
    {
        
    }
    
}
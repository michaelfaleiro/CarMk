using CarMk.Core.Modules.Registration.Entities;
using CarMk.Core.Modules.Registration.Repositories;
using CarMk.Infra.Data;

namespace CarMk.Infra.Repositories;

public class VehicleRepository(MongoDbContext context)
    : MongoRepositoryBase<Vehicle>(context.GetDatabase(), "Vehicles"), IVehicleRepository;
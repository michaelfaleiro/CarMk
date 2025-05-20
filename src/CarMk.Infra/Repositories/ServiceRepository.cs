using CarMk.Core.Modules.Registration.Entities;
using CarMk.Core.Modules.Registration.Repositories;
using CarMk.Infra.Data;

namespace CarMk.Infra.Repositories;

public class ServiceRepository(MongoDbContext context)
    : MongoRepositoryBase<Service>(context.GetDatabase(), "Services"), IServiceRepository;
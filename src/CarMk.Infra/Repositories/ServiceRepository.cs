using CarMk.Core.Modules.Registration.Entities;
using CarMk.Core.Modules.Registration.Repositories;
using CarMk.Infra.Data;

namespace CarMk.Infra.Repositories;

public class ServiceRepository : MongoRepositoryBase<Service>, IServiceRepository
{
    public ServiceRepository(MongoDbContext context) 
        : base(context.GetDatabase(), "Services")
    {
    }

}
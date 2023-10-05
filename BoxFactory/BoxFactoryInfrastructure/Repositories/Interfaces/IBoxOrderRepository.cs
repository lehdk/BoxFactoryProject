using BoxFactoryDomain.Entities;

namespace BoxFactoryInfrastructure.Repositories.Interfaces;

public interface IBoxOrderRepository
{

    Task<List<BoxOrder>> GetAllOrders();

}

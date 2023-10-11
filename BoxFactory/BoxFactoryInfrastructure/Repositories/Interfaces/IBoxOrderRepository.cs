using BoxFactoryDomain.Entities;
using BoxFactoryDomain.RequestModels;

namespace BoxFactoryInfrastructure.Repositories.Interfaces;

public interface IBoxOrderRepository
{

    Task<List<BoxOrder>> GetAllOrders();

    Task<bool> DeleteOrderById(int orderId);

    Task<BoxOrder?> CreateOrder(string street, string number, string city, string zip, List<CreateOrderLine> list);

    Task<DateTime> ShipOrder(int orderId);
}

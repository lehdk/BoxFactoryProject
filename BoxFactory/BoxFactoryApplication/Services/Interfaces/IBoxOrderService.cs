using BoxFactoryDomain.Entities;
using BoxFactoryDomain.RequestModels;

namespace BoxFactoryApplication.Services.Interfaces;

public interface IBoxOrderService
{

    Task<List<BoxOrder>> GetAllOrders();

    Task<bool> DeleteOrderById(int orderId);

    Task<BoxOrder?> CreateOrder(string street, string number, string city, string zip, List<CreateOrderLine> list);
}

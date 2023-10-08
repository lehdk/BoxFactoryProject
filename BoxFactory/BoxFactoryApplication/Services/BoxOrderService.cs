using BoxFactoryApplication.Services.Interfaces;
using BoxFactoryDomain.Entities;
using BoxFactoryDomain.RequestModels;
using BoxFactoryInfrastructure.Repositories.Interfaces;

namespace BoxFactoryApplication.Services;

public sealed class BoxOrderService : IBoxOrderService
{
    private readonly IBoxOrderRepository _boxOrderRepository;

    public BoxOrderService(IBoxOrderRepository boxOrderRepository)
    {
        _boxOrderRepository = boxOrderRepository;
    }

    public async Task<List<BoxOrder>> GetAllOrders()
    {
        return await _boxOrderRepository.GetAllOrders();
    }

    public async Task<bool> DeleteOrderById(int orderId)
    {
        return await _boxOrderRepository.DeleteOrderById(orderId);    
    }

    public async Task<BoxOrder?> CreateOrder(string street, string number, string city, string zip, List<CreateOrderLine> list)
    {
        return await _boxOrderRepository.CreateOrder(street, number, city, zip, list);
    }
}

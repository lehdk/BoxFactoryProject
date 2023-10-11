using BoxFactoryApplication.Services.Interfaces;
using BoxFactoryDomain.Entities;
using BoxFactoryDomain.Exceptions;
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
        if(list.Count == 0)
            throw new EmptyListException("There must be order lines to make an order");

        return await _boxOrderRepository.CreateOrder(street, number, city, zip, list);
    }

    public async Task<DateTime> ShipOrder(int orderId)
    {
        return await _boxOrderRepository.ShipOrder(orderId);
    }
}

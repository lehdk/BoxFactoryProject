using BoxFactoryApplication.Services.Interfaces;
using BoxFactoryDomain.Entities;
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
}

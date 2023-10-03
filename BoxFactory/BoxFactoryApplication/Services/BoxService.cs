using BoxFactoryApplication.Services.Interfaces;
using BoxFactoryDomain.Entities;
using BoxFactoryInfrastructure.Repositories.Interfaces;

namespace BoxFactoryApplication.Services;

public sealed class BoxService : IBoxService
{
    private readonly IBoxRepository _boxRepository;

    public BoxService(IBoxRepository boxRepository)
    {
        _boxRepository = boxRepository;
    }

    public async Task<List<Box>> GetAllBoxes()
    {
        return await _boxRepository.GetAllBoxes();
    }

    public async Task<Box?> GetBoxById(int id)
    {
        return await _boxRepository.GetBoxById(id);
    }

    public async Task<Box?> Create(short width, short height, short length, int weight, BoxColor color)
    {
        return await _boxRepository.Create(width, height, length, weight, color);
    }

    public async Task<Box> UpdateBox(int id, short width, short height, short length, int weight, BoxColor color)
    {
        return await _boxRepository.UpdateBox(id, width, height, length, weight, color);
    }
    public async Task<bool> DeleteBoxById(int id)
    {
        return await _boxRepository.DeleteBoxById(id);
    }
}

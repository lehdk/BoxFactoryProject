using BoxFactoryDomain.Entities;

namespace BoxFactoryInfrastructure.Repositories.Interfaces;

public interface IBoxRepository
{
    public Task<List<Box>> GetAllBoxes();

    public Task<Box?> GetBoxById(int id);

    public Task<bool> DeleteBoxById(int id);

    public Task<Box?> UpdateBox(int id, short width, short height, short length, int weight, BoxColor color);
    public Task<Box?> Create(short width, short height, short length, int weight, BoxColor color);
}

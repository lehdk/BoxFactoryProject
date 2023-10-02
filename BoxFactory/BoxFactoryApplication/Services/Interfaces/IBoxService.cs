namespace BoxFactoryApplication.Services.Interfaces;

using BoxFactoryDomain.Entities;

public interface IBoxService
{
    public Task<List<Box>> GetAllBoxes();

    public Task<Box?> GetBoxById(int id);

    public Task<bool> DeleteBoxById(int id);

    public Task<Box> UpdateBox();

    public Task<Box?> Create(short width, short height, short length, int weight, BoxColor color);
}

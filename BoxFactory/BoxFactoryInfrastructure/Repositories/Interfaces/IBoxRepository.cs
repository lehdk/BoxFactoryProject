using BoxFactoryDomain.Entities;

namespace BoxFactoryInfrastructure.Repositories.Interfaces;

public interface IBoxRepository
{
    public List<Box> GetAllBoxes();

    public Box GetBoxById(int id);

    public Box DeleteBoxById(int id);

    public Box UpdateBox();
}

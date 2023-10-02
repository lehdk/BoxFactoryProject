namespace BoxFactoryApplication.Services.Interfaces;

using BoxFactoryDomain.Entities;

public interface IBoxService
{
    public List<Box> GetAllBoxes();

    public Box GetBoxById(int id);

    public Box DeleteBoxById(int id);

    public Box UpdateBox();
}

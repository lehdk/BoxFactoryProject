using BoxFactoryApplication.Services;
using BoxFactoryDomain.Entities;
using BoxFactoryDomain.Exceptions;
using BoxFactoryDomain.RequestModels;
using BoxFactoryInfrastructure.Repositories.Interfaces;
using Moq;

namespace BoxFactoryUnitTests;

public class BoxOrderServiceTests
{

    private Mock<IBoxOrderRepository> _boxOrderRepositoryMock = new();

    private BoxOrderService _service => new BoxOrderService(_boxOrderRepositoryMock.Object);

    [Fact]
    public async Task CreateOrderReturnsOrderWithCorrectData()
    {
        // Arrange
        var sut = _service;

        // Act
        string street = "Test Street";
        string number = "2b";
        string city = "Varde";
        string zip = "6800";

        int boxId = 5;
        int amount = 2;
        double price = 2.4d;

        var orderLines = new List<CreateOrderLine>()
        {
            new CreateOrderLine()
            {
                BoxId = boxId,
                Amount = amount,
                Price = price,
            }
        };

        _boxOrderRepositoryMock.Setup(s => s.CreateOrder(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<CreateOrderLine>>())).ReturnsAsync(new BoxOrder()
        {
            Id = 1,
            Street = street,
            Number = number,
            City = city,
            Zip = zip,
            Lines = new HashSet<BoxOrderLine>()
            {
                new()
                {
                    Id = 42,
                    BoxId = boxId,
                    Amount = amount,
                    Price = price,
                }
            },
            OrderedAt = DateTime.UtcNow,
            ShippedAt = null
        });

        var result = await sut.CreateOrder(street, number, city, zip, orderLines);

        //Assert
        Assert.NotNull(result);

        Assert.Equal(street, result.Street);
        Assert.Equal(number, result.Number);
        Assert.Equal(city, result.City);
        Assert.Equal(zip, result.Zip);

        Assert.NotNull(result.Lines);

        Assert.Equal(orderLines.First().Price ,result.Lines.First().Price);
        Assert.Equal(amount, result.Lines.First().Amount);
        Assert.Equal(boxId, result.Lines.First().BoxId);
    }

    [Fact]
    public async Task CreateOrderThrowsEmptyListExceptionOnEmptyList()
    {
        // Arrange

        var sut = _service;

        // Act Assert

        await Assert.ThrowsAsync<EmptyListException>(() => sut.CreateOrder("street", "number", "city", "zip", new List<CreateOrderLine>()));
    }
}

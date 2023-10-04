using BoxFactoryAPI.Extensions;
using BoxFactoryDomain.Entities;

namespace BoxFactoryUnitTests;

public class DtoParsersTest
{
    [Fact]
    public void TestBoxToBoxDto()
    {
        // Arrange
        var box = new Box()
        {
            Id = 1,
            Width = 2,
            Height = 3,
            Length = 4,
            Weight = 5,
            Color = BoxColor.Blue,
            CreatedAt = DateTime.UtcNow,
        };

        // Act

        var result = box.ToDto();

        // Assert

        Assert.Equal(result.Id, box.Id);
        Assert.Equal(result.Width, box.Width);
        Assert.Equal(result.Height, box.Height);
        Assert.Equal(result.Length, box.Length);
        Assert.Equal(result.Weight, box.Weight);
        Assert.Equal(result.Color, box.Color);
        Assert.Equal(result.CreatedAt, box.CreatedAt);
    }
}
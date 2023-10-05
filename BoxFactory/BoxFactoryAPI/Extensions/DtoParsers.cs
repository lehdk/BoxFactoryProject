using BoxFactoryAPI.TransferModels;
using BoxFactoryDomain.Entities;

namespace BoxFactoryAPI.Extensions;

public static class DtoParsers
{
    public static List<BoxDTO> ToDto(this IList<Box> list)
    {
        return list.Select(b => b.ToDto()).ToList();
    }

    public static BoxDTO ToDto(this Box box)
    {
        return new()
        {
            Id = box.Id,
            Width = box.Width,
            Height = box.Height,
            Length = box.Length,
            Weight = box.Weight,
            Color = box.Color,
            Price = box.Price,
            CreatedAt = box.CreatedAt
        };
    }
}

using BoxFactoryAPI.TransferModels;
using BoxFactoryDomain.Entities;

namespace BoxFactoryAPI.Extensions;

public static class DtoParsers
{

    /*
     * BOX DTO
     */
    public static List<BoxDto> ToDto(this IList<Box> list)
    {
        return list.Select(b => b.ToDto()).ToList();
    }

    public static BoxDto ToDto(this Box box)
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

    /*
     * BOX ORDER DTO
     */

    public static List<BoxOrderDto> ToDto(this IList<BoxOrder> orderList)
    {
        return orderList.Select(o => o.ToDto()).ToList();
    }

    public static BoxOrderDto ToDto(this BoxOrder order)
    {
        return new BoxOrderDto()
        {
            Id = order.Id,
            Buyer = order.Buyer,
            OrderedAt = order.OrderedAt,
            IsShipped = order.IsShipped,
            Lines = order.Lines.Select(b => b.ToDto()).ToHashSet()
        };
    }

    public static BoxOrderLineDto ToDto(this BoxOrderLine boxOrderLine)
    {
        return new BoxOrderLineDto()
        {
            Id = boxOrderLine.Id,
            Box = boxOrderLine.Box.ToDto(),
            Amount = boxOrderLine.Amount,
            Price = boxOrderLine.Price
        };
    }
}

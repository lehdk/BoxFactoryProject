using BoxFactoryAPI.TransferModels;
using BoxFactoryDomain.Entities;
using BoxFactoryDomain.RequestModels;

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
            Street = order.Street,
            Number = order.Number,
            City = order.City,
            Zip = order.Zip,
            OrderedAt = order.OrderedAt,
            ShippedAt = order.ShippedAt,
            Lines = order.Lines.Select(b => b.ToDto()).ToHashSet()
        };
    }

    public static BoxOrderLineDto ToDto(this BoxOrderLine boxOrderLine)
    {
        return new BoxOrderLineDto()
        {
            Id = boxOrderLine.Id,
            Amount = boxOrderLine.Amount,
            Price = boxOrderLine.Price
        };
    }

    public static CreateOrderLine Parse(this AddOrderLineDto dto)
    {
        return new CreateOrderLine()
        {
            BoxId = dto.BoxId,
            Amount = dto.Amount,
            Price = dto.Price,
        };
    }

    public static List<CreateOrderLine> Parse(this List<AddOrderLineDto> list)
    {
        return list.Select(i => i.Parse()).ToList();
    }
}

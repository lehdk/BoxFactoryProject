using System.ComponentModel.DataAnnotations;

namespace BoxFactoryDomain.RequestModels;

public sealed class CreateOrderLine
{
    [Required]
    public int BoxId { get; set; }

    [Required]
    public int Amount { get; set; }

    [Required]
    public double Price { get; set; }
}

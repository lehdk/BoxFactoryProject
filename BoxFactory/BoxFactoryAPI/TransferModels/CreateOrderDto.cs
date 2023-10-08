using System.ComponentModel.DataAnnotations;

namespace BoxFactoryAPI.TransferModels;

public sealed class CreateOrderDto
{
    [Required]
    [StringLength(100)]
    public string Street { get; set; } = string.Empty;

    [Required]
    [StringLength(20)]
    public string Number { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string City { get; set; } = string.Empty;

    [Required]
    [StringLength(20)]
    public string Zip { get; set; } = string.Empty;

    public List<AddOrderLineDto> OrderLines { get; set; } = new List<AddOrderLineDto>();
}

public sealed class AddOrderLineDto
{
    [Required]
    public int BoxId { get; set; }

    [Required]
    public int Amount { get; set; }

    [Required]
    public double Price { get; set; }
}

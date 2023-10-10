
using System.ComponentModel.DataAnnotations;

namespace BoxFactoryAPI.TransferModels;

public sealed class BoxOrderDto
{
    [Required]
    public int Id { get; set; }

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

    [Required]
    public DateTime OrderedAt { get; set; }

    public DateTime? ShippedAt { get; set; } = null;

    [Required]
    public HashSet<BoxOrderLineDto> Lines { get; set; } = new HashSet<BoxOrderLineDto>();
}

public sealed class BoxOrderLineDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int Amount { get; set; }

    [Required]
    public double Price { get; set; }
}


using System.ComponentModel.DataAnnotations;

namespace BoxFactoryAPI.TransferModels;

public sealed class BoxOrderDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Buyer { get; set; } = string.Empty;

    [Required]
    public DateTime OrderedAt { get; set; }

    [Required]
    public bool IsShipped = false;

    [Required]
    public HashSet<BoxOrderLineDto> Lines { get; set; } = new HashSet<BoxOrderLineDto>();
}

public sealed class BoxOrderLineDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    public BoxDto Box { get; set; }

    [Required]
    public int Amount { get; set; }

    [Required]
    public double Price { get; set; }
}

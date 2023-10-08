using System.ComponentModel.DataAnnotations;

namespace BoxFactoryDomain.Entities;

public sealed class BoxOrder
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
    public HashSet<BoxOrderLine> Lines { get; set; } = new HashSet<BoxOrderLine>();
}

public sealed class BoxOrderLine
{
    [Required]
    public int Id { get; set; }

    [Required]
    public Box Box { get; set; }

    [Required]
    public int Amount { get; set; }

    [Required]
    public double Price { get; set; }
}

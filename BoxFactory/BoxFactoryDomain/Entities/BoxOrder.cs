﻿using System.ComponentModel.DataAnnotations;

namespace BoxFactoryDomain.Entities;

public sealed class BoxOrder
{
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Buyer { get; set; } = string.Empty;

    [Required]
    public DateTime OrderedAt { get; set; }

    [Required]
    public bool IsShipped = false;

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

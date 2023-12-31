﻿using System.ComponentModel.DataAnnotations;
using BoxFactoryDomain.Entities;

namespace BoxFactoryAPI.TransferModels;

public sealed class ModifyObjectDto
{
    /// <summary>
    /// The width of the box in cm
    /// </summary>
    [Range(0, 2000)]
    [Required]
    public short Width { get; set; }

    /// <summary>
    /// The height of the box in cm
    /// </summary>
    [Range(0, 2000)]
    [Required]
    public short Height { get; set; }

    /// <summary>
    /// The length of the box in cm
    /// </summary>
    [Range(0, 2000)]
    [Required]
    public short Length { get; set; }

    /// <summary>
    /// Weight in grams
    /// </summary>
    [Required]
    public int Weight { get; set; }

    /// <summary>
    /// The color of the box
    /// </summary>
    [Required]
    public BoxColor Color { get; set; }

    /// <summary>
    /// The price of the box in DKK
    /// </summary>
    [Required]
    public double Price { get; set; }

}

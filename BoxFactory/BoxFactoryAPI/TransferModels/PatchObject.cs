using System.ComponentModel.DataAnnotations;
using BoxFactoryDomain.Entities;

namespace BoxFactoryAPI.TransferModels;

public sealed class PatchObject
{
    /// <summary>
    /// The width of the box in milimeters
    /// </summary>
    [Range(0, 2000)]
    public short Width { get; set; }

    /// <summary>
    /// The height of the box in milimeters
    /// </summary>
    [Range(0, 2000)]
    public short Height { get; set; }

    /// <summary>
    /// The length of the box in milimeters
    /// </summary>
    [Range(0, 2000)]
    public short Length { get; set; }

    /// <summary>
    /// Weight in grams
    /// </summary>
    public int Weight { get; set; }

    /// <summary>
    /// The color of the box
    /// </summary>
    public BoxColor Color { get; set; }
}

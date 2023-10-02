using BoxFactoryDomain.Entities;
using System.ComponentModel.DataAnnotations;

namespace BoxFactoryAPI.TransferModels;

public sealed class BoxDTO
{
    public int Id { get; set; }

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

    /// <summary>
    /// The date and time when the box was created
    /// </summary>
    public DateTime CreatedAt { get; set; }
}
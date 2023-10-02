using System.ComponentModel.DataAnnotations;

namespace BoxFactoryDomain.Entities;

public sealed class Box
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

public enum BoxColor
{
    Red = 0,
    Blue = 1,
    Green = 2,
    Yellow = 3,
    Purple = 4,
    Orange = 5,
    Pink = 6,
    Brown = 7,
    Gray = 8,
    Teal = 9,
    Cyan = 10,
    Magenta = 11,
    Indigo = 12,
    Lavender = 13,
    Turquoise = 14,
    Maroon = 15,
}
namespace Ambev.DeveloperEvaluation.Domain.ValueObjects.Users;

/// <summary>
/// Value Object for representing a geographic location.
/// Includes latitude and longitude.
/// </summary>
public class Geolocation
{
    /// <summary>
    /// Gets or sets the latitude coordinate.
    /// </summary>
    public decimal Lat { get; set; }

    /// <summary>
    /// Gets or sets the longitude coordinate.
    /// </summary>
    public decimal Long { get; set; }
}
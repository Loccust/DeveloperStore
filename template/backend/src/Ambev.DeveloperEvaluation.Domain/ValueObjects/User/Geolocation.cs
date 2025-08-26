namespace Ambev.DeveloperEvaluation.Domain.ValueObjects.User;

/// <summary>
/// Value Object for representing a geographic location.
/// Includes latitude and longitude.
/// </summary>
public class Geolocation
{
    /// <summary>
    /// Gets or sets the latitude coordinate.
    /// </summary>
    public string Lat { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the longitude coordinate.
    /// </summary>
    public string Long { get; set; } = string.Empty;
}
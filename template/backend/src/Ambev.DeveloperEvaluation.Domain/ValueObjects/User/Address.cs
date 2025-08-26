namespace Ambev.DeveloperEvaluation.Domain.ValueObjects.User;

/// <summary>
/// Value Object for representing a postal address.
/// Includes city, street, number, zipcode and geolocation.
/// </summary>
public class Address
{
    /// <summary>
    /// Gets or sets the city where the user lives.
    /// </summary>
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the street where the user lives.
    /// </summary>
    public string Street { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the number of the building or house.
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Gets or sets the zipcode of the user's address.
    /// </summary>
    public string Zipcode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the geolocation of the address.
    /// Includes latitude and longitude.
    /// </summary>
    public Geolocation Geolocation { get; set; } = new();
}
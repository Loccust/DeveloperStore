namespace Ambev.DeveloperEvaluation.Application.Models.Users;

/// <summary>
/// Model for representing geolocation (latitude and longitude).
/// </summary>
public record GeolocationModel(
    int Lat,
    int Long
);
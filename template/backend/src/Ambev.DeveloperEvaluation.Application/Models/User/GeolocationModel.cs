namespace Ambev.DeveloperEvaluation.Application.Models.User;

/// <summary>
/// Model for representing geolocation (latitude and longitude).
/// </summary>
public record GeolocationModel(
    string Lat,
    string Long
);
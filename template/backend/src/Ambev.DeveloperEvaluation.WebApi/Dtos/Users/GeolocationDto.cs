namespace Ambev.DeveloperEvaluation.WebApi.Dtos.Users;

/// <summary>
/// DTO for representing geolocation (latitude and longitude).
/// </summary>
public record GeolocationDto(
    int Lat,
    int Long
);
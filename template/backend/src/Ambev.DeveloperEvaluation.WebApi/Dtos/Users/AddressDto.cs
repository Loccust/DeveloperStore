namespace Ambev.DeveloperEvaluation.WebApi.Dtos.Users;

/// <summary>
/// DTO for representing an address in the CreateUserCommand.
/// </summary>
public record AddressDto(
    string City,
    string Street,
    int Number,
    string Zipcode,
    GeolocationDto Geolocation
);
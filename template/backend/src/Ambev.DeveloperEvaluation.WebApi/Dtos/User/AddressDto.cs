using Ambev.DeveloperEvaluation.Application.Users.CreateUser;

namespace Ambev.DeveloperEvaluation.Application.Dtos.Users;

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
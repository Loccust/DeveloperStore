namespace Ambev.DeveloperEvaluation.Application.Models.User;

/// <summary>
/// Model for representing an address in the CreateUserCommand.
/// </summary>
public record AddressModel(
    string City,
    string Street,
    int Number,
    string Zipcode,
    GeolocationModel Geolocation
);
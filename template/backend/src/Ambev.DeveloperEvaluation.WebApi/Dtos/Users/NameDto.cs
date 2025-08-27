namespace Ambev.DeveloperEvaluation.WebApi.Dtos.Users;

/// <summary>
/// DTO for representing a full name in the CreateUserCommand.
/// </summary>
public record NameDto(
    string Firstname,
    string Lastname
);
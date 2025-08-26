namespace Ambev.DeveloperEvaluation.Application.Dtos.Users;

/// <summary>
/// DTO for representing a full name in the CreateUserCommand.
/// </summary>
public record NameDto(
    string Firstname,
    string Lastname
);
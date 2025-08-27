namespace Ambev.DeveloperEvaluation.Application.Models.Users;

/// <summary>
/// Model for representing a full name in the CreateUserCommand.
/// </summary>
public record NameModel(
    string Firstname,
    string Lastname
);
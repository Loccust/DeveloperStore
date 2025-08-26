using Ambev.DeveloperEvaluation.Application.Models.User;

namespace Ambev.DeveloperEvaluation.Application.UseCases.Users.CreateUser;

/// <summary>
/// Result returned after creating a user.
/// Inherits all user properties from <see cref="UserModel"/>.
/// </summary>
public class CreateUserResult : UserModel
{
    /// <summary>
    /// Gets or sets the generated identifier for the created user.
    /// </summary>
    public Guid Id { get; set; }
}
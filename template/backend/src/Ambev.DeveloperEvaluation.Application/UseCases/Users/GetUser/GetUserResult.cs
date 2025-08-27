using Ambev.DeveloperEvaluation.Application.Models.Users;

namespace Ambev.DeveloperEvaluation.Application.UseCases.Users.GetUser;

/// <summary>
/// Response model for GetUser operation
/// </summary>
public class GetUserResult : UserModel
{
    /// <summary>
    /// Gets or sets the generated identifier for the created user.
    /// </summary>
    public Guid Id { get; set; }
}

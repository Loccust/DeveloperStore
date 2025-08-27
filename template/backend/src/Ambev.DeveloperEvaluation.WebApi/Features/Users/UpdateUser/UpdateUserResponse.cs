using Ambev.DeveloperEvaluation.WebApi.Dtos.Users;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.UpdateUser;

public class UpdateUserResponse : UserDto
{
    /// <summary>
    /// The unique identifier of the updated user
    /// </summary>
    public Guid Id { get; set; }
}
using Ambev.DeveloperEvaluation.Application.Dtos.Users;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Users.CreateUser;
/// <summary>
/// Base user data transfer object (DTO).
/// Shared across commands and results to ensure consistency.
/// </summary>
public class UserDto
{
    /// <summary>
    /// Gets or sets the username of the user.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the password of the user.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the phone number of the user.
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the status of the user.
    /// </summary>
    public UserStatus Status { get; set; }

    /// <summary>
    /// Gets or sets the role of the user.
    /// </summary>
    public UserRole Role { get; set; }

    /// <summary>
    /// Gets or sets the full name of the user.
    /// </summary>
    public required NameDto Name { get; set; }

    /// <summary>
    /// Gets or sets the address of the user, including geolocation.
    /// </summary>
    public required AddressDto Address { get; set; }
}
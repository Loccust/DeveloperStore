using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Domain.ValueObjects.User;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a user in the system with authentication, profile, and address information.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class User : BaseEntity, IUser
{
    /// <summary>
    /// Gets or sets the user's email address.
    /// Must be unique and in a valid email format.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the user's username.
    /// Used for login and identification in the system.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the hashed password for authentication.
    /// Password must meet security requirements.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the full name of the user.
    /// Stored as a value object containing firstname and lastname.
    /// </summary>
    public Name Name { get; set; } = new();

    /// <summary>
    /// Gets or sets the address of the user.
    /// Stored as a value object containing city, street, number, zipcode and geolocation.
    /// </summary>
    public Address Address { get; set; } = new();

    /// <summary>
    /// Gets or sets the user's phone number.
    /// Must follow a valid phone number format.
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the user's current status.
    /// Indicates whether the user is active, inactive, or suspended.
    /// </summary>
    public UserStatus Status { get; set; }

    /// <summary>
    /// Gets or sets the user's role in the system.
    /// Determines permissions and access levels (Customer, Manager, Admin).
    /// </summary>
    public UserRole Role { get; set; }

    /// <summary>
    /// Gets the date and time when the user was created.
    /// Stored in UTC format.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time of the last update to the user's information.
    /// Stored in UTC format.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <inheritdoc />
    string IUser.Id => Id.ToString();

    /// <inheritdoc />
    string IUser.Username => Username;

    /// <inheritdoc />
    string IUser.Role => Role.ToString();

    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class.
    /// Sets the CreatedAt timestamp automatically.
    /// </summary>
    public User()
    {
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Performs validation of the user entity using the <see cref="UserValidator"/> rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    public ValidationResultDetail Validate()
    {
        var validator = new UserValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    /// <summary>
    /// Activates the user account.
    /// Changes the user's status to Active.
    /// </summary>
    public void Activate()
    {
        Status = UserStatus.Active;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Deactivates the user account.
    /// Changes the user's status to Inactive.
    /// </summary>
    public void Deactivate()
    {
        Status = UserStatus.Inactive;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Suspends the user account.
    /// Changes the user's status to Suspended.
    /// </summary>
    public void Suspend()
    {
        Status = UserStatus.Suspended;
        UpdatedAt = DateTime.UtcNow;
    }
}
namespace Ambev.DeveloperEvaluation.Domain.ValueObjects.User;

/// <summary>
/// Value Object for representing a full name.
/// Includes first name and last name.
/// </summary>
public class Name
{
    /// <summary>
    /// Gets or sets the user's first name.
    /// </summary>
    public string Firstname { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the user's last name.
    /// </summary>
    public string Lastname { get; set; } = string.Empty;
}
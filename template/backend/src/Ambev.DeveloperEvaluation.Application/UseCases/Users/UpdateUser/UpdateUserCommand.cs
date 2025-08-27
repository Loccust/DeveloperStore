using Ambev.DeveloperEvaluation.Application.Models.Users;
using FluentValidation.Results;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.UseCases.Users.UpdateUser;
/// <summary>
/// Command for creating a new user.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a user,
/// including username, password, phone number, email, status, role,
/// full name, and address with geolocation.
public class UpdateUserCommand : UserModel, IRequest<UpdateUserResult>
{
    /// <summary>
    /// Performs validation of the command using <see cref="UpdateUserValidator"/>.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResult"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    public async Task<ValidationResult> ValidateAsync() =>
        await new UpdateUserValidator().ValidateAsync(this);

    /// <summary>
    /// The unique identifier of the user
    /// </summary>
    public Guid Id { get; set; }
}
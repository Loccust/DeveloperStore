using Ambev.DeveloperEvaluation.Application.Models.User;
using FluentValidation.Results;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.UseCases.Users.CreateUser;
/// <summary>
/// Command for creating a new user.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a user,
/// including username, password, phone number, email, status, role,
/// full name, and address with geolocation.
public class CreateUserCommand : UserModel, IRequest<CreateUserResult>
{
    /// <summary>
    /// Performs validation of the command using <see cref="CreateUserCommandValidator"/>.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResult"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    public async Task<ValidationResult> ValidateAsync() =>
        await new CreateUserCommandValidator().ValidateAsync(this);
}
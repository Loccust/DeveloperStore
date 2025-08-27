using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.UseCases.Users.CreateUser;

/// <summary>
/// Validator for CreateUserCommand that defines validation rules for user creation command.
/// </summary>
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateUserCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Email: Must be in valid format (using EmailValidator)
    /// - Username: Required, must be between 3 and 50 characters
    /// - Password: Must meet security requirements (using PasswordValidator)
    /// - Phone: Must match international format (+X XXXXXXXXXX)
    /// - Status: Cannot be set to Unknown
    /// - Role: Cannot be set to None
    /// </remarks>
    public CreateUserCommandValidator()
    {
        RuleFor(user => user.Email).SetValidator(new EmailValidator());
        RuleFor(user => user.Username).NotEmpty().Length(3, 50);
        RuleFor(user => user.Password).SetValidator(new PasswordValidator());
        RuleFor(user => user.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
        RuleFor(user => user.Status).NotEqual(UserStatus.Unknown);
        RuleFor(user => user.Role).NotEqual(UserRole.None);
        RuleFor(x => x.Name).NotNull().WithMessage("Name cannot be null.");

        RuleFor(x => x.Name.Firstname)
            .MinimumLength(3).WithMessage("Firstname must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Firstname cannot be longer than 50 characters.");

        RuleFor(x => x.Name.Lastname)
            .MinimumLength(3).WithMessage("Lastname must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Lastname cannot be longer than 50 characters.");

        RuleFor(x => x.Address).NotNull().WithMessage("Address cannot be null.");

        RuleFor(x => x.Address.Street)
           .NotEmpty().WithMessage("Street is required")
           .MinimumLength(3).WithMessage("Street must be at least 3 characters long")
           .MaximumLength(100).WithMessage("Street must not exceed 100 characters");

        RuleFor(x => x.Address.City)
            .NotEmpty().WithMessage("City is required")
            .MinimumLength(2).WithMessage("City must be at least 2 characters long")
            .MaximumLength(50).WithMessage("City must not exceed 50 characters");

        RuleFor(x => x.Address.Zipcode)
            .NotEmpty().WithMessage("Zipcode is required")
            .Matches(@"^\d{5}-?\d{3}$").WithMessage("Invalid zipcode format (use 00000-000)");

        RuleFor(x => x.Address.Geolocation.Lat)
            .NotEmpty().WithMessage("Latitude  is required")
            .MinimumLength(3).WithMessage("Latitude  must be at least 3 characters long")
            .MaximumLength(3).WithMessage("Latitude  must not exceed 3 characters");

        RuleFor(x => x.Address.Geolocation.Long)
            .NotEmpty().WithMessage("Longitude is required")
            .MinimumLength(3).WithMessage("Longitude must be at least 3 characters long")
            .MaximumLength(3).WithMessage("Longitude must not exceed 3 characters");
    }
}
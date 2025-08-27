using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Email).SetValidator(new EmailValidator());

        RuleFor(user => user.Username)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Username must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Username cannot be longer than 50 characters.");

        RuleFor(user => user.Password).SetValidator(new PasswordValidator());

        RuleFor(user => user.Phone)
            .Matches(@"^\+[1-9]\d{10,14}$")
            .WithMessage("Phone number must start with '+' followed by 11-15 digits.");

        RuleFor(user => user.Status)
            .NotEqual(UserStatus.Unknown)
            .WithMessage("User status cannot be Unknown.");

        RuleFor(user => user.Role)
            .NotEqual(UserRole.None)
            .WithMessage("User role cannot be None.");

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
            .InclusiveBetween(-90, 90).WithMessage("Latitude must be between -90 and 90.");

        RuleFor(x => x.Address.Geolocation.Long)
            .InclusiveBetween(-180, 180).WithMessage("Longitude must be between -180 and 180.");
    }
}

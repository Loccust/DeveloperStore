using Ambev.DeveloperEvaluation.Domain.ValueObjects.Users;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

public class NameValidator : AbstractValidator<Name>
{
    public NameValidator()
    {
        RuleFor(x => x.Firstname)
            .MinimumLength(3).WithMessage("Firstname must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Firstname cannot be longer than 50 characters.");
        RuleFor(x => x.Lastname).NotEmpty()
            .MinimumLength(3).WithMessage("Lastname must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Lastname cannot be longer than 50 characters.");
    }
}
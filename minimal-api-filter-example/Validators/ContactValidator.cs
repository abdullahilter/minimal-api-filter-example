using FluentValidation;
using MinimalApiFilterExample.Models;

namespace MinimalApiFilterExample.Validators;

public class ContactValidator : AbstractValidator<Contact>
{
    public ContactValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(2, 250);

        RuleFor(x => x.Surname)
            .NotEmpty()
            .Length(2, 250);

        RuleFor(x => x.UserName)
            .NotEmpty()
            .Matches("^[a-z ,.'-]+$");

        RuleFor(x => x.EmailAddress)
            .NotEmpty()
            .Matches("^[\\w!#$%&’*+/=?`{|}~^-]+(?:\\.[\\w!#$%&’*+/=?`{|}~^-]+)*@(?:[a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$");

        RuleFor(x => x.DateOfBirth)
            .LessThan(DateTime.Now.AddDays(1))
            .WithMessage("Doğum tarihiniz günümüzden ileri olamaz");
    }
}
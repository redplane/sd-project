using FluentValidation;
using SdProject.Apis.Constants;
using SdProject.Businesses.Cqrs.Commands.Users;

namespace SdProject.Apis.Cqrs.CommandValidators.Users
{
    public class AddUserValidation : AbstractValidator<AddUserCommand>
    {
        public AddUserValidation()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().MaximumLength(100)
                .WithMessage(ValidationMessages.UserFirstnameRequired);
            RuleFor(x => x.LastName).NotNull().NotEmpty().MaximumLength(100)
                .WithMessage(ValidationMessages.UserLastnameRequired);
            RuleFor(x => x.Birthdate).NotNull().WithMessage(ValidationMessages.UserBirthdateRequired);
        }
    }
}
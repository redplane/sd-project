using FluentValidation;
using SdProject.Apis.Constants;
using SdProject.Businesses.Cqrs.Commands.Users;

namespace SdProject.Apis.Cqrs.CommandValidators.Users
{
    public class UpdateUserValidation : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidation()
        {
            RuleFor(x => x.Id).NotNull().WithMessage(ValidationMessages.UserIdRequired);
            RuleFor(x => x.FirstName).NotNull().NotEmpty().MaximumLength(100)
                .WithMessage(ValidationMessages.UserFirstnameRequired);
            RuleFor(x => x.LastName).NotNull().NotEmpty().MaximumLength(100)
                .WithMessage(ValidationMessages.UserLastnameRequired);
            RuleFor(x => x.Birthdate).NotNull().WithMessage(ValidationMessages.UserBirthdateRequired);
        }
    }
}
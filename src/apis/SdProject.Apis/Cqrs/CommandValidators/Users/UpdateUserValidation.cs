
using FluentValidation;
using SdProject.Apis.Constants;
using SdProject.Businesses.Models.Users;

namespace SdProject.Apis.Cqrs.CommandValidators
{
    public class UpdateUserValidation : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidation()
        {
            RuleFor(x => x.Id).NotNull().WithMessage(MessageConstants.USER_ID_REQUIRED);
            RuleFor(x => x.FirstName).NotNull().NotEmpty().MaximumLength(100).WithMessage(MessageConstants.USER_FIRSTNAME_REQUIRED);
            RuleFor(x => x.LastName).NotNull().NotEmpty().MaximumLength(100).WithMessage(MessageConstants.USER_LASTNAME_REQUIRED);
            RuleFor(x => x.Birthdate).NotNull().WithMessage(MessageConstants.USER_BIRTHDATE_REQUIRED);
        }
    }
}

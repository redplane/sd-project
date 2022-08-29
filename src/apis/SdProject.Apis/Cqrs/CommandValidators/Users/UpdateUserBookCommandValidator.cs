using FluentValidation;
using SdProject.Apis.Constants;
using SdProject.Businesses.Cqrs.Commands.Users;

namespace SdProject.Apis.Cqrs.CommandValidators.Users
{
    public class UpdateUserBookValidation : AbstractValidator<UpdateUserBookCommand>
    {
        public UpdateUserBookValidation()
        {
            RuleFor(x => x.Id).NotNull().WithMessage(ValidationMessages.UserIdRequired);
            RuleFor(x => x.UserId).NotNull().WithMessage(ValidationMessages.UserIdRequired);
            RuleFor(x => x.BookId).NotNull().WithMessage(ValidationMessages.BookIdRequired);
        }
    }
}
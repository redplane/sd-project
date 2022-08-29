using FluentValidation;
using SdProject.Apis.Constants;
using SdProject.Businesses.Cqrs.Commands.Users;

namespace SdProject.Apis.Cqrs.CommandValidators.Users
{
    public class AddUserBookValidation : AbstractValidator<AddUserBookCommand>
    {
        public AddUserBookValidation()
        {
            RuleFor(x => x.UserId).NotNull().WithMessage(ValidationMessages.UserIdRequired);
            RuleFor(x => x.BookId).NotNull().WithMessage(ValidationMessages.BookIdRequired);
        }
    }
}
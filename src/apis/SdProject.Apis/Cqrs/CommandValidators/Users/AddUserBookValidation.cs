
using FluentValidation;
using SdProject.Apis.Constants;
using SdProject.Businesses.Models.Users;

namespace SdProject.Apis.Cqrs.CommandValidators
{
    public class AddUserBookValidation : AbstractValidator<AddUserBookCommand>
    {
        public AddUserBookValidation()
        {
            RuleFor(x => x.UserId).NotNull().WithMessage(MessageConstants.USER_ID_REQUIRED);
            RuleFor(x => x.BookId).NotNull().WithMessage(MessageConstants.BOOK_ID_REQUIRED);
        }
    }
}

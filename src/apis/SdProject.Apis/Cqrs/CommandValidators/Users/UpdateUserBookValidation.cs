
using FluentValidation;
using SdProject.Apis.Constants;
using SdProject.Businesses.Models.Users;

namespace SdProject.Apis.Cqrs.CommandValidators.Users
{
    public class UpdateUserBookValidation : AbstractValidator<UpdateUserBookCommand>
    {
        public UpdateUserBookValidation()
        {
            RuleFor(x => x.Id).NotNull().WithMessage(MessageConstants.USER_ID_REQUIRED);
            RuleFor(x => x.UserId).NotNull().WithMessage(MessageConstants.USER_ID_REQUIRED);
            RuleFor(x => x.BookId).NotNull().WithMessage(MessageConstants.BOOK_ID_REQUIRED);
        }
    }
}

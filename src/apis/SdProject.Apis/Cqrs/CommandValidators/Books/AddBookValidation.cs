
using FluentValidation;
using SdProject.Apis.Constants;
using SdProject.Businesses.Models.Users;

namespace SdProject.Apis.Cqrs.CommandValidators.Books
{
    public class AddBookValidation : AbstractValidator<AddBookCommand>
    {
        public AddBookValidation()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().MaximumLength(250).WithMessage(MessageConstants.BOOK_TITLE_REQUIRED);
            RuleFor(x => x.Category).NotNull().NotEmpty().MaximumLength(250).WithMessage(MessageConstants.BOOK_CATEGORY_REQUIRED);
            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage(MessageConstants.BOOK_DESCRIPTION_REQUIRED);
            RuleFor(x => x.Price).NotNull().WithMessage(MessageConstants.BOOK_PRICE_REQUIRED);
        }
    }
}

using FluentValidation;
using SdProject.Apis.Constants;
using SdProject.Businesses.Cqrs.Commands.Books;

namespace SdProject.Apis.Cqrs.CommandValidators.Books
{
    public class AddBookValidation : AbstractValidator<AddBookCommand>
    {
        public AddBookValidation()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().MaximumLength(250)
                .WithMessage(ValidationMessages.BookTitleRequired);
            RuleFor(x => x.Category).NotNull().NotEmpty().MaximumLength(250)
                .WithMessage(ValidationMessages.BookCategoryRequired);
            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage(ValidationMessages.BookDescriptionRequired);
            RuleFor(x => x.Price).NotNull().WithMessage(ValidationMessages.BookPriceRequired);
        }
    }
}
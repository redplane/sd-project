using MediatR;
using SdProject.Core.Entities;

namespace SdProject.Businesses.Cqrs.Commands.Books
{
    public class AddBookCommand : IRequest<Book>
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
using MediatR;
using SdProject.Core.Entities;

namespace SdProject.Businesses.Cqrs.Commands.Books
{
    public class UpdateBookCommand : IRequest<Book>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
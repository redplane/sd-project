using System.Collections.Generic;
using MediatR;
using SdProject.Core.Entities;

namespace SdProject.Businesses.Cqrs.Queries.Books
{
    public class SearchBookQuery : IRequest<IEnumerable<Book>>
    {
        public string Title { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }
    }
}
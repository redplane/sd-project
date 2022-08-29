using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SdProject.Businesses.Cqrs.Queries.Books;
using SdProject.Businesses.Services.Abstractions;
using SdProject.Core.Entities;

namespace SdProject.Apis.Cqrs.QueryHandlers.Books
{
    public class SearchBookRequestHandler : IRequestHandler<SearchBookQuery, IEnumerable<Book>>
    {
        private readonly IBookService _bookService;

        public SearchBookRequestHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public Task<IEnumerable<Book>> Handle(SearchBookQuery request, CancellationToken cancellation)
        {
            return _bookService.SearchAsync(request, cancellation);
        }
    }
}
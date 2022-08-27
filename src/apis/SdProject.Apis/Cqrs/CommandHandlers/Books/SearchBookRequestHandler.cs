using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SdProject.Businesses.Models.Users;
using SdProject.Businesses.Services.Abstractions;
using Core.Entities;

namespace SdProject.Apis.Cqrs.CommandHandlers.User.Commands.Handlers
{
    public class SearchBookRequestHandler : IRequestHandler<SearchBookQuery, IEnumerable<BookEntity>>
    {
        private readonly IBookService _bookService;
        public SearchBookRequestHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public Task<IEnumerable<BookEntity>> Handle(SearchBookQuery request, CancellationToken cancellation)
        {
            return _bookService.SearchBookAsync(request, cancellation);
        }
    }
}

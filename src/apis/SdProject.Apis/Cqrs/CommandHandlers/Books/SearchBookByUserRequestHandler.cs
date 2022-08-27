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
    public class SearchBookByUserRequestHandler : IRequestHandler<SearchBookByUserQuery, IEnumerable<BookEntity>>
    {
        private readonly IBookService _bookService;
        public SearchBookByUserRequestHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public Task<IEnumerable<BookEntity>> Handle(SearchBookByUserQuery request, CancellationToken cancellation)
        {
            return _bookService.FindBookByUserAsync(request, cancellation);
        }
    }
}

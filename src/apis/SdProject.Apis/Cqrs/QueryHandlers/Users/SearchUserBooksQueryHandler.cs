using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SdProject.Businesses.Cqrs.Queries.Users;
using SdProject.Businesses.Services.Abstractions;
using SdProject.Core.Entities;

namespace SdProject.Apis.Cqrs.QueryHandlers.Users
{
    public class SearchUserByBookRequestHandler : IRequestHandler<SearchUserBooksQuery, IEnumerable<Book>>
    {
        private readonly IUserService _userService;

        public SearchUserByBookRequestHandler(IUserService userService)
        {
            _userService = userService;
        }

        public Task<IEnumerable<Book>> Handle(SearchUserBooksQuery request, CancellationToken cancellation)
        {
            return _userService.SearchUserBooksAsync(request, cancellation);
        }
    }
}
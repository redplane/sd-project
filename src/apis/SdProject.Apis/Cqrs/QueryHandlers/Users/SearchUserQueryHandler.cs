using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SdProject.Businesses.Cqrs.Queries.Users;
using SdProject.Businesses.Services.Abstractions;
using SdProject.Core.Entities;

namespace SdProject.Apis.Cqrs.QueryHandlers.Users
{
    public class SearchUserRequestHandler : IRequestHandler<SearchUserQuery, IEnumerable<User>>
    {
        private readonly IUserService _usersService;

        public SearchUserRequestHandler(IUserService usersService)
        {
            _usersService = usersService;
        }

        public Task<IEnumerable<User>> Handle(SearchUserQuery request, CancellationToken cancellation)
        {
            return _usersService.SearchAsync(request, cancellation);
        }
    }
}
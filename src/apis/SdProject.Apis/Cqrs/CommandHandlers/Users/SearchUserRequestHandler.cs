using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SdProject.Businesses.Models.Users;
using SdProject.Businesses.Services.Abstractions;
using Core.Entities;

namespace SdProject.Apis.Cqrs.CommandHandlers.Users
{
    public class SearchUserRequestHandler : IRequestHandler<SearchUserQuery, IEnumerable<global::Core.Entities.User>>
    {
        private readonly IUserService _usersService;
        public SearchUserRequestHandler(IUserService usersService)
        {
            _usersService = usersService;
        }

        public Task<IEnumerable<global::Core.Entities.User>> Handle(SearchUserQuery request, CancellationToken cancellation)
        {
            return _usersService.SearchUserAsync(request, cancellation);
        }
    }
}

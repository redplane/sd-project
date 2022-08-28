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
    public class SearchUserByBookRequestHandler : IRequestHandler<SearchUserByBookQuery, IEnumerable<global::Core.Entities.User>>
    {
        private readonly IUserService _userService;
        public SearchUserByBookRequestHandler(IUserService userService)
        {
            _userService = userService;
        }

        public Task<IEnumerable<global::Core.Entities.User>> Handle(SearchUserByBookQuery request, CancellationToken cancellation)
        {
            return _userService.FindUserByBookAsync(request, cancellation);
        }
    }
}

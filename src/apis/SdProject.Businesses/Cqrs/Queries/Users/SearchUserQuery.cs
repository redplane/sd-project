using System.Collections.Generic;
using MediatR;
using SdProject.Core.Entities;

namespace SdProject.Businesses.Cqrs.Queries.Users
{
    public class SearchUserQuery : IRequest<IEnumerable<User>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
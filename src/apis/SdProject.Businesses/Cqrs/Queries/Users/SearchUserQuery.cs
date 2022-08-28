using System;
using System.Collections.Generic;
using Core.Entities;
using MediatR;

namespace SdProject.Businesses.Models.Users
{
    public class SearchUserQuery : IRequest<IEnumerable<User>> 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using Core.Entities;
using MediatR;

namespace SdProject.Businesses.Models.Users
{
    public class SearchUserByBookQuery : IRequest<IEnumerable<User>> 
    {
        public int BookId { get; set; }
    }
}

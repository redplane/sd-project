using System;
using System.Collections.Generic;
using Core.Entities;
using MediatR;

namespace SdProject.Businesses.Models.Users
{
    public class SearchBookByUserQuery : IRequest<IEnumerable<BookEntity>> 
    {
        public int UserId { get; set; }
    }
}

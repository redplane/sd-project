using System;
using System.Collections.Generic;
using Core.Entities;
using MediatR;

namespace SdProject.Businesses.Models.Users
{
    public class SearchBookByUserQuery : IRequest<IEnumerable<Book>> 
    {
        public int UserId { get; set; }
    }
}

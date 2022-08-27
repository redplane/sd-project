using System;
using System.Collections.Generic;
using Core.Entities;
using MediatR;

namespace SdProject.Businesses.Models.Users
{
    public class SearchBookQuery : IRequest<IEnumerable<BookEntity>> 
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }
}

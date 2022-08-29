using System.Collections.Generic;
using MediatR;
using SdProject.Core.Entities;

namespace SdProject.Businesses.Cqrs.Queries.Users
{
    public class SearchUserBooksQuery : IRequest<IEnumerable<Book>>
    {
        public int UserId { get; set; }
        
        public int? BookId { get; set; }
        
        public bool? HaveRead { get; set; }
    }
}
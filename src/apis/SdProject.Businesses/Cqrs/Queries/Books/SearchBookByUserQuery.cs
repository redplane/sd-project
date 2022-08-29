using System.Collections.Generic;
using MediatR;
using SdProject.Core.Entities;

namespace SdProject.Businesses.Cqrs.Queries.Books
{
    public class SearchBookByUserQuery : IRequest<IEnumerable<Book>>
    {
        #region Properties

        public int UserId { get; set; }

        public bool? HaveRead { get; set; }

        #endregion
    }
}
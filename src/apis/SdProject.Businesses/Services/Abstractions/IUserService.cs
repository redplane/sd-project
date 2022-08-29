using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SdProject.Businesses.Cqrs.Commands.Users;
using SdProject.Businesses.Cqrs.Queries.Users;
using SdProject.Core.Entities;

namespace SdProject.Businesses.Services.Abstractions
{
    public interface IUserService
    {
        Task<IEnumerable<User>> SearchAsync(SearchUserQuery request, CancellationToken cancellationToken = default);
        Task<IEnumerable<Book>> SearchUserBooksAsync(SearchUserBooksQuery request, CancellationToken cancellationToken = default);
        Task<User> AddAsync(AddUserCommand request, CancellationToken cancellationToken = default);
        Task<User> UpdateAsync(UpdateUserCommand request, CancellationToken cancellationToken = default);
        Task<UserBook> AddUserBookAsync(AddUserBookCommand request, CancellationToken cancellationToken = default);
        Task<UserBook> UpdateUserBookAsync(UpdateUserBookCommand request, CancellationToken cancellationToken = default);

        Task<User> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
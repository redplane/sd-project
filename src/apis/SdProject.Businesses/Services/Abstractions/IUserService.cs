using Core.Entities;
using SdProject.Businesses.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SdProject.Businesses.Services.Abstractions
{
    public interface IUserService
    {
        Task<IEnumerable<User>> SearchUserAsync(SearchUserQuery request, CancellationToken cancellation);
        Task<IEnumerable<User>> FindUserByBookAsync(SearchUserByBookQuery request, CancellationToken cancellation);
        Task<User> AddUserAsync(AddUserCommand request, CancellationToken cancellation);
        Task<User> UpdateUserAsync(UpdateUserCommand request, CancellationToken cancellation);
        Task<UserBook> AddUserBookAsync(AddUserBookCommand request, CancellationToken cancellation);
        Task<UserBook> UpdateUserBookAsync(UpdateUserBookCommand request, CancellationToken cancellation);
    }
}

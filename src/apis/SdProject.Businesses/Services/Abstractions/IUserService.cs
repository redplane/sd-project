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
        Task<IEnumerable<UserEntity>> SearchUserAsync(SearchUserQuery request, CancellationToken cancellation);
        Task<IEnumerable<UserEntity>> FindUserByBookAsync(SearchUserByBookQuery request, CancellationToken cancellation);
        Task<UserEntity> AddUserAsync(AddUserCommand request, CancellationToken cancellation);
        Task<UserEntity> UpdateUserAsync(UpdateUserCommand request, CancellationToken cancellation);
    }
}

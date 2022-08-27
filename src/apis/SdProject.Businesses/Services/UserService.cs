using SdProject.Businesses.Services.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;
using SdProject.Businesses.Models.Users;
using SdProject.Core.DbContexts;
using Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SdProject.Businesses.Services
{
    public class UserService : IUserService
    {
        SdPDbContext _context;
        public UserService(SdPDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserEntity>> SearchUserAsync(SearchUserQuery request, CancellationToken cancellation)
        {
            var users = _context.User.AsQueryable();
            if (request != null && !string.IsNullOrWhiteSpace(request.FirstName))
            {
                users = users.Where(x => x.FirstName.Contains(request.FirstName));
            }

            if (request != null && !string.IsNullOrWhiteSpace(request.LastName))
            {
                users = users.Where(x => x.FirstName.Contains(request.LastName));
            }
            return users.ToList();
        }

        public async Task<IEnumerable<UserEntity>> FindUserByBookAsync(SearchUserByBookQuery request, CancellationToken cancellation)
        {
            return (from ub in _context.UserBookEntities
                    join u in _context.User on ub.BookId equals u.Id
                    where ub.BookId == request.BookId
                    select new UserEntity
                    {
                        Id = u.Id,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Birthdate = u.Birthdate
                    }).ToList();
        }
        public async Task<UserEntity> AddUserAsync(AddUserCommand request, CancellationToken cancellation)
        {
            UserEntity entity = new UserEntity { FirstName = request.FirstName, LastName = request.LastName, Birthdate = request.Birthdate };
            var user = _context.User.Add(entity);
            await _context.SaveChangesAsync();
            return user.Entity;
        }

        public async Task<UserEntity> UpdateUserAsync(UpdateUserCommand request, CancellationToken cancellation)
        {
            UserEntity entity = new UserEntity { Id = request.Id, FirstName = request.FirstName, LastName = request.LastName, Birthdate = request.Birthdate };
            var user = _context.User.Update(entity);
            await _context.SaveChangesAsync();
            return user.Entity;
        }
    }
}
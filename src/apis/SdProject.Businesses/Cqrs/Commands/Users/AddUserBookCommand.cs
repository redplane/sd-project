using MediatR;
using SdProject.Core.Entities;

namespace SdProject.Businesses.Cqrs.Commands.Users
{
    public class AddUserBookCommand : IRequest<UserBook>
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}
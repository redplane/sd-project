using System;
using MediatR;
using SdProject.Core.Entities;

namespace SdProject.Businesses.Cqrs.Commands.Users
{
    public class AddUserCommand : IRequest<User>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
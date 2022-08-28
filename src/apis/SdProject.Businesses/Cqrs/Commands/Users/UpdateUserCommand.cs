using System;
using System.Collections.Generic;
using Core.Entities;
using MediatR;

namespace SdProject.Businesses.Models.Users
{
    public class UpdateUserCommand : IRequest<User>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public UpdateUserCommand(){}
    }
}

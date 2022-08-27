using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;
using MediatR;
using Newtonsoft.Json;

namespace SdProject.Businesses.Models.Users
{
    public class AddUserCommand : IRequest<UserEntity>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public AddUserCommand()
        {
        }
    }
}

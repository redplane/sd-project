using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;
using MediatR;
using Newtonsoft.Json;

namespace SdProject.Businesses.Models.Users
{
    public class AddUserBookCommand : IRequest<UserBookEntity>
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public AddUserBookCommand()
        {
        }
    }
}

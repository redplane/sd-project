using System;
using System.Collections.Generic;
using Core.Entities;
using MediatR;

namespace SdProject.Businesses.Models.Users
{
    public class UpdateUserBookCommand : IRequest<UserBookEntity>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public UpdateUserBookCommand(){}
    }
}

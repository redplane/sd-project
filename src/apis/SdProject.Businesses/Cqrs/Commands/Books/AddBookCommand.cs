using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;
using MediatR;
using Newtonsoft.Json;

namespace SdProject.Businesses.Models.Users
{
    public class AddBookCommand : IRequest<BookEntity>
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public AddBookCommand()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using Core.Entities;
using MediatR;

namespace SdProject.Businesses.Models.Users
{
    public class UpdateBookCommand : IRequest<Book>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public UpdateBookCommand(){}
    }
}

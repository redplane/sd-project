using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class BookEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public ICollection<UserBookEntity> UserBooks { get; set; }
        public BookEntity()
        {
        }
    }
}

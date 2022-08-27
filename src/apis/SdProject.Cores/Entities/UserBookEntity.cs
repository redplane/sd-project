using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class UserBookEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public UserEntity User { get; set; }
        public BookEntity  Book { get; set; }
        public UserBookEntity()
        {
        }
    }
}

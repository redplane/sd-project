using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class UserBook
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public bool HaveRead { get; set; }
        public User User { get; set; }
        public Book  Book { get; set; }
        public UserBook()
        {
        }
    }
}

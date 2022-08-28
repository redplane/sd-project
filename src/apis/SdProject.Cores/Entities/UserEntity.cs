using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class UserEntity
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public ICollection<UserBookEntity> UserBooks { get; set; }
        public UserEntity()
        {
        }
    }
}

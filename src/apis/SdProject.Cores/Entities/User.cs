using System;
using System.Collections.Generic;

namespace SdProject.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public ICollection<UserBook> UserBooks { get; set; }
    }
}
using System.Collections.Generic;

namespace SdProject.Core.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public ICollection<UserBook> UserBooks { get; set; }
    }
}
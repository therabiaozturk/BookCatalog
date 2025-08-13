

namespace BookCatalog.Model.Entities
{
    public class Author
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set;}
        public string Biography { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
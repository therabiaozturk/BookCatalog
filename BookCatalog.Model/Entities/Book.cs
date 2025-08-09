using BookCatalog.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Model.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }
        public string? Publisher { get; set; }
        public string Isbn { get; set; } = "";

        // public enum Status { get, set, }

        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

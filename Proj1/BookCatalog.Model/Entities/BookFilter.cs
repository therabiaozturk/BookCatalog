using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Model.Entities
{
    public class BookFilter
    {
        public string? TitleContains { get; set; }
        public Guid? AuthorId { get; set; }
        public Guid? CategoryId { get; set; }
        public string? Isbn { get; set; }

        public int Page { get; set; } = 1;       
        public int PageSize { get; set; } = 20;  
    }
}

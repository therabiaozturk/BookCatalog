using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BookCatalog.Model.Entities
{
    public class AuthorFilter
    {
        public string? NameContains { get; set; }     
        public DateTime? CreatedFrom { get; set; }    
        public DateTime? CreatedTo { get; set; }

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL.AspNet.Attributes;

namespace Data.Models
{
    [GraphType("Books")]
    public class BooksModel : BaseModel
    {
        [GraphField("Title")]
        public string? Title { get; set; }
        [GraphField("Price")]
        public decimal? Price { get; set; }
        [GraphField("Id_Author")]
        public Guid Id_Author { get; set; }
    }
}

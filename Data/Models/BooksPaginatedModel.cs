using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL.AspNet.Attributes;

namespace Data.Models
{
    [GraphType("booksPaginated")]
    public class BooksPaginatedModel
    {
        public Guid Bk_Id_Book { get; set; }
        public string? Bk_Title { get; set; }
        public decimal? Bk_Price { get; set; }
        public Guid Bk_Id_Author { get; set; }
        public string? Bk_Author { get; set; }
        public bool? Bk_Is_Active { get; set; }
        public int Total_Count { get; set; }
    }
}

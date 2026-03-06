using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class BooksModel : BaseModel
    {
        public string? Title { get; set; }
        public decimal? Price { get; set; }
        public Guid Id_Author { get; set; }
    }
}

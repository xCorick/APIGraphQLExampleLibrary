using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class AuthorsBooksModel
    {
        public Guid Id_Author { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Country { get; set; }
        public IEnumerable<BooksListModel>? Books { get; set; }
    }
}

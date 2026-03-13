using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL.AspNet.Attributes;

namespace Data.Models
{
    [GraphType("authors")]
    public class AuthorsModel : BaseModel
    {
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Country { get; set; }
    }
}

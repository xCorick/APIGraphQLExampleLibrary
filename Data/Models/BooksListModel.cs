using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using GraphQL.AspNet.Attributes;

namespace Data.Models
{
    [GraphType("bookList")]
    public class BooksListModel : BaseModel
    {
        [JsonPropertyName("id_author")]
        public override Guid Id { get; set; }
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
}

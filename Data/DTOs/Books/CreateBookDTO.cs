using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL.AspNet.Attributes;

namespace Data.DTOs.Books
{
    [GraphType("createBook")]
    public class CreateBookDTO
    {
        [GraphField("Title")]
        [Required(ErrorMessage = "The title of the book is required")]
        public string? Title { get; set; }
        [GraphField("Price")]
        [Required(ErrorMessage = "The price is required")]
        [Range(0, int.MaxValue, ErrorMessage = "The price make no sense, too lower or too expensive")]
        public decimal Price { get; set; }
        [GraphField("Id_Author")]
        [Required(ErrorMessage = "The id of the author is required")]
        public Guid? Id_Author { get; set; }
    }
}

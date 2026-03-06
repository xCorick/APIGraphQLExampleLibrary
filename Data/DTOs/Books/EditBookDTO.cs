using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs.Books
{
    public class EditBookDTO
    {
        [Required(ErrorMessage = "The id is rquired")]
        public Guid Id_Book { get; set; }
        [Required(ErrorMessage = "The title of the book is required")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "The price is required")]
        [Range(0, int.MaxValue, ErrorMessage = "The price make no sense, too lower or too expensive")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "The id of the author is required")]
        public Guid? Id_Author { get; set; }
    }
}

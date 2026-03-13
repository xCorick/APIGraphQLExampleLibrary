using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL.AspNet.Attributes;

namespace Data.DTOs.Authors
{
    [GraphType("createAuthor")]
    public class CreateAuthorDTO
    {
        [Required(ErrorMessage = "First name is Required")]
        public string? First_Name { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string? Last_Name { get; set; }
        [Required(ErrorMessage = "Country is required")]
        [MaxLength(100, ErrorMessage = "The name of this country is to large")]
        public string? Country { get; set; }
    }
}

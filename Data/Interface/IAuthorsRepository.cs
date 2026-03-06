using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DTOs.Authors;
using Data.Models;

namespace Data.Interface
{
    public interface IAuthorsRepository
    {
        Task<AuthorsModel> CreateAuthor(CreateAuthorDTO createAuthorDTO);
        Task<AuthorsBooksModel> ListAuthorsBooks(Guid id);
        Task<AuthorsModel> UpdateAuthor(EditAuthorDTO editAuthorDTO);
        Task<AuthorsModel> ToggleIsActiveAuthor(Guid id);
    }
}

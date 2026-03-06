using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DTOs.Authors;
using Data.Interface;
using Data.Models;

namespace Data.Repository
{
    public class AuthorsRepository : IAuthorsRepository
    {
        public Task<AuthorsModel> CreateAuthor(CreateAuthorDTO createAuthorDTO)
        {
            throw new NotImplementedException();
        }

        public Task<AuthorsBooksModel> ListAuthorsBooks(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AuthorsModel> ToggleIsActiveAuthor(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AuthorsModel> UpdateAuthor(EditAuthorDTO editAuthorDTO)
        {
            throw new NotImplementedException();
        }
    }
}

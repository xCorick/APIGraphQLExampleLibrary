using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DTOs.Books;
using Data.DTOs.Pagination;
using Data.Models;

namespace Data.Interface
{
    public interface IBooksRepository
    {
        Task<BooksModel> CreateBook(CreateBookDTO createBookDTO);
        Task<BooksModel> UpdateBook(EditBookDTO editBookDTO);
        Task<BooksPaginatedModel> GetBooksPaged(BasePaginationDTO paginationDTO);
        Task<BooksModel> ToggleIsActiveBook(Guid Id);
    }
}

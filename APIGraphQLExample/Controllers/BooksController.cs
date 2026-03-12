using Data.DTOs.Books;
using Data.DTOs.Pagination;
using Data.Interface;
using Data.Models;
using GraphQL.AspNet.Attributes;
using GraphQL.AspNet.Controllers;
using GraphQL.AspNet.Interfaces.Controllers;

namespace APIGraphQLExample.Controllers
{
    [GraphRoute("books")]
    public class BooksController : GraphController
    {
        private readonly IBooksRepository _booksRepository;

        public BooksController(IBooksRepository booksRepository) => _booksRepository = booksRepository;

        [Query("getBooksPaged", typeof(IEnumerable<BooksPaginatedModel>))]
        public async Task<IGraphActionResult> GetBooksPaged([FromGraphQL("basePagination")] BasePaginationDTO basePaginationDTO)
        {
            var result = await _booksRepository.GetBooksPaged(basePaginationDTO);
            return Ok(result);
        }

        [Mutation("createBook", typeof(BooksModel))]
        public async Task<IGraphActionResult> CreateBook([FromGraphQL("createBook")] CreateBookDTO createBookDTO)
        {
            var result = await _booksRepository.CreateBook(createBookDTO);
            return Ok(result);
        }

        [Mutation("updateBook", typeof(BooksModel))]
        public async Task<IGraphActionResult> UpdateBook([FromGraphQL("updateBook")] EditBookDTO editBookDTO)
        {
            var result = await _booksRepository.UpdateBook(editBookDTO);
            return Ok(result);
        }

        [Mutation("ToggleBook", typeof(BooksModel))]
        public async Task<IGraphActionResult> ToggleIsActiveBook([FromGraphQL("toggleBook")] Guid id)
        {
            var result = await _booksRepository.ToggleIsActiveBook(id);
            return Ok(result);
        }
    }
}

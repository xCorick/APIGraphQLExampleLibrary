using Data.DTOs.Authors;
using Data.Interface;
using Data.Models;
using GraphQL.AspNet.Attributes;
using GraphQL.AspNet.Controllers;
using GraphQL.AspNet.Interfaces.Controllers;


namespace APIGraphQLExample.Controllers
{
    [GraphRoute("authors")]
    public class AuthorsController : GraphController
    {
        private readonly IAuthorsRepository _authorsRepository;

        public AuthorsController(IAuthorsRepository authorsRepository) => _authorsRepository = authorsRepository;

        [Query("listAuthorsBooks", typeof(AuthorsBooksModel))]
        public async Task<IGraphActionResult> ListAuthorsBooks([FromGraphQL("id")] Guid id)
        {
            var result = await _authorsRepository.ListAuthorsBooks(id);
            return Ok(result);
        }

        [Mutation("createAuthor", typeof(AuthorsModel))]
        public async Task<IGraphActionResult> CreateAuthor([FromGraphQL("createAuthor")] CreateAuthorDTO createAuthorDTO)
        {
            var result = await _authorsRepository.CreateAuthor(createAuthorDTO);
            return Ok(result);
        }

        [Mutation("updateAuthor", typeof(AuthorsModel))]
        public async Task<IGraphActionResult> UpdateAuthor([FromGraphQL("updateAuthot")] EditAuthorDTO updateAuthorDTO)
        {
            var result = await _authorsRepository.UpdateAuthor(updateAuthorDTO);
            return Ok(result);
        }

        [Mutation("toggleAuthor", typeof(AuthorsModel))]
        public async Task<IGraphActionResult> ToggleAuthor([FromGraphQL("id")] Guid Id)
        {
            var result = await _authorsRepository.ToggleIsActiveAuthor(Id);
            return Ok(result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DTOs.Books;
using Data.DTOs.Pagination;
using Data.Interface;
using Data.Models;
using Npgsql;

namespace Data.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly PostgresConnection _postgresConnection;
        public BooksRepository(PostgresConnection postgresConnection) => _postgresConnection = postgresConnection;

        NpgsqlConnection DbConnection() => new NpgsqlConnection(_postgresConnection.ConnectionString);
        public Task<BooksModel> CreateBook(CreateBookDTO createBookDTO)
        {
            throw new NotImplementedException();
        }

        public Task<BooksPaginatedModel> GetBooksPaged(BasePaginationDTO paginationDTO)
        {
            throw new NotImplementedException();
        }

        public Task<BooksModel> ToggleIsActiveBook(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<BooksModel> UpdateBook(EditBookDTO editBookDTO)
        {
            throw new NotImplementedException();
        }
    }
}

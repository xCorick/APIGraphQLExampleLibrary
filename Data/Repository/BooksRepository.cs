using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DTOs.Books;
using Data.DTOs.Pagination;
using Data.Interface;
using Data.Models;
using System.Data;
using Npgsql;

namespace Data.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly PostgresConnection _postgresConnection;
        public BooksRepository(PostgresConnection postgresConnection) => _postgresConnection = postgresConnection;

        NpgsqlConnection DbConnection() => new NpgsqlConnection(_postgresConnection.ConnectionString);
        public async Task<BooksModel> CreateBook(CreateBookDTO createBookDTO)
        {
            string sqlQuery = "SELECT * FROM create_book(" +
                "p_title := @Title," +
                "p_price := @Price," +
                "p_id_author := @Id_Author);";
            try
            {
                using (var conn = DbConnection())
                {
                    conn.Open();
                    using var command = conn.CreateCommand();
                    command.CommandText = sqlQuery;
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@Title", createBookDTO.Title!);
                    command.Parameters.AddWithValue("@Price", createBookDTO.Price);
                    command.Parameters.AddWithValue("@Id_Author", createBookDTO.Id_Author!);

                    using var reader = await command.ExecuteReaderAsync(); 
                    if(await reader.ReadAsync())
                    {
                        return new BooksModel
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("id_book")),
                            Title = reader.GetString(reader.GetOrdinal("title")),
                            Price = reader.GetDecimal(reader.GetOrdinal("price")),
                            Created_At = reader.GetDateTime(reader.GetOrdinal("created_at")),
                            Updated_At = reader.GetDateTime(reader.GetOrdinal("updated_at")),
                            Is_Active = reader.GetBoolean(reader.GetOrdinal("is_active")),
                            Id_Author = reader.GetGuid(reader.GetOrdinal("id_author"))
                        };
                    }
                    conn.Close();
                    return new BooksModel{ };
                }
            }
            catch (NpgsqlException ex)
            {
                throw new NpgsqlException(ex.Message, ex);
            }
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<BooksPaginatedModel>> GetBooksPaged(BasePaginationDTO paginationDTO)
        {
            string sqlQuery = "select * from get_books_paged(" +
                "p_page := @Page," +
                "p_page_size := @Page_Size," +
                "p_is_active := @Is_Active," +
                "p_order_type := @Order_Type," +
                "p_order_key := @Order_Key," +
                "p_search := @Search);";

            var books = new List<BooksPaginatedModel>();

            try
            {
                using (var conn = DbConnection())
                {
                    conn.Open();
                    using var command = conn.CreateCommand();
                    command.CommandText = sqlQuery;
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@Page", paginationDTO.Page);
                    command.Parameters.AddWithValue("@Page_Size", paginationDTO.Page_Size);
                    command.Parameters.AddWithValue("@Is_Active", paginationDTO.Is_Active);
                    command.Parameters.AddWithValue("@Order_Type", paginationDTO.Order_Type!);
                    command.Parameters.AddWithValue("@Order_Key", paginationDTO.Order_Key!);
                    command.Parameters.AddWithValue("@Search", paginationDTO.Search!);

                    using var reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        var book = new BooksPaginatedModel
                        {
                            Bk_Id_Book = reader.GetGuid(reader.GetOrdinal("bk_id_book")),
                            Bk_Title = reader.GetString(reader.GetOrdinal("bk_title")),
                            Bk_Price = reader.GetDecimal(reader.GetOrdinal("bk_price")),
                            Bk_Id_Author = reader.GetGuid(reader.GetOrdinal("bk_id_author")),
                            Bk_Author = reader.GetString(reader.GetOrdinal("bk_author")),
                            Bk_Is_Active = reader.GetBoolean(reader.GetOrdinal("bk_is_active")),
                            Total_Count = reader.GetInt32(reader.GetOrdinal("total_count"))
                        };
                        books.Add(book);
                    }
                    conn.Close();
                    return books;
                }
            } catch (NpgsqlException ex)
            {
                throw new NpgsqlException(ex.Message, ex);
            }
            //throw new NotImplementedException();
        }

        public async Task<BooksModel> ToggleIsActiveBook(Guid Id)
        {
            string sqlQuery = "select * from toggle_is_active_book(" +
                "p_id_book := @Id);";

            try
            {
                using (var conn = DbConnection())
                {
                    conn.Open();
                    using var command = conn.CreateCommand();
                    command.CommandText = sqlQuery;
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@Id", Id);

                    using var reader = await command.ExecuteReaderAsync();

                    if (await reader.ReadAsync())
                    {
                        return new BooksModel
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("id_book")),
                            Title = reader.GetString(reader.GetOrdinal("title")),
                            Price = reader.GetDecimal(reader.GetOrdinal("price")),
                            Id_Author = reader.GetGuid(reader.GetOrdinal("id_author")),
                            Created_At = reader.GetDateTime(reader.GetOrdinal("created_at")),
                            Updated_At = reader.GetDateTime(reader.GetOrdinal("updated_at"))
                        };
                    }
                    conn.Close();
                    return new BooksModel { };
                }
            }
            catch (NpgsqlException ex)
            {
                throw new NpgsqlException(ex.Message, ex);
            }
            //throw new NotImplementedException();
        }

        public async Task<BooksModel> UpdateBook(EditBookDTO editBookDTO)
        {
            string sqlQuery = "select * from edit_book(" +
                "p_id_book := @Id_Book," +
                "p_title := @Title," +
                "p_price := @Price," +
                "p_id_author := @Id_Author);";
            try
            {
                using (var conn = DbConnection())
                {
                    conn.Open();
                    using var command = conn.CreateCommand();
                    command.CommandText = sqlQuery;
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@Id_Book", editBookDTO.Id_Book);
                    command.Parameters.AddWithValue("@Title", editBookDTO.Title!);
                    command.Parameters.AddWithValue("@Price", editBookDTO.Price);
                    command.Parameters.AddWithValue("@Id_Author", editBookDTO.Id_Author!);

                    using var reader = await command.ExecuteReaderAsync();

                    if (await reader.ReadAsync())
                    {
                        return new BooksModel
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("id_book")),
                            Title = reader.GetString(reader.GetOrdinal("title")),
                            Price = reader.GetDecimal(reader.GetOrdinal("price")),
                            Id_Author = reader.GetGuid(reader.GetOrdinal("id_author")),
                            Created_At = reader.GetDateTime(reader.GetOrdinal("created_at")),
                            Updated_At = reader.GetDateTime(reader.GetOrdinal("updated_at"))
                        };
                    }
                    conn.Close();
                    return new BooksModel { };
                }

            } catch (NpgsqlException ex)
            {
                throw new NpgsqlException(ex.Message, ex);
            }
        }
    }
}

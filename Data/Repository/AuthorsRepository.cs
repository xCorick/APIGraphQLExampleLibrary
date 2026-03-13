using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data.DTOs.Authors;
using Data.Interface;
using Data.Models;
using System.Text.Json;
using Npgsql;

namespace Data.Repository
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly PostgresConnection _connection;

        public AuthorsRepository(PostgresConnection connection) => _connection = connection;

        NpgsqlConnection DbConnection() => new NpgsqlConnection(_connection.ConnectionString);
        public async Task<AuthorsModel> CreateAuthor(CreateAuthorDTO createAuthorDTO)
        {
            string sqlQuery = "SELECT * FROM create_author(" +
                "p_first_name := @First_Name," +
                "p_last_name := @Last_Name," +
                "p_country := @Country);";

            try
            {
                using (var conn = DbConnection())
                {
                    conn.Open();
                    using var command = conn.CreateCommand();
                    command.CommandText = sqlQuery;
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@First_Name", createAuthorDTO.First_Name!);
                    command.Parameters.AddWithValue("@Last_Name", createAuthorDTO.Last_Name!);
                    command.Parameters.AddWithValue("@Country", createAuthorDTO.Country!);

                    using var reader = await command.ExecuteReaderAsync();
                    
                    if(await reader.ReadAsync())
                    {
                        return new AuthorsModel
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("id_author")),
                            First_Name = reader.GetString(reader.GetOrdinal("first_name")),
                            Last_Name = reader.GetString(reader.GetOrdinal("last_name")),
                            Country = reader.GetString(reader.GetOrdinal("country")),
                            Is_Active = reader.GetBoolean(reader.GetOrdinal("is_active")),
                            Created_At = reader.GetDateTime(reader.GetOrdinal("created_at")),
                            Updated_At = reader.GetDateTime(reader.GetOrdinal("updated_at"))
                        };
                    }
                    conn.Close();
                    return new AuthorsModel { };
                }
            }catch (NpgsqlException ex)
            {
                throw new NpgsqlException(ex.Message, ex);
            }
            //throw new NotImplementedException();
        }

        public async Task<AuthorsBooksModel> ListAuthorsBooks(Guid Id)
        {
            string sqlQuery = "SElECT * FROM list_authors_books(" +
                "p_id_author := @Id);";

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
                        var booksJson = reader["books"]?.ToString();

                        var booksList = string.IsNullOrEmpty(booksJson) ? new List<BooksListModel>() :
                            JsonSerializer.Deserialize<IEnumerable<BooksListModel>>(booksJson);
                        return new AuthorsBooksModel
                        {
                            Id_Author = reader.GetGuid(reader.GetOrdinal("id_author")),
                            First_Name = reader.GetString(reader.GetOrdinal("first_name")),
                            Last_Name = reader.GetString(reader.GetOrdinal("last_name")),
                            Country = reader.GetString(reader.GetOrdinal("country")),
                            Books = booksList
                        };
                    }
                    conn.Close();
                    return new AuthorsBooksModel { };
                }
            }catch (NpgsqlException ex)
            {
                throw new NpgsqlException(ex.Message,ex);
            }

            //throw new NotImplementedException();
        }

        public async Task<AuthorsModel> ToggleIsActiveAuthor(Guid Id)
        {
            string sqlQuery = "SELECT * FROM toggle_is_active_author(" +
                "p_id_author := @Id);";
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
                        return new AuthorsModel
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("id_author")),
                            First_Name = reader.GetString(reader.GetOrdinal("first_name")),
                            Last_Name = reader.GetString(reader.GetOrdinal("last_name")),
                            Country = reader.GetString(reader.GetOrdinal("country")),
                            Is_Active = reader.GetBoolean(reader.GetOrdinal("is_active")),
                            Created_At = reader.GetDateTime(reader.GetOrdinal("created_at")),
                            Updated_At = reader.GetDateTime(reader.GetOrdinal("updated_at"))
                        };
                    }
                    conn.Close();
                    return new AuthorsModel { };
                }
            } catch (NpgsqlException ex)
            {
                throw new NpgsqlException(ex.Message, ex);
            }
            // new NotImplementedException();
        }

        public async Task<AuthorsModel> UpdateAuthor(EditAuthorDTO editAuthorDTO)
        {
            string sqlQuery = "SELECT * FROM edit_author(" +
                "p_id_author := @Id_Author," +
                "p_first_name := @First_Name," +
                "p_last_name := @Last_Name," +
                "p_country := @Country);";

            try
            {
                using (var conn = DbConnection())
                {
                    conn.Open();
                    var command = conn.CreateCommand();
                    command.CommandText = sqlQuery;
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@Id_Author", editAuthorDTO.Id_Author);
                    command.Parameters.AddWithValue("@First_Name", editAuthorDTO.First_Name!);
                    command.Parameters.AddWithValue("@Last_Name", editAuthorDTO.Last_Name!);
                    command.Parameters.AddWithValue("@Country", editAuthorDTO.Country!);

                    using var reader = await command.ExecuteReaderAsync();
                    
                    if(await reader.ReadAsync())
                    {
                        return new AuthorsModel
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("id_author")),
                            First_Name = reader.GetString(reader.GetOrdinal("first_name")),
                            Last_Name = reader.GetString(reader.GetOrdinal("last_name")),
                            Country = reader.GetString(reader.GetOrdinal("country")),
                            Is_Active = reader.GetBoolean(reader.GetOrdinal("is_active")),
                            Created_At = reader.GetDateTime(reader.GetOrdinal("created_at")),
                            Updated_At = reader.GetDateTime(reader.GetOrdinal("updated_at"))
                        };
                    }
                    conn.Close();
                    return new AuthorsModel { };
                }
            } catch (NpgsqlException ex)
            {
                throw new NpgsqlException(ex.Message, ex);
            }
            //throw new NotImplementedException();
        }
    }
}

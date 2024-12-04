using Azure.Core;
using BookStore.DAL.Entities;
using BookStore.DAL.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;

        public GenericRepository(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        // Lấy tất cả các đối tượng
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var items = new List<T>();

            // get name class, use when name table == name class
            var tableName = typeof(T).Name;

            var query = $"SELECT * FROM {tableName} WHERE isDeleted = 0";

            try
            {
                using (var command = new SqlCommand(query, _connection, _transaction))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var item = MapToEntity(reader);
                            items.Add(item);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Lỗi SQL: {ex.Message}");
                // Xử lý lỗi, bạn có thể thêm logging hoặc ném lại lỗi tùy ý
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }

            return items;
        }

        // Lấy một đối tượng theo Id
        public async Task<T> GetByIdAsync(long id)
        {
            T item = null;
            var tableName = typeof(T).Name;
            var query = $"SELECT * FROM {tableName} WHERE Id = @Id";

            try
            {
                using (var command = new SqlCommand(query, _connection, _transaction))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            item = MapToEntity(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi từ Repository: " + ex.Message, ex);
            }

            return item;
        }

        // Thêm một đối tượng
        public async Task AddAsync(T entity)
        {
            var tableName = typeof(T).Name;

            var properties = typeof(T).GetProperties();

            var columnNames = string.Join(", ", properties.Select(p => p.Name));

            var parameterNames = string.Join(", ", properties.Select(p => "@" + p.Name));

            var query = $"INSERT INTO {tableName} ({columnNames}) VALUES ({parameterNames})";

            try
            {
                using (var command = new SqlCommand(query, _connection, _transaction))
                {
                    foreach (var property in properties)
                    {
                        var value = property.GetValue(entity);
                        command.Parameters.AddWithValue($"@{property.Name}", value ?? DBNull.Value);
                    }

                    var result = await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi từ Repository: " + ex.Message, ex);
            }
        }


        public async Task UpdateAsync(T entity, Dictionary<string, string> FieldsToUpdate, long id)
        {
            var tableName = typeof(T).Name.ToLower(); 
            var nameColumnId = typeof(T).GetProperties()[0].Name; 

            List<string> keys = FieldsToUpdate.Keys.ToList();
            List<string> values = FieldsToUpdate.Values.ToList();

            var setClause = string.Join(", ", keys.Select(p => $"{p} = @{p}"));

            var query = $"UPDATE {tableName} SET {setClause} WHERE {nameColumnId} = @id";

            try
            {
                using (var command = new SqlCommand(query, _connection, _transaction))
                {
                    foreach (var key in keys)
                    {
                        var value = FieldsToUpdate[key];
                        if (value == null)
                        {
                            command.Parameters.AddWithValue($"@{key}", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue($"@{key}", value);
                        }
                    }

                    command.Parameters.AddWithValue("@id", id);

                    var result = await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi từ Repository: " + ex.Message, ex);
            }
        }



        public async Task DeleteAsync(long id)
        {
            var tableName = typeof(T).Name.ToLower();
            var nameColumnId = typeof(T).GetProperties()[0].Name;
            var query = $"UPDATE {tableName} SET isDeleted = 1 WHERE {nameColumnId} = @Id"; 

            try
            {
                using (var command = new SqlCommand(query, _connection, _transaction))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi từ Repository: " + ex.Message, ex);
            }
        }


        private T MapToEntity(SqlDataReader reader)
        {
            var item = Activator.CreateInstance<T>();

            if (item is Book book)
            {
                book.id = reader.GetInt64(reader.GetOrdinal("id"));
                book.title = reader.GetString(reader.GetOrdinal("title"));
            }

            // mapping column for Category
            if(item is Category category)
            {
                category.category_id = reader.GetInt64(reader.GetOrdinal("category_id"));
                category.name = reader.GetString(reader.GetOrdinal("name"));
                if (!reader.IsDBNull(reader.GetOrdinal("parent_id")))
                {
                    category.parent_id = reader.GetInt64(reader.GetOrdinal("parent_id"));
                }
                else
                {
                    category.parent_id = null;  
                }
                category.is_active = reader.GetBoolean(reader.GetOrdinal("is_active"));
                category.isDeleted = reader.GetBoolean(reader.GetOrdinal("isDeleted"));
               category.createdAt = reader.GetDateTime(reader.GetOrdinal("createdAt")).AddHours(7);
                category.updatedAt = reader.GetDateTime(reader.GetOrdinal("updatedAt")).AddHours(7);

            }

            // mapping column for Author
            if (item is Author author)
            {
                author.author_id = reader.GetInt64(reader.GetOrdinal("author_id"));
                author.name = reader.GetString(reader.GetOrdinal("name"));

                if (!reader.IsDBNull(reader.GetOrdinal("bio")))
                {
                    author.bio = reader.GetString(reader.GetOrdinal("bio"));
                }
                else
                {
                    author.bio = null;
                }

                author.createdAt = reader.GetDateTime(reader.GetOrdinal("createdAt")).AddHours(7);

                if (!reader.IsDBNull(reader.GetOrdinal("updatedAt")))
                {
                    author.updatedAt = reader.GetDateTime(reader.GetOrdinal("updatedAt")).AddHours(7);
                }
                else
                {
                    author.updatedAt = null;
                }

                author.isDeleted = reader.GetBoolean(reader.GetOrdinal("isDeleted"));
            }

            // mapping for table publisher
            if (item is Publisher publisher)
            {
                publisher.publisher_id = reader.GetInt64(reader.GetOrdinal("publisher_id"));
                publisher.name = reader.GetString(reader.GetOrdinal("name"));

                if (!reader.IsDBNull(reader.GetOrdinal("address")))
                {
                    publisher.address = reader.GetString(reader.GetOrdinal("address"));
                }
                else
                {
                    publisher.address = null;
                }

                if (!reader.IsDBNull(reader.GetOrdinal("contact_number")))
                {
                    publisher.contact_number = reader.GetString(reader.GetOrdinal("contact_number"));
                }
                else
                {
                    publisher.contact_number = null;
                }

                publisher.email = reader.GetString(reader.GetOrdinal("email"));

                if (!reader.IsDBNull(reader.GetOrdinal("website")))
                {
                    publisher.website = reader.GetString(reader.GetOrdinal("website"));
                }
                else
                {
                    publisher.website = null;
                }

                publisher.createdAt = reader.GetDateTime(reader.GetOrdinal("createdAt")).AddHours(7);

                publisher.updatedAt = reader.GetDateTime(reader.GetOrdinal("updatedAt")).AddHours(7);

                publisher.isDeleted = reader.GetBoolean(reader.GetOrdinal("isDeleted"));
            }



            // Các ánh xạ khác nếu cần
            return item;
        }
    }

}

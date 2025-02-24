using BookStore.DAL.Entities;
using BookStore.DAL.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
namespace BookStore.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        private readonly MySqlConnection _connection;
        private readonly MySqlTransaction _transaction;

        public GenericRepository(MySqlConnection connection, MySqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        // Lấy tất cả các đối tượng
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var items = new List<T>();

            // Get name of the class and handle reserved keywords
            var tableName = $"`{typeof(T).Name}`"; // Wrap table name with backticks for MySQL

            var query = $"SELECT * FROM {tableName} WHERE isDeleted = 0";

            try
            {
                using (var command = new MySqlCommand(query, _connection, _transaction))
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
            catch (Exception ex)
            {
                throw new Exception("Lỗi từ Repository: " + ex.Message, ex);
            }

            return items;
        }

        // Lấy một đối tượng theo Id
        public async Task<T> GetByIdAsync(long id)
        {
            T item = null;
            var tableName = $"`{typeof(T).Name}`"; // Wrap table name with backticks for MySQL
            var query = $"SELECT * FROM {tableName} WHERE Id = @Id";

            try
            {
                using (var command = new MySqlCommand(query, _connection, _transaction))
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
            var tableName = $"`{typeof(T).Name}`"; // Wrap table name with backticks for MySQL

            var properties = typeof(T).GetProperties();
            var columnNames = string.Join(", ", properties.Select(p => $"`{p.Name}`")); // Wrap column names with backticks for MySQL

            var parameterNames = string.Join(", ", properties.Select(p => "@" + p.Name));

            var query = $"INSERT INTO {tableName} ({columnNames}) VALUES ({parameterNames})";

            try
            {
                using (var command = new MySqlCommand(query, _connection, _transaction))
                {
                    foreach (var property in properties)
                    {
                        var value = property.GetValue(entity);
                        Console.WriteLine("value: " + property.GetValue(entity));
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

        public async Task UpdateAsync(T entity, Dictionary<string, object> FieldsToUpdate, long id)
{
    var tableName = $"`{typeof(T).Name.ToLower()}`"; // Tên bảng có dấu backtick cho MySQL
    var nameColumnId = typeof(T).GetProperties()[0].Name;

    Console.WriteLine("field: ");
    foreach (var field in FieldsToUpdate)
    {
        Console.WriteLine($"Key: {field.Key}, Value: {field.Value}, Type: {field.Value?.GetType()}");
    }

    // Lấy danh sách khóa
    List<string> keys = FieldsToUpdate.Keys.ToList();

    var setClause = string.Join(", ", keys.Select(p => $"`{p}` = @{p}")); // Wrap column names with backticks for MySQL
    var query = $"UPDATE {tableName} SET {setClause} WHERE `{nameColumnId}` = @id";

    try
    {
        using (var command = new MySqlCommand(query, _connection, _transaction))
        {
            foreach (var key in keys)
            {
                var value = FieldsToUpdate[key];

                // Kiểm tra kiểu dữ liệu thực tế và ép kiểu tương ứng
                if (value == null)
                {
                    Console.WriteLine("check 1: NULL value detected");
                    command.Parameters.AddWithValue($"@{key}", DBNull.Value);
                }
                else if (value is string strValue)
                {
                    Console.WriteLine("check 2: String value detected");
                    command.Parameters.AddWithValue($"@{key}", strValue);
                }
                else if (value is long longValue)
                {
                    Console.WriteLine("check 3: Long value detected");
                    command.Parameters.AddWithValue($"@{key}", longValue);
                }
                else if (value is int intValue)
                {
                    Console.WriteLine("check 4: Int value detected");
                    command.Parameters.AddWithValue($"@{key}", intValue);
                }
                else if (value is decimal decimalValue)
                {
                    Console.WriteLine("check 5: Decimal value detected");
                    command.Parameters.AddWithValue($"@{key}", decimalValue);
                }
                else if (value is double doubleValue)
                {
                    Console.WriteLine("check 6: Double value detected");
                    command.Parameters.AddWithValue($"@{key}", doubleValue);
                }
                else if (value is bool boolValue)
                {
                    Console.WriteLine("check 7: Boolean value detected");
                    command.Parameters.AddWithValue($"@{key}", boolValue);
                }
                else if (value is DateTime dateTimeValue)
                {
                    Console.WriteLine("check 8: DateTime value detected");
                    command.Parameters.AddWithValue($"@{key}", dateTimeValue);
                }
                else if (value is JsonElement jsonElement)
                {
                    Console.WriteLine("check 9: JsonElement detected, attempting to convert...");
                    // Kiểm tra nếu JsonElement là chuỗi
                    if (jsonElement.ValueKind == JsonValueKind.String)
                    {
                        command.Parameters.AddWithValue($"@{key}", jsonElement.GetString());
                    }
                    else if (jsonElement.ValueKind == JsonValueKind.Number)
                    {
                        if (jsonElement.TryGetInt32(out int intVal))
                        {
                            command.Parameters.AddWithValue($"@{key}", intVal);
                        }
                        else if (jsonElement.TryGetInt64(out long longVal))
                        {
                            command.Parameters.AddWithValue($"@{key}", longVal);
                        }
                        else if (jsonElement.TryGetDouble(out double doubleVal))
                        {
                            command.Parameters.AddWithValue($"@{key}", doubleVal);
                        }
                    }
                    else if (jsonElement.ValueKind == JsonValueKind.True || jsonElement.ValueKind == JsonValueKind.False)
                    {
                        command.Parameters.AddWithValue($"@{key}", jsonElement.GetBoolean());
                    }
                    else
                    {
                        command.Parameters.AddWithValue($"@{key}", jsonElement.ToString());
                    }
                }
                else
                {
                    Console.WriteLine($"check 10: Unhandled Type ({value.GetType()}) detected, converting to string.");
                    command.Parameters.AddWithValue($"@{key}", value.ToString());
                }
            }

            command.Parameters.AddWithValue("@id", id);

            var result = await command.ExecuteNonQueryAsync();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        throw new Exception("Lỗi từ Repository: " + ex.Message, ex);
    }
}


        public async Task DeleteAsync(long id)
        {
            var tableName = $"`{typeof(T).Name.ToLower()}`";
            var nameColumnId = typeof(T).GetProperties()[0].Name;
            var query = $"UPDATE {tableName} SET isDeleted = 1 WHERE `{nameColumnId}` = @Id"; // Wrap column name with backticks for MySQL

            try
            {
                using (var command = new MySqlCommand(query, _connection, _transaction))
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

        private T MapToEntity(DbDataReader reader)
        {
            var item = Activator.CreateInstance<T>();

            // mapping column for Book
            if (item is Book book)
            {
                book.book_id = reader.GetInt64("book_id");
                book.ISBN = reader.IsDBNull("ISBN") ? null : reader.GetString("ISBN");
                book.title = reader.GetString("title");
                book.price = reader.GetInt64("price");
                book.author_id = reader.GetInt64("author_id");
                book.publisher_id = reader.GetInt64("publisher_id");
                book.category_id = reader.GetInt64("category_id");
                book.imageUrl = reader.IsDBNull("imageUrl") ? null : reader.GetString("imageUrl");
                book.stock_quantity = reader.GetInt32("stock_quantity");
                book.content_data = reader.IsDBNull("content_data") ? null : reader.GetString("content_data");
                book.status = reader.GetBoolean("status");
                book.ReceiveDate = reader.GetDateTime("ReceiveDate");
                book.updatedAt = reader.IsDBNull("updatedAt") ? (DateTime?)null : reader.GetDateTime("updatedAt");
                book.isDeleted = reader.GetBoolean("isDeleted");
                book.createdBy = reader.GetInt64("createdBy");
                book.updatedBy = reader.IsDBNull("updatedBy") ? (long?)null : reader.GetInt64("updatedBy");
                book.deleteBy = reader.IsDBNull("deleteBy") ? (long?)null : reader.GetInt64("deleteBy");
            }

            // mapping column for Category
            if (item is Category category)
            {
                category.category_id = reader.GetInt64("category_id");
                category.name = reader.GetString("name");
                if (!reader.IsDBNull("parent_id"))
                {
                    category.parent_id = reader.GetInt64("parent_id");
                }
                else
                {
                    category.parent_id = null;
                }
                category.is_active = reader.GetBoolean("is_active");
                category.isDeleted = reader.GetBoolean("isDeleted");
                category.createdAt = reader.GetDateTime("createdAt").AddHours(7);
                category.updatedAt = reader.GetDateTime("updatedAt").AddHours(7);
            }

            // mapping column for Author
            if (item is Author author)
            {
                author.author_id = reader.GetInt64("author_id");
                author.name = reader.GetString("name");

                if (!reader.IsDBNull("bio"))
                {
                    author.bio = reader.GetString("bio");
                }
                else
                {
                    author.bio = null;
                }

                author.createdAt = reader.GetDateTime("createdAt").AddHours(7);

                if (!reader.IsDBNull("updatedAt"))
                {
                    author.updatedAt = reader.GetDateTime("updatedAt").AddHours(7);
                }
                else
                {
                    author.updatedAt = null;
                }

                author.isDeleted = reader.GetBoolean("isDeleted");
            }

            // mapping for table publisher
            if (item is Publisher publisher)
            {
                publisher.publisher_id = reader.GetInt64("publisher_id");
                publisher.name = reader.GetString("name");

                if (!reader.IsDBNull("address"))
                {
                    publisher.address = reader.GetString("address");
                }
                else
                {
                    publisher.address = null;
                }

                if (!reader.IsDBNull("contact_number"))
                {
                    publisher.contact_number = reader.GetString("contact_number");
                }
                else
                {
                    publisher.contact_number = null;
                }

                publisher.email = reader.GetString("email");

                if (!reader.IsDBNull("website"))
                {
                    publisher.website = reader.GetString("website");
                }
                else
                {
                    publisher.website = null;
                }

                publisher.createdAt = reader.GetDateTime("createdAt").AddHours(7);

                publisher.updatedAt = reader.GetDateTime("updatedAt").AddHours(7);

                publisher.isDeleted = reader.GetBoolean("isDeleted");
            }

            // mapping for table permission
            if (item is Permission permission)
            {
                permission.permission_id = reader.GetInt64("permission_id");
                permission.name = reader.GetString("name");
                permission.path = reader.GetString("path");
                permission.method = reader.GetString("method");
                permission.module = reader.GetString("module");
                permission.description = reader.IsDBNull("description") ? null : reader.GetString("description");
                permission.createdAt = reader.GetDateTime("createdAt");
                permission.updatedAt = reader.IsDBNull("updatedAt") ? (DateTime?)null : reader.GetDateTime("updatedAt");
                permission.isDeleted = reader.GetBoolean("isDeleted");
                permission.createdBy = reader.GetInt64("createdBy");
                permission.updatedBy = reader.IsDBNull("updatedBy") ? (long?)null : reader.GetInt64("updatedBy");
                permission.deleteBy = reader.IsDBNull("deleteBy") ? (long?)null : reader.GetInt64("deleteBy");
            }

            // Mapping for table User
            if (item is User user)
            {
                user.user_id = reader.GetInt64("user_id");
                user.name = reader.GetString("name");
                user.email = reader.GetString("email");
                user.password = reader.GetString("password");
                user.age = reader.GetByte("age");
                user.gender = reader.IsDBNull("gender") ? null : reader.GetString("gender");
                user.address = reader.IsDBNull("address") ? null : reader.GetString("address");
                user.role_id = reader.GetInt64("role_id");
                user.refreshToken = reader.IsDBNull("refreshToken") ? null : reader.GetString("refreshToken");
                user.createdAt = reader.GetDateTime("createdAt");
                user.updatedAt = reader.IsDBNull("updatedAt") ? (DateTime?)null : reader.GetDateTime("updatedAt");
                user.isDeleted = reader.GetBoolean("isDeleted");
                user.createdBy = reader.IsDBNull("createdBy") ? (long?)null : reader.GetInt64("createdBy");
                user.updatedBy = reader.IsDBNull("updatedBy") ? (long?)null : reader.GetInt64("updatedBy");
                user.deleteBy = reader.IsDBNull("deleteBy") ? (long?)null : reader.GetInt64("deleteBy");
            }

            // Các ánh xạ khác nếu cần
            return item;
        }

    }
}
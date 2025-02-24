using BookStore.DAL.Entities;
using BookStore.DAL.Modal;
using BookStore.DAL.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly MySqlConnection _connection;
        private readonly MySqlTransaction _transaction;

        public UserRepository(MySqlConnection connection, MySqlTransaction transaction) : base(connection, transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public async Task<IEnumerable<UserExtendedRole>> GetAllExtendedAsync()
        {
            var items = new List<UserExtendedRole>();

            var query = @"
SELECT 
    u.user_id, 
    u.name, 
    u.email, 
    u.password, 
    u.age, 
    u.gender, 
    u.address, 
    u.role_id, 
    r.name AS role_name, 
    u.refreshToken, 
    u.createdAt, 
    u.updatedAt, 
    u.isDeleted, 
    u.createdBy, 
    u.updatedBy, 
    u.deleteBy
FROM User u
INNER JOIN Role r ON u.role_id = r.role_id
WHERE u.isDeleted = 0";

            try
            {
                using (var command = new MySqlCommand(query, _connection, _transaction))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var item = new UserExtendedRole
                            {
                              user_id = reader.GetInt64(reader.GetOrdinal("user_id")),
name = reader.GetString(reader.GetOrdinal("name")),
email = reader.GetString(reader.GetOrdinal("email")),
password = reader.GetString(reader.GetOrdinal("password")),
age = reader.GetByte(reader.GetOrdinal("age")),
gender = reader.IsDBNull(reader.GetOrdinal("gender")) ? null : reader.GetString(reader.GetOrdinal("gender")),
address = reader.IsDBNull(reader.GetOrdinal("address")) ? null : reader.GetString(reader.GetOrdinal("address")),
role_id = reader.GetInt64(reader.GetOrdinal("role_id")),
role_name = reader.GetString(reader.GetOrdinal("role_name")),
refreshToken = reader.IsDBNull(reader.GetOrdinal("refreshToken")) ? null : reader.GetString(reader.GetOrdinal("refreshToken")),
createdAt = reader.GetDateTime(reader.GetOrdinal("createdAt")),
updatedAt = reader.IsDBNull(reader.GetOrdinal("updatedAt")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("updatedAt")),
isDeleted = reader.GetBoolean(reader.GetOrdinal("isDeleted")),
createdBy = reader.IsDBNull(reader.GetOrdinal("createdBy")) ? (long?)null : reader.GetInt64(reader.GetOrdinal("createdBy")),
updatedBy = reader.IsDBNull(reader.GetOrdinal("updatedBy")) ? (long?)null : reader.GetInt64(reader.GetOrdinal("updatedBy")),
deleteBy = reader.IsDBNull(reader.GetOrdinal("deleteBy")) ? (long?)null : reader.GetInt64(reader.GetOrdinal("deleteBy"))

                            };

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

        public async Task<IEnumerable<string>> GetAllEmailsAsync()
        {
            var emails = new List<string>();
            var query = "SELECT email FROM User WHERE isDeleted = 0";

            try
            {
                using (var command = new MySqlCommand(query, _connection, _transaction))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            emails.Add(reader.GetString(reader.GetOrdinal("email")));

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi từ Repository: " + ex.Message, ex);
            }

            return emails;
        }
    }
}

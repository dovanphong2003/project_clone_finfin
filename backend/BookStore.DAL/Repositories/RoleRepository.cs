using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DAL.Entities;
using BookStore.DTO.DTOs;
using MySql.Data.MySqlClient; // Sử dụng MySQL

namespace BookStore.DAL.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly MySqlConnection _connection;
        private readonly MySqlTransaction _transaction;

        public RoleRepository(MySqlConnection connection, MySqlTransaction transaction) : base(connection, transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public async Task<IEnumerable<RoleDTO>> GetAllRoleExtendedAsync()
        {
            var roles = new List<RoleDTO>();

            // Sử dụng GROUP_CONCAT thay vì STRING_AGG để tương thích MySQL
            var query = @"
                SELECT 
                    r.role_id,
                    r.name,
                    r.description,
                    r.status,
                    r.createdAt,
                    r.updatedAt,
                    r.isDeleted,
                    GROUP_CONCAT(rp.permission_id) AS ArrIdPermission
                FROM 
                    Role r
                LEFT JOIN 
                    Role_Permission rp ON r.role_id = rp.role_id
                WHERE
                    r.isDeleted = 0
                GROUP BY 
                    r.role_id, r.name, r.description, r.status, r.createdAt, r.updatedAt, r.isDeleted;";

            try
            {
                using (var command = new MySqlCommand(query, _connection, _transaction))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var role = new RoleDTO
                            {
                                role_id = reader.GetInt64(reader.GetOrdinal("role_id")),
                                name = reader.GetString(reader.GetOrdinal("name")),
                                description = reader.GetString(reader.GetOrdinal("description")),
                                status = reader.GetBoolean(reader.GetOrdinal("status")),
                                createdAt = reader.GetDateTime(reader.GetOrdinal("createdAt")),
                                updatedAt = reader.IsDBNull(reader.GetOrdinal("updatedAt")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("updatedAt")),
                                isDeleted = reader.GetBoolean(reader.GetOrdinal("isDeleted")),
                                ArrIdPermission = new List<long>()
                            };

                            if (!reader.IsDBNull(reader.GetOrdinal("ArrIdPermission")))
                            {
                                string arrIdPermission = reader.GetString(reader.GetOrdinal("ArrIdPermission"));
                                role.ArrIdPermission = arrIdPermission.Split(',').Select(long.Parse).ToList();
                            }

                            roles.Add(role);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing the transaction: " + ex.Message, ex);
            }

            return roles;
        }

        public async Task CreateRoleAsync(RoleDTO newRole)
        {
            var queryRole = @"
                INSERT INTO Role (role_id, name, description, status, createdAt, isDeleted)
                VALUES (@role_id, @name, @description, @status, @createdAt, @isDeleted);";

            var queryRolePermissions = @"
                INSERT INTO Role_Permission (role_id, permission_id)
                VALUES (@role_id, @permission_id);";

            try
            {
                using (var command = new MySqlCommand(queryRole, _connection, _transaction))
                {
                    command.Parameters.AddWithValue("@role_id", newRole.role_id);
                    command.Parameters.AddWithValue("@name", newRole.name);
                    command.Parameters.AddWithValue("@description", newRole.description);
                    command.Parameters.AddWithValue("@status", newRole.status);
                    command.Parameters.AddWithValue("@createdAt", DateTime.UtcNow);
                    command.Parameters.AddWithValue("@isDeleted", newRole.isDeleted);

                    await command.ExecuteNonQueryAsync();
                }

                if (newRole.ArrIdPermission != null && newRole.ArrIdPermission.Any())
                {
                    foreach (var permissionId in newRole.ArrIdPermission)
                    {
                        using (var permissionCommand = new MySqlCommand(queryRolePermissions, _connection, _transaction))
                        {
                            permissionCommand.Parameters.AddWithValue("@role_id", newRole.role_id);
                            permissionCommand.Parameters.AddWithValue("@permission_id", permissionId);
                            await permissionCommand.ExecuteNonQueryAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi từ Repository: " + ex.Message, ex);
            }
        }

        public async Task UpdateRoleAsync(UpdateRoleDTO updateRole)
        {
            var updateRoleQuery = new StringBuilder("UPDATE Role SET ");
            var parameters = new List<MySqlParameter>();

            foreach (var field in updateRole.FieldsToUpdate)
            {
                updateRoleQuery.Append($"{field.Key} = @{field.Key}, ");
                parameters.Add(new MySqlParameter($"@{field.Key}", field.Value ?? DBNull.Value));
            }

            updateRoleQuery.Length -= 2;
            updateRoleQuery.Append(" WHERE role_id = @role_id;");
            parameters.Add(new MySqlParameter("@role_id", updateRole.id));

            var deletePermissionsQuery = @"
                DELETE FROM Role_Permission
                WHERE role_id = @role_id
                AND FIND_IN_SET(permission_id, @permission_ids) > 0;";

            var insertPermissionsQuery = "INSERT INTO Role_Permission (role_id, permission_id) VALUES (@role_id, @permission_id);";

            try
            {
                using (var command = new MySqlCommand(updateRoleQuery.ToString(), _connection, _transaction))
                {
                    command.Parameters.AddRange(parameters.ToArray());
                    await command.ExecuteNonQueryAsync();
                }

                if (updateRole.PermissionUpdate != null && updateRole.PermissionUpdate.Any())
                {
                    foreach (var permissionId in updateRole.PermissionUpdate)
                    {
                        using (var permissionCommand = new MySqlCommand(insertPermissionsQuery, _connection, _transaction))
                        {
                            permissionCommand.Parameters.AddWithValue("@role_id", updateRole.id);
                            permissionCommand.Parameters.AddWithValue("@permission_id", permissionId);
                            await permissionCommand.ExecuteNonQueryAsync();
                        }
                    }
                }

                if (updateRole.PermissionDelete != null && updateRole.PermissionDelete.Any())
                {
                    var permissionIds = string.Join(",", updateRole.PermissionDelete);
                    using (var deleteCommand = new MySqlCommand(deletePermissionsQuery, _connection, _transaction))
                    {
                        deleteCommand.Parameters.AddWithValue("@role_id", updateRole.id);
                        deleteCommand.Parameters.AddWithValue("@permission_ids", permissionIds);
                        await deleteCommand.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in repository: " + ex.Message, ex);
            }
        }
    }
}

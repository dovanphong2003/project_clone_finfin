using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DAL.Entities;
using BookStore.DTO.DTOs;
using BookStore.DAL.Repositories;
using Microsoft.Data.SqlClient;

namespace BookStore.DAL.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;

        public RoleRepository(SqlConnection connection, SqlTransaction transaction) : base(connection, transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }
        public async Task<IEnumerable<RoleDTO>> GetAllRoleExtendedAsync()
        {
            var roles = new List<RoleDTO>();

            // Câu truy vấn SQL để lấy tất cả thông tin từ bảng Role và các permission_id từ bảng RolePermission
            var query = @"
        SELECT 
            r.role_id,
            r.name,
            r.description,
            r.status,
            r.createdAt,
            r.updatedAt,
            r.isDeleted,
            STRING_AGG(rp.permission_id, ',') AS ArrIdPermission
        FROM 
            Role r
        JOIN 
            Role_Permission rp ON r.role_id = rp.role_id
        WHERE
            r.isDeleted = 0
        GROUP BY 
            r.role_id, r.name, r.description, r.status, r.createdAt, r.updatedAt, r.isDeleted;";

            try
            {
                using (var command = new SqlCommand(query, _connection, _transaction))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            // Ánh xạ kết quả đọc từ SqlDataReader vào DTO
                            var role = new RoleDTO
                            {
                                role_id = reader.GetInt64(reader.GetOrdinal("role_id")),
                                name = reader.GetString(reader.GetOrdinal("name")),
                                description = reader.GetString(reader.GetOrdinal("description")),
                                status = reader.GetBoolean(reader.GetOrdinal("status")),
                                createdAt = reader.GetDateTime(reader.GetOrdinal("createdAt")),
                                updatedAt = reader.IsDBNull(reader.GetOrdinal("updatedAt")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("updatedAt")),
                                isDeleted = reader.GetBoolean(reader.GetOrdinal("isDeleted")),
                                ArrIdPermission = new List<int>()
                            };

                            // Chuyển đổi chuỗi ArrIdPermission thành List<int>
                            string arrIdPermission = reader.GetString(reader.GetOrdinal("ArrIdPermission"));
                            if (!string.IsNullOrEmpty(arrIdPermission))
                            {
                                string[] permissions = arrIdPermission.Split(',');
                                foreach (var permission in permissions)
                                {
                                    role.ArrIdPermission.Add(int.Parse(permission));
                                }
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
            // SQL query để insert một Role mới
            var queryRole = @"
        INSERT INTO Role (role_id, name, description, status, createdAt, isDeleted)
        VALUES (@role_id, @name, @description, @status, @createdAt, @isDeleted);";

            // Query để insert các Permission liên quan
            var queryRolePermissions = @"
        INSERT INTO Role_Permission (role_id, permission_id)
        VALUES (@role_id, @permission_id);";

            try
            {
                // Mở kết nối và bắt đầu transaction
                using (var command = new SqlCommand(queryRole, _connection, _transaction))
                {
                    // Thêm tham số cho câu truy vấn Role
                    command.Parameters.AddWithValue("@role_id", newRole.role_id);
                    command.Parameters.AddWithValue("@name", newRole.name);
                    command.Parameters.AddWithValue("@description", newRole.description);
                    command.Parameters.AddWithValue("@status", newRole.status);
                    command.Parameters.AddWithValue("@createdAt", DateTime.UtcNow);
                    command.Parameters.AddWithValue("@isDeleted", newRole.isDeleted);

                    // Thực thi câu lệnh insert Role
                    await command.ExecuteNonQueryAsync();
                }

                // Nếu có danh sách permission, thêm chúng vào bảng Role_Permission
                if (newRole.ArrIdPermission != null && newRole.ArrIdPermission.Any())
                {
                    foreach (var permissionId in newRole.ArrIdPermission)
                    {
                        using (var permissionCommand = new SqlCommand(queryRolePermissions, _connection, _transaction))
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
            var parameters = new List<SqlParameter>();

            // Cập nhật các trường cần thiết
            foreach (var field in updateRole.FieldsToUpdate)
            {
                // Kiểm tra kiểu dữ liệu của field.Value và thêm tham số tương ứng vào câu lệnh SQL
                if (field.Value == null)
                {
                    // Xử lý giá trị null
                    updateRoleQuery.Append($"{field.Key} = @{field.Key}, ");
                    parameters.Add(new SqlParameter($"@{field.Key}", DBNull.Value));
                }
                else if (field.Value is string)
                {
                    // Nếu là string, thêm tham số như một chuỗi
                    updateRoleQuery.Append($"{field.Key} = @{field.Key}, ");
                    parameters.Add(new SqlParameter($"@{field.Key}", (string)field.Value));
                }
                else if (field.Value is long)
                {
                    // Nếu là long, thêm tham số như một số nguyên long
                    updateRoleQuery.Append($"{field.Key} = @{field.Key}, ");
                    parameters.Add(new SqlParameter($"@{field.Key}", (long)field.Value));
                }
                else if (field.Value is decimal)
                {
                    // Nếu là decimal, thêm tham số như một số thập phân
                    updateRoleQuery.Append($"{field.Key} = @{field.Key}, ");
                    parameters.Add(new SqlParameter($"@{field.Key}", (decimal)field.Value));
                }
                else if (field.Value is double)
                {
                    // Nếu là double, thêm tham số như một số thực
                    updateRoleQuery.Append($"{field.Key} = @{field.Key}, ");
                    parameters.Add(new SqlParameter($"@{field.Key}", (double)field.Value));
                }
                else if (field.Value is DateTime)
                {
                    // Nếu là DateTime, thêm tham số như một ngày giờ
                    updateRoleQuery.Append($"{field.Key} = @{field.Key}, ");
                    parameters.Add(new SqlParameter($"@{field.Key}", (DateTime)field.Value));
                }
                else
                {
                    // Nếu là kiểu dữ liệu khác, chuyển nó thành chuỗi
                    updateRoleQuery.Append($"{field.Key} = @{field.Key}, ");
                    parameters.Add(new SqlParameter($"@{field.Key}", field.Value.ToString()));
                }
            }
            updateRoleQuery.Length -= 2;
            updateRoleQuery.Append(" WHERE role_id = @role_id;");
            parameters.Add(new SqlParameter("@role_id", updateRole.id));

            var deletePermissionsQuery = @"
        DELETE FROM Role_Permission
        WHERE role_id = @role_id
        AND permission_id IN (SELECT value FROM STRING_SPLIT(@permission_ids, ','));";

            var insertPermissionsQuery = "INSERT INTO Role_Permission (role_id, permission_id) VALUES (@role_id, @permission_id);";

            try
            {
                // Thực hiện UPDATE bảng Role
                using (var command = new SqlCommand(updateRoleQuery.ToString(), _connection, _transaction))
                {
                    command.Parameters.AddRange(parameters.ToArray());
                    await command.ExecuteNonQueryAsync();
                }

                // Thêm quyền vào Role_Permission
                if (updateRole.PermissionUpdate != null && updateRole.PermissionUpdate.Any())
                {
                    foreach (var permissionId in updateRole.PermissionUpdate)
                    {
                        using (var permissionCommand = new SqlCommand(insertPermissionsQuery, _connection, _transaction))
                        {
                            permissionCommand.Parameters.AddWithValue("@role_id", updateRole.id);
                            permissionCommand.Parameters.AddWithValue("@permission_id", permissionId);
                            await permissionCommand.ExecuteNonQueryAsync();
                        }
                    }
                }

                // Xóa quyền khỏi Role_Permission
                if (updateRole.PermissionDelete != null && updateRole.PermissionDelete.Any())
                {
                    var permissionIds = string.Join(",", updateRole.PermissionDelete);
                    using (var deleteCommand = new SqlCommand(deletePermissionsQuery, _connection, _transaction))
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

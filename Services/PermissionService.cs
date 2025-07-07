using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;
using sdr.Helpers;
using sdr.Models;
namespace sdr.Services
{
    public class PermissionService
    {

        private readonly string _connection = DbConnectionManager.GetConnectionString();

        public List<Permission> GetAllPermissions()
        {
            var list = new List<Permission>();
            using (var conn = new SqlConnection(_connection))
            {
                conn.Open();
                string query = "SELECT * FROM Permissions";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Permission
                        {
                            PermissionId = Convert.ToInt32(reader["PermissionId"]),
                            PermissionName = reader["PermissionName"].ToString(),
                            Description = reader["Description"].ToString()
                        });
                    }
                }
            }
            return list;
        }


        public List<Permission> GetPermissionsByRoleId(int roleId)
        {
            var list = new List<Permission>();
            using (var conn = new SqlConnection(_connection))
            {
                conn.Open();
                string query = @"SELECT P.PermissionId, P.PermissionName, P.Description
FROM Permissions P
INNER JOIN RolePermissions RP ON RP.PermissionId = P.PermissionId
WHERE RP.RoleId = @RoleId";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoleId", roleId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Permission
                            {
                                PermissionId = Convert.ToInt32(reader["PermissionId"]),
                                PermissionName = reader["PermissionName"].ToString(),
                                Description = reader["Description"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        public void AssignPermissionsToRole(int roleId, List<Permission> permissions)
        {
            using (var conn = new SqlConnection(_connection))
            {
                conn.Open();

                // Mevcut izinleri sil
                var deleteCmd = new SqlCommand("DELETE FROM RolePermissions WHERE RoleId = @RoleId", conn);
                deleteCmd.Parameters.AddWithValue("@RoleId", roleId);
                deleteCmd.ExecuteNonQuery();

                // Yenilerini ekle
                foreach (var p in permissions)
                {
                    var insertCmd = new SqlCommand("INSERT INTO RolePermissions (RoleId, PermissionId) VALUES (@RoleId, @PermissionId)", conn);
                    insertCmd.Parameters.AddWithValue("@RoleId", roleId);
                    insertCmd.Parameters.AddWithValue("@PermissionId", p.PermissionId);
                    insertCmd.ExecuteNonQuery();
                }
            }
        }

        public List<Permission> GetPermissionsByUserId(int userId)
        {
            var list = new List<Permission>();
            using (var conn = new SqlConnection(_connection))
            {
                conn.Open();
                string query = @"
            SELECT DISTINCT P.PermissionId, P.PermissionName, P.Description
            FROM Permissions P
            INNER JOIN RolePermissions RP ON RP.PermissionId = P.PermissionId
            INNER JOIN Users U ON U.RoleId = RP.RoleId
            WHERE U.UserId = @UserId";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Permission
                            {
                                PermissionId = Convert.ToInt32(reader["PermissionId"]),
                                PermissionName = reader["PermissionName"].ToString(),
                                Description = reader["Description"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }
    }
}


/*
 
var permissionService = new PermissionService();
var permissions = permissionService.GetPermissionsForUser("Yusuf");

// Örnek: butonları yetkiye göre aktif/pasif yap
btnSales.Visible = permissions.Contains("SalesView");
btnPersonnelList.Visible = permissions.Contains("PersonnelListView");*/
using sdr.Models;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using sdr.Helpers;
namespace sdr.Services
{
    public class AuthService
    {
        private readonly string _connection = DbConnectionManager.GetConnectionString();
        public List<string> GetPermissionsByUserId(int userId)
        {
            var permissionList = new List<string>();

            using (var conn = new SqlConnection(_connection))
            {
                conn.Open();
                string query = @"
            SELECT DISTINCT P.PermissionName
            FROM Permissions P
            INNER JOIN RolePermissions RP ON RP.PermissionId = P.PermissionId
            INNER JOIN UserRoles UR ON UR.RoleId = RP.RoleId
            WHERE UR.UserId = @UserId";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            permissionList.Add(reader["PermissionName"].ToString());
                        }
                    }
                }
            }

            return permissionList;
        }

    }
}

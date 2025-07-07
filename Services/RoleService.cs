using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using sdr.Models;
using sdr.Helpers;
using System.Windows.Forms;

namespace sdr.Services
{
    public class RoleService
    {
        private readonly string _connection = DbConnectionManager.GetConnectionString();

        public List<Role> GetAllRoles()
        {
            var roles = new List<Role>();
            using (var conn = new SqlConnection(_connection))
            {
                conn.Open();
                string query = "SELECT * FROM Roles";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        roles.Add(new Role
                        {
                            RoleId = Convert.ToInt32(reader["RoleId"]),
                            RoleName = reader["RoleName"].ToString(),
                            Description = reader["Description"].ToString()
                            
                        });
                    }
                }
            }
            return roles;
        }


        public List<Role> GetRolesByUserId(int userId)
        {
            var roles = new List<Role>();
            using (var conn = new SqlConnection(_connection))
            {
                conn.Open();
                string query = @"SELECT R.RoleId, R.RoleName,R.Description
                                 FROM Roles R
                                 INNER JOIN UserRoles UR ON R.RoleId = UR.RoleId
                                 WHERE UR.UserId = @UserId";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roles.Add(new Role
                            {
                                RoleId = Convert.ToInt32(reader["RoleId"]),
                                RoleName = reader["Name"].ToString()
                            });
                        }
                    }
                }
            }
            return roles;
        }



        public bool UserIsInRole(int userId, string roleName)
        {
            using (var conn = new SqlConnection(_connection))
            {
                conn.Open();
                string query = @"SELECT COUNT(*) FROM UserRoles UR
                                 INNER JOIN Roles R ON UR.RoleId = R.RoleId
                                 WHERE UR.UserId = @UserId AND R.Name = @RoleName";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@RoleName", roleName);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }


        public bool AddRole(Role role)
        {

            try
            {
                using (var conn = new SqlConnection(_connection))
                {
                    conn.Open();


                    string checkQuery = "SELECT COUNT(*) FROM Roles WHERE RoleName = @RoleName";
                    using (var cmd = new SqlCommand(checkQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoleName", role.RoleName);
                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            throw new Exception("A role with this name already exists.");
                        }
                    }


                    string query = "INSERT INTO Roles (RoleName, Description) VALUES (@RoleName, @Description)";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoleName", role.RoleName);
                        cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(role.Description) ? DBNull.Value : (object)role.Description);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Role adding failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



        public bool DeleteRole(int roleId)
        {
            try
            {
                using (var conn = new SqlConnection(_connection))
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        // Rolün izinlerini sil
                        var deleteRolePermissionsCmd = new SqlCommand("DELETE FROM RolePermissions WHERE RoleId = @RoleId", conn, tran);
                        deleteRolePermissionsCmd.Parameters.AddWithValue("@RoleId", roleId);
                        deleteRolePermissionsCmd.ExecuteNonQuery();

                        // Kullanıcıların rolünü temizle (veya farklı role set et)
                        var updateUsersCmd = new SqlCommand("UPDATE Users SET RoleId = NULL WHERE RoleId = @RoleId", conn, tran);
                        updateUsersCmd.Parameters.AddWithValue("@RoleId", roleId);
                        updateUsersCmd.ExecuteNonQuery();

                        // Rolü sil
                        var deleteRoleCmd = new SqlCommand("DELETE FROM Roles WHERE RoleId = @RoleId", conn, tran);
                        deleteRoleCmd.Parameters.AddWithValue("@RoleId", roleId);
                        int affectedRows = deleteRoleCmd.ExecuteNonQuery();

                        tran.Commit();

                        return affectedRows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata logu veya mesaj
                MessageBox.Show("Role deletion failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }




    }
}

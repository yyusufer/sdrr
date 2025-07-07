using System;
using System.Data;
using sdr.Models;
using sdr.Helpers;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;

namespace sdr.Services
{
    public class UserService
    {
        private readonly string _connection;

        public UserService()
        {
            _connection = DbConnectionManager.GetConnectionString();
        }

        public bool IsUsernameExists(string username)
        {
            try
            {
                using (var conn = new SqlConnection(_connection))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // İstersen loglayabilirsin
                MessageBox.Show("Error checking username existence: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Hata olursa "yok" varsayabiliriz
            }
        }

        public bool AddUser(User user)
        {
            try
            {
                if (IsUsernameExists(user.Username))
                {
                    MessageBox.Show("This username is already taken. Please choose a different one.", "Duplicate User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                using (var conn = new SqlConnection(_connection))
                {
                    conn.Open();
                    string query = "INSERT INTO Users (Username, PasswordHash, RoleId, Email, FullName) VALUES (@Username, @PasswordHash, @RoleId, @Email, @FullName)";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", user.Username);
                        cmd.Parameters.AddWithValue("@PasswordHash", HashHelper.ComputeSha256Hash(user.PasswordHash));
                        cmd.Parameters.AddWithValue("@RoleId", user.RoleId);
                        if (string.IsNullOrEmpty(user.Email))
                            cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@Email", user.Email);

                        if (string.IsNullOrEmpty(user.FullName))
                            cmd.Parameters.AddWithValue("@FullName", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@FullName", user.FullName);
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("User has been successfully added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("User could not be added.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Örneğin UNIQUE constraint ihlali gibi SQL hataları
                MessageBox.Show("A database error occurred: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public User GetUserByUsername(string username)
        {
            try
            {
                using (var conn = new SqlConnection(_connection))
                {
                    conn.Open();
                    // SQL Server'da LIMIT yok, TOP kullanılır
                    string query = "SELECT TOP 1 * FROM Users WHERE Username = @Username";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                GetUserId.UserId = Convert.ToInt32(reader["UserId"]);
                                return new User
                                {
                                    UserId = Convert.ToInt32(reader["UserId"]),
                                    Username = reader["Username"].ToString(),
                                    PasswordHash = reader["PasswordHash"].ToString(),
                                    RoleId = Convert.ToInt32(reader["RoleId"]),
                                    Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString(),
                                    FullName = reader["FullName"] == DBNull.Value ? null : reader["FullName"].ToString()

                                };
                                
                            }
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Loglama yapabilirsin
                MessageBox.Show("Error fetching user data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        public static class GetUserId
        {
            public static int UserId { get; set; }
         
        }



        public List<Permission> GetPermissionsByUserId(int userId)
        {
            var permissions = new List<Permission>();

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
                            permissions.Add(new Permission
                            {
                                PermissionId = Convert.ToInt32(reader["PermissionId"]),
                                PermissionName = reader["PermissionName"].ToString(),
                                Description = reader["Description"].ToString()
                            });
                        }
                    }
                }
            }

            return permissions;
        }
        public bool ValidateLogin(string username, string password)
        {
            var user = GetUserByUsername(username);
            if (user == null)
                return false;

            string passwordHash = HashHelper.ComputeSha256Hash(password);
            return user.PasswordHash == passwordHash;
        }





        
    }
}

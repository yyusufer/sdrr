using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdr.Helpers
{
    public class DbConnectionManager
    {
        public class DbConfig
        {
            public string Server { get; set; }
            public string Database { get; set; }
            public bool UseWindowsAuth { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }

        private static readonly string configPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "SDR Sistemleri",
            "dbconfig.json"
        );

        public static string GetConnectionString()
        {
            if (!File.Exists(configPath))
                throw new FileNotFoundException("Database connection settings could not be found.");

            var json = File.ReadAllText(configPath);
            var config = Newtonsoft.Json.JsonConvert.DeserializeObject<DbConfig>(json);

            if (config == null || string.IsNullOrEmpty(config.Server) || string.IsNullOrEmpty(config.Database))
                return null;

            if (config.UseWindowsAuth)
                return $"Server={config.Server};Database={config.Database};Integrated Security=True;";
            else
                return $"Server={config.Server};Database={config.Database};User Id={config.Username};Password={config.Password};";


        }
    }
}


/*Nasıl kullanılır?
 
 
 using sdr.Helpers;

string connectionString = DbConnectionManager.GetConnectionString();

 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdr.Helpers
{
    public static class Session
    {
        public static int UserId { get; set; }
        public static string Username { get; set; }
        public static List<string> UserPermissions { get; set; } = new List<string>();
    }
}

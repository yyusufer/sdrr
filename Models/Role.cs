using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdr.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }

        public List<Permission> Permissions { get; set; } = new List<Permission>();
        public override string ToString()
        {
            return $"{RoleName} - {Description}";
        }
    }
}

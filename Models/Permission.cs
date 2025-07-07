using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdr.Models
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public string PermissionName { get; set; }
        public override string ToString()
        {
            return PermissionName ; 
        }


        public string Description { get; set; }
    }
}

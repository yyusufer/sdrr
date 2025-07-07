using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sdr.Helpers;

namespace sdr.Models
{

    public class User
    {
       
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }


    }

    public class RememberMeData
    {
        public string Username { get; set; }
        public DateTime RememberedAt { get; set; }
    }


}

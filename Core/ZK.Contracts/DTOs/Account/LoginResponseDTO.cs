using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Users;

namespace ZK.Contracts.DTOs.Account
{
    public class LoginResponseDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public int ExpiresIn { get; set; }
        public ICollection<ViewRoleDTO> Roles { get; set; }
    }
}

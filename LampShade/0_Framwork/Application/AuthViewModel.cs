using System.Collections.Generic;

namespace _0_Framwork.Application
{
    public class AuthViewModel
    {
        public long Id { get; set; }

        public long RoleId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public List<int> Permission{ get; set; }
        public string Role { get; set; }
        public AuthViewModel()
        {

        }

        public AuthViewModel(long id, long roleId, string fullName, string userName, List<int> permission    )
        {
            Id = id;
            RoleId = roleId;
            FullName = fullName;
            UserName = userName;
            Permission = permission;
        }
    }
}
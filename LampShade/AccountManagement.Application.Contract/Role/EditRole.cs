using _0_Framwork.Infrastructure;
using System.Collections.Generic;

namespace AccountManagement.Application.Contract.Role
{
    public class EditRole:CreateRole
    {
        public long Id { get; set; }
        public List<PermissionDto> MappedPermissions { get; set; }
    }
}

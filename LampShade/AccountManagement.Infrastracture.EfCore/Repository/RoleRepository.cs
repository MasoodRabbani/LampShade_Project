using _0_Framwork.Application;
using _0_Framwork.Infrastructure;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastracture.EfCore.Repository
{
    public class RoleRepository : RepositoryBase<long, Role>, IRoleRepository
    {
        private readonly AccountContext context;

        public RoleRepository(AccountContext context):base(context)
        {
            this.context = context;
        }

        public EditRole GetDetails(long id)
        {
            var role= context.Roles.Select(s => new EditRole
            {
                Id = s.Id,
                Name = s.Name,
                MappedPermissions=MapPermission(s.Permissions)
            }).AsNoTracking().FirstOrDefault(s => s.Id==id);
            role.Permissions = role.MappedPermissions.Select(s => s.Code).ToList();
            return role;
        }

        private static List<PermissionDto> MapPermission(IEnumerable<Permission> permissions)
        {
            return permissions.Select(s => new PermissionDto(s.Code, s.Name)).ToList();
        }

        public List<RoleViewModel> Search()
        {
            return context.Roles.Select(s=>new RoleViewModel
            {
                Id=s.Id,
                Name=s.Name,
                CreationDate=s.CreationDate.ToFarsi()
            }).ToList();
        }
    }
}

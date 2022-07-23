using _0_Framwork.Domain;
using AccountManagement.Application.Contract.Role;
using System.Collections.Generic;

namespace AccountManagement.Domain.RoleAgg
{
    public interface IRoleRepository : IRepository<long, Role>
    {
        EditRole GetDetails(long id);
        List<RoleViewModel> Search();
    }
}

using _0_Framwork.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contract.Role
{
    public interface IRoleApplication
    {
        OprationResult Create(CreateRole command);
        OprationResult Edit(EditRole command);
        EditRole GetDetails(long id);
        List<RoleViewModel> Search();
    }
}

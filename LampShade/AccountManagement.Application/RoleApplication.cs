using _0_Framwork.Application;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Domain.RoleAgg;
using System.Collections.Generic;

namespace AccountManagement.Application
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository roleRepository;

        public RoleApplication(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public OprationResult Create(CreateRole command)
        {
            var oprationresult=new OprationResult();
            if (roleRepository.Exists(s => s.Name == command.Name))
                return oprationresult.Feiled(ApplicationMessages.DublicatedRecord);
            var role = new Role(command.Name);
            roleRepository.Create(role);
            roleRepository.SaveChanges();
            return oprationresult.Sucsseded();
        }

        public OprationResult Edit(EditRole command)
        {
            var oprationresult = new OprationResult();
            var role = roleRepository.Get(command.Id);
            if(role==null)
                return oprationresult.Feiled(ApplicationMessages.RecordNotFound);
            if (roleRepository.Exists(s => s.Name == command.Name))
                return oprationresult.Feiled(ApplicationMessages.DublicatedRecord);
            role.Edit(command.Name);
            roleRepository.SaveChanges();
            return oprationresult.Sucsseded();
        }

        public EditRole GetDetails(long id)
        {
            return roleRepository.GetDetails(id);
        }

        public List<RoleViewModel> Search()
        {
            return roleRepository.Search();
        }
    }
}

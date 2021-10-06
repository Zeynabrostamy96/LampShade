using _01_Farmework.Application;
using AccountManagement.Domain.RoleAgg;
using AccountManagment.Application.Contracts.Role;
using System.Collections.Generic;

namespace AccountManagment.Application.Role
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _roleRepository;
        public RoleApplication(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public OperationResult Create(CreateRole command)
        {
            var operation = new OperationResult();
            if (_roleRepository.Exists(x => x.Name == command.Name))
                return operation.Faild(ApplicationMessage.DuplicatedRecord);
            var role = new AccountManagement.Domain.RoleAgg.Role(command.Name,new List<Permission>());
            _roleRepository.Create(role);
            _roleRepository.Save();
            return operation.Succedded();
        }

        public OperationResult Edit(EditRole command)
        {
            var operation = new OperationResult();
            var role = _roleRepository.Get(command.id);
            if (role == null)
            
                return operation.Faild(ApplicationMessage.RecordNotFound);
            
            if (_roleRepository.Exists(x => x.Name == command.Name && x.id !=command.id))
                return operation.Faild(ApplicationMessage.DuplicatedRecord);
            role.Edit(command.Name, new List<Permission>());
            _roleRepository.Save();
            return operation.Succedded();
        }

        public EditRole GetDetails(long id)
        {
            return _roleRepository.GetDetails(id);
        }

        public List<RoleViewModel> List()
        {
            return _roleRepository.List();
        }
    }
}

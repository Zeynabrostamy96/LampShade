

using _01_Farmework.Domain;
using AccountManagment.Application.Contracts.Role;
using System.Collections.Generic;

namespace AccountManagement.Domain.RoleAgg
{
    public interface IRoleRepository:IRepository<long ,Role>
    {
        EditRole GetDetails(long id);
        List<RoleViewModel> List();
    }
}



using _01_Farmework.Application;
using System.Collections.Generic;

namespace AccountManagment.Application.Contracts.Role
{
    public  interface IRoleApplication
    {
        OperationResult Create(CreateRole command);
        OperationResult Edit(EditRole command);
        EditRole GetDetails(long id);
        List<RoleViewModel> List();
    }
}

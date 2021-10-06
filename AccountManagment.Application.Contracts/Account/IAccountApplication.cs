

using _01_Farmework.Application;
using System.Collections.Generic;

namespace AccountManagment.Application.Contracts.Account
{
    public  interface IAccountApplication
    {
        OperationResult Register(RegisterAccount command);
        OperationResult Edit(EditAccount command);
        OperationResult Login(Login command);
        OperationResult ChangePassword(changePassword command);
        List<AccountViewModel> Search(AccountSearchModel search);
        EditAccount GetDetails(long id);
        void LogOute();

    }
}

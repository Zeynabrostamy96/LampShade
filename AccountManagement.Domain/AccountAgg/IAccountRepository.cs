

using _01_Farmework.Domain;
using AccountManagment.Application.Contracts.Account;
using System.Collections.Generic;

namespace AccountManagement.Domain.AccountAgg
{
   public  interface IAccountRepository:IRepository<long,Account>
   {
        EditAccount GetDetails(long id);
        Account Get(string username);
        List<AccountViewModel> Search(AccountSearchModel search);

    }
}

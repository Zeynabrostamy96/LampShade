
using _01_Farmework.Application;
using _01_Farmework.Infrastructure;
using AccountManagement.Domain.AccountAgg;
using AccountManagment.Application.Contracts.Account;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AccountManagment.Infrastructure.Repository
{
    public class AccountRepository : RepositoryBase<long, Account>, IAccountRepository
    {
        private readonly AccountContext _accountContext;
        public AccountRepository(AccountContext accountContext):base(accountContext)
        {
            _accountContext = accountContext;

        }

        public Account Get(string username)
        {
            return _accountContext.accounts.FirstOrDefault(x => x.UseName == username);
        }

        public EditAccount GetDetails(long id)
        {
            return _accountContext.accounts.Select(x => new EditAccount
            {
                id=x.id,
                FullName=x.FullName,
                Mobile=x.Mobile,
                //Password=x.Password,
                RoleId=x.RoleId,
                UseName=x.UseName
            }).FirstOrDefault(x => x.id == id);

        }

        public List<AccountViewModel> Search(AccountSearchModel search)
        {
            var query = _accountContext.accounts.Include(x=>x.role).Select(x=>new AccountViewModel 
            { 
                id=x.id,
                FullName=x.FullName,
                Mobile=x.Mobile,
                ProfilePhoto=x.ProfilePhoto,
                UseName=x.UseName,
                Role=x.role.Name,
                Creationdate=x.Crationdate.ToFarsi()
                
            });
            if (!string.IsNullOrWhiteSpace(search.UseName))
                query = query.Where(x => x.UseName.Contains(search.UseName));
            if (!string.IsNullOrWhiteSpace(search.FullName))
                query = query.Where(x => x.UseName.Contains(search.FullName));
            if (!string.IsNullOrWhiteSpace(search.Mobile))
                query = query.Where(x => x.UseName.Contains(search.Mobile));
            if (search.RoleId != 0)
                query = query.Where(x =>x.RoleId==search.RoleId);
            return query.OrderByDescending(x => x.id).ToList();

        }
    }
}

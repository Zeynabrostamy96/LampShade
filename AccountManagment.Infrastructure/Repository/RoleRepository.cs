

using _01_Farmework.Application;
using _01_Farmework.Infrastructure;
using AccountManagement.Domain.RoleAgg;
using AccountManagment.Application.Contracts.Role;
using System.Collections.Generic;
using System.Linq;

namespace AccountManagment.Infrastructure.Repository
{
    public class RoleRepository : RepositoryBase<long, Role>, IRoleRepository
    {
        private readonly AccountContext _accountContext;
        public RoleRepository(AccountContext accountContext):base(accountContext)
        {
            _accountContext = accountContext;
        }
        public EditRole GetDetails(long id)
        {
            return _accountContext.roles.Select(x => new EditRole
            {
                id=x.id,
                Name=x.Name,
            }).FirstOrDefault(x => x.id == id);
        }

        public List<RoleViewModel> List()
        {
            return _accountContext.roles.Select(x => new RoleViewModel
            {
                Id=x.id,
                CreationDate=x.Crationdate.ToFarsi(),
                Name=x.Name
            }).ToList();
        }
    }
}

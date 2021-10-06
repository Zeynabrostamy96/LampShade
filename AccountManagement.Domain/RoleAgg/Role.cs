using _01_Farmework;
using AccountManagement.Domain.AccountAgg;
using System.Collections.Generic;

namespace AccountManagement.Domain.RoleAgg
{
    public class Role:EntityBase
    {
        public string  Name { get; private  set; }
        public List<Account> accounts { get; set; }
        public List<Permission> Permissions { get; private set; }

        public Role()
        {

        }
        public Role(string name, List<Permission> permissions)
        {
            Name = name;
            accounts = new List<Account>();
            Permissions = permissions;
        }
        public void Edit(string name,List<Permission> permissions)
        {
            Name = name;
            Permissions = permissions;
        }
    }
}

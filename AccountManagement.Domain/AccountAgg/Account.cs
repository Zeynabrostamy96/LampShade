using _01_Farmework;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Domain.AccountAgg
{
    public  class Account:EntityBase
    {
        public string FullName { get;private set; }
        public string  UseName { get; private set; }
        public string Password { get; private set; }
        public string Mobile { get; private set; }
        public string ProfilePhoto { get; private set; }
        public long  RoleId { get; private set; }
        public Role role { get;private set; }
        public Account()
        {

        }
        public Account(string fullename,string username,string password,string mobile,string profilephoto,long roleid)
        {
            FullName = fullename;
            UseName = username;
            Password = password;
            Mobile = mobile;
            ProfilePhoto = profilephoto;
            if (roleid == 0)
                RoleId = 2;
            //RoleId = roleid;

        }
        public void Edit(string fullename, string username, string mobile, string profilephoto, long roleid)
        {
            FullName = fullename;
            UseName = username;
            Mobile = mobile;
            if(!string.IsNullOrWhiteSpace(Password))
                ProfilePhoto = profilephoto;
            RoleId = roleid;
        }
        public void ChangePassword(string password)
        {
            Password = password;
        }
    }
}

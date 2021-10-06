

namespace AccountManagment.Application.Contracts.Account
{
    public class AccountViewModel
    {
        public long  id { get; set; }
        public string FullName { get; set; }
        public string UseName { get; set; }
        public string Mobile { get; set; }
        public string ProfilePhoto { get; set; }
        public long RoleId { get; set; }
        public string Role  { get; set; }
        public string Creationdate { get; set; }
    }
}

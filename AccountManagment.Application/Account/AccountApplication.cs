using _01_Farmework.Application;
using _01_Framework.Application;
using AccountManagement.Domain.AccountAgg;
using AccountManagment.Application.Contracts.Account;
using System.Collections.Generic;

namespace AccountManagment.Application.Account
{
    public  class AccountApplication: IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IFileUploader _fileUploader;
        private readonly IAuthHelper _authHelper;

        public AccountApplication( IAccountRepository accountRepository, IPasswordHasher passwordHasher,IFileUploader fileUploader, IAuthHelper authHelper)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _fileUploader = fileUploader;
            _authHelper = authHelper;
        }

        public OperationResult ChangePassword(changePassword command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.id);
            if (account == null)
                return operation.Faild(ApplicationMessage.RecordNotFound);
            if (command.Password != command.RePassword)
                return operation.Faild(ApplicationMessage.PasswordNotMatch);
            var password = _passwordHasher.Hash(command.Password);
            account.ChangePassword(password);
            _accountRepository.Save();
            return operation.Succedded();
        }

        public OperationResult Register(RegisterAccount command)
        {
            var operation = new OperationResult();
            if (_accountRepository.Exists(x => x.UseName == command.UseName || x.Mobile == command.Mobile))
                return operation.Faild(ApplicationMessage.DuplicatedRecord);

            var password = _passwordHasher.Hash(command.Password);
            var path = $"{"ProfilePhotos"}";
            var PhotoName = _fileUploader.Upload(command.ProfilePhoto, path);

            var account = new AccountManagement.Domain.AccountAgg.Account(command.FullName,command.UseName, password, command.Mobile, PhotoName, command.RoleId);
            _accountRepository.Create(account);
            _accountRepository.Save();
            return operation.Succedded();
        }

        public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.id);
            if(account == null)
                return operation.Faild(ApplicationMessage.RecordNotFound);
            if (_accountRepository.Exists(x =>( x.UseName == command.UseName || x.Mobile == command.Mobile )&& x.id != command.id))
                return operation.Faild(ApplicationMessage.DuplicatedRecord);
            var path = $"ProfilePhotos";
            var PhotoName = _fileUploader.Upload(command.ProfilePhoto, path);
            account.Edit(command.FullName, command.UseName, command.Mobile, PhotoName, command.RoleId);
            _accountRepository.Save();
            return operation.Succedded();
        }

        public EditAccount GetDetails(long id)
        {
            return _accountRepository.GetDetails(id);
        }

        public OperationResult Login(Login command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.UserName);

            if (account == null)
                return operation.Faild(ApplicationMessage.WrongUserPass);
          
            (bool Verified, bool NeedsUpgrade)result = _passwordHasher.Check(account.Password,command.Password);

            if (!result.Verified)
                return operation.Faild(ApplicationMessage.WrongUserPass);
            var Authviewmodel = new AuthViewModel()
            {
                id=account.id,
                RoleId=account.RoleId,
                UseName=account.UseName,
                FullName=account.FullName,

            };
            _authHelper.Signin(Authviewmodel);

            return operation.Succedded();
        }

        public void LogOute()
        {
            _authHelper.SignOut();
        }

      

        public List<AccountViewModel> Search(AccountSearchModel search)
        {
          return  _accountRepository.Search(search);
        }
    }
}

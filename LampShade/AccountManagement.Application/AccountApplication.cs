using _0_Framework.Application;
using _0_Framwork.Application;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IPasswordHasher passwordHasher;
        private readonly IAccountRepository accountRepository;
        private readonly IFileUploader fileUploader;
        private readonly IAuthHelper authHelper;
        private readonly IRoleRepository roleRepository;

        public AccountApplication(IPasswordHasher passwordHasher, IAccountRepository accountRepository, IFileUploader fileUploader, IAuthHelper authHelper, IRoleRepository roleRepository)
        {
            this.passwordHasher = passwordHasher;
            this.accountRepository = accountRepository;
            this.fileUploader = fileUploader;
            this.authHelper = authHelper;
            this.roleRepository = roleRepository;
        }

        public OprationResult ChangePassword(ChangePassword command)
        {
            var oprationresuly=new OprationResult();
            var account = accountRepository.Get(command.Id);
            if (account == null)
                return oprationresuly.Feiled(ApplicationMessages.RecordNotFound);
            if (command.Password != command.RePassword)
                return oprationresuly.Feiled(ApplicationMessages.PasswordNotMath);
            var password = passwordHasher.Hash(command.Password);
            account.ChangePassword(password);
            accountRepository.SaveChanges();
            return oprationresuly.Sucsseded();
        }

        public OprationResult Register(Register command)
        {
            var oprationresult=new OprationResult();
            if(accountRepository.Exists(s=>s.UserName == command.UserName||s.Mobile==command.Mobile))
                return oprationresult.Feiled(ApplicationMessages.DublicatedRecord);
            var password = passwordHasher.Hash(command.Password);
            var filename = fileUploader.Upload(command.ProfilePhoto, "Account");
            var account = new Account(command.FullName, command.UserName, password, command.Mobile, command.RoleId, filename);
            accountRepository.Create(account);
            accountRepository.SaveChanges();
            return oprationresult.Sucsseded();
        }

        public OprationResult Edit(EditAccount command)
        {
            var oprationresult = new OprationResult();

            var account = accountRepository.Get(command.Id);
            if (account == null)
                return oprationresult.Feiled(ApplicationMessages.RecordNotFound);
            if (accountRepository.Exists(s => (s.UserName == command.UserName || s.Mobile == command.Mobile)&&s.Id!=command.Id))
                return oprationresult.Feiled(ApplicationMessages.DublicatedRecord);
            var filename = fileUploader.Upload(command.ProfilePhoto, "Account");
            account.Edit(command.FullName, command.UserName,command.Mobile, command.RoleId, filename);
            accountRepository.SaveChanges();
            return oprationresult.Sucsseded();
        }

        public EditAccount GetDetails(long Id)
        {
            return accountRepository.GetDetails(Id);
        }

        public OprationResult Login(Login command)
        {
            OprationResult oprationresult = new OprationResult();
            var account = accountRepository.GetBy(command.UserName);
            if (account == null)
                return oprationresult.Feiled(ApplicationMessages.WrongUserName);
            var result = passwordHasher.Check(account.Password,command.Password);
            if(!result.Verified)
                return oprationresult.Feiled(ApplicationMessages.WrongUserName);

            var permission = roleRepository.Get(account.RoleId)
                .Permissions.Select(s => s.Code).ToList();

            var authviewmodel = new AuthViewModel(account.Id, account.RoleId, account.FullName, account.UserName, permission);


            authHelper.Sigin(authviewmodel);
            return oprationresult.Sucsseded();
        }

        public void Logout()
        {
            authHelper.Sigout();
        }

        public List<AccountViewModel> Search(AccountSearchModel model)
        {
            return accountRepository.Search(model);
        }
    }
}
